using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
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
        private DataTable dtFeedback = new DataTable();
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
                this.LoadStudentfeedback();
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
                    disp_name.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                    LoadProfilePicture(reader["studentPicture"].ToString());
                    string resume = reader["resumeFile"].ToString();
                    disp_email.Text = reader["email"].ToString();
                    disp_address.Text = reader["address"].ToString();
                    disp_status.Text = reader["studentStatus"].ToString();


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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditAccount");
        }

        private void LoadStudentfeedback()
        {
            int studentAccID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM STUDENT_FEEDBACK JOIN INDUSTRY_ACCOUNT ON STUDENT_FEEDBACK.sendfrom = INDUSTRY_ACCOUNT.industry_accID WHERE sendto = @SendTo ORDER BY dateCreated DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@SendTo", studentAccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFeedback);
            }

            listfeedback.DataSource = dtFeedback;
            listfeedback.DataBind();
        }


        protected void SignOut_Click(object sender, EventArgs e)
        {
            
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                Response.Redirect("LoginStudent.aspx");
            
        }

        protected void btnEditStatus_Click(object sender, EventArgs e)
        {

        }
    }
}