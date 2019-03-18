using SimpleSettingsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.location
{
    internal class SSM_UI
    {
        internal static SSM ssm = new SSM(new SSM_File(_ssmPath));
        private const string _ssmPath = "LocationClientUI_Settings.db";

        internal static void InitSSM()
        {
            ssm.Open();

            ssm.AddString("serverAddress", "127.0.0.1", "Default server address");
            ssm.AddInt32("serverPort", 43, "Default server port");
            ssm.AddString("loggingPath", "LocationClient.log", "Default logging path");
            ssm.AddBoolean("developerMode", false, "Enable developer features");
            ssm.AddBoolean("enableLogFile", false, "Enable logging to a file");
            ssm.AddBoolean("autoConnect", false, "Automatically connect to a server");
            ssm.AddBoolean("autoFill", false, "Automatically fills in address, port and timeout");

            ssm.Close();
        }

        internal static void SaveSSM()
        {
            ssm.Open();

            ssm.SetString("serverAddress", Program.GetServerAddress(false));
            ssm.SetInt32("serverPort", Convert.ToInt32(Program.GetServerAddress(true).Split(':')[1]));
            if (!String.IsNullOrEmpty(Program.GetLogPath())) ssm.SetString("loggingPath", Program.GetLogPath());
            ssm.SetBoolean("developerMode", Program.GetDeveloperMode());
            ssm.SetBoolean("enableLogFile", !String.IsNullOrEmpty(Program.GetLogPath()));
            ssm.SetBoolean("autoConnect", Program.GetUiAutoConnect());
            ssm.SetBoolean("autoFill", Program.GetUiAutoFill());


            ssm.Close();
        }

        internal static void LoadSSM()
        {
            ssm.Open();

            Program.SetServerAddress(ssm.GetString("serverAddress"), Convert.ToUInt16(ssm.GetInt32("serverPort")));
            if (ssm.GetBoolean("enableLogFile")) Program.SetLogPath(ssm.GetString("loggingPath"));
            Program.SetDeveloperMode(ssm.GetBoolean("developerMode"));
            Program.SetUiAutoConnect(ssm.GetBoolean("autoConnect"));
            Program.SetUiAutoFill(ssm.GetBoolean("autoFill"));

            ssm.Close();
        }
    }
}
