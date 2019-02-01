using mullak99.ACW.NetworkACW.LCHLib;
using mullak99.ACW.NetworkACW.LCHLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.locationserver
{
    public class LocationServer
    {
        private TcpListener _listener;
        private TcpClient _client;

        private IPAddress _ip = IPAddress.Any;
        private int _port;

        private bool _connected = false;

        public LocationServer(int port = 43, bool runAsync = true)
        {
            _port = port;
            _listener = new TcpListener(_ip, _port);

            if (runAsync) OpenAsync();
            else Open();
        }

        public void Open()
        {
            if (!_connected)
            {
                _connected = true;

                Logging.Log(String.Format("Listening for connections on '{0}:{1}'.", _ip, _port));

                while (_connected)
                {
                    _listener.Start();
                    _client = _listener.AcceptTcpClient();

                    HandleClientRequest(_client);
                }
            }
            else Logging.Log("Server already running!", 3);
        }

        public void OpenAsync()
        {
            if (!_connected)
            {
                _connected = true;

                _listener.Start();
                Logging.Log(String.Format("Listening for connections on '{0}:{1}'.", _ip, _port));
                WaitForClients();
            }
            else Logging.Log("Server already running!", 3);
        }

        private void WaitForClients()
        {
            _listener.BeginAcceptTcpClient(new System.AsyncCallback(OnClientConnected), null);
        }

        private void OnClientConnected(IAsyncResult asyncResult)
        {
            try
            {
                TcpClient client = _listener.EndAcceptTcpClient(asyncResult);
                if (client != null)
                    Logging.Log("Received: " + client.Client.RemoteEndPoint.ToString());
                HandleClientRequest(client);
            }
            catch (Exception e)
            {
                Logging.Log("An unexpected error occured at OnClientConnected! Exception: " + e.ToString(), 3);
            }
            WaitForClients();
        }

        private void HandleClientRequest(TcpClient client)
        {
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
            string returnMessage = ExecuteCommand(LCH.ConvertStringToCommand(Encoding.UTF8.GetString(buffer, 0, bytesRead)));

            byte[] dataBytes = ASCIIEncoding.UTF8.GetBytes(returnMessage);
            nwStream.Write(dataBytes, 0, dataBytes.Length);
        }

        private string ExecuteCommand(Command command)
        {
            List<string> args = command.GetArguments();

            if (command.GetType() == typeof(CommandGetLocation))
            {
                Logging.Log("CommandGetLocation: " + string.Join(" ", args));

                return "Recieved CommandGetLocation: " + string.Join(" ", args);
            }
            else if (command.GetType() == typeof(CommandSetLocation))
            {
                Logging.Log("CommandSetLocation: " + string.Join(" ", args));

                return "Recieved CommandSetLocation: " + string.Join(" ", args);
            }
            else
                throw new Exception("Unsupported command!");
        }

        public void Close()
        {
            _connected = false;
            _client.Close();
            _listener.Stop();
        }
    }
}
