using SimpleSettingsManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mullak99.ACW.NetworkACW.location
{
    public partial class LocationClientForm : Form
    {
        public static LocationClient location;

        public static string showErrorOnTick = "";

        public LocationClientForm()
        {
            InitializeComponent();
            titleLabel.Text += Program.GetVersion();
            registerDetoggles();

            ConnectMenuButton_Click(null, null);

            if (Program.GetUiAutoConnect() && connectPanel.GetConnected())
                GetLocationMenuButton_Click(null, null);
        }

        private void registerDetoggles()
        {
            connectMenuButton.registerDetoggles(new LCHLib.mUI.CustomControls.SubMenuButton[3] { getLocationMenuButton, setLocationMenuButton, settingsMenuButton });
            getLocationMenuButton.registerDetoggles(new LCHLib.mUI.CustomControls.SubMenuButton[3] { connectMenuButton, setLocationMenuButton, settingsMenuButton });
            setLocationMenuButton.registerDetoggles(new LCHLib.mUI.CustomControls.SubMenuButton[3] { connectMenuButton, getLocationMenuButton, settingsMenuButton });
            settingsMenuButton.registerDetoggles(new LCHLib.mUI.CustomControls.SubMenuButton[3] { connectMenuButton, getLocationMenuButton, setLocationMenuButton });
        }

        private void ShowConnectionError(string error)
        {
            ConnectMenuButton_Click(null, null);
            connectPanel.SetConnected(false);
            connectPanel.ShowError(error);

            connectMenuButton.Selected = true;
            getLocationMenuButton.Selected = false;
            setLocationMenuButton.Selected = false;
            settingsMenuButton.Selected = false;
        }

        private void Runtime_Tick(object sender, EventArgs e)
        {
            if (connectPanel.GetConnected())
            {
                getLocationMenuButton.Enabled = true;
                setLocationMenuButton.Enabled = true;

                getLocationPanel.UpdateConsole();
                setLocationPanel.UpdateConsole();
            }
            else
            {
                getLocationMenuButton.Enabled = false;
                setLocationMenuButton.Enabled = false;
            }

            if (!String.IsNullOrEmpty(showErrorOnTick))
            {
                ShowConnectionError(showErrorOnTick);
                showErrorOnTick = "";
            }

            Program.logging.SetDeveloperMode(Program.GetDeveloperMode());
        }

        private void ConnectMenuButton_Click(object sender, EventArgs e)
        {
            connectPanel.Enabled = true;
            connectPanel.Visible = true;

            getLocationPanel.Enabled = false;
            getLocationPanel.Visible = false;

            setLocationPanel.Enabled = false;
            setLocationPanel.Visible = false;

            settingsPanel.Enabled = false;
            settingsPanel.Visible = false;
        }

        private void GetLocationMenuButton_Click(object sender, EventArgs e)
        {
            connectMenuButton.Selected = false;
            getLocationMenuButton.Selected = true;

            connectPanel.Enabled = false;
            connectPanel.Visible = false;

            getLocationPanel.Enabled = true;
            getLocationPanel.Visible = true;

            setLocationPanel.Enabled = false;
            setLocationPanel.Visible = false;

            settingsPanel.Enabled = false;
            settingsPanel.Visible = false;
        }

        private void SetLocationMenuButton_Click(object sender, EventArgs e)
        {
            connectMenuButton.Selected = false;
            setLocationMenuButton.Selected = true;

            connectPanel.Enabled = false;
            connectPanel.Visible = false;

            getLocationPanel.Enabled = false;
            getLocationPanel.Visible = false;

            setLocationPanel.Enabled = true;
            setLocationPanel.Visible = true;

            settingsPanel.Enabled = false;
            settingsPanel.Visible = false;
        }

        private void SettingsMenuButton_Click(object sender, EventArgs e)
        {
            connectPanel.Enabled = false;
            connectPanel.Visible = false;

            getLocationPanel.Enabled = false;
            getLocationPanel.Visible = false;

            setLocationPanel.Enabled = false;
            setLocationPanel.Visible = false;

            settingsPanel.Enabled = true;
            settingsPanel.Visible = true;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void SidePanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, sidePanel.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void TitleBar_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, titleBar.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void QuitButton_MouseEnter(object sender, EventArgs e)
        {
            quitButton.BackColor = Color.Red;
            quitButton.ForeColor = Color.Black;
        }

        private void QuitButton_MouseLeave(object sender, EventArgs e)
        {
            quitButton.BackColor = Color.Transparent;
            quitButton.ForeColor = Color.LightGray;
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
