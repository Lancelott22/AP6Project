using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ctuconnect
{
    public partial class MyAccount1 : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtFeedback = new DataTable();
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
            else if (!IsPostBack && Session["StudentEmail"] != null)
            {
                int studentAccID = Convert.ToInt32(Session["STUDENT_ACC_ID"].ToString());
                DisplayStudent(studentAccID);
                this.LoadStudentfeedback();
                refreshStatus();
                
            }
           
        }

        void refreshStatus()
        {
            if (disp_status.Text == "Alumni")
            {
                btnEditStatus.Visible = false;
            }
            else
            {
                btnEditStatus.Visible = true;
            }
        }

        private void DisplayStudent(int studentaccID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM STUDENT_ACCOUNT JOIN PROGRAM ON STUDENT_ACCOUNT.COURSE_ID = PROGRAM.COURSE_ID WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentaccID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    disp_name.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                    LoadProfilePicture(reader["studentPicture"].ToString());
                    string resume = reader["resumeFile"].ToString();
                    disp_email.Text = reader["personalEmail"].ToString();
                    disp_address.Text = reader["address"].ToString();
                    disp_status.Text = reader["studentStatus"].ToString();
                    disp_contact.Text = reader["contactNumber"].ToString();
                    disp_course.Text = reader["course"].ToString();
                    lblinterestOrHobby.Text = HttpUtility.HtmlDecode(reader["interestOrHobby"].ToString());


                    if (!string.IsNullOrEmpty(resume))
                    {
                        lblResume.Text = "Uploaded";
                        btnViewResume.Visible = true;
                    }
                    else
                    {
                        lblResume.Text = "No attached file";

                    }

                }
                reader.Close();
                this.refreshStatus();
            }
        }
        private void LoadProfilePicture(string profilePicturePath)
        {
            if (!string.IsNullOrEmpty(profilePicturePath))
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/" + profilePicturePath;
            }
            else
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/defaultprofile.jpg";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditAccount");
        }

        private void LoadStudentfeedback()
        {
            int studentAccID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM STUDENT_FEEDBACK JOIN INDUSTRY_ACCOUNT ON STUDENT_FEEDBACK.sendfrom = INDUSTRY_ACCOUNT.industry_accID WHERE sendto = @SendTo ORDER BY dateCreated DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@SendTo", studentAccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFeedback);
            }

            listfeedback.DataSource = dtFeedback;
            listfeedback.DataBind();
            if (listfeedback.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
        }


        protected void SignOut_Click(object sender, EventArgs e)
        {
            
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                Response.Redirect("LoginStudent.aspx");
            
        }


        protected void btnViewResume_Click(object sender, EventArgs e)
        {
            int studentAccID = Convert.ToInt32(Session["STUDENT_ACC_ID"].ToString());

            // Retrieve and display the resume file
            byte[] resumeFileData = GetResumeFileData(studentAccID);

            if (resumeFileData != null)
            {
                // Provide the file data for download in a new browser tab
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf"; // Set the appropriate content type
                Response.AddHeader("content-disposition", "inline; filename=resume.pdf"); // Open in a new tab
                Response.BinaryWrite(resumeFileData);
                Response.End();
            }
        }

        private byte[] GetResumeFileData(int studentAccID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT resumeFile FROM STUDENT_ACCOUNT WHERE student_accID = @studentAccID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAccID", studentAccID);

                db.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Assuming that the result is a file path, read the file content
                    string fileName = result.ToString();
                    string filePath = "~/images/resume/" + fileName; // Construct the path
                    byte[] fileData = System.IO.File.ReadAllBytes(Server.MapPath(filePath));
                    return fileData;
                }

                return null; // No file found
            }
            
        }

        protected void btnEditResume_Click(object sender, EventArgs e)
        {
            int studentAccID = Convert.ToInt32(Session["STUDENT_ACC_ID"].ToString());
            Response.Redirect("EditResume.aspx");
        }

        protected void btnCloseStatus_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal2();", true);
        }

        protected void btnSaveStatus_Click(object sender, EventArgs e)
        {
            int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
            int studentID = Convert.ToInt32(Session["ID"].ToString());
            var status = drpStudentStatus.Text;

            // Retrieve current values from the database
            bool isGraduate = GetIsGraduate(studentID);
            string currentStatus = GetStudentStatus(studentAcctID);

            // Check if the status is being changed to "Alumni" and the student is a graduate
            if (status == "Alumni" && !isGraduate)
            {
                //lblstatus.Text = "Error: Cannot change to Alumni status if not graduated.";
                //lblstatus.Visible = true;
                Response.Write("<script>alert('Error: Cannot change to Alumni status if not graduated.');history.back();</script>");

                return;
            } 
            else if (status == "Intern")
            {
                using (var db = new SqlConnection(conDB))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;

                        // Update the database with the new values
                        cmd.CommandText = "UPDATE STUDENT_ACCOUNT SET "
                            + "studentStatus ='" + status + "'"
                            + "WHERE student_accID='" + studentAcctID + "'";

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            Response.Write("<script>alert('Updated Successfully')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to Update')</script>");
                        }
                    }
                }
                return;
            }

            // Continue with updating the database if the conditions are met
            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    // Update the database with the new values
                    cmd.CommandText = "UPDATE STUDENT_ACCOUNT SET "
                        + "isGraduated = 1,"
                        + "studentStatus ='" + status + "', "
                        + "yearGraduated = (SELECT yearGraduated FROM Graduates_Table WHERE studentId='" + studentID + "') "
                        + "WHERE student_accID='" + studentAcctID + "'";

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        LogOut();
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

        protected void btnEditStatus_Click(object sender, EventArgs e)
        {
            int studentAccID = Convert.ToInt32(Session["STUDENT_ACC_ID"].ToString());
            // Open the modal dialog and populate it with existing values
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openModal2();", true);
            LoadStatus(studentAccID);
        }

        private void LoadStatus(int studentAcctID)
        {
            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM STUDENT_ACCOUNT WHERE student_accID ='" + studentAcctID + "'";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        drpStudentStatus.Text = reader["studentStatus"].ToString();
                        Session["ID"] = reader["studentId"].ToString();
                    }
                }

            }
        }

        private string GetStudentStatus(int studentAcctID)
        {
            string studentStatus = string.Empty;

            using (var db = new SqlConnection(conDB))
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

            using (var db = new SqlConnection(conDB))
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

        void LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Write("<script>alert('Student status changed to Alumni. Please log in as Alumni');document.location='LoginStudent.aspx'</script>");
        }

        protected void btnCloseHobby_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal();", true);
        }

        protected void btnSaveHobby_Click(object sender, EventArgs e)
        {
            try
            {
                int studentAccID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                //string interviewDetails = txtInterviewDetails.Text;
                string interestOrhobby = HttpUtility.HtmlEncode(txtInterestHobby.Text);

                using (var db = new SqlConnection(conDB))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        string sql = "UPDATE STUDENT_ACCOUNT SET interestOrHobby = @InterestOrHooby WHERE student_accID = @StudentAcctID";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@StudentAcctID", studentAccID);
                        cmd.Parameters.AddWithValue("@InterestOrHooby", interestOrhobby);

                        cmd.ExecuteNonQuery();

                        Response.Write("<script>alert('Updated Successfully')</script>");

                    }
                }
                this.DisplayStudent(studentAccID);
                    
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid Input!'); history.back();</script>" + ex.Message);
            }
        }

        protected void btnEditInterest_Click(object sender, EventArgs e)
        {
            int studentAccID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
            string interestOrHobby = HttpUtility.HtmlDecode(GetInterestOrhobbyFromDatabase(studentAccID));



            // Open the modal dialog and populate it with existing values
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openModal('{interestOrHobby}');", true);

        }

        private string GetInterestOrhobbyFromDatabase(int student_accID)
        {
            string interestOrHooby = string.Empty;

            using (var connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT interestOrHobby FROM STUDENT_ACCOUNT WHERE student_accID = @StudentAcctID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentAcctID", student_accID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                interestOrHooby = reader.GetString(0);

                            }
                        }
                    }
                }
            }

            return interestOrHooby;
        }

        protected void UpdateResume_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openModal4();", true);
        }

        protected void btnClose4_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal4();", true);
        }

        protected void btnUploadResume_Click(object sender, EventArgs e)
        {
            int studentAcctID = Convert.ToInt32(Session["STUDENT_ACC_ID"].ToString());
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openModal3();", true);
            LoadResumeFile(studentAcctID);
        }

        protected void btnCloseResume_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal3();", true);
        }

        protected void btnSaveResumeback_Click(object sender, EventArgs e)
        {
            int studentAcctID = Convert.ToInt32(Session["STUDENT_ACC_ID"].ToString());
            if (resumeUpload.HasFile)
            {

                string fileName = Path.GetFileName(resumeUpload.FileName);
                string filePath = Server.MapPath("~/images/Resume/") + fileName;

                resumeUpload.SaveAs(filePath);

                SaveResumeFilePath(studentAcctID.ToString(), fileName);

                LoadResumeFile(studentAcctID);


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

        private void SaveResumeFilePath(string studentAcctID, string resumeFile)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "UPDATE STUDENT_ACCOUNT SET resumeFile = @ResumeFile WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ResumeFile", resumeFile);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                cmd.ExecuteNonQuery();

                this.refreshStatus();
                Response.Write("<script>alert('Resume uploaded successfully.')</script>");
            }
        }
        private string GetResumeFilePath(int studentAcctID)
        {
            string resumeFilePath = string.Empty;
            using (var db = new SqlConnection(conDB))
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

    }
}