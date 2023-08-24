using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Open a socket
            // 2. Bind it to a local endpoint
            // 3. Listen for incoming connections
            // 4. Accept the connection
            // 5. Send/Recieve data
            // 6. Close the socket

            IPAddress localIp = IPAddress.Parse("0.0.0.0");
            IPEndPoint localEndpoint = new IPEndPoint(localIp, 5555);

            Socket serverSocket = new Socket(
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(localEndpoint);

            serverSocket.Listen(10);

            Socket clientSocket = serverSocket.Accept();
            // clientSocket.LocalEndPoint
            // clientSocket.RemoteEndPoint

             string message = "welcome to the server!";

            int sentBytes = clientSocket.Send(Encoding.UTF8.GetBytes(message));

            byte[] receiveBuffer = new byte[1024];
            int bytesReceived = clientSocket.Receive(receiveBuffer);

            string messageReceived = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);
            Console.WriteLine(messageReceived);

            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();


            //serverSocket.Shutdown(SocketShutdown.Both);
            //serverSocket.Close();
        }
    }
}
