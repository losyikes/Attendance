﻿using System.Net;
using System.ServiceModel;
using System.Runtime.Serialization;
using System;

namespace AttendanceLib
{
    [DataContract]
    public class Student : User
    {
        [DataMember]
        public bool Absent { get; set; }
        
        public Student(string mac)
        {
            IDMacAddress = mac;
            Userlevel = 1;
        }
    }
}