using System;
using System.Collections.Generic;
using System.Linq;
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

        [STAThread]
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i][0] == '-' || args[i][0] == '/')
                {
                    // Program Args
                    progArgs.Add(args[i]);
                    //TODO: Add support for parameters with arguments
                }
                else
                {
                    // Command Args
                    commandArgs.Add(args[i]);
                    //TODO: Add support for parameters with arguments
                }
            }


            //if (args.Length == 0)
            if (false)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                AllocConsole();
                LocationClient location = new LocationClient("127.0.0.1", 43);

                location.SendCommand(LCH.ConvertStringToCommand(string.Join(" ", commandArgs)));

                //location.SendCommand(LCH.ConvertStringToCommand("mullak99 Library"));
                //location.SendCommand(LCH.ConvertStringToCommand("mullak99"));

                location.Close();
                Console.ReadKey();
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();
    }
}
