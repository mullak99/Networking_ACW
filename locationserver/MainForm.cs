using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mullak99.ACW.NetworkACW.locationserver
{
    public partial class LocationServerForm : Form
    {
        public static LocationServer server;

        public LocationServerForm()
        {
            InitializeComponent();

            LocationServerForm.CheckForIllegalCrossThreadCalls = false;
            titleLabel.Text += Program.GetVersion();
            registerDetoggles();

            ConsoleMenuButton_Click(null, null);
        }

        private void registerDetoggles()
        {
            consoleMenuButton.registerDetoggles(new LCHLib.mUI.CustomControls.SubMenuButton[2] { databaseMenuButton, settingsMenuButton });
            databaseMenuButton.registerDetoggles(new LCHLib.mUI.CustomControls.SubMenuButton[2] { consoleMenuButton, settingsMenuButton });
            settingsMenuButton.registerDetoggles(new LCHLib.mUI.CustomControls.SubMenuButton[2] { consoleMenuButton, databaseMenuButton });
        }

        private void Runtime_Tick(object sender, EventArgs e)
        {
            consolePanel.RuntimeUpdate();
            databasePanel.RuntimeUpdate();
        }

        private void ConsoleMenuButton_Click(object sender, EventArgs e)
        {
            consolePanel.Enabled = true;
            consolePanel.Visible = true;

            databasePanel.Enabled = false;
            databasePanel.Visible = false;

            settingsPanel.Enabled = false;
            settingsPanel.Visible = false;
        }

        private void DatabaseMenuButton_Click(object sender, EventArgs e)
        {
            consolePanel.Enabled = false;
            consolePanel.Visible = false;

            databasePanel.Enabled = true;
            databasePanel.Visible = true;

            settingsPanel.Enabled = false;
            settingsPanel.Visible = false;
        }

        private void SettingsMenuButton_Click(object sender, EventArgs e)
        {
            consolePanel.Enabled = false;
            consolePanel.Visible = false;

            databasePanel.Enabled = false;
            databasePanel.Visible = false;

            settingsPanel.Enabled = true;
            settingsPanel.Visible = true;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if (server != null && server.GetListening())
                server.Close();

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
