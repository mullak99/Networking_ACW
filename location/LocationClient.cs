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
        private UInt16 _port, _timeOut;

        /// <summary>
        /// Connect to a specific server using TCP
        /// </summary>
        /// <param name="serverIpAddress">IP Address of the server</param>
        /// <param name="serverPort">Port of the server</param>
        /// <param name="timeOut">Timeout to use for all requests to the server</param>
        public LocationClient(IPAddress serverIpAddress, UInt16 serverPort, UInt16 timeOut = 2000, bool autoStart = true)
        {
            try
            {
                Program.logging.Log(String.Format("Starting LocationClient {0}...", Program.GetVersion()), 0);

                if (Program.GetDeveloperMode())
                    Program.logging.Log(String.Format("Developer Mode Enabled!", Program.GetVersion()), 0);

                _ip = serverIpAddress.ToString();
                _port = serverPort;
                _timeOut = timeOut;

                if (autoStart) Open();
            }
            catch (SocketException)
            {
                Program.logging.Log(String.Format("'{0}' is not an address!", serverIpAddress.ToString()), 2, true);
            }
        }

        /// <summary>
        /// Gets if the client is connected to a server
        /// </summary>
        /// <returns>If the client is connected</returns>
        public bool GetConnected()
        {
            return _connected;
        }

        /// <summary>
        /// Opens the connection to the server
        /// </summary>
        /// <returns>Logging message</returns>
        public string Open()
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
                    if (_timeOut < 10000 && !ar.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(_timeOut), false)) // If the _timeOut is less than 10,000ms, use _timeOut for the actual time-out
                    {
                        _client.Close();
                        throw new TimeoutException();
                    }
                    else if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(10000), false)) // Otherwise, use 10,000ms as the time-out
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

                string message = String.Format("Connected to server at '{0}:{1}'!", _ip, _port);
                _connected = true;

                Program.logging.Log(message, 0);
                return message;
            }
            catch (SocketException e)
            {
                _connected = false;

                if (e.ToString().Contains("No connection could be made because the target machine"))
                {
                    string message = String.Format("Server at '{0}:{1}' could not be reached!", _ip, _port);

                    Program.logging.Log(message, 2);
                    return message;
                }
                else
                {
                    string message = "An unexpected SocketException error occured while connecting to the server! Exception: " + e.ToString();

                    Program.logging.Log(message, 3);
                    return message;
                }
            }
            catch (TimeoutException)
            {
                string message = String.Format("Connection to '{0}:{1}' timed out!", _ip, _port);

                Program.logging.Log(message, 2, true);
                return message;
            }
            catch (Exception e)
            {
                string message = "An unexpected error occured while connecting to the server! Exception: " + e.ToString();

                Program.logging.Log(message, 3);
                return message;
            }
        }

        /// <summary>
        /// Closes the connection to the server
        /// </summary>
        /// <returns>Logging message</returns>
        public string Close()
        {
            if (_connected)
            {
                _connected = false;
                _client.Close();

                string message = String.Format("Disconnected from server '{0}:{1}'!", _ip, _port);

                Program.logging.Log(message, 0);
                return message;
            }
            else return "Not connected to a server!";
        }

        /// <summary>
        /// Sends a command to the server and waits for a reponse
        /// </summary>
        /// <param name="command">Command to send to the server</param>
        /// <returns>Logging message</returns>
        public string SendCommand(Command command)
        {
            try
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
                        string message = "Send request timed out";

                        Program.logging.Log(message, 2);
                        return message;
                    }

                    return WaitForResponse(command);
                }
                else
                {
                    string message = "You are not connected to a server!";

                    Program.logging.Log(message, 2);
                    return message;
                }
            }
            catch (Exception e)
            {
                string message = "An unexpected error occured when sending a command to the server! Exception: " + e.Message;

                Program.logging.Log(message, 3);
                return message;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Waits for the response from the server and returns the formatted response
        /// </summary>
        /// <param name="command">Command sent to the server</param>
        /// <returns>Correctly formatted response from the server</returns>
        private string WaitForResponse(Command command)
        {
            try
            {
                StreamReader sr = new StreamReader(_client.GetStream(), Encoding.ASCII);

                string data = sr.ReadToEnd();

                Program.logging.Log(String.Format("Recieved (Protocol={0}): {1}", command.GetProtocol().ToString(), data.Replace("\r\n", "<CR><LF>")), 0);

                if (command.GetType() == typeof(CommandGetLocation))
                {
                    CommandGetLocation cmd = (CommandGetLocation)command;
                    string message = "";

                    if (cmd.ResolveResponse(data))
                        message = cmd.ToString();
                    else
                        message = data.ToString();

                    Program.logging.Log(message, 1, true);
                    return message;
                }
                else if (command.GetType() == typeof(CommandSetLocation))
                {
                    CommandSetLocation cmd = (CommandSetLocation)command;
                    string message = "";

                    if (cmd.ResolveResponse(data))
                        message = String.Format("{0} location changed to be {1}\r\n", cmd.GetPersonID().TrimEnd(' '), cmd.GetLocation().TrimEnd(' '));
                    else
                        message = String.Format("ERROR: An unexpected error occured while changing {0}'s location!\r\n", cmd.GetPersonID().TrimEnd(' '));

                    Program.logging.Log(message, 1, true);
                    return message;
                }
                else
                {
                    Program.logging.Log(data);
                    return data;
                }
            }
            catch (IOException)
            {
                string message = "Server failed to respond in time!";

                Program.logging.Log(message, 2);
                return message;
            }
        }
    }
}
