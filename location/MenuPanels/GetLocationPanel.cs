using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mullak99.ACW.NetworkACW.LCHLib.mUI;
using mullak99.ACW.NetworkACW.LCHLib.Commands;
using mullak99.ACW.NetworkACW.LCHLib;

namespace mullak99.ACW.NetworkACW.location.MenuPanels
{
    public partial class GetLocationPanel : UserControl
    {
        public GetLocationPanel()
        {
            InitializeComponent();
            UpdateConsole();
            protocolComboBox.SelectedIndex = 0;
        }

        public void UpdateConsole()
        {
            pseudoConsole.Enabled = Program.GetDeveloperMode();
            pseudoConsole.Visible = Program.GetDeveloperMode();

            devConsoleLabel.Enabled = Program.GetDeveloperMode();
            devConsoleLabel.Visible = Program.GetDeveloperMode();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nameTextBox.Text))
                sendButton.Enabled = false;

            sendButton.Enabled = true;
        }

        private LCH.Protocol IdentifyProtocol()
        {
            switch (protocolComboBox.Text)
            {
                case "HTTP/1.1":
                    return LCH.Protocol.HTTP11;
                case "HTTP/1.0":
                    return LCH.Protocol.HTTP10;
                case "HTTP/0.9":
                    return LCH.Protocol.HTTP09;
                case "WHOIS":
                default:
                    return LCH.Protocol.WHOIS;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                nameTextBox.Enabled = false;
                protocolComboBox.Enabled = false;

                if (Program.GetDeveloperMode()) Program.logging.SetConsoleOut(new RichTextBoxWriter(pseudoConsole));

                string personName;
                if (nameTextBox.Text.Contains(" "))
                    personName = "\"" + nameTextBox.Text + "\"";
                else
                    personName = nameTextBox.Text;


                string response = LocationClientForm.location.SendCommand(new CommandGetLocation(personName, IdentifyProtocol()));
                if (Program.GetDeveloperMode()) Program.logging.ResetConsoleOut();

                if (Program.GetDeveloperMode())
                {
                    pseudoConsole.SelectionStart = pseudoConsole.TextLength;
                    pseudoConsole.ScrollToCaret();
                }

                if (response == "You are not connected to a server!")
                {
                    responseLabel.Text = "";
                    LocationClientForm.showErrorOnTick = "Connection Lost! Please check your internet connection.";
                }
                else if (response == "ERROR: no entries found")
                {
                    responseLabel.Text = String.Format("'{0}' does not exist on the server!", nameTextBox.Text);
                }
                else
                {
                    responseLabel.Text = response.TrimEnd('\r', '\n') + ".";
                }

                nameTextBox.Enabled = true;
                protocolComboBox.Enabled = true;
            }
            else sendButton.Enabled = false;
        }

        private void DevConsoleLabel_Click(object sender, EventArgs e)
        {
            pseudoConsole.Clear();
        }
    }
}
