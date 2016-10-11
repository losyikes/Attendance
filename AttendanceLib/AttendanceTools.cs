using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AttendanceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AttendanceTools" in both code and config file together.
    public class AttendanceTools : IAttendanceTools
    {
        
        public bool CheckAdminAccess()
        {
            bool AdminAccess = false;
            if (persist.currentUser.Userlevel == 2)
            {
                AdminAccess = true;
            }
            return AdminAccess;
        }

        public string LoginUser(string mac, IPAddress ip)
        {
            if (UpdateLocation(ip))
            {
                if (UpdateAttendance(mac))
                {
                    return "logget ind på skolen";
                }
                else
                {
                    return "login er gået galt";
                }
            }
            else
            {
                if (UpdateAttendance(mac))
                {
                    return "logget ind hjemmefra";
                }
                else
                {
                    return "login er gået galt";
                }
            }
        }

        public List<Student> ShowAttendance()
        {
            if (CheckAdminAccess())
            {
                return persist.studentList;
            }
            return null;
        }

        public bool UpdateAttendance(string mac)
        {
            try
            {
                bool absenceSet = false;
                for (int i = 0; i < persist.studentList.Count; i++)
                {
                    if (persist.studentList[i].IDMacAddress == mac)
                    {
                        persist.studentList[i].Absent = false;
                        persist.currentUser = persist.studentList[i];
                        absenceSet = true;
                    }
                }
                if (absenceSet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateLocation(IPAddress ip)
        {
            //public static bool IsLocalIpAddress(string host)
            string client = ip.ToString();
            try
            { // get client IP addresses
                IPAddress[] clientIPs = Dns.GetHostAddresses(client);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                // test if any client IP equals to any local IP or to localhost
                foreach (IPAddress clientIP in clientIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(clientIP)) return true;
                    // is local address
                    foreach (IPAddress localIP in localIPs)
                    {
                        if (clientIP.Equals(localIP)) return true;
                    }
                }
            }
            catch { }
            return false;
        }
    }
}
