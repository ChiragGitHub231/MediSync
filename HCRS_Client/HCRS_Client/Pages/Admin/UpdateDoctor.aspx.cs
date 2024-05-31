using HCRS_Client.PatientServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class UpdateDoctor : System.Web.UI.Page
    {
        DoctorServiceReference.DoctorServiceClient doctorServiceClient = new DoctorServiceReference.DoctorServiceClient();
        int doctorId;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the PatientId from the query string
            doctorId = Convert.ToInt32(Request.QueryString["Id"]);

            if (!IsPostBack)
            {
                DoctorServiceReference.Doctor user = new DoctorServiceReference.Doctor();
                user = doctorServiceClient.GetDoctorById(doctorId);

                txtName.Value = user.Name;
                txtSpecialization.Value = user.Specialization;
                txtExperience.Value = user.Experience.ToString();
                txtContact.Value = user.Contact_No.ToString();
                txtAddress.Value = user.Address.ToString();
                textEmail.Value = user.Email.ToString();
                
                if(user.Gender.Trim() == "Male")
                {
                    male.Checked = true;
                }
                else if(user.Gender.Trim() == "Female")
                {
                    female.Checked = true;
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            DoctorServiceReference.Doctor user = new DoctorServiceReference.Doctor();

            user.Name = txtName.Value;
            user.Experience = int.Parse(txtExperience.Value);
            user.Specialization = txtSpecialization.Value;
            user.Email = textEmail.Value;
            user.Contact_No = txtContact.Value;
            user.Address = txtAddress.Value;

            String Gender = "";
            if (male.Checked)
            {
                Gender = "Male";
            }
            else if (female.Checked)
            {
                Gender = "Female";
            }
            user.Gender = Gender;

            bool isUpdated = false;
            isUpdated = doctorServiceClient.Update(doctorId, user);

            if (isUpdated == true)
            {
                Response.Redirect("Doctors.aspx");
            }
        }
    }
}