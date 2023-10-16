using Microsoft.Ajax.Utilities;
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
            if (!IsPostBack)
            {

                disp_name.Text = Session["FNAME"].ToString() + " " + Session["INITIAL"].ToString() + ". " + Session["LNAME"].ToString();
                disp_studentID.Text = Session["STUDENT_ID"].ToString();
                disp_studentStatus.Text = Session["STATUS"].ToString();
                disp_course.Text = Session["COURSE"].ToString();
                string resume = Session["RESUMEFILE"].ToString();

                string profilePicturePath = Session["PROFILE"].ToString();

                LoadProfilePicture(profilePicturePath);

                if (!string.IsNullOrEmpty(resume))
                {
                    lblResume.Text = "Uploaded";
                }
                else
                {
                    lblResume.Text = "No attached file";
                }
            }


        }

        private void LoadProfilePicture(string profilePicturePath)
        {
            if (!string.IsNullOrEmpty(profilePicturePath))
            {
                profileImage.ImageUrl = profilePicturePath;
            }
            else
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/defaultprofile.jpg";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditAccount");
        }
    }
}