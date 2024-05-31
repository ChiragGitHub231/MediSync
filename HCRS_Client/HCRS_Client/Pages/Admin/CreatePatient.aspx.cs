using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class CreatePatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        PatientServiceReference.PatientServiceClient patientServiceClient = new PatientServiceReference.PatientServiceClient();
        protected void createBtn_Click(object sender, EventArgs e)
        {
            PatientServiceReference.Patient user = new PatientServiceReference.Patient();

            user.Name = txtName.Value;
            //user.DOB = txtDOB.Value;
            user.DOB = txtDOB1.Text;
            user.Age = Convert.ToInt32(txtAge.Value);
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
            isInserted = patientServiceClient.Insert(user);

            if (isInserted == true)
            {
                txtName.Value = "";
                txtDOB.Value = "";
                male.Checked = false;
                female.Checked = false;
                txtAge.Value = "";
                textEmail.Value = "";
                txtContact.Value = "";
                txtAddress.Value = "";

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