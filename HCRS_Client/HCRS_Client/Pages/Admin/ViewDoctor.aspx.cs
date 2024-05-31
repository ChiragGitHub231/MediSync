using HCRS_Client.PatientServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class ViewDoctor : System.Web.UI.Page
    {
        DoctorServiceReference.DoctorServiceClient doctorServiceClient = new DoctorServiceReference.DoctorServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayDoctorDetails();
            }
        }

        protected void DisplayDoctorDetails()
        {
            // Retrieve the PatientId from the query string
            int doctorId = Convert.ToInt32(Request.QueryString["Id"]);

            DoctorServiceReference.Doctor user = new DoctorServiceReference.Doctor();

            user = doctorServiceClient.GetDoctorById(doctorId);

            txtName.Value = user.Name;
            txtExperience.Value = user.Experience.ToString();
            txtSpecialization.Value = user.Specialization.ToString();
            txtContact.Value = user.Contact_No.ToString();
            txtAddress.Value = user.Address.ToString();
            textEmail.Value = user.Email.ToString();

            if (user.Gender.Trim() == "Male")
            {
                male.Checked = true;
            }
            else if (user.Gender.Trim() == "Female")
            {
                female.Checked = true;
            }
        }
    }
}