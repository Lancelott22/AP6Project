using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Student : System.Web.UI.MasterPage
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            
                displayStudentInfo();
            
        }

        private void displayStudentInfo()
        {
            if (!string.IsNullOrEmpty(Session["PROFILE"].ToString()))
            {
                imageProfile.ImageUrl = "~/images/StudentProfiles/" + Session["PROFILE"].ToString();
                profileimg.Src = "~/images/StudentProfiles/" + Session["PROFILE"].ToString();
            }
            else
            {
                imageProfile.ImageUrl = "~/images/StudentProfiles/defaultprofile.jpg";
                profileimg.Src = "~/images/StudentProfiles/defaultprofile.jpg";
            }

            lblname.Text = Session["FNAME"].ToString() + " " + Session["LNAME"].ToString();
            lblstudentID.Text = Session["STUDENT_ID"].ToString();
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginStudent.aspx");

        }
    }
}