﻿using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using mullak99.ACW.NetworkACW.LCHLib;
using mullak99.ACW.NetworkACW.locationserver.Save;
using mullak99.ACW.NetworkACW.locationserver.Save.SaveMethod;

namespace mullak99.ACW.NetworkACW.locationserver
{
    static class Program
    {
        public static Locations locations;

        private static bool _UI = false;
        private static int _port = 43;

        private static bool _verbose = false;
        private static bool _showVer = false;
        private static bool _useTextFileDB = false;

        internal static Logging logging;
        private static string _logFile;
        private static string _dbFile;

        private const bool _isDevBuild = true;

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
                else if (args[i].ToLower().TrimStart('/', '-') == "v" || args[i].ToLower().TrimStart('/', '-') == "version") // Show Version
                    _showVer = true;
                else if (args[i].ToLower().TrimStart('/', '-') == "a" || args[i].ToLower().TrimStart('/', '-') == "alternatedb") // Alternate DB (Use Text File)
                    _useTextFileDB = true;
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

            DatabaseType dbType = DatabaseType.SQLite;
            if (_useTextFileDB) dbType = DatabaseType.TextFile;

            logging = new Logging(_verbose, _logFile);
            locations = new Locations(_dbFile, dbType);

            if (_UI)
            {
                if (!IsLinux) FreeConsole();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                if (!IsLinux) AllocConsole();

                if (_showVer)
                {
                    Console.WriteLine("LocationServer " + GetVersion(true));
                }
                else
                {
                    LocationServer server = new LocationServer(_port);

                    if (GetDebug())
                        Console.ReadKey();
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
                if (incBuildDate) return String.Format("v{0}.{1}.{2}-{3} ({4})", version.Major, version.Minor, version.MajorRevision, version.MinorRevision, buildDate);
                else return String.Format("v{0}.{1}.{2}-{3}", version.Major, version.Minor, version.MajorRevision, version.MinorRevision);
            }
            else
            {
                if (incBuildDate) return String.Format("v{0}.{1}.{2} ({3})", version.Major, version.Minor, version.MajorRevision, buildDate);
                else return String.Format("v{0}.{1}.{2}", version.Major, version.Minor, version.MajorRevision);
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

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

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
