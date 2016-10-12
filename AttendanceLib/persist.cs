using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace AttendanceLib
{
    public class persist
    {
        public static List<Student> studentList = new List<Student>();
        public static User currentUser;

        public persist()
        {

            // add the current PC to the registered userlist as a student
            string mac = string.Empty;
            bool keepGoing = true;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && keepGoing == true)
                {
                    mac += nic.GetPhysicalAddress().ToString();
                    keepGoing = false;
                }
            }
            studentList.Add(new Student(mac, "morten"));
            currentUser = studentList.Last();
        }
    }
}
