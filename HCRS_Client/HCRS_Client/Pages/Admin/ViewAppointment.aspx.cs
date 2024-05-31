using HCRS_Client.AppointmentServiceReference;
using HCRS_Client.PatientServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HCRS_Client.Pages.Admin
{
    public partial class ViewAppointment : System.Web.UI.Page
    {
        AppointmentServiceReference.AppointmentServiceClient appointmentServiceClient = new AppointmentServiceReference.AppointmentServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulatePatientDropdown();

                PopulateDoctorDropdown();

                // Retrieve the PatientId from the query string
                int appointmentId = Convert.ToInt32(Request.QueryString["Id"]);

                AppointmentServiceReference.AppointmentInfo appointmentInfo = new AppointmentServiceReference.AppointmentInfo();

                appointmentInfo = appointmentServiceClient.GetAppointmentById(appointmentId);

                // Select the patient in the DropDownList
                foreach (ListItem item in ddlPatientName.Items)
                {
                    if (item.Text.Trim() == appointmentInfo.PatientName.Trim())
                    {
                        item.Selected = true;
                        break;
                    }
                }

                // Select the doctor in the DropDownList
                foreach (ListItem item in ddlDoctorName.Items)
                {
                    if (item.Text.Trim() == appointmentInfo.DoctorName.Trim())
                    {
                        item.Selected = true;
                        break;
                    }
                }

                txtDate.Value = DateTime.Parse(appointmentInfo.Date).ToString("yyyy-MM-dd");
                txtTime.Value = DateTime.Parse(appointmentInfo.Time).ToString("HH:mm");
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
    }
}