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
    public partial class IndustryProfile : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

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
            }
        }

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

        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");
        }
    }
}