using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace AttendanceLib
{
    class persist
    {
        public static List<Student> studentList = new List<Student>();

        public persist()
        {

            // add the current PC to the registered userlist as a student
            string mac = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    mac += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            studentList.Add(new Student(mac));
        }
    }
}
