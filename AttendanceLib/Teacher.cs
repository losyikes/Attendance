using System.Net;

namespace AttendanceLib
{
    public class Teacher : User
    {
        public Teacher(string mac)
        {
            IDMacAddress = mac;
            Userlevel = 2;
        }
    }
}