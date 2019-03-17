using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mullak99.ACW.NetworkACW.location.MenuPanels
{
    public partial class ConnectPanel : UserControl
    {
        private IPAddress _address;

        private bool _isConnected = false;

        public ConnectPanel()
        {
            InitializeComponent();
        }

        public bool GetConnected()
        {
            return _isConnected;
        }

        public bool SetConnected(bool connected)
        {
            ConnectButtonMode(connected);
            return _isConnected;
        }

        private void ConnectButtonMode(bool connected)
        {
            if (connected)
            {
                connectButton.Text = "Disconnect";
                connectButton.BackColor = Color.Red;

                serverAddressTextBox.Enabled = false;
                portTextBox.Enabled = false;
                timeoutDelayTextBox.Enabled = false;

                _isConnected = true;
            }
            else
            {
                connectButton.Text = "Connect";
                connectButton.BackColor = Color.ForestGreen;

                serverAddressTextBox.Enabled = true;
                portTextBox.Enabled = true;
                timeoutDelayTextBox.Enabled = true;

                _isConnected = false;
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!GetConnected())
            {
                LocationClientForm.location = new LocationClient(_address, Convert.ToInt32(portTextBox.Value), Convert.ToUInt16(timeoutDelayTextBox.Value), false);

                if (LocationClientForm.location.Open().Contains("Connected to server"))
                {
                    ConnectButtonMode(true);
                }
                else
                {
                    ConnectButtonMode(false);
                }

                LocationClientForm.location.Close();
            }
            else
            {
                LocationClientForm.location.Close();
                ConnectButtonMode(false);
            }
        }

        private void ServerAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(serverAddressTextBox.Text, out _address))
                connectButton.Enabled = true;
            else
            {
                try
                {
                    _address = Dns.GetHostAddresses(serverAddressTextBox.Text)[0];
                    connectButton.Enabled = true;
                }
                catch
                {
                    connectButton.Enabled = false;
                }
            }
        }
    }
}
