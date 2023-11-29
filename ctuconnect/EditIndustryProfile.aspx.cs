using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace ctuconnect
{
    public partial class EditIndustryProfile : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            int industryAcctID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
            if (!IsPostBack)
            {
                if (industryAcctID > 0)
                {
                    using (var db = new SqlConnection(connDB))
                    {
                        db.Open();
                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "SELECT * FROM INDUSTRY_ACCOUNT WHERE industry_accID ='" + industryAcctID + "'";
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                txtname.Text = reader["industryName"].ToString();
                                txtlocation.Text = reader["location"].ToString();
                            }
                        }

                    }

                    LoadProfilePicture(industryAcctID);
                    LoadContactPerson(industryAcctID);
                }
            }
        }

        protected void btnUploadPicture_Click(object sender, EventArgs e)
        {

            if (fileUploadProfilePicture.HasFile)
            {
                int industryAcctID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
                string fileName = Path.GetFileName(fileUploadProfilePicture.FileName);
                string filePath = Server.MapPath("~/images/IndustryProfile/") + industryAcctID + "_" + fileName;

                fileUploadProfilePicture.SaveAs(filePath);

                // Save the profile picture file path to the database 
                SaveProfilePicturePath(industryAcctID.ToString(), industryAcctID + "_" + fileName);

                LoadProfilePicture(industryAcctID); // Reload the profile picture after uploading

            }
        }

        private void SaveProfilePicturePath(string industryAcctID, string profilePicture)
        {
            using (var db = new SqlConnection(connDB))
            {
                string query = "UPDATE INDUSTRY_ACCOUNT SET industryPicture = @ProfilePicture WHERE industry_accID = @industryAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ProfilePicture", profilePicture);
                cmd.Parameters.AddWithValue("@industryAcctID", industryAcctID);

                db.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private string GetProfilePicturePath(int industryAcctID)
        {
            string profilePicture = string.Empty;
            using (var db = new SqlConnection(connDB))
            {
                string query = "SELECT industryPicture FROM INDUSTRY_ACCOUNT WHERE industry_accID = @industryAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@industryAcctID", industryAcctID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    profilePicture = reader["industryPicture"].ToString();
                }
                reader.Close();
            }
            return profilePicture;
        }

        private void LoadProfilePicture(int industryAcctID)
        {
            // Retrieve the profile picture path from the database (you need to implement this part)
            string profilePicture = GetProfilePicturePath(industryAcctID);

            if (!string.IsNullOrEmpty(profilePicture))
            {
                imgProfilePicture.ImageUrl = "~/images/IndustryProfile/" + profilePicture;
            }
            else
            {
                // If no profile picture is found, display a default image (you can set a default image in the ImageUrl)
                imgProfilePicture.ImageUrl = "~/images/IndustryProfile/defaultprofile.jpg";
            }
        }

        private void LoadContactPerson(int industryAccID)
        {
            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CONTACT_PERSON WHERE industry_accID ='" + industryAccID + "'";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtfname.Text = reader["fName"].ToString();
                        txtlname.Text = reader["LName"].ToString();
                        txtposition.Text = reader["position"].ToString();
                        txtContactNum.Text = reader["contactNumber"].ToString();
                        txtContactEmail.Text = reader["contactEmail"].ToString();
                    }
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int industryAcctID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());

            var name = txtname.Text;
            var location = txtlocation.Text;

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE INDUSTRY_ACCOUNT SET "
                        + "industryName ='" + name + "', "
                        + "location ='" + location + "'"
                        + "WHERE industry_accID='" + industryAcctID + "'";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        saveContactPerson(industryAcctID);
                    }
                        

                }

            }
            

        }

        private void saveContactPerson(int industryAccID)
        {
            var fname = txtfname.Text;
            var lname = txtlname.Text;
            var position = txtposition.Text;
            var contactNum = txtContactNum.Text;
            var contactEmail = txtContactEmail.Text;

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE CONTACT_PERSON SET "
                        + "fName ='" + fname + "', "
                        + "LName ='" + lname + "',"
                        + "position ='" + position + "',"
                        + "contactNumber ='" + contactNum + "',"
                        + "contactEmail ='" + contactEmail + "'"
                        + "WHERE industry_accID='" + industryAccID + "'";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                        Response.Write("<script>alert('Profile Updated!');document.location='IndustryProfile.aspx'</script>");

                }

            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndustryProfile.aspx");
        }
    }
}