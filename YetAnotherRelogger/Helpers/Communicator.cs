﻿using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Xml.Serialization;
using YetAnotherRelogger.Helpers.Bot;
using YetAnotherRelogger.Helpers.Tools;
using YetAnotherRelogger.Properties;

namespace YetAnotherRelogger.Helpers
{
    public class Communicator
    {
        #region singleton
        static readonly Communicator instance = new Communicator();

        static Communicator()
        {
        }

        Communicator()
        {
        }

        public static Communicator Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        private static int _connections;
        public static int Connections
        {
            get
            {
                return _connections;
            }
            set
            {
                _connections = value < 0 ? 0 : value;
                StatConnections += _connections;
            }
        }
        public static int StatConnections { get; set; }
        public static int StatFailed { get; set; }

        Thread _threadWorker;
        public void Start()
        {
            _threadWorker = new Thread(Worker) { IsBackground = true };
            _threadWorker.Start();
        }

        public void Worker()
        {
            while (true)
            {
                try
                {
                    var serverStream = new NamedPipeServerStream("YetAnotherRelogger", PipeDirection.InOut, 254);
                    serverStream.WaitForConnection();
                    var handleClient = new HandleClient(serverStream);
                    new Thread(handleClient.Start).Start();
                }
                catch (Exception ex)
                {
                    StatFailed++;
                    DebugHelper.Exception(ex);
                }
            }
        }

        class HandleClient : IDisposable
        {
            private StreamReader _reader;
            private StreamWriter _writer;
            private NamedPipeServerStream _stream;

            public HandleClient(NamedPipeServerStream stream)
            {
                _stream = stream;
                _reader = new StreamReader(stream);
                _writer = new StreamWriter(stream) { AutoFlush = true };
            }

            public void Start()
            {
                var isXml = false;
                var xml = string.Empty;
                var duration = DateTime.Now;
                Connections++;
                try
                {
                    Debug.WriteLine("PipeConnection [{0}]: Connected:{1}", _stream.GetHashCode(), _stream.IsConnected);
                    while (_stream.IsConnected)
                    {
                        var temp = _reader.ReadLine();
                        if (temp == null)
                        {
                            Thread.Sleep(Program.Sleeptime);
                            continue;
                        }
                        if (temp.Equals("END"))
                        {
                            Debug.WriteLine("PipeConnection [{0}]: Duration:{1} XML:{2}", _stream.GetHashCode(), General.DateSubtract(duration, false), xml);
                            HandleXml(xml);
                        }

                        if (temp.StartsWith("XML:"))
                        {
                            temp = temp.Substring(4);
                            isXml = true;
                        }

                        if (isXml)
                        {
                            xml += temp + "\n";
                        }
                        else
                        {
                            Debug.WriteLine("PipeConnection [{0}]: Duration:{1} Data:{2}", _stream.GetHashCode(), General.DateSubtract(duration, false), temp);
                            HandleMsg(temp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    StatFailed++;
                }
                Debug.WriteLine("PipeConnection [{0}]: Connected:{1} Duration:{2}ms", _stream.GetHashCode(), _stream.IsConnected, General.DateSubtract(duration, false));
                Dispose();
                Connections--;
            }

            private void HandleXml(string data)
            {
                BotStats stats;
                var xml = new XmlSerializer(typeof(BotStats));
                using (var stringReader = new StringReader(data))
                {
                    stats = xml.Deserialize(stringReader) as BotStats;
                }

                if (stats != null)
                {
                    try
                    {
                        var bot = BotSettings.Instance.Bots.FirstOrDefault(b => (b != null && b.Demonbuddy != null && b.Demonbuddy.Proc != null) && b.Demonbuddy.Proc.Id == stats.Pid);
                        if (bot != null)
                        {
                            if (bot.AntiIdle.Stats == null) bot.AntiIdle.Stats = new BotStats();

                            bot.AntiIdle.UpdateCoinage(stats.Coinage);
                            bot.AntiIdle.Stats = stats;
                            bot.AntiIdle.LastStats = DateTime.Now;
                            Send(bot.AntiIdle.Reply());
                            return;
                        }

                        Logger.Instance.WriteGlobal("Could not find a matching bot for Demonbuddy:{0}", stats.Pid);
                        return;
                    }
                    catch (Exception ex)
                    {
                        StatFailed++;
                        Send("Internal server error: " + ex.Message);
                        DebugHelper.Exception(ex);
                        return;
                    }
                }
                Send("Roger!");
            }

            private void HandleMsg(string msg)
            {
                // Message Example:
                // PID:CMD DATA
                // 1234:GameLeft 25-09-1985 18:27:00
                Debug.WriteLine("Recieved: " + msg);
                try
                {
                    var pid = msg.Split(':')[0];
                    var cmd = msg.Substring(pid.Length + 1).Split(' ')[0];
                    int x;
                    msg = msg.Substring(((x = pid.Length + cmd.Length + 2) >= msg.Length ? 0 : x));

                    var b = BotSettings.Instance.Bots.FirstOrDefault(f => (f.Demonbuddy != null && f.Demonbuddy.Proc != null) && f.Demonbuddy.Proc.Id == Convert.ToInt32(pid));
                    if (b == null)
                    {
                        Send("Error: Unknown process");
                        StatFailed++;
                        return;
                    }

                    switch (cmd)
                    {
                        case "Initialized":
                            b.AntiIdle.Stats = new BotStats
                                          {
                                              LastGame = DateTime.Now.Ticks,
                                              LastPulse = DateTime.Now.Ticks,
                                              PluginPulse = DateTime.Now.Ticks,
                                              LastRun = DateTime.Now.Ticks
                                          };
                            b.AntiIdle.LastStats = DateTime.Now;
                            b.AntiIdle.State = IdleState.CheckIdle;
                            b.AntiIdle.IsInitialized = true;
                            b.AntiIdle.InitAttempts = 0;
                            Send("Roger!");
                            break;
                        case "GameLeft":
                            b.ProfileSchedule.Count++;
                            if (b.ProfileSchedule.Current.Runs > 0)
                                Logger.Instance.Write(b, "Runs completed ({0}/{1})", b.ProfileSchedule.Count, b.ProfileSchedule.MaxRuns);
                            else
                                Logger.Instance.Write(b, "Runs completed {0}", b.ProfileSchedule.Count);

                            if (b.ProfileSchedule.IsDone)
                            {
                                var newprofile = b.ProfileSchedule.GetProfile;
                                Logger.Instance.Write(b, "Next profile: {0}", newprofile);
                                Send("LoadProfile " + newprofile);
                            }
                            else
                                Send("Roger!");
                            break;
                        case "UserStop":
                            b.Status = string.Format("User Stop: {0:d-m H:M:s}", DateTime.Now);
                            b.AntiIdle.State = IdleState.UserStop;
                            Logger.Instance.Write(b, "Demonbuddy stopped by user");
                            Send("Roger!");
                            break;
                        case "StartDelay":
                            var delay = new DateTime(long.Parse(msg));
                            b.AntiIdle.StartDelay = delay.AddSeconds(60);
                            b.AntiIdle.State = IdleState.StartDelay;
                            Send("Roger!");
                            break;
                        // Giles Compatibility
                        case "ThirdpartyStop":
                            b.Status = string.Format("Thirdparty Stop: {0:d-m H:M:s}", DateTime.Now);
                            b.AntiIdle.State = IdleState.UserStop;
                            Logger.Instance.Write(b, "Demonbuddy stopped by Thirdparty");
                            Send("Roger!");
                            break;
                        case "TrinityPause":
                            b.AntiIdle.State = IdleState.UserPause;
                            Logger.Instance.Write(b, "Trinity Pause Detected");
                            Send("Roger!");
                            break;
                        case "AllCompiled":
                            Send(b.Demonbuddy.ForceEnableAllPlugins ? "ForceEnableAll" : "ForceEnableYar");
                            break;
                        case "CrashTender":
                            if (Settings.Default.UseKickstart && File.Exists(msg))
                                b.Demonbuddy.CrashTender(msg);
                            else
                                b.Demonbuddy.CrashTender();
                            Send("Roger!");
                            break;
                        case "CheckConnection":
                            ConnectionCheck.CheckValidConnection(silent: true);
                            Send("Roger!");
                            break;
                        case "NewMonsterPowerLevel":
                            Logger.Instance.Write(b, "Sending MonsterPowerLevel: {0}", b.ProfileSchedule.Current.MonsterPowerLevel);
                            Send("MonsterPower " + (int)b.ProfileSchedule.Current.MonsterPowerLevel);
                            break;
                        case "D3Exit":
                            Send("Shutdown");
                            break;
                        // Unknown command reply
                        default:
                            Send("Unknown command!");
                            Logger.Instance.WriteGlobal("Unknown command recieved: " + msg);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    StatFailed++;
                    Send("Internal server error: " + ex.Message);
                    DebugHelper.Exception(ex);
                }
            }

            private void Send(string msg)
            {
                try
                {
                    _writer.WriteLine(msg);
                }
                catch (Exception ex)
                {
                    StatFailed++;
                    DebugHelper.Exception(ex);
                }
            }

            public void SendShutdown()
            {
                Send("Shutdown");
            }

            public void Dispose()
            {
                //Free managed resources
                if (_stream != null)
                {
                    try { _stream.Close(); }
                    catch { }
                    _stream = null;
                }
                if (_reader != null)
                {
                    try { _reader.Close(); }
                    catch { }
                    _reader = null;
                }
                if (_writer != null)
                {
                    try { _writer.Close(); }
                    catch { }
                    _writer = null;
                }

            }
        }
    }
}
