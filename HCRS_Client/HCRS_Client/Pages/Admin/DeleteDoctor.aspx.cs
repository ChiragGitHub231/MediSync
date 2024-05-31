using HCRS_Client.PatientServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class DeleteDoctor : System.Web.UI.Page
    {
        DoctorServiceReference.DoctorServiceClient doctorServiceClient = new DoctorServiceReference.DoctorServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the PatientId from the query string
                int doctorId = Convert.ToInt32(Request.QueryString["Id"]);

                bool isDeleted = false;
                isDeleted = doctorServiceClient.Delete(doctorId);

                if (isDeleted == true)
                {
                    Response.Redirect("Doctors.aspx");
                }
            }
        }
    }
}