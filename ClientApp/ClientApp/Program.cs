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
            IPAddress localIp = IPAddress.Parse("192.168.100.163");
            IPEndPoint remoteEndpoint = new IPEndPoint(localIp, 5555);



            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);



            socket.Connect(remoteEndpoint);



            while (socket.Connected)
            {
                Console.Write("> ");
                string message = Console.ReadLine();



                int sentBytes = socket.Send(Encoding.UTF8.GetBytes(message));



                if (message.Contains("[[END]]"))
                {
                    break;
                }



                byte[] receiveBuffer = new byte[128];
                int bytesReceived = socket.Receive(receiveBuffer);



                string messageReceived = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);



                if (!messageReceived.Contains("[[RECV]]"))
                {
                    Console.WriteLine($"Invalid message received: {messageReceived}");
                }
                else
                {
                    Console.WriteLine("Message delivered!");
                }
            }



            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
