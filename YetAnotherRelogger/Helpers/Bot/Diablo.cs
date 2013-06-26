﻿using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using YetAnotherRelogger.Helpers.Tools;
using YetAnotherRelogger.Properties;

namespace YetAnotherRelogger.Helpers.Bot
{
    public class DiabloClass
    {
        [XmlIgnore]
        public BotClass Parent { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public int Priority { get; set; }

        public string Location2
        {
            get
            {
                var ret = Parent.UseDiabloClone
                              ? Path.Combine(Parent.DiabloCloneLocation, Path.GetFileName(Path.GetDirectoryName(Location)), Path.GetFileName(Location))
                              : Location;
                Debug.WriteLine("文件路径: {0}", ret);
                return ret;
            }
        }
        
        // Isboxer
        public bool UseIsBoxer { get; set; }
        public string DisplaySlot { get; set; }
        public string CharacterSet { get; set; }

        // Position
        public bool ManualPosSize { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        [XmlIgnore] public Rectangle AutoPos; 

        // Remove frame
        public bool NoFrame { get; set; }

        // Authenticator
        public bool UseAuthenticator { get; set; }
        public string Serial { get; set; }
        public string RestoreCode { get; set; }

        // Affinity
        // If CpuCount does not match current machines CpuCount,
        // the affinity is set to all processor
        public int CpuCount          { get; set; }
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

        [XmlIgnore] public Process Proc;
        [XmlIgnore] public IntPtr MainWindowHandle;
        [XmlIgnore] private bool _isStopped;

        public bool IsRunning  //是否运行中
        {
            get
            {
                return (Proc != null && !Proc.HasExited && !_isStopped);
            }
        }

        public DiabloClass() 
        {
            CpuCount = Environment.ProcessorCount;
            ProcessorAffinity = AllProcessors;
        }

        [XmlIgnore] private DateTime _lastRepsonse;
        public void CrashCheck()   //崩溃检查   1、进程已退出什么也不干   2.未响应时间超过60秒结束进程
        {
            if (Proc.HasExited)
                return;

            if (CrashChecker.IsResponding(MainWindowHandle))
            {
                _lastRepsonse = DateTime.Now;
                Parent.Status = "监控中";
            }
            else
                Parent.Status = string.Format("Diablo 已经 ({0} 秒未响应 )", DateTime.Now.Subtract(_lastRepsonse).TotalSeconds);

            if (DateTime.Now.Subtract(_lastRepsonse).TotalSeconds > 60)
            {
                
                Logger.Instance.Write("Diablo:{0}: 超过60秒未响应", Proc.Id);
                Logger.Instance.Write("Diablo:{0}: 结束进程", Proc.Id);
                try
                {
                    if (Proc != null && !Proc.HasExited)  
                        Proc.Kill();
                }
                catch (Exception ex)
                {
                    DebugHelper.Exception(ex);
                }
            }
        }

        public void Start()
        {
            if (!Parent.IsStarted)
                return;

            if (!File.Exists(Location))
            {
                Logger.Instance.Write("没有找到文件: {0}", Location);
                return;
            }

            _isStopped = false;
            // Ping check
            while (Settings.Default.ConnectionCheckPing && !ConnectionCheck.PingCheck() && !_isStopped)
            {
                Parent.Status = "等待网络连接";
                Logger.Instance.WriteGlobal("PingCheck: 等待十秒后再试!");
                Thread.Sleep(10000);
               
            }

            // Check valid host
            while (Settings.Default.ConnectionCheckIpHost && !ConnectionCheck.CheckValidConnection() && !_isStopped)
            {
                Parent.Status = "Wait on host validation";
                Logger.Instance.WriteGlobal("ConnectionValidation: Waiting 10 seconds and trying again!");
                Thread.Sleep(10000);
            }

            // Check if we need to create a Diablo clone
            if (Parent.UseDiabloClone)
                DiabloClone.Create(Parent);

            Parent.Status = "Prepare Diablo"; // Update Status

            General.AgentKiller(); // Kill all Agent.exe processes

            // 准备启动暗黑
            var agentDBPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Battle.net\Agent\agent.db";
            if (File.Exists(agentDBPath))
            {
                Logger.Instance.Write("Deleting: {0}", agentDBPath);
                try
                {
                    File.Delete(agentDBPath);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write("Failed to delete! Exception: {0}", ex.Message);
                    DebugHelper.Exception(ex);
                }
            }

            // Copy D3Prefs
            if (!string.IsNullOrEmpty(Parent.D3PrefsLocation))
                D3Prefs();

            // Registry Changes
            RegistryClass.ChangeLocale(Parent.Diablo.Language); // change language
            RegistryClass.ChangeRegion(Parent.Diablo.Region); // change region

            if (UseIsBoxer)
                IsBoxerStarter();
            else if (Settings.Default.UseD3Starter)
                ApocD3Starter();
            else
            {
                try
                {
                    var arguments = "-launch";
                    var pi = new ProcessStartInfo(Location2, arguments) { WorkingDirectory = Path.GetDirectoryName(Location2) };
                    pi = UserAccount.ImpersonateStartInfo(pi, Parent);
                    // Set working directory to executable location
                    Parent.Status = "Starting Diablo"; // Update Status
                    Proc = Process.Start(pi);
                }
                catch (Exception ex)
                {
                    Parent.Stop();
                    DebugHelper.Exception(ex);
                    return;
                }
            }

            if (!UseIsBoxer) // Don't want to fight with isboxer
            {
                if (CpuCount != Environment.ProcessorCount)
                {
                    ProcessorAffinity = AllProcessors; // set it to all ones
                    CpuCount = Environment.ProcessorCount;
                }
                Proc.ProcessorAffinity = (IntPtr)ProcessorAffinity;
            }

           
            if (_isStopped) return; // Halt here when bot is stopped while we where waiting for it to become active

            // 等待暗黑完全加载
            var state = (Settings.Default.UseD3Starter || UseIsBoxer ? 0 : 2);
            var handle = IntPtr.Zero;
            var timedout = false;
            LimitStartTime(true); // reset startup time
            while ((!Proc.HasExited && state < 4))
            {
                if (timedout) return;
                //Debug.WriteLine("Splash: " + FindWindow.FindWindowClass("D3 Splash Window Class", Proc.Id) + " Main:" + FindWindow.FindWindowClass("D3 Main Window Class", Proc.Id));
                switch (state)
                {
                    case 0:
                        handle = FindWindow.FindWindowClass("D3 Splash Window Class", Proc.Id);
                        if (handle != IntPtr.Zero)
                        {
                            Logger.Instance.Write("Diablo:{0}: Found D3 Splash Window ({1})", Proc.Id, handle);
                            state++;
                            LimitStartTime(true); // reset startup time
                        }
                        timedout = LimitStartTime();
                        break;
                    case 1:
                        handle = FindWindow.FindWindowClass("D3 Splash Window Class", Proc.Id);
                        if (handle == IntPtr.Zero)
                        {
                            Logger.Instance.Write("Diablo:{0}: D3 Splash Window Closed ({1})", Proc.Id, handle);
                            state++;
                            LimitStartTime(true); // reset startup time
                        }
                        timedout = LimitStartTime();
                        break;
                    case 2:
                        handle = FindWindow.FindWindowClass("D3 Main Window Class", Proc.Id);
                        if (handle != IntPtr.Zero)
                        {
                            Logger.Instance.Write("Diablo:{0}: Found D3 Main Window ({1})", Proc.Id, handle);
                            state++;
                            LimitStartTime(true); // reset startup time
                        }
                        timedout = LimitStartTime();
                        break;
                    case 3:
                        if (CrashChecker.IsResponding(handle))
                        {
                            MainWindowHandle = handle;
                            state++;
                            LimitStartTime(true); // reset startup time
                        }
                        timedout = LimitStartTime();
                        break;
                }
                Thread.Sleep(500);
            }
            if (timedout) return;

            if (Program.IsRunAsAdmin)
                Proc.PriorityClass = General.GetPriorityClass(Priority);
            else
                Logger.Instance.Write(Parent, "Failed to change priority (No admin rights)");
            // Continue after launching stuff
            Logger.Instance.Write("Diablo:{0}: Waiting for process to become ready", Proc.Id);

            var timeout = DateTime.Now;
            while (true)
            {
                if (General.DateSubtract(timeout) > 30)
                {
                    Logger.Instance.Write("Diablo:{0}: Failed to start!", Proc.Id);
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
                catch (Exception ex)
                {
                    DebugHelper.Exception(ex);
                }
            }

            if (!IsRunning) return;

            _lastRepsonse = DateTime.Now;

            Thread.Sleep(1500);
            if (NoFrame) AutoPosition.RemoveWindowFrame(MainWindowHandle, true); // Force remove window frame
            if (ManualPosSize)
                AutoPosition.ManualPositionWindow(MainWindowHandle, X, Y, W, H, Parent);
            else if (Settings.Default.UseAutoPos)
                AutoPosition.PositionWindows();

            Logger.Instance.Write("Diablo:{0}: Process is ready", Proc.Id);
            
            // Demonbuddy start delay
            if (Settings.Default.DemonbuddyStartDelay > 0)
            {
                Logger.Instance.Write("Demonbuddy start delay, waiting {0} seconds", Settings.Default.DemonbuddyStartDelay);
                Thread.Sleep((int) Settings.Default.DemonbuddyStartDelay*1000);
            }
        }

        

        [XmlIgnore] private DateTime _timeStartTime;
        private bool LimitStartTime(bool reset = false)
        {
            if (reset)
                _timeStartTime = DateTime.Now;
            else if (General.DateSubtract(_timeStartTime) > (int)Settings.Default.DiabloStartTimeLimit)
            {
                Logger.Instance.Write("Diablo:{0}: Starting diablo timed out!", Proc.Id);
                Parent.Restart();
                return true;
            }
            return false;
        }
        private void ApocD3Starter()
        {
            Parent.Status = "D3Starter: Starting Diablo"; // Update Status
            var d3StarterSuccess = false;
            try
            {
                var starter = new Process
                                  {
                                      StartInfo =
                                          {
                                              FileName = Settings.Default.D3StarterPath,
                                              WorkingDirectory = Path.GetDirectoryName(Settings.Default.D3StarterPath),
                                              Arguments = string.Format("\"{0}\" 1", Location2),
                                              UseShellExecute = false,
                                              RedirectStandardOutput = true,
                                              CreateNoWindow = true,
                                              WindowStyle = ProcessWindowStyle.Hidden
                                          }
                                  };
                starter.StartInfo = UserAccount.ImpersonateStartInfo(starter.StartInfo, Parent);
                starter.Start();

                Match m;
                while (!starter.HasExited)
                {
                    var l = starter.StandardOutput.ReadLine();
                    if (l == null) continue;

                    Logger.Instance.Write("D3Starter: " + l);
                    if ((m = Regex.Match(l, @"Process ID (\d+) started.")).Success)
                        Proc = Process.GetProcessById(Convert.ToInt32(m.Groups[1].Value));
                    if (Regex.Match(l, @"\d game instances started! All done!").Success)
                    {
                        d3StarterSuccess = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write("D3Starter Error: {0}", ex.Message);
                DebugHelper.Exception(ex);
            }

            if (!d3StarterSuccess)
            {
                Logger.Instance.Write("D3Starter failed!");
                Parent.Stop();
                Parent.Status = "D3Starter Failed!";
            }
        }
        private void IsBoxerStarter()
        {
            if (string.IsNullOrEmpty(Settings.Default.ISBoxerPath) || !File.Exists(Settings.Default.ISBoxerPath))
            {
                Logger.Instance.Write(Parent, "Can't find InnerSpace executable!");
                Parent.Stop();
                return;
            }
            if (string.IsNullOrEmpty(CharacterSet))
            {
                Logger.Instance.Write(Parent, "Is boxer is not configured!");
                Parent.Stop();
                return;
            }

            var isboxer = new Process
            {
                StartInfo =
                {
                    FileName = Settings.Default.ISBoxerPath,
                    WorkingDirectory = Path.GetDirectoryName(Settings.Default.ISBoxerPath),
                    Arguments = string.Format("run isboxer -launchslot \"{0}\" {1}", CharacterSet,DisplaySlot),
                }
            };
            Logger.Instance.Write(Parent, "Starting InnerSpace: {0}", Settings.Default.ISBoxerPath);
            Logger.Instance.Write(Parent, "With arguments: {0}", isboxer.StartInfo.Arguments);
            //isboxer.StartInfo = UserAccount.ImpersonateStartInfo(isboxer.StartInfo, Parent);
            isboxer.Start();

            
            // Find diablo process
            var exeName = Path.GetFileNameWithoutExtension(Location);
            Logger.Instance.Write(Parent, "Searching for new process: {0}", exeName);
            if (string.IsNullOrEmpty(exeName))
            {
                Logger.Instance.Write(Parent, "Failed GetFileNameWithoutExtension!");
                Parent.Stop();
                return;
            }

            // Create snapshot from all running processes
            var currProcesses = Process.GetProcesses();
            var timeout = DateTime.Now;
            while (General.DateSubtract(timeout) < 20)
            {
                Thread.Sleep(250);
                var p = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.Equals(exeName) && 
                    // Find Diablo inside relogger
                    BotSettings.Instance.Bots.FirstOrDefault(z => z.Diablo.Proc != null && !z.Diablo.Proc.HasExited && z.Diablo.Proc.Id == x.Id) == null && 
                    // Find Diablo in all processes
                    currProcesses.FirstOrDefault(y => y.Id == x.Id) == null);

                if (p == null) continue;
                Logger.Instance.Write(Parent, "Found new Diablo III Name: \"{0}\", Pid: {1}", p.ProcessName, p.Id);
                Proc = p;
                return;
            }

            Logger.Instance.Write(Parent, "Failed to find new Diablo III");
            Parent.Stop();
        }
        private void D3Prefs()
        {
            var imp = new Impersonator();
            if (Parent.UseWindowsUser)
                imp.Impersonate(Parent.WindowsUserName, "localhost", Parent.WindowsUserPassword);
            // Copy D3Prefs
            Logger.Instance.Write("Replacing D3Prefs for user: {0}", Environment.UserName);
            var currentprefs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                               @"\Diablo III\D3Prefs.txt";
            if (Directory.Exists(Path.GetDirectoryName(currentprefs)))
            {
                Logger.Instance.Write("Copy custom D3Prefs file to: {0}", currentprefs);
                try
                {
                    File.Copy(Parent.D3PrefsLocation, currentprefs, true);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write("Failed to copy D3Prefs file: {0}", ex);
                }
            }
            else
                Logger.Instance.Write("D3Prefs Failed: Path to \"{0}\" does not exist!", currentprefs);
            if (imp != null)
                imp.Dispose();


            // Also replace Default User D3Prefs
            var defaultprefs =
                Regex.Match(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                            string.Format(@"(.+)\\{0}.*", Environment.UserName)).Groups[1].Value;
            if (Directory.Exists(defaultprefs + "\\Default"))
                defaultprefs += "\\Default";
            else if (Directory.Exists(defaultprefs + "\\Default User"))
                defaultprefs += "\\Default User";
            else
                return;
            defaultprefs += @"\Diablo III\D3Prefs.txt";
            if (Directory.Exists(Path.GetDirectoryName(defaultprefs)))
            {
                Logger.Instance.Write("Copy custom D3Prefs file to: {0}", defaultprefs);
                try
                {
                    File.Copy(Parent.D3PrefsLocation, defaultprefs, true);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write("Failed to copy d3prefs file: {0}", ex);
                }
            }
            Thread.Sleep(1000);
        }

        public void Stop()
        {
            _isStopped = true;

            if (Proc == null || Proc.HasExited) return;

            Logger.Instance.WriteGlobal("<{0}> Diablo:{1}: Kill process", Parent.Name, Proc.Id);
            Proc.Kill();
        }


    }

    
}
