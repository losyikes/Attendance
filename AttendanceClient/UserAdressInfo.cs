using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace AttendanceClient
{
    class UserAdressInfo
    {
        public IPAddress GetLocalIPAddress()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
        public string GetMacAddresse()
        {
            return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress()).FirstOrDefault().ToString();
        }
    }
}
