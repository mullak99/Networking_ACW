using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleSettingsManager;

namespace mullak99.ACW.NetworkACW.location.MenuPanels
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
            SetButtonEnabled(autoConnButton, Program.GetUiAutoConnect());
            SetButtonEnabled(persistentAddrButton, Program.GetUiAutoFill());
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

        private void PersistentAddrButton_Click(object sender, EventArgs e)
        {
            SetButtonEnabled(persistentAddrButton, !GetButtonEnabled(persistentAddrButton));

            Program.SetUiAutoFill(GetButtonEnabled(persistentAddrButton));

            if (!Program.GetUiAutoFill()) Program.SetServerAddress("127.0.0.1", 43);

            SSM_UI.SaveSSM();
        }

        private void WriteLogButton_Click(object sender, EventArgs e)
        {
            SetButtonEnabled(writeLogButton, !GetButtonEnabled(writeLogButton));

            if (GetButtonEnabled(writeLogButton)) Program.SetLogPath("LocationClient.log");
            else Program.SetLogPath("");

            Program.logging.SetLogPath(Program.GetLogPath());

            SSM_UI.SaveSSM();
        }

        private void DevModeButton_Click(object sender, EventArgs e)
        {
            SetButtonEnabled(devModeButton, !GetButtonEnabled(devModeButton));

            Program.SetDeveloperMode(GetButtonEnabled(devModeButton));
            Program.logging.SetDeveloperMode(Program.GetDeveloperMode());
            SSM_UI.SaveSSM();
        }

        private void AutoConnButton_Click(object sender, EventArgs e)
        {
            SetButtonEnabled(autoConnButton, !GetButtonEnabled(autoConnButton));

            Program.SetUiAutoConnect(GetButtonEnabled(autoConnButton));
            SSM_UI.SaveSSM();
        }
    }
}
