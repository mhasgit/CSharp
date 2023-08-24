using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessagingClient();
        }

        static void MessagingClient()
        {
            IPAddress localIp = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEndpoint = new IPEndPoint(localIp, 5555);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(remoteEndpoint);

            while (socket.Connected)
            {
                Console.Write("You: ");
                string message = Console.ReadLine();

                int sentBytes = socket.Send(Encoding.UTF8.GetBytes(message));

                if (message.Contains("[[END]]"))
                {
                    break;
                }

                byte[] receiveBuffer = new byte[1024];
                int bytesReceived = socket.Receive(receiveBuffer);

                string messageReceived = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);
                Console.WriteLine($"Other: {messageReceived}");
            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }


    }
}
