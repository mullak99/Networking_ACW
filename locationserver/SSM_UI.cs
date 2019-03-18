using SimpleSettingsManager;
using System;

namespace mullak99.ACW.NetworkACW.locationserver
{
    internal class SSM_UI
    {
        internal static SSM ssm = new SSM(new SSM_File(_ssmPath));
        private const string _ssmPath = "LocationServerUI_Settings.db";

        internal static void InitSSM()
        {
            ssm.Open();

            ssm.AddInt32("serverPort", 43, "Default server port");
            ssm.AddString("loggingPath", "LocationClient.log", "Default logging path");
            ssm.AddString("dbPath", "LocationServer_DB.db", "Default database path");
            ssm.AddBoolean("developerMode", false, "Enable developer features");
            ssm.AddBoolean("enableLogFile", false, "Enable logging to a file");
            ssm.AddBoolean("enableDbFile", false, "Enable saving database to a file");
            ssm.AddBoolean("autoStart", false, "Automatically start the server");
            ssm.AddBoolean("autoFill", false, "Automatically fills in address, port and timeout");

            ssm.Close();
        }

        internal static void SaveSSM()
        {
            ssm.Open();

            ssm.SetInt32("serverPort", Convert.ToInt32(Program.GetPort()));
            if (!String.IsNullOrEmpty(Program.GetLogPath())) ssm.SetString("loggingPath", Program.GetLogPath());
            if (!String.IsNullOrEmpty(Program.GetDbPath())) ssm.SetString("dbPath", Program.GetDbPath());
            ssm.SetBoolean("developerMode", Program.GetDeveloperMode());
            ssm.SetBoolean("enableLogFile", !String.IsNullOrEmpty(Program.GetLogPath()));
            ssm.SetBoolean("enableDbFile", !String.IsNullOrEmpty(Program.GetDbPath()));
            ssm.SetBoolean("autoStart", Program.GetAutoStart());

            ssm.Close();
        }

        internal static void LoadSSM()
        {
            ssm.Open();

            Program.SetPort(Convert.ToUInt16(ssm.GetInt32("serverPort")));
            if (ssm.GetBoolean("enableLogFile")) Program.SetLogPath(ssm.GetString("loggingPath"));
            if (ssm.GetBoolean("enableDbFile")) Program.SetDbPath(ssm.GetString("dbPath"));
            Program.SetDeveloperMode(ssm.GetBoolean("developerMode"));
            Program.SetAutoStart(ssm.GetBoolean("autoStart"));

            Program.logging.SetLogPath(Program.GetLogPath());
            Program.logging.SetDeveloperMode(Program.GetDeveloperMode());
            Program.locations.SetDbPath(Program.GetDbPath());

            ssm.Close();
        }
    }
}
