using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using mullak99.ACW.NetworkACW.LCHLib;
using mullak99.ACW.NetworkACW.locationserver.Save;

namespace mullak99.ACW.NetworkACW.locationserver
{
    static class Program
    {
        public static Locations locations = new Locations();

        private static bool _UI = false;
        private static int _port = 43;

        private static bool _verbose = false;

        internal static Logging logging;
        private static string _logFile;
        private static string _dbFile;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLower().TrimStart('/', '-') == "p" && !String.IsNullOrEmpty(args[i + 1]) && int.TryParse(args[i + 1], out _port))
                    i++;
                else if (args[i].ToLower().TrimStart('/', '-') == "w")
                    _UI = true;
                else if (args[i].ToLower().TrimStart('/', '-') == "d" || args[i].ToLower().TrimStart('/', '-') == "debug" || args[i].ToLower().TrimStart('/', '-') == "verbose") // Debug Mode
                    _verbose = true;
                else if (args[i].ToLower().TrimStart('/', '-') == "l" && !String.IsNullOrEmpty(args[i + 1])) // Log File Path
                {
                    _logFile = args[i + 1];
                    i++;
                }
                else if (args[i].ToLower().TrimStart('/', '-') == "f" && !String.IsNullOrEmpty(args[i + 1])) // DB File Path
                {
                    _dbFile = args[i + 1];
                    i++;
                }
            }

            logging = new Logging(_verbose, _logFile);

            if (_UI)
            {
                FreeConsole();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                AllocConsole();
                LocationServer server = new LocationServer(_port);

                if (GetDebug())
                    Console.ReadKey();
            }
        }

        public static string GetVersion()
        {
            string[] ver = (typeof(locationserver.Program).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version).Split('.');

            return "v" + ver[0] + "." + ver[1] + "." + ver[2];
        }

        public static bool GetDebug()
        {
            return _verbose;
        }

        public static string GetLogPath()
        {
            return _logFile;
        }

        public static string GetDbPath()
        {
            return _dbFile;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();
    }
}
