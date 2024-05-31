using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HCRS_Client.Pages.Admin
{
    public partial class DeletePatient : System.Web.UI.Page
    {
        PatientServiceReference.PatientServiceClient patientServiceClient = new PatientServiceReference.PatientServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the PatientId from the query string
                int patientId = Convert.ToInt32(Request.QueryString["Id"]);

                bool isDeleted = false;
                isDeleted = patientServiceClient.Delete(patientId);

                if(isDeleted == true)
                {
                    Response.Redirect("Patients.aspx");
                }
            }
        }
    }
}