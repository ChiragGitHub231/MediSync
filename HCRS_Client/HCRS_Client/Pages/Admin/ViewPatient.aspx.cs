using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class ViewPatient : System.Web.UI.Page
    {
        PatientServiceReference.PatientServiceClient patientServiceClient = new PatientServiceReference.PatientServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayPatientDetails();
            }
        }

        protected void DisplayPatientDetails()
        {
            // Retrieve the PatientId from the query string
            int patientId = Convert.ToInt32(Request.QueryString["Id"]);

            PatientServiceReference.Patient user = new PatientServiceReference.Patient();

            user = patientServiceClient.GetPatientById(patientId);

            txtName.Value = user.Name;
            txtDOB.Value = DateTime.Parse(user.DOB).ToString("yyyy-MM-dd");
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
}