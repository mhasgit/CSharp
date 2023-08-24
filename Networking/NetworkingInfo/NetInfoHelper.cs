using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace NetworkingInfo
{
    delegate void NetworkAvailibilityChanged(object sender, NetworkAvailabilityEventArgs args);

    internal class NetInfoHelper
    {

        void NicDiscovery()
        {
            NetworkChange.NetworkAvailabilityChanged += NetworkAvailibilityChanged;
        }

        void NetworkAvailibilityChanged(object sender, NetworkAvailabilityEventArgs args)
        {
            if(args.IsAvailable)
            {
                Console.WriteLine("Network is Online");
            }
            else
            {
                Console.WriteLine("Network is Offline");
            }
        }

        public void NetworkIterfaceTest()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                // 
            }

            IPGlobalProperties props = IPGlobalProperties.GetIPGlobalProperties();
            // props.DhcpScopeName
            // props.DomainName

            props.GetActiveTcpConnections();
            props.GetActiveTcpListeners();
            props.GetActiveUdpListeners();
            props.GetIcmpV4Statistics();
            props.GetIcmpV6Statistics();
            props.GetIPv4GlobalStatistics();
            props.GetIPv6GlobalStatistics();

            UdpStatistics udpStats = props.GetUdpIPv4Statistics();
            props.GetUdpIPv6Statistics();
            props.GetTcpIPv4Statistics();
            props.GetTcpIPv6Statistics();
        }


        void NetInfoTests()
        {
            // networkAdapters, nics,
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface nic in networkInterfaces)
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
                IPv4InterfaceStatistics ipv4Stats = nic.GetIPv4Statistics();
                IPInterfaceProperties nicProps = nic.GetIPProperties();
            }

            foreach (NetworkInterface nic in networkInterfaces)
            {
                List<string> unicastAddresses = new List<string>();
                if (nic.Supports(NetworkInterfaceComponent.IPv4))
                {

                    if (nic.OperationalStatus == OperationalStatus.Up
                        && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback
                        && !nic.Description.ToLower().Contains("virtual"))
                    {
                        IPInterfaceProperties nicProps = nic.GetIPProperties();
                        // var interfaceUnicastAddr = nicProps.UnicastAddresses;
                        // var interfaceMask = nicProps.UnicastAddresses[0].IPv4Mask;
                        foreach (UnicastIPAddressInformation unicastAddr in nicProps.UnicastAddresses)
                        {
                            if (unicastAddr.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                unicastAddresses.Add(unicastAddr.Address.ToString());
                            }
                        }
                    }
                }
            }

            // List of IPs her
        }
    }


}
