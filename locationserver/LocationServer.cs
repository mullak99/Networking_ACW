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

        private bool _connected = false;

        public LocationServer(int port)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);

            Open();
        }

        public void Open()
        {
            _connected = true;

            while (_connected)
            {
                _listener.Start();

                _client = _listener.AcceptTcpClient();

                NetworkStream nwStream = _client.GetStream();
                byte[] buffer = new byte[_client.ReceiveBufferSize];

                int bytesRead = nwStream.Read(buffer, 0, _client.ReceiveBufferSize);

                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: " + dataReceived);

                if (dataReceived.ToLower().Replace("!", "") == "ping")
                {
                    Console.WriteLine("Sending back: Pong!");
                    byte[] dataBytes = ASCIIEncoding.ASCII.GetBytes("Pong!");
                    nwStream.Write(dataBytes, 0, dataBytes.Length);
                }
                else
                {
                    Console.WriteLine("Sending back: " + dataReceived);
                    nwStream.Write(buffer, 0, bytesRead);
                }   
            }
        }

        public void Close()
        {
            _connected = false;
            _client.Close();
            _listener.Stop();
        }
    }
}
