using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HCRS_Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class PatientService : IPatientService
    {
        public bool Insert(Patient user)
        {
            bool isInserted = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO HCRS_DB.dbo.Patient_Info (Name, DOB, Gender, Age, Contact_No, Email, Address) VALUES (@Name, @DOB, @Gender, @Age, @Contact_No, @Email, @Address)", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@DOB", user.DOB);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@Age", user.Age);
            command.Parameters.AddWithValue("@Contact_No", user.Contact_No);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Address", user.Address);

            //  if Record Successfully Inserted then it returns 1
            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isInserted = true;
            }
            connection.Close();

            return isInserted;
        }

        public PatientData GetPatientData()
        {
            PatientData patientData = new PatientData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Patient_Info", connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable patientTable = new DataTable("patientTable");

            dataAdapter.Fill(patientTable);

            patientData.patientTable = patientTable;

            connection.Close();

            return patientData;
        }


        public Patient GetPatientById(int id)
        {
            Patient user = new Patient();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Patient_Info WHERE Patient_Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader sqlDataReader = command.ExecuteReader();

            if (sqlDataReader.Read())
            {
                user.Name = sqlDataReader["Name"].ToString();
                user.DOB = sqlDataReader["DOB"].ToString();
                user.Gender = (string)sqlDataReader["Gender"];
                user.Age = (int)sqlDataReader["Age"];
                user.Contact_No = sqlDataReader["Contact_No"].ToString();
                user.Email = sqlDataReader["Email"].ToString();
                user.Address = sqlDataReader["Address"].ToString();
            }
            connection.Close();

            return user;
        }

        
        public bool Update(int id, Patient user)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE HCRS_DB.dbo.Patient_Info SET Name=@Name, DOB=@DOB, Gender=@Gender, Age=@Age, Contact_No=@Contact_No, Email=@Email, Address=@Address WHERE Patient_Id=@Id", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@DOB", user.DOB);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@Age", user.Age);
            command.Parameters.AddWithValue("@Contact_No", user.Contact_No);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Address", user.Address);
            command.Parameters.AddWithValue("@Id", id);

            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isUpdated = true;
            }
            connection.Close();

            return isUpdated;
        }

        
        public bool Delete(int id)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM HCRS_DB.dbo.Patient_Info WHERE Patient_Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isDeleted = true;
            }
            connection.Close();

            return isDeleted;
        }


        public int GetPatientCount()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM HCRS_DB.dbo.Patient_Info", connection);

            count = (int)command.ExecuteScalar();

            connection.Close();

            return count;
        }


        public PatientData SearchPatientByName(string name)
        {
            PatientData patientData = new PatientData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Patient_Info WHERE Name LIKE @Name", connection);
            command.Parameters.AddWithValue("@Name", name + "%");

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable patientTable = new DataTable("patientTable");

            dataAdapter.Fill(patientTable);

            patientData.patientTable = patientTable;

            connection.Close();

            return patientData;
        }


        public PatientData SearchPatientByAddress(string address)
        {
            PatientData patientData = new PatientData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Patient_Info WHERE Address LIKE @Address", connection);
            command.Parameters.AddWithValue("@Address", "%" + address + "%");

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable patientTable = new DataTable("patientTable");

            dataAdapter.Fill(patientTable);

            patientData.patientTable = patientTable;

            connection.Close();

            return patientData;
        }


        public PatientData SearchPatientByDate(string firstDate, string lastDate)
        {
            PatientData patientData = new PatientData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Patient_Info WHERE DOB BETWEEN @firstDate AND @lastDate", connection);
            command.Parameters.AddWithValue("@firstDate", firstDate);
            command.Parameters.AddWithValue("@lastDate", lastDate);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable patientTable = new DataTable("patientTable");

            dataAdapter.Fill(patientTable);

            patientData.patientTable = patientTable;

            connection.Close();

            return patientData;
        }
    }


    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class DoctorService : IDoctorService
    {
        public bool Insert(Doctor user)
        {
            bool isInserted = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO HCRS_DB.dbo.Doctor_Info (Name, Specialization, Gender, Contact_No, Experience, Email, Address) VALUES (@Name, @Specialization, @Gender, @Contact_No, @Experience, @Email, @Address)", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Specialization", user.Specialization);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@Experience", user.Experience);
            command.Parameters.AddWithValue("@Contact_No", user.Contact_No);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Address", user.Address);

            //  if Record Successfully Inserted then it returns 1
            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isInserted = true;
            }
            connection.Close();

            return isInserted;
        }

        public DoctorData GetDoctorData()
        {
            DoctorData doctorData = new DoctorData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Doctor_Info", connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable doctorTable = new DataTable("doctorTable");

            dataAdapter.Fill(doctorTable);

            doctorData.doctorTable = doctorTable;

            connection.Close();

            return doctorData;
        }


        public Doctor GetDoctorById(int id)
        {
            Doctor user = new Doctor();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Doctor_Info WHERE Doctor_Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader sqlDataReader = command.ExecuteReader();

            if (sqlDataReader.Read())
            {
                user.Name = sqlDataReader["Name"].ToString();
                user.Specialization = sqlDataReader["Specialization"].ToString();
                user.Gender = (string)sqlDataReader["Gender"];
                user.Experience = (int)sqlDataReader["Experience"];
                user.Contact_No = sqlDataReader["Contact_No"].ToString();
                user.Email = sqlDataReader["Email"].ToString();
                user.Address = sqlDataReader["Address"].ToString();
            }
            connection.Close();

            return user;
        }


        public bool Update(int id, Doctor user)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE HCRS_DB.dbo.Doctor_Info SET Name=@Name, Specialization=@Specialization, Gender=@Gender, Address=@Address, Contact_No=@Contact_No, Email=@Email, Experience=@Experience WHERE Doctor_Id=@Id", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Specialization", user.Specialization);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@Address", user.Address);
            command.Parameters.AddWithValue("@Contact_No", user.Contact_No);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Experience", user.Experience);
            command.Parameters.AddWithValue("@Id", id);

            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isUpdated = true;
            }
            connection.Close();

            return isUpdated;
        }


        public bool Delete(int id)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM HCRS_DB.dbo.Doctor_Info WHERE Doctor_Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isDeleted = true;
            }
            connection.Close();

            return isDeleted;
        }


        public int GetDoctorCount()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM HCRS_DB.dbo.Doctor_Info", connection);

            count = (int)command.ExecuteScalar();

            connection.Close();

            return count;
        }


        public DoctorData SearchDoctorByName(string name)
        {
            DoctorData doctorData = new DoctorData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Doctor_Info WHERE Name LIKE @Name", connection);
            command.Parameters.AddWithValue("@Name", name + "%");

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable doctorTable = new DataTable("doctorTable");

            dataAdapter.Fill(doctorTable);

            doctorData.doctorTable = doctorTable;

            connection.Close();

            return doctorData;
        }


        public DoctorData SearchDoctorBySpecialization(string specialization)
        {
            DoctorData doctorData = new DoctorData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Doctor_Info WHERE Specialization LIKE @Specialization", connection);
            command.Parameters.AddWithValue("@Specialization", specialization + "%");

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable doctorTable = new DataTable("doctorTable");

            dataAdapter.Fill(doctorTable);

            doctorData.doctorTable = doctorTable;

            connection.Close();

            return doctorData;
        }


        public DoctorData SearchDoctorByExperience(string experience)
        {
            DoctorData doctorData = new DoctorData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Doctor_Info WHERE Experience >= @Experience", connection);
            command.Parameters.AddWithValue("@Experience", experience);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable doctorTable = new DataTable("doctorTable");

            dataAdapter.Fill(doctorTable);

            doctorData.doctorTable = doctorTable;

            connection.Close();

            return doctorData;
        }
    }


    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class AppointmentService : IAppointmentService
    {
        public bool Insert(Appointment appointment)
        {
            bool isInserted = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO HCRS_DB.dbo.Appointment_Info (Patient_Id, Doctor_Id, Date, Time) VALUES (@Patient_Id, @Doctor_Id, @Date, @Time)", connection);
            command.Parameters.AddWithValue("@Patient_Id", appointment.PatientId);
            command.Parameters.AddWithValue("@Doctor_Id", appointment.DoctorId);
            command.Parameters.AddWithValue("@Date", appointment.Date);
            command.Parameters.AddWithValue("@Time", appointment.Time);

            //  if Record Successfully Inserted then it returns 1
            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isInserted = true;
            }
            connection.Close();

            return isInserted;
        }

        public List<Appointment_Patient> GetAllPatients()
        {
            List<Appointment_Patient> patients = new List<Appointment_Patient>();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Patient_Info", connection);

            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Appointment_Patient appointment_Patient = new Appointment_Patient();
                appointment_Patient.PatientId = (int)sqlDataReader["Patient_Id"];
                appointment_Patient.PatientName = sqlDataReader["Name"].ToString();
                patients.Add(appointment_Patient);
            }

            connection.Close();

            return patients;
        }

        public List<Appointment_Doctor> GetAllDoctors()
        {
            List<Appointment_Doctor> doctors = new List<Appointment_Doctor>();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM HCRS_DB.dbo.Doctor_Info", connection);

            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Appointment_Doctor appointment_Doctor = new Appointment_Doctor();
                appointment_Doctor.DoctorId = (int)sqlDataReader["Doctor_Id"];
                appointment_Doctor.DoctorName = sqlDataReader["Name"].ToString();
                doctors.Add(appointment_Doctor);
            }

            connection.Close();

            return doctors;
        }

        public AppointmentData GetAppointmentData()
        {
            AppointmentData appointmentData = new AppointmentData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            string query = @"SELECT
                                A.Appointment_Id,
                                P.Name AS PatientName, 
                                D.Name AS DoctorName,
                                A.Date,
                                A.Time
                            FROM 
                                HCRS_DB.dbo.Appointment_Info A
                            INNER JOIN 
                                HCRS_DB.dbo.Patient_Info P ON A.Patient_Id = P.Patient_Id
                            INNER JOIN 
                                HCRS_DB.dbo.Doctor_Info D ON A.Doctor_Id = D.Doctor_Id";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable appointmentTable = new DataTable("appointmentTable");

            dataAdapter.Fill(appointmentTable);

            appointmentData.appointmentTable = appointmentTable;

            connection.Close();

            return appointmentData;
        }

        public AppointmentInfo GetAppointmentById(int id)
        {
            AppointmentInfo appointment = new AppointmentInfo();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            string query = @"SELECT
                                A.Appointment_Id,
                                P.Name AS PatientName, 
                                D.Name AS DoctorName,
                                A.Date,
                                A.Time
                            FROM 
                                HCRS_DB.dbo.Appointment_Info A
                            INNER JOIN 
                                HCRS_DB.dbo.Patient_Info P ON A.Patient_Id = P.Patient_Id
                            INNER JOIN 
                                HCRS_DB.dbo.Doctor_Info D ON A.Doctor_Id = D.Doctor_Id
                            WHERE
                                A.Appointment_Id = @Id";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader sqlDataReader = command.ExecuteReader();

            if (sqlDataReader.Read())
            {
                appointment.PatientName = sqlDataReader["PatientName"].ToString();
                appointment.DoctorName = sqlDataReader["DoctorName"].ToString();
                appointment.Date = sqlDataReader["Date"].ToString();
                appointment.Time = sqlDataReader["Time"].ToString();
            }
            connection.Close();

            return appointment;
        }

        public bool Update(int id, Appointment appointment)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE HCRS_DB.dbo.Appointment_Info SET Patient_Id=@Patient_Id, Doctor_Id=@Doctor_Id, Date=@Date, Time=@Time WHERE Appointment_Id=@Id", connection);
            command.Parameters.AddWithValue("@Patient_Id", appointment.PatientId);
            command.Parameters.AddWithValue("@Doctor_Id", appointment.DoctorId);
            command.Parameters.AddWithValue("@Date", appointment.Date);
            command.Parameters.AddWithValue("@Time", appointment.Time);
            command.Parameters.AddWithValue("@Id", id);

            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isUpdated = true;
            }
            connection.Close();

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM HCRS_DB.dbo.Appointment_Info WHERE Appointment_Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                isDeleted = true;
            }
            connection.Close();

            return isDeleted;
        }

        public int GetAppointmentCount()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM HCRS_DB.dbo.Appointment_Info", connection);

            count = (int)command.ExecuteScalar();

            connection.Close();

            return count;
        }


        public AppointmentData SearchAppointmentByPatientName(string patientName)
        {
            AppointmentData appointmentData = new AppointmentData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            string query = @"SELECT
                                A.Appointment_Id,
                                P.Name AS PatientName, 
                                D.Name AS DoctorName,
                                A.Date,
                                A.Time
                            FROM 
                                HCRS_DB.dbo.Appointment_Info A
                            INNER JOIN 
                                HCRS_DB.dbo.Patient_Info P ON A.Patient_Id = P.Patient_Id
                            INNER JOIN 
                                HCRS_DB.dbo.Doctor_Info D ON A.Doctor_Id = D.Doctor_Id
                            WHERE P.Name LIKE @PatientName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientName", patientName + "%");

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable appointmentTable = new DataTable("appointmentTable");

            dataAdapter.Fill(appointmentTable);

            appointmentData.appointmentTable = appointmentTable;

            connection.Close();

            return appointmentData;
        }

        public AppointmentData SearchAppointmentByDoctorName(string doctorName)
        {
            AppointmentData appointmentData = new AppointmentData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            string query = @"SELECT
                                A.Appointment_Id,
                                P.Name AS PatientName, 
                                D.Name AS DoctorName,
                                A.Date,
                                A.Time
                            FROM 
                                HCRS_DB.dbo.Appointment_Info A
                            INNER JOIN 
                                HCRS_DB.dbo.Patient_Info P ON A.Patient_Id = P.Patient_Id
                            INNER JOIN 
                                HCRS_DB.dbo.Doctor_Info D ON A.Doctor_Id = D.Doctor_Id
                            WHERE D.Name LIKE @DoctorName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DoctorName", doctorName + "%");

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable appointmentTable = new DataTable("appointmentTable");

            dataAdapter.Fill(appointmentTable);

            appointmentData.appointmentTable = appointmentTable;

            connection.Close();

            return appointmentData;
        }

        public AppointmentData SearchAppointmentByDate(string firstDate, string lastDate)
        {
            AppointmentData appointmentData = new AppointmentData();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SC563AA\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30");
            connection.Open();

            string query = @"SELECT
                                A.Appointment_Id,
                                P.Name AS PatientName, 
                                D.Name AS DoctorName,
                                A.Date,
                                A.Time
                            FROM 
                                HCRS_DB.dbo.Appointment_Info A
                            INNER JOIN 
                                HCRS_DB.dbo.Patient_Info P ON A.Patient_Id = P.Patient_Id
                            INNER JOIN 
                                HCRS_DB.dbo.Doctor_Info D ON A.Doctor_Id = D.Doctor_Id
                            WHERE A.Date BETWEEN @firstDate AND @lastDate";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstDate", firstDate);
            command.Parameters.AddWithValue("@lastDate", lastDate);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable appointmentTable = new DataTable("appointmentTable");

            dataAdapter.Fill(appointmentTable);

            appointmentData.appointmentTable = appointmentTable;

            connection.Close();

            return appointmentData;
        }
    }
}
