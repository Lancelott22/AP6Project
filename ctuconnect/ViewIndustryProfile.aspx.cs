using System;
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
                
                //if (Request.QueryString["industry_accID"] != null)
                //{
                    // Get the value of the student_accID parameter
                    //string industryAccID = Request.QueryString["industry_accID"];
                    string industryAccID = "600000";


                    displayIndustryInfo(industryAccID);
                    displayContactPerson(industryAccID);

                    this.LoadIndustryFeedback(industryAccID);

                //}
                //else
                //{
                    
                //}
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

        private void LoadIndustryFeedback(string industryAccID)
        {

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM INDUSTRY_FEEDBACK WHERE sendto = @SendTo ORDER BY dateCreated DESC";
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

        protected void addReview_Click(object sender, EventArgs e)
        {
            //string industryAccID = Request.QueryString["industry_accID"];
            string industryAccID = "600000";
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#AddReviewlModal').modal('show');", true);

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE INDUSTRY_ACCOUNT.industry_accID = '" +  industryAccID + "' ";
                //string query = "SELECT * FROM COORDINATOR_ACCOUNT WHERE coordinator_accID = '" + coordinatorID + "' ";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtsendto.Text = reader["industryName"].ToString();

                }


            }
        }

        protected void Submit_ButtonClick(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conDB))
            {
                string sendfrom = txtsendfrom.Text;
                string sendto = txtsendto.Text;
                string jobtitle = txtposition.Text;
                string rating = companyRating.SelectedValue;
                string feedback = txtfeedback.Text;

                connection.Open();
                using (var dmd = connection.CreateCommand())
                { //SQL Statement
                    dmd.CommandType = CommandType.Text;
                    dmd.CommandText = "INSERT INTO INDUSTRY_FEEDBACK (sendfrom, sendto, jobTitle, rating, feedback, dateCreated)  "
                                    + " VALUES (@SendFrom,@SendTo,@JobTitle,@Rating,@Feedback, @DateCreated)";

                    dmd.Parameters.AddWithValue("@SendFrom", sendfrom);
                    dmd.Parameters.AddWithValue("@SendTo", sendto);
                    dmd.Parameters.AddWithValue("@JobTitle", jobtitle);
                    dmd.Parameters.AddWithValue("@Rating", rating);
                    dmd.Parameters.AddWithValue("@Feedback", feedback);
                    dmd.Parameters.AddWithValue("@DateCreated", DateTime.Now.ToString("yyyy/MM/dd"));
                    

                    var ctr = dmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        //Response.Write("<script>alert('Applicant officially hired')</script>");
                        //this.LoadApplicants();
                    }
                    else
                    {
                        Response.Write("<script>alert('Data is not save')</script>");
                    }
                }
            }


        }


    }
}