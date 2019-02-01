using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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

        private static bool _useHTTP09 = false;
        private static bool _useHTTP10 = false;
        private static bool _useHTTP11 = false;

        private static bool _verbose = false;

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
                        progArgs.Add(string.Join(" ", args[i], args[i + 1]));
                        i++;
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "p" && !String.IsNullOrEmpty(args[i + 1]) && int.TryParse(args[i + 1], out _serverPort)) // Server Port
                    {
                        progArgs.Add(string.Join(" ", args[i], args[i + 1]));
                        i++;
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "t" && !String.IsNullOrEmpty(args[i + 1]) && UInt16.TryParse(args[i + 1], out _timeOut)) // Timeout (ms)
                    {
                        progArgs.Add(string.Join(" ", args[i], args[i + 1]));
                        i++;
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "h9" && _useHTTP10 == false && _useHTTP11 == false) // HTTP/0.9
                    {
                        _useHTTP09 = true;
                        progArgs.Add(args[i]);
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "h0" && _useHTTP09 == false && _useHTTP11 == false) // HTTP/1.0
                    {
                        _useHTTP10 = true;
                        progArgs.Add(args[i]);
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "h1" && _useHTTP09 == false && _useHTTP10 == false) // HTTP/1.1
                    {
                        _useHTTP11 = true;
                        progArgs.Add(args[i]);
                    }
                    else if (args[i].ToLower().TrimStart('/', '-') == "d" || args[i].ToLower().TrimStart('/', '-') == "debug" || args[i].ToLower().TrimStart('/', '-') == "verbose") // Debug Mode
                    {
                        _verbose = true;
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


            if (args.Length == 0)
            {
                FreeConsole();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                AllocConsole();
                LocationClient location = new LocationClient(Dns.GetHostAddresses(_serverAddress)[0].ToString(), _serverPort, _timeOut);

                location.SendCommand(LCH.ConvertStringToCommand(string.Join(" ", commandArgs)));

                //location.SendCommand(LCH.ConvertStringToCommand("mullak99 Library"));
                //location.SendCommand(LCH.ConvertStringToCommand("mullak99"));

                location.Close();
                Console.ReadKey();
            }
        }

        public static string GetVersion()
        {
            string[] ver = (typeof(location.Program).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version).Split('.');

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
