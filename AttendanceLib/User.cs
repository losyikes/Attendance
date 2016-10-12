using System.Net;
using System.ServiceModel;
using System.Runtime.Serialization;
using System;

namespace AttendanceLib
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string IDMacAddress { get; set; }
        [DataMember]
        public int Userlevel { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}