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
        private int _port, _timeOut;

        public LocationClient(IPAddress serverIpAddress, int serverPort, UInt16 timeOut = 2000)
        {
            Program.logging.Log(String.Format("Starting LocationClient {0}...", Program.GetVersion()), 0);

            if (Program.GetDebug())
                Program.logging.Log(String.Format("Debug Mode Enabled!", Program.GetVersion()), 0);

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
                
                Program.logging.Log(String.Format("Connected to server at '{0}:{1}'!", _ip, _port), 0);
                _connected = true;
            }
            catch (SocketException e)
            {
                _connected = false;

                if (e.ToString().Contains("No connection could be made because the target machine"))
                    Program.logging.Log(String.Format("Server at '{0}:{1}' could not be reached!", _ip, _port), 2);
                else
                    Program.logging.Log("An unexpected SocketException error occured while connecting to the server! Exception: " + e.ToString(), 3);
            }
            catch (TimeoutException)
            {
                Program.logging.Log(String.Format("Connection to '{0}:{1}' timed out!", _ip, _port), 2);
            }
            catch (Exception e)
            {
                Program.logging.Log("An unexpected error occured while connecting to the server! Exception: " + e.ToString(), 3);
            }
        }

        public void Close()
        {
            if (_connected)
            {
                _connected = false;
                _client.Close();

                Program.logging.Log(String.Format("Disconnected from server '{0}:{1}'!", _ip, _port), 0);
            }
        }

        public void WaitForResponse(Command command)
        {
            try
            {
                StreamReader sr = new StreamReader(_client.GetStream(), Encoding.ASCII);

                string data = sr.ReadToEnd();

                Program.logging.Log(String.Format("Recieved (Protocol={0}): {1}", command.GetProtocol().ToString(), data.Replace("\r\n", "<CR><LF>")), 0);

                if (command.GetType() == typeof(CommandGetLocation))
                {
                    CommandGetLocation cmd = (CommandGetLocation)command;

                    if (cmd.ResolveResponse(data))
                        Program.logging.Log(cmd.ToString(), 1, true);
                    else
                        Program.logging.Log("ERROR: no entries found", 1, true);
                }
                else if (command.GetType() == typeof(CommandSetLocation))
                {
                    CommandSetLocation cmd = (CommandSetLocation)command;

                    if (cmd.ResolveResponse(data))
                        Program.logging.Log(String.Format("{0} location changed to be {1}\r\n", cmd.GetPersonID().TrimEnd(' '), cmd.GetLocation().TrimEnd(' ')), 1, true);
                    else
                        Program.logging.Log(String.Format("ERROR: An unexpected error occured while changing {0}'s location!\r\n", cmd.GetPersonID().TrimEnd(' ')), 1, true);
                }
                else Program.logging.Log(data);
            }
            catch (IOException)
            {
                Program.logging.Log("Server failed to respond in time!", 2);
            }
        }

        public void SendCommand(Command command)
        {
            if (!_connected) Open();

            string data = command.ComposeCommand();

            if (_connected)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(_client.GetStream(), Encoding.ASCII);
                    sw.Write(data);
                    sw.Flush();

                    Program.logging.Log(String.Format("Sending (Protocol={0}): {1}", command.GetProtocol().ToString(), data.Replace("\r\n", "<CR><LF>")), 0);
                }
                catch (IOException)
                {
                    Program.logging.Log("Send request timed out.", 2);
                }

                WaitForResponse(command);
            }
            else Program.logging.Log("You are not connected to a server!", 2);

            Close();
        }
    }
}
