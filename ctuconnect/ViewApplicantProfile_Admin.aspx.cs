using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ctuconnect
{
    public partial class ViewApplicantProfile_Admin : System.Web.UI.Page
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
                    Response.Redirect("Login.aspx");
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
                    disp_email.Text = reader["email"].ToString();
                    disp_course.Text = reader["course"].ToString();
                    disp_contact.Text = reader["contactNumber"].ToString();

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

        private string CalculateOverallRatingStars(string industryID)
        {
            int overallRating = 0;
            int totalRatings = 0;

            // Retrieve feedback ratings for the industry
            string feedbackQuery = "SELECT rating FROM INDUSTRY_FEEDBACK WHERE sendto = @IndustryID";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand feedbackCommand = new SqlCommand(feedbackQuery, db);
                feedbackCommand.Parameters.AddWithValue("@IndustryID", industryID);
                db.Open();
                SqlDataReader feedbackReader = feedbackCommand.ExecuteReader();

                while (feedbackReader.Read())
                {
                    int rating = Convert.ToInt32(feedbackReader["rating"]);
                    overallRating += rating;
                    totalRatings++;
                }

                feedbackReader.Close();
            }

            // Calculate the average rating (rounded to the nearest integer)
            if (totalRatings > 0)
            {
                overallRating = (int)Math.Round((double)overallRating / totalRatings);
            }

            // Generate HTML for star icons based on the calculated overall rating
            StringBuilder stars = new StringBuilder();
            for (int i = 0; i < overallRating; i++)
            {
                stars.Append("<i class='fa fa-star'></i>");
            }

            return stars.ToString();
        }
    }
}