using System.Net;

namespace AttendanceLib
{
    public class Teacher : User
    {
        public Teacher(string mac, string name)
        {
            IDMacAddress = mac;
            Userlevel = 2;
            Name = name;
        }
    }
}