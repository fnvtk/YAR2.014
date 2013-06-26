using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using System.Diagnostics;
using System.IO;
using YetAnotherRelogger.Helpers.Tools;

namespace YetAnotherRelogger.Helpers.Bot
{
    public class DemonbuddyClass
    {
        [XmlIgnore] public BotClass Parent { get; set; }
        [XmlIgnore] private Process _proc;
        [XmlIgnore] public Process Proc  //公用进程  返回进程_proc      |  进程存在则把PID赋值给他
        {
            get { return _proc; }
            set
            {
                if (value != null)
                    Parent.DemonbuddyPid = value.Id.ToString();
                _proc = value;
            }
        }

        [XmlIgnore] private bool _isStopped;
        [XmlIgnore] public bool IsRunning { get {  return (Proc != null && !Proc.HasExited && !_isStopped); } }

        [XmlIgnore] public  IntPtr MainWindowHandle;

        // Buddy Auth
        public string BuddyAuthUsername { get; set; }
        public string BuddyAuthPassword { get; set; }
        [XmlIgnore] public DateTime LoginTime { get; set; }
        [XmlIgnore] public bool FoundLoginTime { get; set; }
        
        // Demonbuddy
        public string Location { get; set; }
        public string Key { get; set; }
        public string CombatRoutine { get; set; }
        public bool NoFlash { get; set; }
        public bool AutoUpdate { get; set; }
        public bool NoUpdate { get; set; }
        public int Priority { get; set; }

        // Affinity
        // If CpuCount does not match current machines CpuCount,
        // the affinity is set to all processor
        //分配cpu
        public int CpuCount { get; set; }
        public int ProcessorAffinity { get; set; }

        [XmlIgnore] public int AllProcessors
        {
            get
            {
                int intProcessorAffinity = 0;
                for (int i = 0; i < Environment.ProcessorCount; i++)
                    intProcessorAffinity |= (1 << i);
                return intProcessorAffinity;
            }
        }

        // Position位置
        public bool ManualPosSize { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        [XmlIgnore] public Rectangle AutoPos;

        [XmlIgnore] private bool _crashTenderRestart;

        public bool ForceEnableAllPlugins { get; set; }

        public DemonbuddyClass()
        {
            CpuCount = Environment.ProcessorCount;
            ProcessorAffinity = AllProcessors;
        }


        public bool IsInitialized  //初始化
        {
            get
            {
                // 暗黑没有运行就关闭DB并返回FALSE
                if (!Parent.Diablo.IsRunning)
                {
                    Parent.Demonbuddy.Stop(true);
                    return false;
                }

                if ((!Parent.AntiIdle.IsInitialized && General.DateSubtract(Parent.AntiIdle.InitTime) > 180) || !IsRunning)//反闲置没有初始化并且闲置时间>180秒 或没有运行
                {
                    Parent.AntiIdle.FailedInitCount++;
                    if (Parent.AntiIdle.FailedInitCount >= (Parent.AntiIdle.InitAttempts > 0 ? 1 : 3))
                    {
                        Parent.AntiIdle.InitAttempts++;
                        Logger.Instance.Write(Parent, "Demonbuddy:{0}: 超过三次打开失败", Parent.Demonbuddy.Proc.Id);
                        Parent.Standby();
                    }
                    else
                    {
                        Logger.Instance.Write(Parent, "Demonbuddy:{0}: 失败次数 {1}/3", Parent.Demonbuddy.Proc.Id, Parent.AntiIdle.FailedInitCount);
                        Parent.Demonbuddy.Stop(true);
                    }
                    return false;
                }
                return Parent.AntiIdle.IsInitialized;
            }
        }

        private DateTime _lastRepsonse;   
        public void CrashCheck()   //崩溃检查
        {
            if (Proc.HasExited)
                return;

            if (CrashChecker.IsResponding(MainWindowHandle))
                _lastRepsonse = DateTime.Now;

            if (DateTime.Now.Subtract(_lastRepsonse).TotalSeconds > 90)//运行时间超过90秒
            {
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 超过90秒没有反映", Proc.Id);
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 关闭", Proc.Id);
                try
                {
                    if (Proc != null && !Proc.HasExited) //进程不存在或退出关闭主窗口
                        //Proc.CloseMainWindow();  //通过主程序关闭窗口
                        Proc.Kill();  //直接关闭
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(Parent, "关闭失败", ex.Message);
                    DebugHelper.Exception(ex);
                }
            }
        }

        public void Start(bool noprofile = false, string profilepath = null, bool crashtenderstart = false)
        {
            if (!Parent.IsStarted || !Parent.Diablo.IsRunning || (_crashTenderRestart && !crashtenderstart)) return;
            if (!File.Exists(Location))
            {
                Logger.Instance.Write("找不到路径: {0}", Location);
                return;
            }

            while (Parent.IsStarted && Parent.Diablo.IsRunning)
            {
                // Get Last login time and kill old session 杀死旧进程
                if (GetLastLoginTime) BuddyAuth.Instance.KillSession(Parent);

                _isStopped = false;

                // Reset AntiIdle;  重置反闲置
                Parent.AntiIdle.Reset(true);

                var arguments = "-pid=" + Parent.Diablo.Proc.Id;
                arguments += " -key=" + Key;
                arguments += " -autostart";
                arguments += string.Format(" -routine=\"{0}\"", CombatRoutine);
                arguments += string.Format(" -bnetaccount=\"{0}\"", Parent.Diablo.Username);
                arguments += string.Format(" -bnetpassword=\"{0}\"", Parent.Diablo.Password);

                if (profilepath != null)
                {
                    // Check if current profile path is Kickstart
                    var file = Path.GetFileName(profilepath);
                    if (file == null || (file.Equals("YAR_Kickstart.xml") || file.Equals("YAR_TMP_Kickstart.xml")))
                        profilepath = Parent.ProfileSchedule.Current.Location;

                    var profile = new Profile() {Location = profilepath};
                    var path = ProfileKickstart.GenerateKickstart(profile);
                    Logger.Instance.Write("Using Profile {0}", path);
                    arguments += string.Format(" -profile=\"{0}\"", path);
                }
                else if (Parent.ProfileSchedule.Profiles.Count > 0 && !noprofile)
                {
                    var path = Parent.ProfileSchedule.GetProfile;
                    Logger.Instance.Write("Using Scheduled Profile {0}", path);
                    if (File.Exists(path))
                        arguments += string.Format(" -profile=\"{0}\"", path);
                }
                else if (!noprofile)
                    Logger.Instance.Write("Warning: Launching Demonbuddy without a starting profile (Add a profile to the profilescheduler for this bot)");

                if (NoFlash) arguments += " -noflash";
                if (AutoUpdate) arguments += " -autoupdate";
                if (NoUpdate) arguments += " -noupdate";

                if (ForceEnableAllPlugins)
                    arguments += " -YarEnableAll";

                Debug.WriteLine("DB Arguments: {0}", arguments);

                var p = new ProcessStartInfo(Location, arguments) {WorkingDirectory = Path.GetDirectoryName(Location)};
                p = UserAccount.ImpersonateStartInfo(p, Parent);

                // Check/Install latest Communicator plugin
                var plugin = string.Format("{0}\\Plugins\\YAR\\Plugin.cs", p.WorkingDirectory);
                if (!PluginVersionCheck.Check(plugin)) PluginVersionCheck.Install(plugin);


                DateTime timeout;
                try // Try to start Demonbuddy
                {
                    Parent.Status = "Starting Demonbuddy"; // Update Status
                    Proc = Process.Start(p);

                    if (Program.IsRunAsAdmin)
                        Proc.PriorityClass = General.GetPriorityClass(Priority);
                    else
                        Logger.Instance.Write(Parent, "Failed to change priority (No admin rights)");


                    // Set affinity
                    if (CpuCount != Environment.ProcessorCount)
                    {
                        ProcessorAffinity = AllProcessors; // set it to all ones
                        CpuCount = Environment.ProcessorCount;
                    }
                    Proc.ProcessorAffinity = (IntPtr) ProcessorAffinity;


                    Logger.Instance.Write(Parent, "Demonbuddy:{0}: Waiting for process to become ready", Proc.Id);

                    timeout = DateTime.Now;
                    while (true)
                    {
                        if (General.DateSubtract(timeout) > 30)
                        {
                            Logger.Instance.Write(Parent, "Demonbuddy:{0}: 启动失败!", Proc.Id);
                            Parent.Restart();
                            return;
                        }
                        Thread.Sleep(500);
                        try
                        {
                            Proc.Refresh();
                            if (Proc.WaitForInputIdle(100) || CrashChecker.IsResponding(MainWindowHandle))
                                break;
                        }
                        catch
                        {
                        }
                    }

                    if (_isStopped) return;

                }
                catch (Exception ex)
                {
                    DebugHelper.Exception(ex);
                    Parent.Stop();
                }

                timeout = DateTime.Now;
                while (!FindMainWindow())
                {
                    if (General.DateSubtract(timeout) > 30)
                    {
                        MainWindowHandle = Proc.MainWindowHandle;
                        break;
                    }
                    Thread.Sleep(500);
                }

                // 窗口位置
                if (ManualPosSize)
                    AutoPosition.ManualPositionWindow(MainWindowHandle, X, Y, W, H, Parent);
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: Process is ready", Proc.Id);

                // Wait for demonbuddy to be Initialized (this means we are logged in) 等待游戏登陆
                // If we don't wait here the Region changeing for diablo fails! 
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 等待登陆Diablo", Proc.Id);
                while (!IsInitialized && !_isStopped)
                    Thread.Sleep(1000);
                // We made to many attempts break here
                if (Parent.AntiIdle.FailedInitCount > 3) break;
                if (!Parent.AntiIdle.IsInitialized) continue; // Retry

                // We are ready to go
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 已初始化，准备开始", Proc.Id);
                Parent.AntiIdle.FailedInitCount = 0; // only reset counter
                break;
            } // while (Parent.IsStarted && Parent.Diablo.IsRunning)
        }

        private bool FindMainWindow()  //寻找窗口
        {
            var handle = FindWindow.EqualsWindowCaption("Demonbuddy", Proc.Id);
            if (handle != IntPtr.Zero)
            {
                MainWindowHandle = handle;
                Logger.Instance.Write(Parent, "Found Demonbuddy: MainWindow ({0})", handle);
                return true;
            }
            handle = FindWindow.EqualsWindowCaption("Demonbuddy - BETA", Proc.Id);
            if (handle != IntPtr.Zero)
            {
                MainWindowHandle = handle;
                Logger.Instance.Write(Parent, "Found Demonbuddy - BETA: MainWindow ({0})", handle);
                return true;
            }
            handle = FindWindow.EqualsWindowCaption("DB - ", Proc.Id);
            if (handle != IntPtr.Zero)
            {
                MainWindowHandle = handle;
                Logger.Instance.Write(Parent, "Found DB - : MainWindow ({0})", handle);
                return true;
            }
            return false;
        }

        public void Stop(bool force = false)  //DB窗口关闭
        {
            _isStopped = true;

            if (Proc == null || Proc.HasExited) return;

            // 强制关闭
            if (force)
            {
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 强制关闭!", Proc.Id);
                Proc.Kill();
                return;
            }

            if (Proc != null && !Proc.HasExited) //如果进程还在，并且没有退出
            {
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 关闭窗口中", Proc.Id);
                Proc.CloseMainWindow();
                //Proc.Kill();
            }
            if (Parent.Diablo.Proc == null || Parent.Diablo.Proc.HasExited)  //如果暗黑进程关闭或退出, 杀死进程，反闲置赋初值，并等60秒再启动
            {
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 等待关闭", Proc.Id);
                //Proc.CloseMainWindow();
				Proc.Kill();
                Parent.AntiIdle.State = IdleState.Terminate;
                Proc.WaitForExit(60000);
                if (Proc == null || Proc.HasExited) //进程不存在或退出，显示已关闭
                {
                    Logger.Instance.Write(Parent, "Demonbuddy:{0}: 已关闭.", Proc.Id);
                    return;
                }
            }

            if (Proc.HasExited) //程序退出   |  程序未响应  杀死进程
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 已关闭.", Proc.Id);
            else if (!Proc.Responding)
            {
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: 错误关闭，杀死进程", Proc.Id);
                Proc.Kill();
            }
        }

        public void CrashTender(string profilepath = null) //没有选择脚本不运行
        {
            _crashTenderRestart = true;
            Logger.Instance.Write(Parent, "CrashTender: 正在停止 Demonbuddy:{0}", Proc.Id);
            Stop(true); // Force DB to stop
            Logger.Instance.Write(Parent, "CrashTender: 没有选择脚本");


            if (profilepath != null)
                Start(profilepath:profilepath, crashtenderstart: true);
            else
                Start(noprofile: true, crashtenderstart: true);
            _crashTenderRestart = false;
        }

        private bool GetLastLoginTime   //取得最后登陆时间
        {
            get
            {
                // No info to get from any process
                if (Proc == null) return false;

                // get log dir
                var logdir = Path.Combine(Path.GetDirectoryName(Location), "Logs");
                if (logdir.Length == 0 || !Directory.Exists(logdir))
                { // Failed to get log dir so exit here
                    Logger.Instance.Write(Parent, "Demonbuddy:{0}: Failed to find logdir", Proc.Id);
                    return false;
                }
                // get log file
                var logfile = string.Empty;
                var success = false;
                var starttime = Proc.StartTime;
                // Loop a few times if log is not found on first attempt and add a minute for each loop
                for (int i = 0; i <= 3; i++)
                {
                    // Test if logfile exists for current process starttime + 1 minute
                    logfile = string.Format("{0}\\{1} {2}.txt", logdir, Proc.Id, starttime.AddMinutes(i).ToString("yyyy-MM-dd HH.mm"));
                    if (File.Exists(logfile))
                    {
                        success = true;
                        break;
                    }
                }
                
                if (success)
                {
                    Logger.Instance.Write(Parent, "Demonbuddy:{0}: Found matching log: {1}", Proc.Id, logfile);

                    // Read Log file
                    // [11:03:21.173 N] Logging in...
                    try
                    {
                        int lineNumber = -1;
                        using (var fs = new FileStream(logfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var reader = new StreamReader(fs);
                            var time = new TimeSpan();
                            bool Logging = false;
                            while (!reader.EndOfStream)
                            {
                                // only read 1000 lines from log file, so we don't spend all day looking through the log.
                                lineNumber++;

                                if (lineNumber > 1000)
                                    break;

                                var line = reader.ReadLine();
                                if (line == null) continue;

                                if (Logging && line.Contains("Attached to Diablo III with pid"))
                                {
                                    LoginTime =
                                        DateTime.Parse(string.Format("{0:yyyy-MM-dd} {1}",
                                                                     starttime.ToUniversalTime(),
                                                                     time));
                                    Logger.Instance.Write("Found login time: {0}", LoginTime);
                                    return true;
                                }
                                var m = new Regex(@"^\[(.+) .\] Logging in\.\.\.$",
                                              RegexOptions.Compiled).Match(line);
                                if (m.Success)
                                {
                                    time = TimeSpan.Parse(m.Groups[1].Value);
                                    Logging = true;
                                }

                                Thread.Sleep(5); // Be nice for CPU
                            }
                            Logger.Instance.Write(Parent, "Demonbuddy:{0}: Failed to find login time", Proc.Id);
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Write(Parent, "Demonbuddy:{0}: Error accured while reading log", Proc.Id);
                        DebugHelper.Exception(ex);
                    }
                }
                // Else print error + return false
                Logger.Instance.Write(Parent, "Demonbuddy:{0}: Failed to find matching log", Proc.Id);
                return false;
            }
        }
    }
}
