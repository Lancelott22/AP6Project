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
    public partial class EditAccount : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Student_ACC_ID"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
            else if (!IsPostBack && Session["StudentEmail"] != null && Session["STATUSorTYPE"].ToString() == "Alumni" && bool.Parse(Session["IsAnswered"].ToString()) == false)
            {
                Response.Redirect("Alumni_Employment_Form.aspx");
            }
            if (!IsPostBack)
            {
                int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                if (studentAcctID > 0)
                {
                    using (var db = new SqlConnection(connDB))
                    {
                        db.Open();
                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "SELECT * FROM STUDENT_ACCOUNT WHERE student_accID ='" + studentAcctID + "'";
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                txtfname.Text = reader["firstName"].ToString();
                                txtinitials.Text = reader["midInitials"].ToString();
                                txtlname.Text = reader["lastName"].ToString();
                                Session["ID"] = reader["studentId"].ToString();
                                txtaddress.Text = reader["address"].ToString();
                                txtcontact.Text = reader["contactNumber"].ToString();
                                txtctuemail.Text = reader["email"].ToString();
                                txtPersonalEmail.Text = reader["personalEmail"].ToString();

                            }
                        }

                    }

                    LoadProfilePicture(studentAcctID);
                }
            }

        }

        protected void ValidateGmailAccount(object source, ServerValidateEventArgs args)
        {
            // Extract the email address from the TextBox
            string email = txtPersonalEmail.Text.Trim();

            // Validate that it ends with "@gmail.com"
            if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                args.IsValid = false;
                return;
            }

            args.IsValid = true;
        }


        protected void btnUploadPicture_Click(object sender, EventArgs e)
        {

            if (fileUploadProfilePicture.HasFile)
            {
                int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                string fileName = Path.GetFileName(fileUploadProfilePicture.FileName);
                string filePath = Server.MapPath("~/images/StudentProfiles/") + studentAcctID + "_" + fileName;

                fileUploadProfilePicture.SaveAs(filePath);

                // Save the profile picture file path to the database 
                SaveProfilePicturePath(studentAcctID.ToString(), studentAcctID + "_" + fileName);

                LoadProfilePicture(studentAcctID); // Reload the profile picture after uploading

            }
        }

        private void SaveProfilePicturePath(string studentAcctID, string profilePicture)
        {
            using (var db = new SqlConnection(connDB))
            {
                string query = "UPDATE STUDENT_ACCOUNT SET studentPicture = @ProfilePicture WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ProfilePicture", profilePicture);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private string GetProfilePicturePath(int studentAcctID)
        {
            string profilePicture = string.Empty;
            using (var db = new SqlConnection(connDB))
            {
                string query = "SELECT studentPicture FROM STUDENT_ACCOUNT WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    profilePicture = reader["studentPicture"].ToString();
                }
                reader.Close();
            }
            return profilePicture;
        }

        private void LoadProfilePicture(int studentAcctID)
        {
            // Retrieve the profile picture path from the database (you need to implement this part)
            string profilePicture = GetProfilePicturePath(studentAcctID);

            if (!string.IsNullOrEmpty(profilePicture))
            {
                imgProfilePicture.ImageUrl = "~/images/StudentProfiles/" + profilePicture;
            }
            else
            {
                // If no profile picture is found, display a default image (you can set a default image in the ImageUrl)
                imgProfilePicture.ImageUrl = "~/images/StudentProfiles/defaultprofile.jpg";
            }
        }

          


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyAccount.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                int studentID = Convert.ToInt32(Session["ID"].ToString());

                var ctu = txtctuemail.Text;
                var personal = txtPersonalEmail.Text;
                var lastname = txtlname.Text;
                var firstname = txtfname.Text;
                var initials = txtinitials.Text;
                var contact = txtcontact.Text;
                var address = txtaddress.Text;




                // Continue with updating the database if the conditions are met
                using (var db = new SqlConnection(connDB))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;

                        // Update the database with the new values
                        cmd.CommandText = "UPDATE STUDENT_ACCOUNT SET "
                            + "lastName ='" + lastname + "', "
                            + "firstName ='" + firstname + "',"
                            + "midInitials ='" + initials + "',"
                            + "contactNumber ='" + contact + "',"
                            + "address ='" + address + "',"
                            + "email ='" + ctu + "',"
                            + "personalEmail ='" + personal + "'"
                            + "WHERE student_accID='" + studentAcctID + "'";

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            Response.Write("<script>alert('Record Updated!');document.location='MyAccount.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Record Failed to Update!')</script>");
                        }
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Record Failed to Update!')</script>");
            }
        }

    }
}