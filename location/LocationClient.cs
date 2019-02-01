using mullak99.ACW.NetworkACW.LCHLib.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.location
{
    public class LocationClient
    {
        private TcpClient _client;
        private bool _connected = false;

        private string _ip;
        private int _port;

        public LocationClient(string serverAddress, int serverPort)
        {
            _ip = serverAddress;
            _port = serverPort;

            Open();
        }

        public void Open()
        {
            try
            {
                _client = new TcpClient(_ip, _port);

                Logging.Log(String.Format("Connected to server at '{0}:{1}'!", _ip, _port));
                _connected = true;
            }
            catch (SocketException e)
            {
                _connected = false;

                if (e.ToString().Contains("No connection could be made because the target machine"))
                    Logging.Log(String.Format("Server at '{0}:{1}' could not be reached!", _ip, _port), 3);
                else
                    Logging.Log("An unexpected SocketException error occured while connecting to the server! Exception: " + e.ToString(), 3);
            }
            catch (Exception e)
            {
                Logging.Log("An unexpected error occured while connecting to the server! Exception: " + e.ToString(), 3);
            }
        }

        public void Close()
        {
            if (_connected)
            {
                _connected = false;
                _client.Close();

                Logging.Log(String.Format("Disconnected from server '{0}:{1}'!", _ip, _port));
            }
        }

        public void WaitForResponse()
        {
            try
            {
                NetworkStream nwStream = _client.GetStream();
                nwStream.ReadTimeout = 2000;

                byte[] bytesToRead = new byte[_client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, _client.ReceiveBufferSize);
                Logging.Log("Received: " + Encoding.UTF8.GetString(bytesToRead, 0, bytesRead));
            }
            catch (IOException)
            {
                Logging.Log("Read request timed out.", 2);
            }
        }

        public void SendCommand(Command command)
        {
            SendRawString(command.ComposeCommand());
        }

        private void SendRawString(string data)
        {
            if (_connected)
            {
                try
                {
                    NetworkStream nwStream = _client.GetStream();

                    byte[] dataBytes = ASCIIEncoding.UTF8.GetBytes(data);
                    Logging.Log("Sending: " + data);
                    nwStream.Write(dataBytes, 0, dataBytes.Length);
                }
                catch (IOException)
                {
                    Logging.Log("Send request timed out.", 2);
                }

                WaitForResponse();
            }
            else Logging.Log("You are not connected to a server!", 2);

        }
    }
}
