using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceClient.ServiceReference1;
using AttendanceClient.ServiceReference2;


namespace AttendanceClient
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            EchoServiceClient client = new EchoServiceClient();
            AttendanceToolsClient toolClient = new AttendanceToolsClient();
            //foreach(var Item in toolClient.ShowAttendance())
            //{
            //    Console.WriteLine(Item.IDMacAddress);
            //}
            Console.WriteLine(client.EchoString("hello world"));
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
            client.Close();
        }
    }
}
