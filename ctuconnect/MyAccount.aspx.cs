using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class MyAccount1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["StudentEmail"] == null)
            {
                Response.Redirect("LoginStudent.aspx");

            } else
            {
                disp_name.Text = Session["FNAME"].ToString() + " " + Session["INITIAL"].ToString() + ". " + Session["LNAME"].ToString();
                disp_studentID.Text = Session["STUDENT_ID"].ToString();
                disp_studentStatus.Text = Session["STATUS"].ToString();
                disp_course.Text = Session["COURSE"].ToString();
                disp_employeeStatus.Text = "Pending";

                string imagePath = "~/images/StudentProfiles/" + Session["PROFILE"].ToString();
                profileImage1.ImageUrl = imagePath;
            }
            


        }
    }
}