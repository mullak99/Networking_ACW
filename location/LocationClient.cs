using System;
using System.Collections.Generic;
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

        public LocationClient(string ipAddress, int port)
        {
            _client = new TcpClient(ipAddress, port);
        }

        public void Close()
        {
            _client.Close();
        }

        public void WaitForResponse()
        {
            NetworkStream nwStream = _client.GetStream();

            byte[] bytesToRead = new byte[_client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, _client.ReceiveBufferSize);
            Console.WriteLine("Received: " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
        }

        public void SendRawString(string data)
        {
            NetworkStream nwStream = _client.GetStream();

            byte[] dataBytes = ASCIIEncoding.ASCII.GetBytes(data);
            Console.WriteLine("Sending: " + data);
            nwStream.Write(dataBytes, 0, dataBytes.Length);

            WaitForResponse();
        }
    }
}
