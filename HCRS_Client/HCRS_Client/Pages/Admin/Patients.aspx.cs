using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class Patients : System.Web.UI.Page
    {
        PatientServiceReference.PatientServiceClient patientServiceClient = new PatientServiceReference.PatientServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayPatientDetails();
            errMsg.Text = "";
        }

        protected void DisplayPatientDetails()
        {
            PatientServiceReference.PatientData patientData = new PatientServiceReference.PatientData();

            patientData = patientServiceClient.GetPatientData();

            DataTable patientTable = new DataTable();

            patientTable = patientData.patientTable;

            PatientGridView.DataSource = patientTable;
            PatientGridView.DataBind();

            // Change the column name
            if (PatientGridView.HeaderRow != null)
            {
                PatientGridView.HeaderRow.Cells[3].Text = "Id";
                PatientGridView.HeaderRow.Cells[5].Text = "Date of Birth";
                PatientGridView.HeaderRow.Cells[8].Text = "Contact No";
                PatientGridView.HeaderRow.Cells[9].Text = "Email Id";
            }
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            errMsg.Text = "";

            PatientServiceReference.PatientData patientData = new PatientServiceReference.PatientData();

            patientData = patientServiceClient.SearchPatientByName(txtName.Text.Trim().ToLower());

            DataTable patientTable = new DataTable();

            patientTable = patientData.patientTable;

            if(patientTable.Rows.Count > 0)
            {
                PatientGridView.DataSource = null;
                PatientGridView.DataBind();

                PatientGridView.DataSource = patientTable;
                PatientGridView.DataBind();
            } 
            else
            {
                errMsg.Text = "Record with specified name is not found";
            }

            // Change the column name
            if (PatientGridView.HeaderRow != null)
            {
                PatientGridView.HeaderRow.Cells[3].Text = "Id";
                PatientGridView.HeaderRow.Cells[5].Text = "Date of Birth";
                PatientGridView.HeaderRow.Cells[8].Text = "Contact No";
                PatientGridView.HeaderRow.Cells[9].Text = "Email Id";
            }
        }

        protected void txtAddress_TextChanged(object sender, EventArgs e)
        {
            errMsg.Text = "";

            PatientServiceReference.PatientData patientData = new PatientServiceReference.PatientData();

            patientData = patientServiceClient.SearchPatientByAddress(txtAddress.Text.Trim().ToLower());

            DataTable patientTable = new DataTable();

            patientTable = patientData.patientTable;

            if (patientTable.Rows.Count > 0)
            {
                PatientGridView.DataSource = null;
                PatientGridView.DataBind();

                PatientGridView.DataSource = patientTable;
                PatientGridView.DataBind();
            }
            else
            {
                errMsg.Text = "Record with specified address is not found";
            }

            // Change the column name
            if (PatientGridView.HeaderRow != null)
            {
                PatientGridView.HeaderRow.Cells[3].Text = "Id";
                PatientGridView.HeaderRow.Cells[5].Text = "Date of Birth";
                PatientGridView.HeaderRow.Cells[8].Text = "Contact No";
                PatientGridView.HeaderRow.Cells[9].Text = "Email Id";
            }
        }


        protected void searchBtn_Clicked(object sender, EventArgs e)
        {
            errMsg.Text = "";

            string firstDate = txtFromDate.Text.Trim();
            string lastDate = txtToDate.Text.Trim();

            if(firstDate == "")
            {
                firstDate = DateTime.Now.Date.ToString();
            }

            if(lastDate == "")
            {
                lastDate = DateTime.Now.Date.ToString();
            }

            PatientServiceReference.PatientData patientData = new PatientServiceReference.PatientData();

            patientData = patientServiceClient.SearchPatientByDate(firstDate, lastDate);

            DataTable patientTable = new DataTable();

            patientTable = patientData.patientTable;

            if (patientTable.Rows.Count > 0)
            {
                PatientGridView.DataSource = null;
                PatientGridView.DataBind();

                PatientGridView.DataSource = patientTable;
                PatientGridView.DataBind();
            }
            else
            {
                errMsg.Text = "Record with specified date is not found";
            }

            // Change the column name
            if (PatientGridView.HeaderRow != null)
            {
                PatientGridView.HeaderRow.Cells[3].Text = "Id";
                PatientGridView.HeaderRow.Cells[5].Text = "Date of Birth";
                PatientGridView.HeaderRow.Cells[8].Text = "Contact No";
                PatientGridView.HeaderRow.Cells[9].Text = "Email Id";
            }
        }
    }
}