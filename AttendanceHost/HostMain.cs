using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using AttendanceLib;
using System.ServiceModel.Description;

namespace AttendanceHost
{
    class HostMain
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/AttendanceLib/");

            ServiceHost selfHost2 = new ServiceHost(typeof(AttendanceTools), baseAddress);


            try
            {
                // Step 3 Add a service endpoint.
                selfHost2.AddServiceEndpoint(typeof(IAttendanceTools), new WSHttpBinding(), "AttendanceTools");

                //Step 4 Enable metadata exchange.

                ServiceMetadataBehavior smb2 = new ServiceMetadataBehavior();
                smb2.HttpGetEnabled = true;
                selfHost2.Description.Behaviors.Add(smb2);

                // Step 5 Start the service.
                //selfHost.Open();
                selfHost2.Open();

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.

                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
