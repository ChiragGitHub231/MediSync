using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HCRS_Service
{
    [ServiceContract]
    public interface IPatientService
    {
        [OperationContract]
        bool Insert(Patient user);

        [OperationContract]
        PatientData GetPatientData();

        [OperationContract]
        Patient GetPatientById(int id);

        [OperationContract]
        bool Update(int id, Patient user);

        [OperationContract]
        bool Delete(int id);

        [OperationContract]
        int GetPatientCount();

        [OperationContract]
        PatientData SearchPatientByName(string name);

        [OperationContract]
        PatientData SearchPatientByAddress(string address);

        [OperationContract]
        PatientData SearchPatientByDate(string firstDate, string lastDate);
    }

    [DataContract]
    public class PatientData
    {
        [DataMember]
        public DataTable patientTable { get; set; }
    }


    [ServiceContract]
    public interface IDoctorService
    {
        [OperationContract]
        bool Insert(Doctor user);

        [OperationContract]
        DoctorData GetDoctorData();

        [OperationContract]
        Doctor GetDoctorById(int id);

        [OperationContract]
        bool Update(int id, Doctor user);

        [OperationContract]
        bool Delete(int id);

        [OperationContract]
        int GetDoctorCount();

        [OperationContract]
        DoctorData SearchDoctorByName(string name);

        [OperationContract]
        DoctorData SearchDoctorBySpecialization(string specialization);

        [OperationContract]
        DoctorData SearchDoctorByExperience(string experience);
    }

    [DataContract]
    public class DoctorData
    {
        [DataMember]
        public DataTable doctorTable { get; set; }
    }


    [ServiceContract]
    public interface IAppointmentService
    {
        [OperationContract]
        bool Insert(Appointment appointment);

        [OperationContract]
        List<Appointment_Patient> GetAllPatients();

        [OperationContract]
        List<Appointment_Doctor> GetAllDoctors();

        [OperationContract]
        AppointmentData GetAppointmentData();

        [OperationContract]
        AppointmentInfo GetAppointmentById(int id);

        [OperationContract]
        bool Update(int id, Appointment appointment);

        [OperationContract]
        bool Delete(int id);

        [OperationContract]
        int GetAppointmentCount();

        [OperationContract]
        AppointmentData SearchAppointmentByPatientName(string patientName);

        [OperationContract]
        AppointmentData SearchAppointmentByDoctorName(string doctorName);

        [OperationContract]
        AppointmentData SearchAppointmentByDate(string firstDate, string lastDate);
    }

    [DataContract]
    public class AppointmentData
    {
        [DataMember]
        public DataTable appointmentTable { get; set; }
    }
}
