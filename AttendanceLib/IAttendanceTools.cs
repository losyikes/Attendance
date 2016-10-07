using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace AttendanceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAttendanceTools" in both code and config file together.
    [ServiceContract]
    public interface IAttendanceTools
    {
        [OperationContract]
        string LoginUser(string mac, IPAddress ip);
        bool UpdateLocation(IPAddress ip);
        bool UpdateAttendance(string mac);
        bool CheckAdminAccess();
        [OperationContract]
        List<Student> ShowAttendance();
        
    }
}
