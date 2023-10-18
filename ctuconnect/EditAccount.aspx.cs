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
            int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
            if (!IsPostBack)
            {
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
                                drpStudentStatus.Text = reader["studentStatus"].ToString();
                            }
                        }

                    }
                }
            }

        }

        protected void btnUploadPicture_Click(object sender, EventArgs e)
        {
            if (fileUploadProfilePicture.HasFile)
            {
                int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                string fileName = Path.GetFileName(fileUploadProfilePicture.FileName);
                string filePath = Server.MapPath("~/images/StudentProfiles/") + studentAcctID + "_" + fileName;

                fileUploadProfilePicture.SaveAs(filePath);

                // Save the profile picture file path to the database (you need to implement this part)
                SaveProfilePicturePath(studentAcctID.ToString(),  studentAcctID + "_" + fileName);

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = resumeUpload.PostedFile;  /// upload file
            string filename = Path.GetFileName(postedFile.FileName);///to check the filename 
            int filesize = postedFile.ContentLength; //to get the filesize
            string logpath = "c:\\ResumeFiles"; //creating a drive to upload or save the image
            string filepath = Path.Combine(logpath, filename);
            var lastname = txtlname.Text;
            var firstname = txtfname.Text;
            var initials = txtinitials.Text;
            var status = drpStudentStatus.Text;

            int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE STUDENT_ACCOUNT SET "
                        + "resumeFile ='" + filename + "', "
                        + "lastName ='" + lastname + "', "
                        + "firstName ='" + firstname + "',"
                        + "midInitials ='" + initials + "',"
                        + "studentStatus ='" + status + "'"
                        + "WHERE student_accID='" + studentAcctID + "'";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                        Response.Write("<script>alert('Record Updated!')</script>");
                    Response.Redirect("MyAccount.aspx");

                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyAccount.aspx");
        }
    }
}