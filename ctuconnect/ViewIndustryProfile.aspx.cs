﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class ViewIndustryProfile : System.Web.UI.Page
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
                    displaySender();

                }
                else
                {

                }
            }
            
        }

        void displaySender()
        {
            int studentID = Convert.ToInt32(Session["Student_ACC_ID"]);
            using (var db = new SqlConnection(conDB))
            {

                string query = "SELECT * FROM STUDENT_ACCOUNT WHERE student_accID = '" + studentID + "' ";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtsendfrom.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();

                }
                reader.Close();
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
                string query = "SELECT * FROM INDUSTRY_FEEDBACK WHERE sendto = @SendTo ORDER BY dateCreated DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@SendTo", industryAccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFeedback);
            }

            listfeedback.DataSource = dtFeedback;
            listfeedback.DataBind();
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

        protected void btnFeedback_Click(object sender, EventArgs e)
        {
            
            // Open the modal dialog and populate it with existing values
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openModal();", true);

        }

        protected void saveFeedback(object sender, EventArgs e)
        {
            
            int sendto = Convert.ToInt32(Request.QueryString["industry_accID"]);
            int sendfrom = Convert.ToInt32(Session["Student_ACC_ID"]);
            string summary = "N/A";
                using (SqlConnection connection = new SqlConnection(conDB))
                {
                    string jobtitle = txtjobposition.Text;
                    string rating = companyRating.SelectedValue;
                    string feedback = txtfeedback.Text;

                    connection.Open();
                    using (var dmd = connection.CreateCommand())
                    { //SQL Statement
                        dmd.CommandType = CommandType.Text;
                        dmd.CommandText = "INSERT INTO INDUSTRY_FEEDBACK (sendfrom, sendto, jobTitle, rating, feedbackSummary, feedback, dateCreated)  "
                                        + " VALUES (@Sendfrom,@Sendto,@JobTitle,@Rating,@FeedbackSummary,@Feedback, @DateCreated)";

                        dmd.Parameters.AddWithValue("@Sendfrom", sendfrom);
                        dmd.Parameters.AddWithValue("@Sendto", sendto);
                        dmd.Parameters.AddWithValue("@JobTitle", jobtitle);
                        dmd.Parameters.AddWithValue("@Rating", rating);
                        dmd.Parameters.AddWithValue("@FeedbackSummary", summary);
                        dmd.Parameters.AddWithValue("@Feedback", feedback);
                        dmd.Parameters.AddWithValue("@DateCreated", DateTime.Now.ToString("yyyy/MM/dd"));


                        var ctr = dmd.ExecuteNonQuery();
                        if (ctr > 0)
                        {
                            Response.Write("<script>alert('Feedback submitted successfully! Thank you for your input.')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Data is not save')</script>");
                        }
                    }
                }
                this.LoadIndustryFeedback();
            
            

        }

        protected void closeEditModal(object sender, EventArgs e)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal();", true);
        }
    }
}