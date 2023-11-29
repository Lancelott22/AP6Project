using Microsoft.Ajax.Utilities;
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
    public partial class MyAccount1 : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Student_ACC_ID"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
            else if (!IsPostBack && Session["StudentEmail"] != null)
            {
                int studentAccID = Convert.ToInt32(Session["STUDENT_ACC_ID"].ToString());
                DisplayStudent(studentAccID);
            }
           
        }

        private void DisplayStudent(int studentaccID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM STUDENT_ACCOUNT JOIN PROGRAM ON STUDENT_ACCOUNT.COURSE_ID = PROGRAM.COURSE_ID WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentaccID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    disp_name.Text = reader["firstName"].ToString() + " " + reader["midInitials"].ToString() + " " + reader["lastName"].ToString();
                    disp_studentStatus.Text = reader["studentStatus"].ToString();
                    LoadProfilePicture(reader["studentPicture"].ToString());
                    disp_course.Text = reader["course"].ToString();
                    string resume = reader["resumeFile"].ToString();
                    disp_studentID.Text = reader["studentId"].ToString();

                    if (!string.IsNullOrEmpty(resume))
                    {
                        lblResume.Text = "Uploaded";
                    }
                    else
                    {
                        lblResume.Text = "No attached file";
                    }



                }
                reader.Close();

            }
        }
        private void LoadProfilePicture(string profilePicturePath)
        {
            if (!string.IsNullOrEmpty(profilePicturePath))
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/" + profilePicturePath;
            }
            else
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/defaultprofile.jpg";
            }
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