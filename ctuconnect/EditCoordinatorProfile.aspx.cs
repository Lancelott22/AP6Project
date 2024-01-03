using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.IO;

namespace ctuconnect
{
    public partial class EditCoordinatorProfile : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
            if (!IsPostBack)
            {
                int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"].ToString());
                if (coordinatorID > 0)
                {
                    using (var db = new SqlConnection(connDB))
                    {
                        db.Open();
                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "SELECT * FROM COORDINATOR_ACCOUNT WHERE coordinator_accID ='" + coordinatorID + "'";
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                txtfname.Text = reader["firstName"].ToString();
                                txtinitials.Text = reader["midInitials"].ToString();
                                txtlname.Text = reader["lastName"].ToString();
                                txtemail.Text = reader["username"].ToString();
                            }
                        }

                    }

                    LoadProfilePicture(coordinatorID);
                }
                else
                {
                    Response.Redirect("LoginOJTCoordinator.aspx");
                }
            }
        }

        private void SaveProfilePicturePath(string coordinatorAcctID, string profilePicture)
        {
            using (var db = new SqlConnection(connDB))
            {
                string query = "UPDATE COORDINATOR_ACCOUNT SET coordinatorPicture = @ProfilePicture WHERE coordinator_accID = @coordinatorAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ProfilePicture", profilePicture);
                cmd.Parameters.AddWithValue("@coordinatorAcctID", coordinatorAcctID);

                db.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnUploadPicture_Click(object sender, EventArgs e)
        {

            if (fileUploadProfilePicture.HasFile)
            {
                int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"].ToString());
                string fileName = Path.GetFileName(fileUploadProfilePicture.FileName);
                string filePath = Server.MapPath("~/images/OJTCoordinatorProfile/") + coordinatorID + "_" + fileName;

                fileUploadProfilePicture.SaveAs(filePath);

                // Save the profile picture file path to the database 
                SaveProfilePicturePath(coordinatorID.ToString(), coordinatorID + "_" + fileName);

                LoadProfilePicture(coordinatorID); // Reload the profile picture after uploading

            }
        }

        private string GetProfilePicturePath(int coordinatorAcctID)
        {
            string profilePicture = string.Empty;
            using (var db = new SqlConnection(connDB))
            {
                string query = "SELECT coordinatorPicture FROM COORDINATOR_ACCOUNT WHERE coordinator_accID = @coordinatorAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@coordinatorAcctID", coordinatorAcctID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    profilePicture = reader["coordinatorPicture"].ToString();
                }
                reader.Close();
            }
            return profilePicture;
        }

        private void LoadProfilePicture(int coordinatorAcctID)
        {
            // Retrieve the profile picture path from the database (you need to implement this part)
            string profilePicture = GetProfilePicturePath(coordinatorAcctID);

            if (!string.IsNullOrEmpty(profilePicture))
            {
                imgProfilePicture.ImageUrl = "~/images/OJTCoordinatorProfile/" + profilePicture;
            }
            else
            {
                // If no profile picture is found, display a default image (you can set a default image in the ImageUrl)
                imgProfilePicture.ImageUrl = "~/images/OJTCoordinatorProfile/defaultprofile.jpg";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"].ToString());
            var lastname = txtlname.Text;
            var firstname = txtfname.Text;
            var initials = txtinitials.Text;
            var email = txtemail.Text;

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE COORDINATOR_ACCOUNT SET "
                        + "lastName ='" + lastname + "', "
                        + "firstName ='" + firstname + "',"
                        + "midInitials ='" + initials + "',"
                        + "username ='" + email + "'"
                        + "WHERE coordinator_accID='" + coordinatorID + "'";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                        Response.Write("<script>alert('Record Updated!');document.location='OJTCoordinator_Profile.aspx'</script>");

                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OJTCoordinator_Profile.aspx");
        }
    }
}