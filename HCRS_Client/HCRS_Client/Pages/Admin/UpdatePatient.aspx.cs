using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class UpdatePatient : System.Web.UI.Page
    {
        PatientServiceReference.PatientServiceClient patientServiceClient = new PatientServiceReference.PatientServiceClient();
        int patientId;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the PatientId from the query string
            patientId = Convert.ToInt32(Request.QueryString["Id"]);

            if (!IsPostBack)
            {
                PatientServiceReference.Patient user = new PatientServiceReference.Patient();

                user = patientServiceClient.GetPatientById(patientId);

                txtName.Value = user.Name;
                txtDOB1.Text = DateTime.Parse(user.DOB).ToString("yyyy-MM-dd");
                txtAge.Value = user.Age.ToString();
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

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            PatientServiceReference.Patient user = new PatientServiceReference.Patient();

            user.Name = txtName.Value;
            //user.DOB = txtDOB.Value;
            user.DOB = txtDOB1.Text;
            user.Age = int.Parse(txtAge.Value);
            user.Email = textEmail.Value;
            user.Contact_No = txtContact.Value;
            user.Address = txtAddress.Value;

            String Gender = "";

            if (male.Checked)
            {
                Gender = "Male";
            }
            else if(female.Checked)
            {
                Gender = "Female";
            }
            user.Gender = Gender;

            bool isUpdated = false;
            isUpdated = patientServiceClient.Update(patientId, user);

            if (isUpdated == true)
            {
                Response.Redirect("Patients.aspx");
            }
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            // Calculate age and set it to the age field
            txtAge.Value = CalculateAge(txtDOB1.Text).ToString();
        }

        private int CalculateAge(string dob)
        {
            DateTime dobDate;
            if (DateTime.TryParse(dob, out dobDate))
            {
                DateTime today = DateTime.Today;
                int age = today.Year - dobDate.Year;
                if (dobDate > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
            return 0; // Handle invalid date of birth
        }
    }
}