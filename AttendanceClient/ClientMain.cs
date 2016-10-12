using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceClient.ServiceReference1;
using AttendanceClient.ServiceReference2;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;


namespace AttendanceClient
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            ClientMain cm = new ClientMain();
            cm.Run();
            //EchoServiceClient client = new EchoServiceClient();
            
            //Console.WriteLine(client.EchoString("hello world"));
            
        }
        void Run()
        {
            AttendanceToolsClient toolClient = new AttendanceToolsClient();
            toolClient.LoginUser(GetMacAddresse(), GetLocalIPAddress());
            Console.WriteLine(toolClient.ShowAttendanceList());
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
            toolClient.Close();
        }
        IPAddress GetLocalIPAddress()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
        string GetMacAddresse()
        {
            return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress()).FirstOrDefault().ToString();
        }
    }
}
