using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HCRS_Service
{
    [DataContract]
    public class Patient
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string DOB { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Contact_No { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Address { get; set; }
    }

    [DataContract]
    public class Doctor
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Specialization { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public int Experience { get; set; }

        [DataMember]
        public string Contact_No { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Address { get; set; }
    }

    [DataContract]
    public class Appointment
    {
        [DataMember]
        public int PatientId { get; set; }

        [DataMember]
        public int DoctorId { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string Time { get; set; }
    }

    [DataContract]
    public class Appointment_Patient
    {
        [DataMember]
        public int PatientId { get; set; }

        [DataMember]
        public string PatientName { get; set; }
    }

    [DataContract]
    public class Appointment_Doctor
    {
        [DataMember]
        public int DoctorId { get; set; }

        [DataMember]
        public string DoctorName { get; set; }
    }

    [DataContract]
    public class AppointmentInfo
    {
        [DataMember]
        public string PatientName { get; set; }

        [DataMember]
        public string DoctorName { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string Time { get; set; }
    }
}
