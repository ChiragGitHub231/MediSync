using HCRS_Client.PatientServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class DeleteAppointment : System.Web.UI.Page
    {
        AppointmentServiceReference.AppointmentServiceClient appointmentServiceClient = new AppointmentServiceReference.AppointmentServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the PatientId from the query string
                int patientId = Convert.ToInt32(Request.QueryString["Id"]);

                bool isDeleted = false;
                isDeleted = appointmentServiceClient.Delete(patientId);

                if (isDeleted == true)
                {
                    Response.Redirect("Appointments.aspx");
                }
            }
        }
    }
}