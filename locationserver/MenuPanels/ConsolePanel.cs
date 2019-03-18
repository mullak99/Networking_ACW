using System;
using System.Windows.Forms;
using mullak99.ACW.NetworkACW.LCHLib.mUI;

namespace mullak99.ACW.NetworkACW.locationserver.MenuPanels
{
    public partial class ConsolePanel : UserControl
    {
        private DateTime _serverStart;
        private UInt16 _port;

        public ConsolePanel()
        {
            InitializeComponent();

            SSM_UI.LoadSSM();
            if (Program.GetAutoStart()) StartServer_Click(null, null);
        }

        public void RuntimeUpdate()
        {
            if (LocationServerForm.server != null && LocationServerForm.server.GetListening())
            {
                startServer.Enabled = false;
                rebootServer.Enabled = true;
                stopServer.Enabled = true;
                portTextBox.Enabled = false;

                TimeSpan uptime = (DateTime.UtcNow - _serverStart);

                if (uptime.TotalDays >= 1)
                    upTimeCount.Text = uptime.ToString(@"d\:hh\:mm\:ss");
                else
                    upTimeCount.Text = uptime.ToString(@"hh\:mm\:ss");
            }
            else
            {
                startServer.Enabled = true;
                rebootServer.Enabled = false;
                stopServer.Enabled = false;
                portTextBox.Enabled = true;
            }
        }

        private void StartServer_Click(object sender, EventArgs e)
        {
            _port = Convert.ToUInt16(portTextBox.Value);
            LocationServerForm.server = new LocationServer(_port, false);

            Program.logging.SetConsoleOut(new RichTextBoxWriter(consoleWindow));
            LocationServerForm.server.Open();
            _serverStart = DateTime.UtcNow;
        }

        private void RebootServer_Click(object sender, EventArgs e)
        {
            StopServer_Click(sender, e);
            StartServer_Click(sender, e);
        }

        private void StopServer_Click(object sender, EventArgs e)
        {
            upTimeCount.Text = "00:00:00";
            LocationServerForm.server.Close();
        }

        private void ClearConsoleButton_Click(object sender, EventArgs e)
        {
            consoleWindow.Clear();
        }

        private void ConsoleWindow_TextChanged(object sender, EventArgs e)
        {
            consoleWindow.SelectionStart = consoleWindow.TextLength;
            consoleWindow.ScrollToCaret();
        }
    }
}
