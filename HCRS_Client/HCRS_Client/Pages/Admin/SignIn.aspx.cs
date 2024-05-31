using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCRS_Client.Pages.Admin
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Text;


            if (username == "Admin" && password == "Admin123")
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username or Password!')</script>");
                Response.Redirect("SignIn.aspx");
            }

            this.username.Text = string.Empty;
            this.password.Text = string.Empty;
        }
    }
}