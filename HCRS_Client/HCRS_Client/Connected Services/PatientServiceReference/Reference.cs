﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCRS_Client.PatientServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Patient", Namespace="http://schemas.datacontract.org/2004/07/HCRS_Service")]
    [System.SerializableAttribute()]
    public partial class Patient : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Contact_NoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DOBField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contact_No {
            get {
                return this.Contact_NoField;
            }
            set {
                if ((object.ReferenceEquals(this.Contact_NoField, value) != true)) {
                    this.Contact_NoField = value;
                    this.RaisePropertyChanged("Contact_No");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DOB {
            get {
                return this.DOBField;
            }
            set {
                if ((object.ReferenceEquals(this.DOBField, value) != true)) {
                    this.DOBField = value;
                    this.RaisePropertyChanged("DOB");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PatientData", Namespace="http://schemas.datacontract.org/2004/07/HCRS_Service")]
    [System.SerializableAttribute()]
    public partial class PatientData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Data.DataTable patientTableField;
        
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
        public System.Data.DataTable patientTable {
            get {
                return this.patientTableField;
            }
            set {
                if ((object.ReferenceEquals(this.patientTableField, value) != true)) {
                    this.patientTableField = value;
                    this.RaisePropertyChanged("patientTable");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PatientServiceReference.IPatientService")]
    public interface IPatientService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/Insert", ReplyAction="http://tempuri.org/IPatientService/InsertResponse")]
        bool Insert(HCRS_Client.PatientServiceReference.Patient user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/Insert", ReplyAction="http://tempuri.org/IPatientService/InsertResponse")]
        System.Threading.Tasks.Task<bool> InsertAsync(HCRS_Client.PatientServiceReference.Patient user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/GetPatientData", ReplyAction="http://tempuri.org/IPatientService/GetPatientDataResponse")]
        HCRS_Client.PatientServiceReference.PatientData GetPatientData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/GetPatientData", ReplyAction="http://tempuri.org/IPatientService/GetPatientDataResponse")]
        System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.PatientData> GetPatientDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/GetPatientById", ReplyAction="http://tempuri.org/IPatientService/GetPatientByIdResponse")]
        HCRS_Client.PatientServiceReference.Patient GetPatientById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/GetPatientById", ReplyAction="http://tempuri.org/IPatientService/GetPatientByIdResponse")]
        System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.Patient> GetPatientByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/Update", ReplyAction="http://tempuri.org/IPatientService/UpdateResponse")]
        bool Update(int id, HCRS_Client.PatientServiceReference.Patient user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/Update", ReplyAction="http://tempuri.org/IPatientService/UpdateResponse")]
        System.Threading.Tasks.Task<bool> UpdateAsync(int id, HCRS_Client.PatientServiceReference.Patient user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/Delete", ReplyAction="http://tempuri.org/IPatientService/DeleteResponse")]
        bool Delete(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/Delete", ReplyAction="http://tempuri.org/IPatientService/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/GetPatientCount", ReplyAction="http://tempuri.org/IPatientService/GetPatientCountResponse")]
        int GetPatientCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/GetPatientCount", ReplyAction="http://tempuri.org/IPatientService/GetPatientCountResponse")]
        System.Threading.Tasks.Task<int> GetPatientCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/SearchPatientByName", ReplyAction="http://tempuri.org/IPatientService/SearchPatientByNameResponse")]
        HCRS_Client.PatientServiceReference.PatientData SearchPatientByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/SearchPatientByName", ReplyAction="http://tempuri.org/IPatientService/SearchPatientByNameResponse")]
        System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.PatientData> SearchPatientByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/SearchPatientByAddress", ReplyAction="http://tempuri.org/IPatientService/SearchPatientByAddressResponse")]
        HCRS_Client.PatientServiceReference.PatientData SearchPatientByAddress(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/SearchPatientByAddress", ReplyAction="http://tempuri.org/IPatientService/SearchPatientByAddressResponse")]
        System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.PatientData> SearchPatientByAddressAsync(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/SearchPatientByDate", ReplyAction="http://tempuri.org/IPatientService/SearchPatientByDateResponse")]
        HCRS_Client.PatientServiceReference.PatientData SearchPatientByDate(string firstDate, string lastDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPatientService/SearchPatientByDate", ReplyAction="http://tempuri.org/IPatientService/SearchPatientByDateResponse")]
        System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.PatientData> SearchPatientByDateAsync(string firstDate, string lastDate);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPatientServiceChannel : HCRS_Client.PatientServiceReference.IPatientService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PatientServiceClient : System.ServiceModel.ClientBase<HCRS_Client.PatientServiceReference.IPatientService>, HCRS_Client.PatientServiceReference.IPatientService {
        
        public PatientServiceClient() {
        }
        
        public PatientServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PatientServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PatientServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PatientServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Insert(HCRS_Client.PatientServiceReference.Patient user) {
            return base.Channel.Insert(user);
        }
        
        public System.Threading.Tasks.Task<bool> InsertAsync(HCRS_Client.PatientServiceReference.Patient user) {
            return base.Channel.InsertAsync(user);
        }
        
        public HCRS_Client.PatientServiceReference.PatientData GetPatientData() {
            return base.Channel.GetPatientData();
        }
        
        public System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.PatientData> GetPatientDataAsync() {
            return base.Channel.GetPatientDataAsync();
        }
        
        public HCRS_Client.PatientServiceReference.Patient GetPatientById(int id) {
            return base.Channel.GetPatientById(id);
        }
        
        public System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.Patient> GetPatientByIdAsync(int id) {
            return base.Channel.GetPatientByIdAsync(id);
        }
        
        public bool Update(int id, HCRS_Client.PatientServiceReference.Patient user) {
            return base.Channel.Update(id, user);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAsync(int id, HCRS_Client.PatientServiceReference.Patient user) {
            return base.Channel.UpdateAsync(id, user);
        }
        
        public bool Delete(int id) {
            return base.Channel.Delete(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int id) {
            return base.Channel.DeleteAsync(id);
        }
        
        public int GetPatientCount() {
            return base.Channel.GetPatientCount();
        }
        
        public System.Threading.Tasks.Task<int> GetPatientCountAsync() {
            return base.Channel.GetPatientCountAsync();
        }
        
        public HCRS_Client.PatientServiceReference.PatientData SearchPatientByName(string name) {
            return base.Channel.SearchPatientByName(name);
        }
        
        public System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.PatientData> SearchPatientByNameAsync(string name) {
            return base.Channel.SearchPatientByNameAsync(name);
        }
        
        public HCRS_Client.PatientServiceReference.PatientData SearchPatientByAddress(string address) {
            return base.Channel.SearchPatientByAddress(address);
        }
        
        public System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.PatientData> SearchPatientByAddressAsync(string address) {
            return base.Channel.SearchPatientByAddressAsync(address);
        }
        
        public HCRS_Client.PatientServiceReference.PatientData SearchPatientByDate(string firstDate, string lastDate) {
            return base.Channel.SearchPatientByDate(firstDate, lastDate);
        }
        
        public System.Threading.Tasks.Task<HCRS_Client.PatientServiceReference.PatientData> SearchPatientByDateAsync(string firstDate, string lastDate) {
            return base.Channel.SearchPatientByDateAsync(firstDate, lastDate);
        }
    }
}
