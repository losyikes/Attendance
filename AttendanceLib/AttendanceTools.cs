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
        
        persist dbStudents = new persist();
        IPAddress currentIp;
        string currentMac;
        
        
        public bool CheckAdminAccess()
        {
            //bool AdminAccess = false;
            //if (persist.currentUser.Userlevel == 2)
            //{
            //    AdminAccess = true;
            //}
            //return AdminAccess;
            return true;
        }
        public void LoginUser(string mac, IPAddress ip)
        {
            currentMac = mac;
            persist.currentMac = mac;
            currentIp = ip;
            if(persist.studentList.Find(x=>x.IDMacAddress == currentMac) != null)
            {
                persist.currentUser = persist.studentList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault();
                RegisterStudent();
            }
            else if(persist.teacherList.Find(x => x.IDMacAddress == currentMac) != null)
            {
                persist.currentUser = persist.teacherList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault();
            }
            persist.currentIp = ip;
        }
        public Type GetCurrentUserType()
        {
            return persist.currentUser.GetType();
        }
        public string GetCurrentUserTypeString()
        {
            return GetCurrentUserType().ToString();
        }
        public string ShowAttendanceStatus()
        {
            
            string attendanceText = "";
            if (IsValidIp(persist.currentIp.ToString()))
            {
                if (IsAttendanceSet())
                {
                    attendanceText = "logget ind på skolen";
                }
                else
                    attendanceText = "login er gået galt";
            }
            else
            {
                if (IsAttendanceSet())
                    attendanceText = "logget ind hjemmefra";
                else
                    attendanceText = "login er gået galt";
            }
            persist.menuLevel = 0;
            return attendanceText;
        }
        public void LoginTeacher()
        {
            persist.currentUser = persist.teacherList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault();
        }
        public string ShowAttendanceList()
        {
            if (CheckAdminAccess())
            {
                string attendanceString = "";
                int i = 0;
                foreach (Student student in persist.studentList)
                {
                    i++;
                    attendanceString += i.ToString() + ". " + student.Name + " " + "Mac: " + student.IDMacAddress + "\n";
                }
                return attendanceString;
            }
            return null;
        }
        public bool IsAttendanceSet()
        {
            try
            {
                if (persist.studentList.Where(x => x.IDMacAddress == persist.currentMac).FirstOrDefault().Absent == false)
                    return true;
                else
                    return false;
                
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsValidIp(string ip)
        {
            bool isValid = false;
            //public static bool IsLocalIpAddress(string host)
            string client = persist.currentIp.ToString();
            try
            { // get client IP addresses
                IPAddress[] clientIPs = Dns.GetHostAddresses(client);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                // test if any client IP equals to any local IP or to localhost
                foreach (IPAddress clientIP in clientIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(clientIP)) isValid = true;
                    // is local address
                    foreach (IPAddress localIP in localIPs)
                    {
                        if (clientIP.Equals(localIP)) isValid = true;
                        else isValid = false;
                    }
                }
            }
            catch { isValid = false; }
            return isValid;
            
            
        }
        public string ShowStartMenu()
        {
            
            if (GetCurrentUserType() == typeof(Teacher))
            {
                return ShowTeacherMenu();
            }
            else
            {
                return ShowAttendanceStatus();
            }
            
        }
        
        public void RegisterStudent()
        {
            Student student = persist.studentList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault();
            student.Absent = false;
        }
        public string ShowTeacherMenu()
        {
            
            string menu = "Please pick an option: \n\n";
            menu += "1. Show all students \n";
            menu += "2. Show present students \n";
            menu += "3. Show absent students \n";
            menu += "0. Exit";
            persist.menuLevel = 2;
            return menu;
        }
        public string ShowTeacherMenuChoice(int choice)
        {
            persist.menuLevel = 3;
            if (GetCurrentUserType() == typeof(Teacher))
            {
                switch (choice)
                {
                    case 0:
                        persist.menuLevel = 0;
                        return "exiting";
                    case 1:
                        return ShowStudents("all");
                    case 2:
                        return ShowStudents("present");
                    case 3:
                        return ShowStudents("absent");
                    default:
                        return "Invalid menu choice";
                }
            }
            else
                return "Goodbye";
            
        }
        public string ShowStudents(string status)
        {
            persist.menuLevel = 1;
            List<Student> studentsList;
            string showStudentList = "";
            if (status.ToLower() == "present")
                studentsList = persist.studentList.Where(x => x.Absent == false).ToList();
            else if(status.ToLower() == "absent")
                studentsList = persist.studentList.Where(x => x.Absent == true).ToList();
            else
                studentsList = persist.studentList;
            
            int i = 0;
            foreach (Student student in studentsList)
            {
                i++;
                showStudentList += i.ToString() + ". " + student.Name + " " + "Mac: " + student.IDMacAddress + "\n";
            }
            return showStudentList;
            
        }
        public void AddStudent(string macAddress, string name)
        {
            persist.studentList.Add(new Student(macAddress, name));
        }
        public void CreateFakeUser(string type, string macAdress)
        {
            if(type.ToLower() == "teacher")
            {
                persist.teacherList.Add(new Teacher(macAdress, "TestTeacher"));
            }
            else if(type.ToLower() == "student")
            {
                persist.studentList.Add(new Student(macAdress, "TestStudent"));
            }
        }
        public int GetMenuLevel()
        {
            return persist.menuLevel;
        }
        
    }
}
