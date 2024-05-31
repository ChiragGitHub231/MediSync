using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class Appointments : System.Web.UI.Page
    {
        AppointmentServiceReference.AppointmentServiceClient appointmentServiceClient = new AppointmentServiceReference.AppointmentServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayAppointmentDetails();
            errMsg.Text = "";
        }

        protected void DisplayAppointmentDetails()
        {
            AppointmentServiceReference.AppointmentData appointmentData = new AppointmentServiceReference.AppointmentData();

            appointmentData = appointmentServiceClient.GetAppointmentData();

            DataTable appointmentTable = new DataTable();

            appointmentTable = appointmentData.appointmentTable;

            AppointmentGridView.DataSource = appointmentTable;
            AppointmentGridView.DataBind();

            // Change the column name
            if (AppointmentGridView.HeaderRow != null)
            {
                AppointmentGridView.HeaderRow.Cells[3].Text = "Id";
                AppointmentGridView.HeaderRow.Cells[4].Text = "Patient Name";
                AppointmentGridView.HeaderRow.Cells[5].Text = "Doctor Name";
            }
        }

        protected void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            errMsg.Text = "";

            AppointmentServiceReference.AppointmentData appointmentData = new AppointmentServiceReference.AppointmentData();

            appointmentData = appointmentServiceClient.SearchAppointmentByPatientName(txtPatientName.Text.Trim().ToLower());

            DataTable appointmentTable = new DataTable();

            appointmentTable = appointmentData.appointmentTable;

            if (appointmentTable.Rows.Count > 0)
            {
                AppointmentGridView.DataSource = null;
                AppointmentGridView.DataBind();

                AppointmentGridView.DataSource = appointmentTable;
                AppointmentGridView.DataBind();
            }
            else
            {
                errMsg.Text = "Record with specified patient name is not found";
            }

            // Change the column name
            if (AppointmentGridView.HeaderRow != null)
            {
                AppointmentGridView.HeaderRow.Cells[3].Text = "Id";
                AppointmentGridView.HeaderRow.Cells[4].Text = "Patient Name";
                AppointmentGridView.HeaderRow.Cells[5].Text = "Doctor Name";
            }
        }

        protected void txtDoctorName_TextChanged(object sender, EventArgs e)
        {
            errMsg.Text = "";

            AppointmentServiceReference.AppointmentData appointmentData = new AppointmentServiceReference.AppointmentData();

            appointmentData = appointmentServiceClient.SearchAppointmentByDoctorName(txtDoctorName.Text.Trim().ToLower());

            DataTable appointmentTable = new DataTable();

            appointmentTable = appointmentData.appointmentTable;

            if (appointmentTable.Rows.Count > 0)
            {
                AppointmentGridView.DataSource = null;
                AppointmentGridView.DataBind();

                AppointmentGridView.DataSource = appointmentTable;
                AppointmentGridView.DataBind();
            }
            else
            {
                errMsg.Text = "Record with specified doctor name is not found";
            }

            // Change the column name
            if (AppointmentGridView.HeaderRow != null)
            {
                AppointmentGridView.HeaderRow.Cells[3].Text = "Id";
                AppointmentGridView.HeaderRow.Cells[4].Text = "Patient Name";
                AppointmentGridView.HeaderRow.Cells[5].Text = "Doctor Name";
            }
        }

        protected void searchBtn_Clicked(object sender, EventArgs e)
        {
            errMsg.Text = "";

            string firstDate = txtFromDate.Text.Trim();
            string lastDate = txtToDate.Text.Trim();

            if (firstDate == "")
            {
                firstDate = DateTime.Now.Date.ToString();
            }

            if (lastDate == "")
            {
                lastDate = DateTime.Now.Date.ToString();
            }

            AppointmentServiceReference.AppointmentData appointmentData = new AppointmentServiceReference.AppointmentData();

            appointmentData = appointmentServiceClient.SearchAppointmentByDate(firstDate, lastDate);

            DataTable appointmentTable = new DataTable();

            appointmentTable = appointmentData.appointmentTable;

            if (appointmentTable.Rows.Count > 0)
            {
                AppointmentGridView.DataSource = null;
                AppointmentGridView.DataBind();

                AppointmentGridView.DataSource = appointmentTable;
                AppointmentGridView.DataBind();
            }
            else
            {
                errMsg.Text = "Record with specified date is not found";
            }

            // Change the column name
            if (AppointmentGridView.HeaderRow != null)
            {
                AppointmentGridView.HeaderRow.Cells[3].Text = "Id";
                AppointmentGridView.HeaderRow.Cells[4].Text = "Patient Name";
                AppointmentGridView.HeaderRow.Cells[5].Text = "Doctor Name";
            }
        }
    }
}