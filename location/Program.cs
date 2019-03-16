using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using mullak99.ACW.NetworkACW.LCHLib;

namespace mullak99.ACW.NetworkACW.location
{
    static class Program
    {
        private static List<string> commandArgs = new List<string>();
        private static List<string> progArgs = new List<string>();

        private static string _serverAddress = "127.0.0.1";
        private static int _serverPort = 43;
        private static UInt16 _timeOut = 2000;

        internal static Logging logging;
        private static string _logFile;

        private static LCH.Protocol _protocol = LCH.Protocol.WHOIS;

        private static bool _verbose = false;
        private static bool _showVer = false;

        private const bool _isDevBuild = true;

        [STAThread]
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i][0] == '-' || args[i][0] == '/')
                {
                    // Program Args
                    if (args[i].ToLower().TrimStart('/', '-') == "h" && !String.IsNullOrEmpty(args[i + 1])) // Server Address
                    {
                        _serverAddress = args[i + 1];
                        if (_serverAddress == "localhost") _serverAddress = "127.0.0.1";
                        progArgs.Add(string.Join(" ", args[i], args[i + 1]));
                        i++;
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "p" && !String.IsNullOrEmpty(args[i + 1]) && int.TryParse(args[i + 1], out _serverPort)) // Server Port
                    {
                        progArgs.Add(string.Join(" ", args[i], args[i + 1]));
                        i++;
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "t" && !String.IsNullOrEmpty(args[i + 1])) // Timeout (ms)
                    {
                        progArgs.Add(string.Join(" ", args[i], args[i + 1]));
                        i++;
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "l" && !String.IsNullOrEmpty(args[i + 1])) // Log File Path
                    {
                        _logFile = args[i + 1];
                        progArgs.Add(string.Join(" ", args[i], args[i + 1]));
                        i++;
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "h9") // HTTP/0.9
                    {
                        _protocol = LCH.Protocol.HTTP09;
                        progArgs.Add(args[i]);
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "h0") // HTTP/1.0
                    {
                        _protocol = LCH.Protocol.HTTP10;
                        progArgs.Add(args[i]);
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "h1") // HTTP/1.1
                    {
                        _protocol = LCH.Protocol.HTTP11;
                        progArgs.Add(args[i]);
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "d" || args[i].ToLower().TrimStart('/', '-') == "debug" || args[i].ToLower().TrimStart('/', '-') == "verbose") // Debug Mode
                    {
                        _verbose = true;
                        progArgs.Add(args[i]);
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "v" || args[i].ToLower().TrimStart('/', '-') == "version") // Show Version
                    {
                        _showVer = true;
                        progArgs.Add(args[i]);
                    }
                    else progArgs.Add(args[i]);
                }
                else
                {
                    // Command Args
                    commandArgs.Add(args[i]);
                }
            }

            logging = new Logging(_verbose, _logFile);

            if (args.Length == 0)
            {
                if (!IsLinux)
                {
                    var handle = GetConsoleWindow();

                    FreeConsole();
                    ShowWindow(handle, SW_HIDE);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LocationClientForm());
            }
            else
            {
                if (!IsLinux) AllocConsole();

                if (_showVer)
                {
                    Console.WriteLine("LocationClient " + GetVersion(true));
                }
                else
                {
                    try
                    {
                        LocationClient location = new LocationClient(Dns.GetHostAddresses(_serverAddress)[0], _serverPort, _timeOut);

                        location.SendCommand(LCH.ConvertStringToCommand(string.Join(" ", commandArgs), _protocol));

                        location.Close();
                        if (GetDebug())
                            Console.ReadKey();
                    }
                    catch (SocketException)
                    {
                        logging.Log(String.Format("'{0}' is not an address!", _serverAddress), 2);
                    }
                }
            }
        }

        public static string GetVersion(bool incBuildDate = false)
        {
            #pragma warning disable 0162
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = GetLinkerTime(Assembly.GetExecutingAssembly());

            if (_isDevBuild)
            {
                if (incBuildDate) return String.Format("v{0}.{1}.{2}-{3} ({4})", version.Major, version.Minor, version.Build, version.Revision, buildDate);
                else return String.Format("v{0}.{1}.{2}-{3}", version.Major, version.Minor, version.Build, version.Revision);
            }
            else
            {
                if (incBuildDate) return String.Format("v{0}.{1}.{2} ({3})", version.Major, version.Minor, version.Build, buildDate);
                else return String.Format("v{0}.{1}.{2}", version.Major, version.Minor, version.Build);
            }
            #pragma warning restore 0162
        }

        public static bool GetDebug()
        {
            return _verbose;
        }

        public static string GetLogPath()
        {
            return _logFile;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public static DateTime GetLinkerTime(Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }
    }
}
