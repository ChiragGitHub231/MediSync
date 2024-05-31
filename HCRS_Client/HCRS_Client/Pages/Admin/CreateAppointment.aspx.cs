using HCRS_Client.AppointmentServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class CreateAppointment : System.Web.UI.Page
    {
        AppointmentServiceClient appointmentServiceClient = new AppointmentServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Ensure dropdown list is only populated on initial page load
            {
                PopulatePatientDropdown();

                PopulateDoctorDropdown();
            }
        }

        protected void PopulatePatientDropdown()
        {
            List<AppointmentServiceReference.Appointment_Patient> patients = new List<Appointment_Patient>();

            patients = appointmentServiceClient.GetAllPatients().ToList();

            // Clear existing items in dropdown list
            ddlPatientName.Items.Clear();

            // Add a default "Select Patient" option
            ddlPatientName.Items.Add(new ListItem("Select Patient", ""));

            // Iterate over the list of patients and add each patient's name to the dropdown list
            foreach (var patient in patients)
            {
                ddlPatientName.Items.Add(new ListItem(patient.PatientName, patient.PatientId.ToString()));
            }
        }

        protected void PopulateDoctorDropdown()
        {
            List<AppointmentServiceReference.Appointment_Doctor> doctors = new List<Appointment_Doctor>();

            doctors = appointmentServiceClient.GetAllDoctors().ToList();

            // Clear existing items in dropdown list
            ddlDoctorName.Items.Clear();

            // Add a default "Select Patient" option
            ddlDoctorName.Items.Add(new ListItem("Select Doctor", ""));

            // Iterate over the list of patients and add each patient's name to the dropdown list
            foreach (var doctor in doctors)
            {
                ddlDoctorName.Items.Add(new ListItem(doctor.DoctorName, doctor.DoctorId.ToString()));
            }
        }


        protected void createBtn_Click(object sender, EventArgs e)
        {
            AppointmentServiceReference.Appointment appointment = new AppointmentServiceReference.Appointment();

            ListItem selectedPatient = ddlPatientName.SelectedItem;
            ListItem selectedDoctor = ddlDoctorName.SelectedItem;

            appointment.PatientId = int.Parse(selectedPatient.Value);
            appointment.DoctorId = int.Parse(selectedDoctor.Value);
            appointment.Date = txtDate.Value;
            appointment.Time = txtTime.Value;

            bool isInserted = false;
            isInserted = appointmentServiceClient.Insert(appointment);

            if(isInserted == true)
            {
                Response.Redirect("Appointments.aspx");
            }
        }
    }
}