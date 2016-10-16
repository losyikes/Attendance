using Microsoft.VisualStudio.TestTools.UnitTesting;
using AttendanceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;

namespace AttendanceLib.Tests
{
    [TestClass()]
    public class AttendanceToolsTests
    {
        persist dbStudents = new persist();
        IPAddress currentIp;
        string currentMac;

        [TestMethod()]
        public void LoginUserTest(string mac, IPAddress ip)
        {
            //arrange
            currentMac = mac;
            currentIp = ip;

            //Act
            if (persist.studentList.Find(x => x.IDMacAddress == currentMac) != null)
            {
                //Assert
                persist.currentUser = persist.studentList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault();

                Assert.AreEqual(persist.currentUser, persist.studentList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault<Student>());
            }
            //Act
            else if (persist.teacherList.Find(x => x.IDMacAddress == currentMac) != null)
            {
                //Assert
                persist.currentUser = persist.teacherList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault();

                Assert.AreEqual(persist.currentUser, persist.teacherList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault<Teacher>());
            }

        }

        [TestMethod()]
        public string ShowAttendanceStatusTest()
        {
            string attendanceText = "";
            if (IsValidIpTest())
            {
                if (IsAttendanceSetTest())
                {
                    attendanceText = "logget ind på skolen";
                    Assert.IsNotNull(attendanceText);
                }
                else
                {
                    attendanceText = "login er gået galt";
                    Assert.IsNotNull(attendanceText);
                }

            }
            else
            {
                if (IsAttendanceSetTest())
                {
                    attendanceText = "logget ind hjemmefra";
                    Assert.IsNotNull(attendanceText);
                }

                else
                {
                    attendanceText = "login er gået galt";
                    Assert.IsNotNull(attendanceText);
                }


            }
            persist.menuLevel = 0;
            return attendanceText;
        }

        public Type GetCurrentUserTypeTest()
        {
            Assert.IsNotNull(persist.currentUser.GetType());
            return persist.currentUser.GetType();
        }

        [TestMethod()]
        public void LoginTeacherTest()
        {
            persist.currentUser = persist.teacherList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault();

            Assert.AreEqual(persist.currentUser, persist.teacherList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault<Teacher>());
        }

        [TestMethod()]
        public void ShowAttendanceListTest()
        {

            string attendanceString = "";
            int i = 0;
            foreach (Student student in persist.studentList)
            {
                i++;
                attendanceString += i.ToString() + ". " + student.Name + " " + "Mac: " + student.IDMacAddress + "\n";
            }
            Assert.IsNotNull(attendanceString);

        }

        [TestMethod()]
        public bool IsAttendanceSetTest()
        {
            try
            {
                bool absenceSet = false;
                for (int i = 0; i < persist.studentList.Count; i++)
                {
                    if (persist.studentList[i].IDMacAddress == currentMac)
                    {
                        persist.studentList[i].Absent = false;
                        persist.currentUser = persist.studentList[i];
                        absenceSet = true;

                        Assert.AreEqual(persist.currentUser, persist.studentList[i]);
                        Assert.IsTrue(absenceSet);

                    }
                }
                if (absenceSet)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        [TestMethod()]
        public bool IsValidIpTest()
        {
            //public static bool IsLocalIpAddress(string host)
            string client = currentIp.ToString();
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
                        Assert.AreEqual(clientIP, localIP);
                        if (clientIP.Equals(localIP)) { return true; }
                    }
                }
            }
            catch { }
            return false;
        }

        [TestMethod()]
        public string ShowStartMenuTest()
        {
            if (GetCurrentUserTypeTest() == typeof(Teacher))
            {
                return ShowTeacherMenuTest();
            }
            else
            {
                return ShowAttendanceStatusTest();
            }
        }

        [TestMethod()]
        public void RegisterStudentTest()
        {
            Student student = persist.studentList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault();
            Assert.AreEqual(student, persist.studentList.Where(x => x.IDMacAddress == currentMac).FirstOrDefault<Student>());

        }

        [TestMethod()]
        public string ShowTeacherMenuTest()
        {
            string menu = "Please pick an option: \n\n";
            menu += "1. Show all students \n";
            menu += "2. Show present students \n";
            menu += "3. Show absent students \n";
            menu += "0. Exit";
            persist.menuLevel = 2;

            Assert.IsNotNull(menu);
            return menu;
        }

        [TestMethod()]
        public string ShowTeacherMenuChoiceTest(int choice)
        {
            persist.menuLevel = 3;
            if (GetCurrentUserTypeTest() == typeof(Teacher))
            {
                switch (choice)
                {
                    case 0:
                        persist.menuLevel = 0;
                        return "exiting";
                    case 1:
                        return ShowStudentsTest("all");
                    case 2:
                        return ShowStudentsTest("present");
                    case 3:
                        return ShowStudentsTest("absent");
                    default:
                        return "Invalid menu choice";
                }
            }
            else
                return "Goodbye";
        }

        [TestMethod()]
        public string ShowStudentsTest(string status)
        {
            persist.menuLevel = 1;
            List<Student> studentsList;
            string showStudentList = "";
            if (status.ToLower() == "present")
                studentsList = persist.studentList.Where(x => x.Absent == false).ToList();
            else if (status.ToLower() == "absent")
                studentsList = persist.studentList.Where(x => x.Absent == true).ToList();
            else
                studentsList = persist.studentList;

            int i = 0;
            foreach (Student student in studentsList)
            {
                i++;
                showStudentList += i.ToString() + ". " + student.Name + " " + "Mac: " + student.IDMacAddress + "\n";
                Assert.IsNotNull(showStudentList);
            }
            return showStudentList;


        }

        [TestMethod()]
        public void AddStudentTest(string macAddress, string name)
        {
            persist.studentList.Add(new Student(macAddress, name));
            Assert.IsNotNull(persist.studentList.Where(x => x.IDMacAddress == macAddress && x.Name == name).FirstOrDefault<Student>());
        }

        [TestMethod()]
        public void CreateFakeUserTest(string type, string macAdress)
        {
            if (type.ToLower() == "teacher")
            {
                persist.teacherList.Add(new Teacher(macAdress, "TestTeacher"));
                Assert.IsNotNull(persist.teacherList.Where(x => x.IDMacAddress == macAdress && x.Name == "TestTeacher").FirstOrDefault<Teacher>());
            }
            else if (type.ToLower() == "student")
            {
                persist.studentList.Add(new Student(macAdress, "TestStudent"));
                Assert.IsNotNull(persist.studentList.Where(x => x.IDMacAddress == macAdress && x.Name == "TestStudent").FirstOrDefault<Student>());
            }
        }

        [TestMethod()]
        public int GetMenuLevelTest()
        {
            Assert.IsNotNull(persist.menuLevel);
            return persist.menuLevel;
        }
    }
}