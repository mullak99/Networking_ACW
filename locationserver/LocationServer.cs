using mullak99.ACW.NetworkACW.LCHLib;
using mullak99.ACW.NetworkACW.LCHLib.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace mullak99.ACW.NetworkACW.locationserver
{
    public class LocationServer
    {
        private TcpListener _listener;
        //private Socket _netSocket;
        private NetworkStream _socketStream;

        private IPAddress _ip = IPAddress.Any;
        private int _port;

        private bool _connected = false;

        public LocationServer(int port = 43, bool runAsync = true)
        {
            Logging.Log(String.Format("Starting LocationServer {0}...", Program.GetVersion()));

            _port = port;
            _listener = new TcpListener(_ip, _port);

            Open();
        }

        public void Open()
        {
            if (!_connected)
            {
                StartListener();
                WaitForClients();
            }
            else Logging.Log("Server already running!", 2);
        }

        private void StartListener()
        {
            try
            {
                _listener.Start();

                Logging.Log(String.Format("Listening for connections on '{0}:{1}'.", _ip, _port));

                _connected = true;
            }
            catch (SocketException e)
            {
                _connected = false;

                if (e.ToString().Contains("Only one usage of each socket address"))
                    Logging.Log(String.Format("An existing server is already running on this port ({0})!", _port), 2);
                else
                    Logging.Log("An unexpected SocketException occured on StartListener. Exception: " + e.ToString(), 3);
            }
            catch (Exception e)
            {
                _connected = false;
                Logging.Log("An unexpected exception occured on StartListener. Exception: " + e.ToString(), 3);
            }
        }

        private void WaitForClients()
        {
            if (_connected)
                _listener.BeginAcceptSocket(new System.AsyncCallback(OnClientConnected), null);
        }

        private void OnClientConnected(IAsyncResult asyncResult)
        {
            try
            {
                Socket netSocket = _listener.EndAcceptSocket(asyncResult);
                if (netSocket != null)
                {
                    _socketStream = new NetworkStream(netSocket);
                    HandleClientRequest(_socketStream);
                }
                
            }
            catch (NotImplementedException e)
            {
                Logging.Log(String.Format("The server does not support the command '{0}'. Is the server outdated?", e.Message.Split('|')[1], 2));
            }
            catch (Exception e)
            {
                Logging.Log("An unexpected error occured at OnClientConnected! Exception: " + e.ToString(), 3);
            }
            WaitForClients();
        }

        private void HandleClientRequest(NetworkStream netStream)
        {
            StreamReader sr = new StreamReader(netStream);
            StreamWriter sw = new StreamWriter(netStream);

            string recievedMessage = sr.ReadToEnd();

            Logging.Log("Received: " + recievedMessage.Replace(Environment.NewLine, ""));

            string returnMessage = ExecuteCommand(LCH.ConvertStringToCommand(recievedMessage.Replace(Environment.NewLine, "")));

            Logging.Log("Sending: " + returnMessage);

            sw.WriteLine(returnMessage);
            sw.Flush();
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
            _socketStream.Close();
            _listener.Stop();
        }
    }
}
