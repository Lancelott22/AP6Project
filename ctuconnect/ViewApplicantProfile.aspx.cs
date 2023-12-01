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
    public partial class ViewApplicantProfile : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request.QueryString["student_accID"] != null)
                {
                    
                    string studentAccID = Request.QueryString["student_accID"];
                    DisplayStudent(studentAccID);

                }
                else
                {
                    
                }
            }
            
        }

        
        private void DisplayStudent(string studentaccID)
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
                    disp_address.Text = reader["address"].ToString();
                    disp_contactNumber.Text = reader["contactNumber"].ToString();

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
        
    }
}