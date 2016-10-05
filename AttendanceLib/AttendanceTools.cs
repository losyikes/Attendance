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
        bool IAttendanceTools.CheckAdminAccess()
        {
            throw new NotImplementedException();
        }

        string IAttendanceTools.LoginUser(PhysicalAddress mac, IPAddress ip)
        {
            throw new NotImplementedException();
        }

        List<Student> IAttendanceTools.ShowAttendance()
        {
            throw new NotImplementedException();
        }

        bool IAttendanceTools.UpdateAttendance()
        {
            throw new NotImplementedException();
        }

        bool IAttendanceTools.UpdateLocation()
        {
            throw new NotImplementedException();
        }
    }
}
