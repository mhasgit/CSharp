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
            MessagingServer();
        }

        static void MessagingServer()
        {
            const int port = 5555;
            IPAddress localIp = IPAddress.Parse("0.0.0.0");
            IPEndPoint localEndpoint = new IPEndPoint(localIp, port);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(localEndpoint);
                serverSocket.Listen(10);

                Console.WriteLine($"Listening for connections on port: {port}");

                while (true)
                {
                    Socket clientSocket = serverSocket.Accept();
                    Console.WriteLine($"Client connected: {clientSocket.RemoteEndPoint.ToString()}");

                    while (clientSocket.Connected)
                    {
                        byte[] messageBuffer = new byte[1024];
                        int bytesReceived = clientSocket.Receive(messageBuffer);
                        string messageReceived = Encoding.UTF8.GetString(messageBuffer, 0, bytesReceived);

                        if (messageReceived.Contains("[[END]]"))
                        {
                            break;
                        }

                        Console.WriteLine($"Other: {messageReceived}");
                        Console.Write("You:  ");
                        string message = Console.ReadLine();
                        clientSocket.Send(Encoding.UTF8.GetBytes(message));
                    }

                    Console.WriteLine($"Client disconnected: {clientSocket.RemoteEndPoint.ToString()}");
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void SimpleServer()
        {
            // 1. Open a socket
            // 2. Bind it to a local endpoint
            // 3. Listen for incoming connections
            // 4. Accept the connection
            // 5. Send/Recieve data
            // 6. Close the socket

            // clientSocket.LocalEndPoint
            // clientSocket.RemoteEndPoint

            // string message = "welcome to the server!";

            //int sentBytes = clientSocket.Send(Encoding.UTF8.GetBytes(message));

            //byte[] receiveBuffer = new byte[1024];
            //int bytesReceived = clientSocket.Receive(receiveBuffer);

            //string messageReceived = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);
            //Console.WriteLine(messageReceived);

            //clientSocket.Shutdown(SocketShutdown.Both);
            //clientSocket.Close();


            //serverSocket.Shutdown(SocketShutdown.Both);
            //serverSocket.Close();
        }
    }
}
