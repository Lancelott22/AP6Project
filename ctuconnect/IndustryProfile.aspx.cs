using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;

namespace ctuconnect
{
    public partial class IndustryProfile : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

        private DataTable dtFeedback = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");

            }
            else
            {
                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;
                displayIndustryInfo();
                displayContactPerson();

                this.LoadIndustryFeedback();
            }
            if (checkVerified())
            {
                verifiedIcon.Attributes.Add("title", "Verified");
                verifiedIcon.Attributes.Add("class", "fa fa-check-circle m-1 text-info");
            }
            else
            {
                verifiedIcon.Attributes.Add("title", "Unverified");
                verifiedIcon.Attributes.Add("class", "fa fa-check-circle m-1 text-danger");
            }
        }

        /*
        void displayIndustryInfo()
        {
            string industryID = Session["INDUSTRY_ACC_ID"].ToString();
            using (var db = new SqlConnection(conDB))
            {

                string query = "SELECT * FROM INDUSTRY_ACCOUNT WHERE industry_accID = '" + industryID + "' ";
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

                }
                reader.Close();
            }
        }*/
        bool checkVerified()
        {
            int industry_accId = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select isVerified from INDUSTRY_ACCOUNT where industry_accID = @industry_accID", con);
            cmd.Parameters.AddWithValue("@industry_accID", industry_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["isVerified"] == DBNull.Value || bool.Parse(reader["isVerified"].ToString()) == false)
                {
                    reader.Close();
                    con.Close();
                    return false;

                }
                else
                {
                    reader.Close();
                    con.Close();
                    return true;
                }

            }
            reader.Close();
            con.Close();
            return false;
        }
        void displayIndustryInfo()
        {
            string industryID = Session["INDUSTRY_ACC_ID"].ToString();
            using (var db = new SqlConnection(conDB))
            {
                // Retrieve the industry details
                string industryQuery = "SELECT * FROM INDUSTRY_ACCOUNT WHERE industry_accID = @IndustryID";
                SqlCommand industryCommand = new SqlCommand(industryQuery, db);
                industryCommand.Parameters.AddWithValue("@IndustryID", industryID);
                db.Open();
                SqlDataReader industryReader = industryCommand.ExecuteReader();

                if (industryReader.Read())
                {
                    // Load and display general information
                    LoadProfilePicture(industryReader["industryPicture"].ToString());
                    disp_name.Text = industryReader["industryName"].ToString();
                    lblName.Text = industryReader["industryName"].ToString();
                    lblLocation.Text = industryReader["location"].ToString();
                    lblEmail.Text = industryReader["email"].ToString();

                    // Calculate and display overall rating as stars
                    lblOverallRating.Text = CalculateOverallRatingStars(industryID);
                }

                industryReader.Close();
            }
        }

        private void displayContactPerson()
        {
            string industryID = Session["INDUSTRY_ACC_ID"].ToString();
            using (var db = new SqlConnection(conDB))
            {

                string query = "SELECT * FROM CONTACT_PERSON WHERE industry_accID = '" + industryID + "' ";
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
            
            int industryAccID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM INDUSTRY_FEEDBACK JOIN STUDENT_ACCOUNT ON INDUSTRY_FEEDBACK.sendfrom = STUDENT_ACCOUNT.student_accID WHERE sendto = @SendTo ORDER BY dateCreated DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@SendTo", industryAccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFeedback);
            }

            rptfeedback.DataSource = dtFeedback;
            rptfeedback.DataBind();
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

        // Helper method to calculate overall rating and generate star icons
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


        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");
        }
    }
}