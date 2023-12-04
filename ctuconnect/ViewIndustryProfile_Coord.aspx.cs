using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ctuconnect
{
    public partial class ViewIndustryProfile_Coord : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtFeedback = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["industry_accID"] != null)
                {
                    // Get the value of the student_accID parameter
                    string industryAccID = Request.QueryString["industry_accID"];
                    //string industryAccID = "600000";


                    displayIndustryInfo(industryAccID);
                    displayContactPerson(industryAccID);

                    this.LoadIndustryFeedback();

                }
                else
                {
                    Response.Redirect("LoginOJTCoordinator.aspx");
                }
            }

        }

        void displayIndustryInfo(string industryAccID)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "SELECT * FROM INDUSTRY_ACCOUNT WHERE industry_accID = '" + industryAccID + "' ";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LoadProfilePicture(reader["industryPicture"].ToString());
                    disp_name.Text = reader["industryName"].ToString();
                    lblName.Text = reader["industryName"].ToString();
                    lblLocation.Text = reader["location"].ToString();
                    lblEmail.Text = reader["email"].ToString();

                    // Calculate and display overall rating as stars
                    lblOverallRating.Text = CalculateOverallRatingStars(industryAccID);

                }
                reader.Close();
            }
        }

        /*
        protected int displayRate()
        {
            int sendto = Convert.ToInt32(Request.QueryString["industry_accID"]);
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM INDUSTRY_FEEDBACK WHERE sendto = '" + sendto + "'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }
        */

        private void displayContactPerson(string industryAccID)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "SELECT * FROM CONTACT_PERSON WHERE industry_accID = '" + industryAccID + "' ";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    contactName.Text = reader["fName"].ToString() + " " + reader["LName"].ToString();
                    contactPosition.Text = reader["position"].ToString();
                    contactNumber.Text = reader["contactNumber"].ToString();
                    contactEmail.Text = reader["contactEmail"].ToString();

                }
                reader.Close();
            }
        }

        private void LoadProfilePicture(string profilePicturePath)
        {
            if (!string.IsNullOrEmpty(profilePicturePath))
            {
                industryProfile.ImageUrl = "~/images/IndustryProfile/" + profilePicturePath;
            }
            else
            {
                industryProfile.ImageUrl = "~/images/IndustryProfile/defaultprofile.jpg";
            }
        }

        private void LoadIndustryFeedback()
        {
            string industryAccID = Request.QueryString["industry_accID"];
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM INDUSTRY_FEEDBACK JOIN STUDENT_ACCOUNT ON INDUSTRY_FEEDBACK.sendfrom = STUDENT_ACCOUNT.student_accID WHERE sendto = @SendTo ORDER BY dateCreated DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@SendTo", industryAccID);

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

        protected string GetStarRating(int rating)
        {
            StringBuilder stars = new StringBuilder();

            for (int i = 0; i < rating; i++)
            {
                stars.Append("<i class='fa fa-star'></i>");
            }

            return stars.ToString();
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