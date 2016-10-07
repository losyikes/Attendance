using System.Net;

namespace AttendanceLib
{
    public class Student : User
    {
        public Student(string mac, IPAddress ip)
        {
            IDMacAddress = mac;
            IPAddressStudent = ip;
            Userlevel = 1;
        }
    }
}