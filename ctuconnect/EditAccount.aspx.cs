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
                                Session["ID"] = reader["studentId"].ToString();
                            }
                        }

                    }

                    LoadProfilePicture(studentAcctID);
                    LoadResumeFile(studentAcctID);
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

        private void LoadResumeFile(int studentAcctID)
        {
            // Retrieve the resume file path from the database
            string resumeFilePath = GetResumeFilePath(studentAcctID);

            if (!string.IsNullOrEmpty(resumeFilePath))
            {

                // Get only the file name from the resume file path
                string resumeFileName = resumeFilePath;

                // Display the file name in the label control
                lblResumeFileName.Text = resumeFileName;
            }
            else
            {
                // Handle the case where no resume file is found
                lblResumeFileName.Text = "No resume file found.";
            }
        }

        private string GetResumeFilePath(int studentAcctID)
        {
            string resumeFilePath = string.Empty;
            using (var db = new SqlConnection(connDB))
            {
                string query = "SELECT resumeFile FROM STUDENT_ACCOUNT WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resumeFilePath = reader["resumeFile"].ToString();
                }
                reader.Close();
            }
            return resumeFilePath;
        }

        /*
        private void uploadResume()
        {

            if (resumeUpload.HasFile)
            {
                int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                string fileName = Path.GetFileName(resumeUpload.FileName);
                string filePath = Server.MapPath("~/images/Resume/") + studentAcctID + "_" + fileName;

                resumeUpload.SaveAs(filePath);

                SaveResumeFilePath(studentAcctID.ToString(), studentAcctID + "_" + fileName);

                LoadResumeFile(studentAcctID); // Reload the profile picture after uploading

            }
        }
        */

        private void SaveResumeFilePath(string studentAcctID, string resumeFile)
        {
            using (var db = new SqlConnection(connDB))
            {
                string query = "UPDATE STUDENT_ACCOUNT SET resumeFile = @ResumeFile WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ResumeFile", resumeFile);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                cmd.ExecuteNonQuery();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
            int studentID = Convert.ToInt32(Session["ID"].ToString());

            if (resumeUpload.HasFile)
            {

                string fileName = Path.GetFileName(resumeUpload.FileName);
                string filePath = Server.MapPath("~/images/Resume/") + studentAcctID + "_" + fileName;

                resumeUpload.SaveAs(filePath);

                SaveResumeFilePath(studentAcctID.ToString(), studentAcctID + "_" + fileName);

                LoadResumeFile(studentAcctID);

            }

            var lastname = txtlname.Text;
            var firstname = txtfname.Text;
            var initials = txtinitials.Text;
            var status = drpStudentStatus.Text;

            // Retrieve current values from the database
            bool isGraduate = GetIsGraduate(studentID);
            string currentStatus = GetStudentStatus(studentAcctID);

            // Check if the status is being changed to "Alumni" and the student is a graduate
            if (status == "Alumni" && !isGraduate)
            {
                lblstatus.Text = "Error: Cannot change to Alumni status if not graduated.";
                lblstatus.Visible = true;
                return;
            }

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
                        + "isGraduated = 1,"
                        + "studentStatus ='" + status + "' "
                        + "WHERE student_accID='" + studentAcctID + "'";

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Record Updated!');document.location='MyAccount.aspx'</script>");
                    }
                    else
                    {
                        // Handle the case where the update failed
                        lblstatus.Text = "Error: Failed to update record.";
                        lblstatus.Visible = true;
                    }
                }
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyAccount.aspx");
        }

        private string GetStudentStatus(int studentAcctID)
        {
            string studentStatus = string.Empty;

            using (var db = new SqlConnection(connDB))
            {
                string query = "SELECT studentStatus FROM STUDENT_ACCOUNT WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    studentStatus = reader["studentStatus"].ToString();
                }

                reader.Close();
            }

            return studentStatus;
        }

        private bool GetIsGraduate(int studentID)
        {
            
            bool isGraduate = false;

            using (var db = new SqlConnection(connDB))
            {
                // Check if the studentID exists in the Graduates_Table
                string checkQuery = "SELECT COUNT(*) FROM GRADUATES_TABLE WHERE studentID = @studentID";
                SqlCommand checkCmd = new SqlCommand(checkQuery, db);
                checkCmd.Parameters.AddWithValue("@studentID", studentID);

                db.Open();
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // If studentID exists in Graduates_Table, set isGraduate to true
                    isGraduate = true;
                }

            }

            return isGraduate;

        }

        

    }
}