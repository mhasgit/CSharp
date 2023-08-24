using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace SocketsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("192.168.0.10"); // IPAddress.Loopback;
            // Socket socket = new Socket()

            string quadNotationIpBinary = GetBinaryIpString(IPAddress.Parse("192.168.0.10"));
            Console.WriteLine(GetBinaryIpString(IPAddress.Parse("192.168.0.10")));
            Console.WriteLine(GetBinaryIpString(IPAddress.Parse("255.255.255.0")));

            IPEndPoint localEndpoint = new IPEndPoint(ip, 5555);

        }

        static string GetBinaryIpString(IPAddress address)
        {
            byte[] octets = address.GetAddressBytes();
            string[] octetString = new string[octets.Length];
            for (int i = 0; i < octets.Length; i++)
            {
                octetString[i] = Convert.ToString(octets[i], 2).PadLeft(8, '0');
            }

            return string.Join(".", octetString);
        }
    }
}
