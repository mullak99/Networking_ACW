using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mullak99.ACW.NetworkACW.locationserver
{
    static class Program
    {
        private static bool _UI = false;

        private static int _port = 43;

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
            }

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

                Console.ReadKey();
            }
        }

        public static string GetVersion()
        {
            string[] ver = (typeof(locationserver.Program).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version).Split('.');

            return "v" + ver[0] + "." + ver[1] + "." + ver[2];
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();
    }
}
