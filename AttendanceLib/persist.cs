using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace AttendanceLib
{
    public class persist
    {
        public static List<Student> studentList = new List<Student>();
        public static List<Teacher> teacherList = new List<Teacher>();
        public static int menuLevel = 1;
        public static User currentUser;

        public persist()
        {

            // add the current PC to the registered userlist as a student
            //string mac = string.Empty;
            //bool keepGoing = true;
            //foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            //{
            //    if (nic.OperationalStatus == OperationalStatus.Up && keepGoing == true)
            //    {
            //        mac += nic.GetPhysicalAddress().ToString();
            //        keepGoing = false;
            //    }
            //}
            //studentList.Add(new Student(mac, "morten"));
            fillLists();
            //currentUser = studentList.Last();
        }
        void fillLists()
        {
            List<Student> fillStudentList = new List<Student>();
            //studentList.Add(new Student("94DE80AE5E85", "MortenStudent"));
            fillStudentList.Add(new Student("94DE80AE5E86", "PeterStudent") { Absent = true });
            fillStudentList.Add(new Student("94DE80AE5E87", "AndersStudent") { Absent = false });
            fillStudentList.Add(new Student("94DE80AE5E88", "JensStudent") { Absent = true });
            fillStudentList.Add(new Student("94DE80AE5E89", "SørenStudent") { Absent = false });
            fillStudentList.Add(new Student("94DE80AE5E90", "KeldStudent") { Absent = false });
            fillStudentList.Add(new Student("94DE80AE5E91", "MogenStudent") { Absent = true });
            if(studentList.Count == 0)
            {
                studentList = fillStudentList;
            }
            
            List<Teacher> fillTeacherList = new List<Teacher>();
            fillTeacherList.Add(new Teacher("94DE80AE5E92", "MortenTeacher"));
            if(teacherList.Count == 0)
            {
                teacherList = fillTeacherList;
            }
            
        }
       
    }
}
