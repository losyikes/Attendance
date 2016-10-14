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
        void LoginUser(string mac, IPAddress ip);
        [OperationContract]
        Type GetCurrentUserType();
        [OperationContract]
        string GetCurrentUserTypeString();
        [OperationContract]
        string ShowAttendanceStatus();
        [OperationContract]
        void LoginTeacher();
        bool IsValidIp(string ip);
        [OperationContract]
        bool IsAttendanceSet();
        [OperationContract]
        bool CheckAdminAccess();
        [OperationContract]
        string ShowAttendanceList();
        [OperationContract]
        string ShowStartMenu();
       
        [OperationContract]
        void RegisterStudent();
        [OperationContract]
        string ShowTeacherMenu();
        [OperationContract]
        string ShowTeacherMenuChoice(int choice);
        [OperationContract]
        string ShowStudents(string status);
        [OperationContract]
        void AddStudent(string macAddress, string name);
        [OperationContract]
        void CreateFakeUser(string type, string macAddress);
        [OperationContract]
        int GetMenuLevel();
        
    }
}
