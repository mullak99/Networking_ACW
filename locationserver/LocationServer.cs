using mullak99.ACW.NetworkACW.LCHLib;
using mullak99.ACW.NetworkACW.LCHLib.Commands;
using mullak99.ACW.NetworkACW.locationserver.Save;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.locationserver
{
    public class LocationServer
    {
        TcpListener _listener;
        private IPAddress _ip = IPAddress.Any;
        private int _port;

        private bool _connected = false;

        public LocationServer(int port = 43, bool runAsync = true)
        {
            Program.logging.Log(String.Format("Starting LocationServer {0}...", Program.GetVersion()));

            if (Program.GetDebug())
                Program.logging.Log(String.Format("Debug Mode Enabled!", Program.GetVersion()), 0);

            _port = port;

            _listener = new TcpListener(_ip, _port);

            StartListener();
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
                    Task.Run(() => HandleClient(client));
                }
            }
            catch (SocketException e)
            {
                _connected = false;

                if (e.ToString().Contains("Only one usage of each socket address"))
                    Program.logging.Log(String.Format("An existing server is already running on this port ({0})!", _port), 2);
                else
                    Program.logging.Log("An unexpected SocketException occured on StartListener. Exception: " + e.ToString(), 3);
            }
            catch (Exception e)
            {
                _connected = false;
                Program.logging.Log("An unexpected exception occured on StartListener. Exception: " + e.ToString(), 3);
            }
        }

        private void HandleClient(Socket client)
        {
            Program.logging.Log("Client connection recieved!", 0);

            NetworkStream netStream = new NetworkStream(client);

            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = netStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            string recievedMessage = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead).TrimEnd('\n', '\r');

            Program.logging.Log("Received: " + recievedMessage);

            string returnMessage = ExecuteCommand(LCH.ConvertStringToCommand(recievedMessage));

            Program.logging.Log("Sending: " + returnMessage);

            byte[] dataBytes = ASCIIEncoding.ASCII.GetBytes(returnMessage);
            netStream.Write(dataBytes, 0, dataBytes.Length);

            netStream.Close();
            client.Close();
        }

        private string ExecuteCommand(Command command)
        {
            List<string> args = command.GetArguments();

            if (command.GetType() == typeof(CommandGetLocation))
            {
                CommandGetLocation getLocation = (CommandGetLocation)command;
                Program.logging.Log("CommandGetLocation: " + string.Join(" ", getLocation.GetArguments()), 0);

                PersonLocation pLocation = Program.locations.GetPersonLocation(getLocation.GetPersonID());

                if (pLocation != null)
                    return pLocation.GetPersonLocation();
                else
                    return "ERROR: no entries found";
            }
            else if (command.GetType() == typeof(CommandSetLocation))
            {
                CommandSetLocation setLocation = (CommandSetLocation)command;
                Program.logging.Log("CommandSetLocation: " + string.Join(" ", setLocation.GetArguments()), 0);

                bool success = Program.locations.AddPersonLocation(new PersonLocation(setLocation.GetPersonID(), setLocation.GetLocation()));

                if (success)
                    return "OK";
                else
                    return String.Format("ERROR: Could not add '{0}' to location '{1}' in the database! Please contact the server operator for more information!", setLocation.GetPersonID(), setLocation.GetLocation());
            }
            else
                return "ERROR: an unexpected error occured!";
        }

        public void Close()
        {
            _connected = false;
            _listener.Stop();
        }
    }
}
