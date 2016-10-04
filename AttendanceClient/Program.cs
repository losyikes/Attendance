using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceClient.ServiceReference1;

namespace AttendanceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EchoServiceClient client = new EchoServiceClient();
            Console.WriteLine(client.EchoString("hello world"));
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
            client.Close();
        }
    }
}
