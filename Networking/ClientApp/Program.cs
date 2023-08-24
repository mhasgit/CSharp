using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Open a socket
            // 2. Connect it to a remote endpoint
            // 3. Send/Recieve data
            // 4. Close the socket


            IPAddress localIp = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEndpoint = new IPEndPoint(localIp, 5555);

            Socket socket = new Socket(
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(remoteEndpoint);

            byte[] receiveBuffer = new byte[1024];
            int bytesReceived = socket.Receive(receiveBuffer);

            string messageReceived = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);
            Console.WriteLine(messageReceived);

            string message = "Good bye server!";
            int sentBytes = socket.Send(Encoding.UTF8.GetBytes(message));

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
