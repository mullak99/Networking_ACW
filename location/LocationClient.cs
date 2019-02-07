using mullak99.ACW.NetworkACW.LCHLib.Commands;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace mullak99.ACW.NetworkACW.location
{
    public class LocationClient
    {
        private TcpClient _client;
        private bool _connected = false;

        private string _ip;
        private int _port;

        private int _timeOut;

        public LocationClient(IPAddress serverIpAddress, int serverPort, UInt16 timeOut = 2000)
        {
            Logging.Log(String.Format("Starting LocationClient {0}...", Program.GetVersion()));

            _ip = serverIpAddress.ToString();
            _port = serverPort;
            _timeOut = Convert.ToInt32(timeOut);

            Open();
        }

        public void Open()
        {
            try
            {
                _client = new TcpClient();
                _client.ReceiveTimeout = _timeOut;
                _client.SendTimeout = _timeOut;

                IAsyncResult ar = _client.BeginConnect(_ip, _port, null, null);
                System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
                try
                {
                    if (_timeOut < 10000 && !ar.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(_timeOut), false))
                    {
                        _client.Close();
                        throw new TimeoutException();
                    }
                    else if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(10000), false))
                    {
                        _client.Close();
                        throw new TimeoutException();
                    }

                    _client.EndConnect(ar);
                }
                finally
                {
                    wh.Close();
                }

                Logging.Log(String.Format("Connected to server at '{0}:{1}'!", _ip, _port));
                _connected = true;
            }
            catch (SocketException e)
            {
                _connected = false;

                if (e.ToString().Contains("No connection could be made because the target machine"))
                    Logging.Log(String.Format("Server at '{0}:{1}' could not be reached!", _ip, _port), 2);
                else
                    Logging.Log("An unexpected SocketException error occured while connecting to the server! Exception: " + e.ToString(), 3);
            }
            catch (TimeoutException)
            {
                Logging.Log(String.Format("Connection to '{0}:{1}' timed out!", _ip, _port), 2);
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
                StreamReader sr = new StreamReader(_client.GetStream());

                Logging.Log("Recieved: " + sr.ReadToEnd().TrimEnd('\n'), 0);

                Logging.Log(sr.ReadToEnd().TrimEnd('\n'));
            }
            catch (IOException)
            {
                Logging.Log("Read request timed out.", 2);
            }
        }

        public void SendCommand(Command command)
        {
            if (!_connected) Open();

            SendRawString(command.ComposeCommand());
            Close();
        }

        private void SendRawString(string data)
        {
            if (_connected)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(_client.GetStream());
                    Logging.Log("Sending: " + data.TrimEnd('\n'), 0);
                    sw.WriteLine(data);
                    sw.Flush();
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
