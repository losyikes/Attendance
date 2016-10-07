using System.Net;

namespace AttendanceLib
{
    public class User
    {
        public string IDMacAddress { get; set; }
        public IPAddress IPAddressStudent { get; set; }
        public int Userlevel { get; set; }
    }
}