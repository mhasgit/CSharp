using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace NetworkingInfo
{
    internal class NetInfoHelper
    {

        public void NetworkIterfaceTest()
        {
            // networkAdapters, nics,
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
           
            foreach(NetworkInterface nic  in networkInterfaces)
            {
                Console.WriteLine(nic.Id);
                Console.WriteLine(nic.Name);
                Console.WriteLine(nic.OperationalStatus);
                Console.WriteLine(nic.NetworkInterfaceType);
                Console.WriteLine(nic.Speed);

                if (nic.Supports(NetworkInterfaceComponent.IPv4))
                {
                    Console.WriteLine("Supports IPv4");
                }

                if (nic.Supports(NetworkInterfaceComponent.IPv6))
                {
                    Console.WriteLine("Supports IPv6");
                }

                PhysicalAddress macAddress = nic.GetPhysicalAddress();
                byte[] macBytes = macAddress.GetAddressBytes();
                // Convert.ToString(macBytes[0], 16);

                IPInterfaceStatistics nicStats = nic.GetIPStatistics();
                
            }
        }
    }

    
}
