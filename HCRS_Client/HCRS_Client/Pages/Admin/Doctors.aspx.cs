using HCRS_Client.PatientServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class Doctors : System.Web.UI.Page
    {
        DoctorServiceReference.DoctorServiceClient doctorServiceClient = new DoctorServiceReference.DoctorServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayDoctorDetails();
            errMsg.Text = "";
        }

        protected void DisplayDoctorDetails()
        {
            DoctorServiceReference.DoctorData doctorData = new DoctorServiceReference.DoctorData();

            doctorData = doctorServiceClient.GetDoctorData();

            DataTable doctorTable = new DataTable();

            doctorTable = doctorData.doctorTable;

            DoctorGridView.DataSource = doctorTable;
            DoctorGridView.DataBind();

            // Change the column name
            if (DoctorGridView.HeaderRow != null)
            {
                DoctorGridView.HeaderRow.Cells[3].Text = "Id";
                DoctorGridView.HeaderRow.Cells[6].Text = "Contact No";
                DoctorGridView.HeaderRow.Cells[7].Text = "Email Id";
            }
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            errMsg.Text = "";
            DoctorServiceReference.DoctorData doctorData = new DoctorServiceReference.DoctorData();

            doctorData = doctorServiceClient.SearchDoctorByName(txtName.Text.Trim().ToLower());

            DataTable doctorTable = new DataTable();

            doctorTable = doctorData.doctorTable;

            if (doctorTable.Rows.Count > 0)
            {
                DoctorGridView.DataSource = null;
                DoctorGridView.DataBind();

                DoctorGridView.DataSource = doctorTable;
                DoctorGridView.DataBind();
            }
            else
            {
                errMsg.Text = "Record with specified name is not found";
            }

            // Change the column name
            if (DoctorGridView.HeaderRow != null)
            {
                DoctorGridView.HeaderRow.Cells[3].Text = "Id";
                DoctorGridView.HeaderRow.Cells[6].Text = "Contact No";
                DoctorGridView.HeaderRow.Cells[7].Text = "Email Id";
            }
        }

        protected void txtSpecialization_TextChanged(object sender, EventArgs e)
        {
            errMsg.Text = "";
            DoctorServiceReference.DoctorData doctorData = new DoctorServiceReference.DoctorData();

            doctorData = doctorServiceClient.SearchDoctorBySpecialization(txtSpecialization.Text.Trim().ToLower());

            DataTable doctorTable = new DataTable();

            doctorTable = doctorData.doctorTable;

            if (doctorTable.Rows.Count > 0)
            {
                DoctorGridView.DataSource = null;
                DoctorGridView.DataBind();

                DoctorGridView.DataSource = doctorTable;
                DoctorGridView.DataBind();
            }
            else
            {
                errMsg.Text = "Record with specified specialization is not found";
            }

            // Change the column name
            if (DoctorGridView.HeaderRow != null)
            {
                DoctorGridView.HeaderRow.Cells[3].Text = "Id";
                DoctorGridView.HeaderRow.Cells[6].Text = "Contact No";
                DoctorGridView.HeaderRow.Cells[7].Text = "Email Id";
            }
        }

        protected void txtExperience_TextChanged(object sender, EventArgs e)
        {
            errMsg.Text = "";
            DoctorServiceReference.DoctorData doctorData = new DoctorServiceReference.DoctorData();

            doctorData = doctorServiceClient.SearchDoctorByExperience(txtExperience.Text.Trim());

            DataTable doctorTable = new DataTable();

            doctorTable = doctorData.doctorTable;

            if (doctorTable.Rows.Count > 0)
            {
                DoctorGridView.DataSource = null;
                DoctorGridView.DataBind();

                DoctorGridView.DataSource = doctorTable;
                DoctorGridView.DataBind();
            }
            else
            {
                errMsg.Text = "Record with specified experience is not found";
            }

            // Change the column name
            if (DoctorGridView.HeaderRow != null)
            {
                DoctorGridView.HeaderRow.Cells[3].Text = "Id";
                DoctorGridView.HeaderRow.Cells[6].Text = "Contact No";
                DoctorGridView.HeaderRow.Cells[7].Text = "Email Id";
            }
        }
    }
}