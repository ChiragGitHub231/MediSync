using HCRS_Client.PatientServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class Home : System.Web.UI.Page
    {
        PatientServiceReference.PatientServiceClient PatientServiceClient = new PatientServiceReference.PatientServiceClient();
        DoctorServiceReference.DoctorServiceClient doctorServiceClient = new DoctorServiceReference.DoctorServiceClient();
        AppointmentServiceReference.AppointmentServiceClient appointmentServiceClient = new AppointmentServiceReference.AppointmentServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int patientCount = 0, doctorCount = 0, appointmentCount = 0;

            patientCount = PatientServiceClient.GetPatientCount();
            doctorCount = doctorServiceClient.GetDoctorCount();
            appointmentCount = appointmentServiceClient.GetAppointmentCount();

            PatientCount.Text = patientCount.ToString();
            DoctorCount.Text = doctorCount.ToString();
            AppointmentCount.Text = appointmentCount.ToString();

            DisplayPatientDetails();

            DisplayDoctorDetails();

            DisplayAppointmentDetails();
        }

        protected void DisplayPatientDetails()
        {
            PatientServiceReference.PatientData patientData = new PatientServiceReference.PatientData();

            patientData = PatientServiceClient.GetPatientData();

            DataTable patientTable = new DataTable();

            patientTable = patientData.patientTable;

            // Select only the first 3 rows
            DataTable limitedPatientTable = patientTable.AsEnumerable().Take(3).CopyToDataTable();

            PatientGridView.DataSource = limitedPatientTable;
            PatientGridView.DataBind();


            // Change the column name
            if (PatientGridView.HeaderRow != null)
            {
                PatientGridView.HeaderRow.Cells[3].Text = "Id";
                PatientGridView.HeaderRow.Cells[5].Text = "Date of Birth";
                PatientGridView.HeaderRow.Cells[8].Text = "Contact No";
                PatientGridView.HeaderRow.Cells[9].Text = "Email Id";
            }
        }

        protected void DisplayDoctorDetails()
        {
            DoctorServiceReference.DoctorData doctorData = new DoctorServiceReference.DoctorData();

            doctorData = doctorServiceClient.GetDoctorData();

            DataTable doctorTable = new DataTable();

            doctorTable = doctorData.doctorTable;

            // Select only the first 3 rows
            DataTable limitedDoctorTable = doctorTable.AsEnumerable().Take(3).CopyToDataTable();

            DoctorGridView.DataSource = limitedDoctorTable;
            DoctorGridView.DataBind();

            // Change the column name
            if (DoctorGridView.HeaderRow != null)
            {
                DoctorGridView.HeaderRow.Cells[3].Text = "Id";
                DoctorGridView.HeaderRow.Cells[6].Text = "Contact No";
                DoctorGridView.HeaderRow.Cells[7].Text = "Email Id";
            }
        }

        protected void DisplayAppointmentDetails()
        {
            AppointmentServiceReference.AppointmentData appointmentData = new AppointmentServiceReference.AppointmentData();

            appointmentData = appointmentServiceClient.GetAppointmentData();

            DataTable appointmentTable = appointmentTable = appointmentData.appointmentTable;

            if (appointmentTable.Rows.Count > 0)
            {
                // Select only the first 3 rows
                DataTable limitedAppointmentTable = appointmentTable.AsEnumerable().Take(3).CopyToDataTable();

                AppointmentGridView.DataSource = limitedAppointmentTable;
            }
            else
            {
                AppointmentGridView.DataSource = appointmentTable;
            }

            AppointmentGridView.DataBind();

            // Change the column name
            if (AppointmentGridView.HeaderRow != null)
            {
                AppointmentGridView.HeaderRow.Cells[3].Text = "Id";
                AppointmentGridView.HeaderRow.Cells[4].Text = "Patient Name";
                AppointmentGridView.HeaderRow.Cells[5].Text = "Doctor Name";
            }
        }
    }
}