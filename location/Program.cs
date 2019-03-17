using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
            #region CLI Arguments
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
                    else if (args[i].ToLower().TrimStart('/', '-') == "d" || args[i].ToLower().TrimStart('/', '-') == "dev" || args[i].ToLower().TrimStart('/', '-') == "debug"|| args[i].ToLower().TrimStart('/', '-') == "developer" || args[i].ToLower().TrimStart('/', '-') == "verbose") // Developer Mode
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
            #endregion

            logging = new Logging(_verbose, _logFile);

            if (_showVer)
            {
                logging.Log("LocationClient " + GetVersion(true), 1, true);
            }
            else if (commandArgs.Count == 0 && !IsLinux) // Launch GUI (Skip if is Linux)
            {
                ShowWindow(GetConsoleWindow(), SW_HIDE); // Hides Command Prompt

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LocationClientForm());
            }
            else if (commandArgs.Count == 0 && IsLinux)
            {
                logging.Log("LocationClient GUI is not supported on Linux. Please use the command line arguments instead.", 1, true);
            }
            else
            {
                LocationClient location = new LocationClient(Dns.GetHostAddresses(_serverAddress)[0], _serverPort, _timeOut);
                location.SendCommand(LCH.ConvertStringToCommand(string.Join(" ", commandArgs), _protocol));

                if (GetDeveloperMode()) Console.ReadKey();
            }
        }

        #region Getters and Setters

        /// <summary>
        /// Gets the version of LocationClient
        /// </summary>
        /// <param name="incBuildDate">Append the build date of the current LocationClient exe to the version string</param>
        /// <returns>Formatted version string</returns>
        public static string GetVersion(bool incBuildDate = false)
        {
            #pragma warning disable 0162
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = GetBuildDateTime();

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

        /// <summary>
        /// Sets the IP and Port used to connect to the server
        /// </summary>
        /// <param name="ipAddress">Server IP Address</param>
        /// <param name="port">Server Port</param>
        public static void SetServerAddress(string ipAddress, int port)
        {
            _serverAddress = ipAddress;
            _serverPort = port;
        }

        /// <summary>
        /// Gets the address of the server
        /// </summary>
        /// <param name="includePort">Whether to append the port to the end of the address (after a colon)</param>
        /// <returns>Server Address (e.g. "x.x.x.x" or "x.x.x.x:port")</returns>
        public static string GetServerAddress(bool includePort)
        {
            if (includePort) return _serverAddress + ":" + _serverPort;
            else return _serverAddress;
        }

        /// <summary>
        /// Sets the timeout on wait operations
        /// </summary>
        /// <param name="timeout">Max wait time (in milliseconds)</param>
        public static void SetTimeout(UInt16 timeout)
        {
            _timeOut = timeout;
        }

        /// <summary>
        /// Gets the timeout used on wait operations
        /// </summary>
        /// <returns>Max wait time (in milliseconds)</returns>
        public static UInt16 GetTimeout()
        {
            return _timeOut;
        }

        /// <summary>
        /// Sets if LocationClient should run in Developer Mode (Enhanced debugging)
        /// </summary>
        /// <param name="devMode"></param>
        public static void SetDeveloperMode(bool devMode)
        {
            _verbose = devMode;
            SetDeveloperMode(_verbose);
            if (devMode) logging.Log("Developer Mode Enabled!", 0);
        }

        /// <summary>
        /// Gets if LocationClient has been launched in developer mode.
        /// </summary>
        /// <returns>If the program is in Developer Mode</returns>
        public static bool GetDeveloperMode()
        {
            return _verbose;
        }

        /// <summary>
        /// Sets the path of the log file
        /// </summary>
        /// <param name="path">Log filepath</param>
        public static void SetLogPath(string path)
        {
            _logFile = path;
            logging.Log(String.Format("Log path changed to '{0}'", path), 0);
        }

        /// <summary>
        /// Gets the path of the log file
        /// </summary>
        /// <returns>Log filepath</returns>
        public static string GetLogPath()
        {
            return _logFile;
        }

        /// <summary>
        /// If LocationClient is running on Linux
        /// </summary>
        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        /// <summary>
        /// Gets the Time & Date of when LocationClient was built
        /// </summary>
        /// <returns>DateTime of when LocationClient was built</returns>
        public static DateTime GetBuildDateTime()
        {
            var filePath = Assembly.GetExecutingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }
        #endregion

        #region Hybrid Console & Windows Form Workaround
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        #endregion
    }
}
