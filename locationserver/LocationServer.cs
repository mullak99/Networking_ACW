using mullak99.ACW.NetworkACW.LCHLib;
using mullak99.ACW.NetworkACW.LCHLib.Commands;
using mullak99.ACW.NetworkACW.locationserver.Save;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace mullak99.ACW.NetworkACW.locationserver
{
    public class LocationServer
    {
        TcpListener _listener;
        Thread _listenerThread;

        private IPAddress _ip = IPAddress.Any;
        private int _port;

        private bool _connected = false;

        public LocationServer(int port = 43)
        {
            _port = port;

            Open();
        }

        public void Open()
        {
            if (!_connected)
            {
                Program.logging.Log(String.Format("Starting LocationServer {0}...", Program.GetVersion()));

                if (Program.GetDebug())
                    Program.logging.Log("Debug Mode Enabled!", 0);

                _listener = new TcpListener(_ip, _port);

                _listenerThread = new Thread(() => StartListener());
                _listenerThread.Start();
            }
            else Program.logging.Log("LocationServer is already running!", 2);
        }

        private void StartListener()
        {
            try
            {
                _listener.Start();
                Program.logging.Log(String.Format("Listening for connections on '{0}:{1}'.", _ip, _port));
                _connected = true;

                while (_connected)
                {
                    Socket client = _listener.AcceptSocket();   

                    Thread handleRequest = new Thread(() => HandleClient(client));
                    handleRequest.Start();
                }
            }
            catch (SocketException e)
            {
                if (e.ToString().Contains("Only one usage of each socket address"))
                    Program.logging.Log(String.Format("An existing server is already running on this port ({0})!", _port), 2);
                else
                    Program.logging.Log("An unexpected SocketException occured on StartListener. Exception: " + e.ToString(), 3);
            }
            catch (Exception e)
            {
                Program.logging.Log("An unexpected exception occured on StartListener. Exception: " + e.ToString(), 3);
            }
            finally
            {
                _connected = false;
            }
        }

        private void HandleClient(Socket client)
        {
            Program.logging.Log("Client connection recieved!", 0);

            NetworkStream netStream = new NetworkStream(client);

            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = netStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            string recievedMessage = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead).TrimEnd('\n', '\r');

            Program.logging.Log("Received: " + recievedMessage.Replace("\r\n", "<CR><LF>"), 0);

            LCH.Protocol protocol = LCH.Protocol.WHOIS;
            Command command = LCH.ConvertClientRequestToCommand(recievedMessage, ref protocol);

            string returnMessage = ExecuteCommand(command, protocol);

            Program.logging.Log(String.Format("Sending (Protocol={0}): {1}", command.GetProtocol().ToString(), returnMessage.Replace("\r\n", "<CR><LF>")));

            byte[] dataBytes = ASCIIEncoding.ASCII.GetBytes(returnMessage);
            netStream.Write(dataBytes, 0, dataBytes.Length);

            netStream.Close();
            client.Close();
        }

        private string ExecuteCommand(Command command, LCH.Protocol protocol = LCH.Protocol.WHOIS)
        {
            if (command.GetType() == typeof(CommandGetLocation))
            {
                CommandGetLocation getLocation = (CommandGetLocation)command;

                Program.logging.Log(String.Format("CommandGetLocation (Protocol={0}): {1}", getLocation.GetProtocol().ToString(), string.Join(" ", getLocation.GetArguments())));

                PersonLocation pLocation = Program.locations.GetPersonLocation(getLocation.GetPersonID());

                if (pLocation != null) getLocation.SetLocation(pLocation.GetPersonLocation());

                return getLocation.RespondToClient();
            }
            else if (command.GetType() == typeof(CommandSetLocation))
            {
                CommandSetLocation setLocation = (CommandSetLocation)command;

                Program.logging.Log(String.Format("CommandSetLocation (Protocol={0}): {1}", setLocation.GetProtocol().ToString(), string.Join(" ", setLocation.GetArguments())));

                return setLocation.RespondToClient(Program.locations.AddPersonLocation(new PersonLocation(setLocation.GetPersonID(), setLocation.GetLocation()), true));
            }
            return "ERROR: an unexpected error occured!";
        }

        public void Close()
        {
            _connected = false;
            _listenerThread.Abort();
            _listener.Stop();
        }
    }
}
