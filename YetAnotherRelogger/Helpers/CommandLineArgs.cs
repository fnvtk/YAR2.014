using System;

namespace YetAnotherRelogger.Helpers
{
    public static class CommandLineArgs   //开机是否自动启动
    {
        public static bool WindowsAutoStart { get; set; }
        public static bool AutoStart { get; set; }
        public static bool SafeMode { get; set; }

        public static void Get()   //定义GET()静态类
        {
            var args = Environment.GetCommandLineArgs();  //取得环境参数
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-winstart":
                        WindowsAutoStart = true;
                        break;
                    case "-autostart":
                        AutoStart = true;
                        break;
                    case "-safemode":
                        SafeMode = true;
                        break;
                    default:
                        // Unknown argument passed
                        // Do nothing
                        break;
                }
            }
        }
    }
}
