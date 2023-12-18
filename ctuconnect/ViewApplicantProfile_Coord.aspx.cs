using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class ViewApplicantProfile_Coord : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtFeedback = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["student_accID"] != null)
                {
                    string studentAccID = Request.QueryString["student_accID"];
                    DisplayStudent(studentAccID);
                    this.LoadStudentfeedback();
                }
                else
                {
                    Response.Redirect("LoginOJTCoordinator.aspx");
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
                    disp_name.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                    disp_status.Text = reader["studentStatus"].ToString();
                    LoadProfilePicture(reader["studentPicture"].ToString());
                    string resume = reader["resumeFile"].ToString();
                    disp_address.Text = reader["address"].ToString();
                    disp_email.Text = reader["personalEmail"].ToString();
                    disp_course.Text = reader["course"].ToString();
                    disp_contact.Text = reader["contactNumber"].ToString();
                    lblinterestOrHobby.Text = HttpUtility.HtmlDecode(reader["interestOrHobby"].ToString());

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


        private void LoadStudentfeedback()
        {

            string studentAccID = Request.QueryString["student_accID"];
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
            if (listfeedback.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }

        }
    }
}