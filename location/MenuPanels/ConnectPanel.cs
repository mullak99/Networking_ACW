﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace mullak99.ACW.NetworkACW.location.MenuPanels
{
    public partial class ConnectPanel : UserControl
    {
        private string _address;
        private UInt16 _port, _timeOut;

        private bool _isConnected = false;

        public ConnectPanel()
        {
            InitializeComponent();

            ServerAddressTextBox_Leave(null, null);

            try
            {
                portTextBox.Value = Convert.ToUInt16(Program.GetServerAddress(true).Split(':')[1]);
            }
            catch
            {
                Program.SetServerAddress("127.0.0.1", 43);
            }

            timeoutDelayTextBox.Value = Program.GetTimeout();

            _address = serverAddressTextBox.Text;

            if (Program.GetUiAutoConnect()) ConnectButton_Click(null, null);
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

        public void ShowError(string error)
        {
            errorLabel.Text = error;
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

                ShowError("Connection Successful!");
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
            if (ValidateAddress())
            {
                if (!GetConnected())
                {
                    LocationClientForm.location = new LocationClient(Dns.GetHostAddresses(_address)[0], Convert.ToUInt16(portTextBox.Value), Convert.ToUInt16(timeoutDelayTextBox.Value), false);

                    if (LocationClientForm.location.Open().Contains("Connected to server"))
                    {
                        Program.SetServerAddress(_address, _port);
                        SSM_UI.SaveSSM();
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
        }

        private bool ValidateAddress()
        {
            try
            {
                _ = Dns.GetHostAddresses(serverAddressTextBox.Text)[0];

                _address = serverAddressTextBox.Text;
                _port = Convert.ToUInt16(portTextBox.Value);
                _timeOut = Convert.ToUInt16(timeoutDelayTextBox.Value);
                connectButton.Enabled = true;
                Program.SetServerAddress(_address, _port);
                SSM_UI.SaveSSM();
                return true;
            }
            catch
            {
                connectButton.Enabled = false;
                return false;
            }
        }

        private void TextBoxAutoFill(TextBox textBox, string autoFill, bool defaultText)
        {
            if (defaultText)
            {
                if (textBox.ForeColor == Color.Black && String.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.ForeColor = Color.Gray;
                    textBox.Text = autoFill;
                }
            }
            else
            {
                if (textBox.ForeColor == Color.Gray)
                {
                    textBox.ForeColor = Color.Black;
                    textBox.Text = "";
                }
            }
        }

        private void ServerAddressTextBox_Enter(object sender, EventArgs e)
        {
            TextBoxAutoFill(serverAddressTextBox, Program.GetServerAddress(false), false);
        }

        private void ServerAddressTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxAutoFill(serverAddressTextBox, Program.GetServerAddress(false), true);
        }
    }
}
