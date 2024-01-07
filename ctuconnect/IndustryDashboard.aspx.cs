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
    public partial class IndustryDashboard : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

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
                getTotalHired();
                getTotalApplicant();
                getTotalJob();

                if (!ContactExists())
                {
                    // Perform the insertion
                    InsertContactPerson();
                }
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
        bool checkVerified()
        {
            int industry_accId = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select isVerified from INDUSTRY_ACCOUNT where industry_accID = @industry_accID", conDB);
            cmd.Parameters.AddWithValue("@industry_accID", industry_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["isVerified"] == DBNull.Value || bool.Parse(reader["isVerified"].ToString()) == false)
                {
                    reader.Close();
                    conDB.Close();
                    return false;

                }
                else
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }

            }
            reader.Close();
            conDB.Close();
            return false;
        }
        private bool ContactExists()
        {
            int industryID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT COUNT(*) FROM CONTACT_PERSON WHERE industry_accID = @IndustryAccID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@IndustryAccID", industryID);

                db.Open();

                int count = (int)cmd.ExecuteScalar();

                return count > 0;

            }

        }
        private void InsertContactPerson()
        {
            int industryID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
            
            using (conDB)
            {
                conDB.Open();
                using (var cmd = conDB.CreateCommand())
                {
                    //SQL Statement
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO CONTACT_PERSON (industry_accID) VALUES (@industry_accID)";

                    cmd.Parameters.AddWithValue("@industry_accID", industryID);
                    cmd.ExecuteNonQuery();
                }
                
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");
        }
        void getTotalHired()
        {   
            int industryID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(id) as TotalHired from HIRED_LIST WHERE ((internshipStatus = 'Ongoing' and studentType = 'Intern' ) or ( workStatus = 'Ongoing' and studentType = 'Alumni')) and industry_accID = '" + industryID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
               totalHired.InnerText = reader["TotalHired"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void getTotalApplicant()
        {
            int industryID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(applicantID) as TotalApplicant from APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) and industry_accID = '" + industryID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalApplicant.InnerText = reader["TotalApplicant"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void getTotalJob()
        {
            int industryID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE (isDeletedByAdmin = 'false' or isDeletedByAdmin IS NULL) and industry_accID = '" + industryID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalJobs.InnerText = reader["TotalJob"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        protected void Submit_Suggestions(object sender, EventArgs e)
        {
            int industryAccID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"]);
            string suggestions = txtsuggestion.Text;

            using (conDB)
            {
                conDB.Open();
                using (var cmd = conDB.CreateCommand())
                {
                    //SQL Statement
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO SUGGESTIONS (industry_accID, suggestion, dateCreated, isRead, isRemove ) " +
                                          "VALUES (@industry_accID, @suggestion, @dateCreated, @isRead, @isRemove)";

                    cmd.Parameters.AddWithValue("@industry_accID", industryAccID);
                    cmd.Parameters.AddWithValue("@suggestion", suggestions);
                    cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@isRead", 0);
                    cmd.Parameters.AddWithValue("@isRemove", 0);
                    cmd.ExecuteNonQuery();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('show');", true);
            }

        }
        protected void Close_SuccessPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('hide');document.location='IndustryDashboard.aspx'", true);
        }
    }
}