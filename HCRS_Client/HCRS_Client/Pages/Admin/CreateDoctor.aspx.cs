using HCRS_Client.PatientServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class CreateDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DoctorServiceReference.DoctorServiceClient doctorServiceClient = new DoctorServiceReference.DoctorServiceClient();
        protected void createBtn_Click(object sender, EventArgs e)
        {
            DoctorServiceReference.Doctor user = new DoctorServiceReference.Doctor();

            user.Name = txtName.Value;
            user.Specialization = txtSpecialization.Value;
            user.Experience = Convert.ToInt32(txtExperience.Value);
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

            bool isInserted = false;
            isInserted = doctorServiceClient.Insert(user);

            if (isInserted == true)
            {
                txtName.Value = "";
                male.Checked = false;
                female.Checked = false;
                txtExperience.Value = "";
                textEmail.Value = "";
                txtContact.Value = "";
                txtAddress.Value = "";

                Response.Redirect("Doctors.aspx");
            }
        }
    }
}