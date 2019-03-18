using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mullak99.ACW.NetworkACW.locationserver.MenuPanels
{
    public partial class SettingsPanel : UserControl
    {
        public SettingsPanel()
        {
            InitializeComponent();

            SSM_UI.InitSSM();
            SSM_UI.LoadSSM();

            LoadProg();
        }

        private void LoadProg()
        {
            SetButtonEnabled(devModeButton, Program.GetDeveloperMode());
            SetButtonEnabled(writeLogButton, !String.IsNullOrEmpty(Program.GetLogPath()));
            SetButtonEnabled(autoStartButton, Program.GetAutoStart());
            SetButtonEnabled(writeDbButton, !String.IsNullOrEmpty(Program.GetDbPath()));
        }

        private void SetButtonEnabled(Button button, bool enabled)
        {
            if (enabled)
            {
                button.Text = "Enabled";
                button.BackColor = Color.ForestGreen;
            }
            else
            {
                button.Text = "Disabled";
                button.BackColor = Color.Red;
            }
        }

        private bool GetButtonEnabled(Button button)
        {
            if (button.BackColor == Color.ForestGreen)
                return true;

            return false;
        }

        private void AutoStartButton_Click(object sender, EventArgs e)
        {
            SetButtonEnabled(autoStartButton, !GetButtonEnabled(autoStartButton));

            Program.SetAutoStart(GetButtonEnabled(autoStartButton));
            SSM_UI.SaveSSM();
        }

        private void WriteLogButton_Click(object sender, EventArgs e)
        {
            SetButtonEnabled(writeLogButton, !GetButtonEnabled(writeLogButton));

            if (GetButtonEnabled(writeLogButton)) Program.SetLogPath("LocationServer.log");
            else Program.SetLogPath("");

            Program.logging.SetLogPath(Program.GetLogPath());
            SSM_UI.SaveSSM();
        }

        private void WriteDbButton_Click(object sender, EventArgs e)
        {
            SetButtonEnabled(writeDbButton, !GetButtonEnabled(writeDbButton));

            if (GetButtonEnabled(writeDbButton)) Program.SetDbPath("LocationServer_DB.db");
            else Program.SetDbPath("");

            Program.locations.SetDbPath(Program.GetDbPath());
            SSM_UI.SaveSSM();
        }

        private void DevModeButton_Click(object sender, EventArgs e)
        {
            SetButtonEnabled(devModeButton, !GetButtonEnabled(devModeButton));

            Program.SetDeveloperMode(GetButtonEnabled(devModeButton));
            Program.logging.SetDeveloperMode(Program.GetDeveloperMode());
            SSM_UI.SaveSSM();
        }
    }
}
