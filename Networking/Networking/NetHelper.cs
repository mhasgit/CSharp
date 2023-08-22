using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    internal class NetHelper
    {
        /*
         * Class A   (byte 1) 1-126 approx 16M devices
         * Class B   (byte 1) 128-191 approx 65535 devices
         * Class C   (byte 1) 192-223 approx 254 devices
         * Class D   (byte 1) 224-239 Multicast ip addresses
         * Class E   (byte 1) 240-255 Uses for Testing
         */

        /*
         * Private Ip addresses is for LAN
         * 
         * Class A private ip is 10
         * Class B 172.16-172.31
         * Class C 192.168.0-192.168.255
         */
    }
}
