using System.Net;

namespace AttendanceLib
{
    public class Student : User
    {
        public bool Absent { get; set; }
        public Student(string mac)
        {
            IDMacAddress = mac;
            Userlevel = 1;
        }
    }
}