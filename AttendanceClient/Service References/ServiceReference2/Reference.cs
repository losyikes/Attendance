﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AttendanceClient.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Student", Namespace="http://schemas.datacontract.org/2004/07/AttendanceLib")]
    [System.SerializableAttribute()]
    public partial class Student : AttendanceClient.ServiceReference2.User {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AbsentField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Absent {
            get {
                return this.AbsentField;
            }
            set {
                if ((this.AbsentField.Equals(value) != true)) {
                    this.AbsentField = value;
                    this.RaisePropertyChanged("Absent");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/AttendanceLib")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AttendanceClient.ServiceReference2.Student))]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDMacAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserlevelField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IDMacAddress {
            get {
                return this.IDMacAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.IDMacAddressField, value) != true)) {
                    this.IDMacAddressField = value;
                    this.RaisePropertyChanged("IDMacAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Userlevel {
            get {
                return this.UserlevelField;
            }
            set {
                if ((this.UserlevelField.Equals(value) != true)) {
                    this.UserlevelField = value;
                    this.RaisePropertyChanged("Userlevel");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IAttendanceTools")]
    public interface IAttendanceTools {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAttendanceTools/LoginUser", ReplyAction="http://tempuri.org/IAttendanceTools/LoginUserResponse")]
        string LoginUser(string mac, System.Net.IPAddress ip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAttendanceTools/LoginUser", ReplyAction="http://tempuri.org/IAttendanceTools/LoginUserResponse")]
        System.Threading.Tasks.Task<string> LoginUserAsync(string mac, System.Net.IPAddress ip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAttendanceTools/UpdateAttendance", ReplyAction="http://tempuri.org/IAttendanceTools/UpdateAttendanceResponse")]
        bool UpdateAttendance(string mac);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAttendanceTools/UpdateAttendance", ReplyAction="http://tempuri.org/IAttendanceTools/UpdateAttendanceResponse")]
        System.Threading.Tasks.Task<bool> UpdateAttendanceAsync(string mac);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAttendanceTools/CheckAdminAccess", ReplyAction="http://tempuri.org/IAttendanceTools/CheckAdminAccessResponse")]
        bool CheckAdminAccess();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAttendanceTools/CheckAdminAccess", ReplyAction="http://tempuri.org/IAttendanceTools/CheckAdminAccessResponse")]
        System.Threading.Tasks.Task<bool> CheckAdminAccessAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAttendanceTools/ShowAttendance", ReplyAction="http://tempuri.org/IAttendanceTools/ShowAttendanceResponse")]
        AttendanceClient.ServiceReference2.Student[] ShowAttendance();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAttendanceTools/ShowAttendance", ReplyAction="http://tempuri.org/IAttendanceTools/ShowAttendanceResponse")]
        System.Threading.Tasks.Task<AttendanceClient.ServiceReference2.Student[]> ShowAttendanceAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAttendanceToolsChannel : AttendanceClient.ServiceReference2.IAttendanceTools, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AttendanceToolsClient : System.ServiceModel.ClientBase<AttendanceClient.ServiceReference2.IAttendanceTools>, AttendanceClient.ServiceReference2.IAttendanceTools {
        
        public AttendanceToolsClient() {
        }
        
        public AttendanceToolsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AttendanceToolsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AttendanceToolsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AttendanceToolsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string LoginUser(string mac, System.Net.IPAddress ip) {
            return base.Channel.LoginUser(mac, ip);
        }
        
        public System.Threading.Tasks.Task<string> LoginUserAsync(string mac, System.Net.IPAddress ip) {
            return base.Channel.LoginUserAsync(mac, ip);
        }
        
        public bool UpdateAttendance(string mac) {
            return base.Channel.UpdateAttendance(mac);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAttendanceAsync(string mac) {
            return base.Channel.UpdateAttendanceAsync(mac);
        }
        
        public bool CheckAdminAccess() {
            return base.Channel.CheckAdminAccess();
        }
        
        public System.Threading.Tasks.Task<bool> CheckAdminAccessAsync() {
            return base.Channel.CheckAdminAccessAsync();
        }
        
        public AttendanceClient.ServiceReference2.Student[] ShowAttendance() {
            return base.Channel.ShowAttendance();
        }
        
        public System.Threading.Tasks.Task<AttendanceClient.ServiceReference2.Student[]> ShowAttendanceAsync() {
            return base.Channel.ShowAttendanceAsync();
        }
    }
}
