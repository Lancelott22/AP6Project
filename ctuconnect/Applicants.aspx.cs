using iTextSharp.tool.xml.html;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.Signatures;
using System.Web.UI.HtmlControls;
using iText.IO.Image;

namespace ctuconnect
{
    public partial class Applicants : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

        private DataTable dtApplicants = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");
            }
            if (!IsPostBack && Session["IndustryEmail"] != null)
            {
                if (!IsPostBack && Request.QueryString["jobid"] != null)
                {
                    filterByJob();
                    Job_Title.InnerText = "All Applicants for " + Request.QueryString["jobtitle"].ToString() + " Position";
                    Job_Title.Visible = true;
                }
                else if (!IsPostBack && Request.QueryString["student_accID"] != null)
                {
                    filterByStudent();
                }
                else
                {
                    this.LoadApplicants();
                    Job_Title.Visible = false;
                }

                currentApplicantID = -1;
                ChangeReviewButtonText();
                ChangeScheduleButtonText();
                ChangeApplicantButton();
                endorsementButton();

                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;


            }
            else
            {
                // It's a postback, check if currentApplicantID exists in ViewState
                if (ViewState["CurrentApplicantID"] != null)
                {
                    currentApplicantID = (int)ViewState["CurrentApplicantID"];
                }
                else
                {
                    // If it doesn't exist in ViewState, set a default value
                    currentApplicantID = -1; // Set to a default value or -1
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
            con.Open();
            SqlCommand cmd = new SqlCommand("select isVerified from INDUSTRY_ACCOUNT where industry_accID = @industry_accID", con);
            cmd.Parameters.AddWithValue("@industry_accID", industry_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["isVerified"] == DBNull.Value || bool.Parse(reader["isVerified"].ToString()) == false)
                {
                    reader.Close();
                    con.Close();
                    return false;

                }
                else
                {
                    reader.Close();
                    con.Close();
                    return true;
                }

            }
            reader.Close();
            con.Close();
            return false;
        }
        void ChangeReviewButtonText()
        {
            foreach (RepeaterItem item in rptApplicant.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Button btnReview = (Button)item.FindControl("btnReview");
                    Button btnSchedule = (Button)item.FindControl("btnSchedule");
                    Label lblresumeStatus = (Label)item.FindControl("lblresumeStatus");
                    Button btnApplication = (Button)item.FindControl("btnApplication");

                    if (lblresumeStatus != null)
                    {

                        string resumeStatusText = lblresumeStatus.Text;

                        if (resumeStatusText == "Reviewed")
                        {
                            btnReview.Text = "Reviewed";
                            lblresumeStatus.BackColor = System.Drawing.Color.GreenYellow;
                            lblresumeStatus.Style["width"] = "90px";
                            lblresumeStatus.Style["padding-left"] = "0.5em";
                            lblresumeStatus.Style["height"] = "20px";
                            lblresumeStatus.Style["border-radius"] = "15px";
                        }
                        else
                        {
                            lblresumeStatus.BackColor = System.Drawing.Color.Yellow;
                            lblresumeStatus.Style["width"] = "80px";
                            lblresumeStatus.Style["padding-left"] = "0.5em";
                            lblresumeStatus.Style["height"] = "20px";
                            lblresumeStatus.Style["border-radius"] = "15px";
                            btnSchedule.Visible = false;
                            btnApplication.Visible= false;
                        }
                    }
                }
            }
        }

        void ChangeScheduleButtonText()
        {
            foreach (RepeaterItem item in rptApplicant.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Button btnApplication = (Button)item.FindControl("btnApplication");
                    Button btnSchedule = (Button)item.FindControl("btnSchedule");
                    Label lblinterviewStatus = (Label)item.FindControl("lblinterviewStatus");

                    if (lblinterviewStatus != null)
                    {

                        string interviewStatusText = lblinterviewStatus.Text;

                        if (interviewStatusText == "Scheduled")
                        {
                            btnSchedule.Text = "Reschedule";
                            lblinterviewStatus.BackColor = System.Drawing.Color.GreenYellow;
                            lblinterviewStatus.Style["width"] = "100px";
                            lblinterviewStatus.Style["padding-left"] = "0.5em";
                            lblinterviewStatus.Style["height"] = "20px";
                            lblinterviewStatus.Style["border-radius"] = "15px";
                        }
                        else
                        {
                            lblinterviewStatus.BackColor = System.Drawing.Color.Yellow;
                            lblinterviewStatus.Style["width"] = "80px";
                            lblinterviewStatus.Style["padding-left"] = "0.5em";
                            lblinterviewStatus.Style["height"] = "20px";
                            lblinterviewStatus.Style["border-radius"] = "15px";
                            btnApplication.Visible = false;
                        }
                    }

                }
            }
        }

        void ChangeApplicantButton()
        {
            foreach (RepeaterItem item in rptApplicant.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblapplicantStatus = (Label)item.FindControl("lblapplicantStatus");
                    Button btnSchedule = (Button)item.FindControl("btnSchedule");
                    Button btnApplication = (Button)item.FindControl("btnApplication");

                    if (lblapplicantStatus != null)
                    {

                        string applicantStatusText = lblapplicantStatus.Text;

                        if (applicantStatusText == "Hired")
                        {
                            btnApplication.Visible = false;
                            btnSchedule.Visible = false;
                            lblapplicantStatus.BackColor = System.Drawing.Color.GreenYellow;
                            lblapplicantStatus.Style["width"] = "100px";
                            lblapplicantStatus.Style["padding-left"] = "1.5em";
                            lblapplicantStatus.Style["height"] = "20px";
                            lblapplicantStatus.Style["border-radius"] = "15px";


                        }
                        else if (applicantStatusText == "Rejected")
                        {
                            btnApplication.Visible = false;
                            btnSchedule.Visible = false;
                            lblapplicantStatus.BackColor = System.Drawing.Color.Red;
                            lblapplicantStatus.Style["width"] = "90px";
                            lblapplicantStatus.Style["padding-left"] = "0.5em";
                            lblapplicantStatus.Style["height"] = "20px";
                            lblapplicantStatus.Style["border-radius"] = "15px";
                        }
                        else
                        {
                            //txtrequirements.Enabled = true;
                            //txtDateStart.Enabled = true;
                            //drpApplicantStatus.Visible = true;
                            //btnSubmit.Visible = true;

                            lblapplicantStatus.BackColor = System.Drawing.Color.Yellow;
                            lblapplicantStatus.Style["width"] = "80px";
                            lblapplicantStatus.Style["padding-left"] = "0.5em";
                            lblapplicantStatus.Style["height"] = "20px";
                            lblapplicantStatus.Style["border-radius"] = "15px";


                        }
                    }

                }
            }
            
        }

        void endorsementButton()
        {
            //int industryAccID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
            foreach (RepeaterItem item in rptApplicant.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {

                    Button btnendorsement = (Button)item.FindControl("btnEndorsement");
                    Label lblendorsement = (Label)item.FindControl("lblEndorsement");
                    Label endorsementStatus = (Label)item.FindControl("lblendorsementStatus");

                    string endorsement = lblendorsement.Text;
                    if (string.IsNullOrEmpty(endorsement))
                    {
                        btnendorsement.Visible = false;
                        endorsementStatus.Visible = true;
                    }
                }
            }

        }

        private void LoadApplicants()
        {

            int industryAccID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM APPLICANT WHERE industry_accID = @industryAcctID ORDER BY dateApplied DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@industryAcctID", industryAccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtApplicants);
            }

            rptApplicant.DataSource = dtApplicants;
            rptApplicant.DataBind();
        }

        
        protected void SearchApplicant_Click(object sender, EventArgs e)
        {
            string applicantss = ApplicantsID.Text;
            SearchApplicants(applicantss);
        }

        void SearchApplicants(string applicantss)
        {
            int industryAccID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM APPLICANT WHERE industry_accID = @industryAcctID and applicantFname LIKE '%" + applicantss + "%' or " +
                    "applicantLname LIKE '%" + applicantss + "%' or resumeStatus LIKE '%" + applicantss + "%' or " +
                    "interviewStatus LIKE '%" + applicantss + "%' or applicantStatus LIKE '%" + applicantss + "%' ORDER BY dateApplied DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@industryAcctID", industryAccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtApplicants);
            }

            rptApplicant.DataSource = dtApplicants;
            rptApplicant.DataBind();
            this.ChangeReviewButtonText();
            this.ChangeScheduleButtonText();
            this.ChangeApplicantButton();
            this.endorsementButton();

        }
        

        protected void EndorsementButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Endorsement")
            {
                int applicantID = Convert.ToInt32(e.CommandArgument);

                byte[] endorsementFileData = GetEndorsementFileData(applicantID);

                if (endorsementFileData != null)
                {
                    // Provide the file data for download in a new browser tab
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf"; // Set the appropriate content type
                    Response.AddHeader("content-disposition", "inline; filename=endorsement.pdf"); // Open in a new tab
                    Response.BinaryWrite(endorsementFileData);
                    Response.End();
                }
            }
        }

        private byte[] GetEndorsementFileData(int applicantID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT endorsementLetter FROM APPLICANT WHERE applicantID = @applicantID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@applicantID", applicantID);

                db.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Assuming that the result is a file path, read the file content
                    string fileName = result.ToString();
                    string filePath = "~/images/EndorsementLetter/" + fileName; // Construct the path
                    byte[] fileData = System.IO.File.ReadAllBytes(Server.MapPath(filePath));
                    return fileData;
                }

                return null; // No file found
            }
        }

        protected void ReviewButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Review")
            {
                int applicantID = Convert.ToInt32(e.CommandArgument);

                // Update the resumeStatus to "Reviewed" in the database
                UpdateResumeStatus(applicantID);

                // Retrieve and display the resume file
                byte[] resumeFileData = GetResumeFileData(applicantID);

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
            ChangeReviewButtonText();
            ChangeScheduleButtonText();
        }

        private void UpdateResumeStatus(int applicantID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT resumeStatus FROM APPLICANT WHERE applicantID = @applicantID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@applicantID", applicantID);

                db.Open();
                string result = cmd.ExecuteScalar().ToString();

                if (result == "Reviewed")
                {
                    return;
                }
                else if (result == "Pending")
                {
                    using (var db1 = new SqlConnection(conDB))
                    {
                        string query1 = "UPDATE APPLICANT SET resumeStatus = 'Reviewed', resumeReviewedDate = @ResumeReviewDate WHERE applicantID = @applicantID";
                        SqlCommand cmd1 = new SqlCommand(query1, db1);
                        cmd1.Parameters.AddWithValue("@applicantID", applicantID);
                        cmd1.Parameters.AddWithValue("@ResumeReviewDate", DateTime.Now.ToString("yyyy/MM/dd"));

                        db1.Open();
                        cmd1.ExecuteNonQuery();

                        sendResumeStatus(applicantID);
                    }
                }
            }          

        }

        void sendResumeStatus(int applicantID)
        {
            string industryName = Session["INDUSTRYNAME"].ToString();

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM APPLICANT WHERE applicantID = @ApplicantID";
                    command.Parameters.AddWithValue("@ApplicantID", applicantID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            string emailApplicant = reader["applicantEmail"].ToString();
                            string positionApplicant = reader["appliedPosition"].ToString();
                            string nameApplicant = reader["applicantFname"].ToString() + " " + reader["applicantLname"].ToString();

                            reader.Close();

                            string sendFrom = Session["IndustryEmail"].ToString();
                            MailMessage mm = new MailMessage();
                            mm.From = new MailAddress(sendFrom, "Message from " + industryName);
                            mm.To.Add(emailApplicant);
                            mm.Subject = "Resume Status";
                            mm.Body = string.Format("Dear {0}, <br /><br />" +
                                "I am writing to inform you that we have thoroughly reviewed your resume " +
                                "for the {1} position at {2}. Your qualifications " +
                                "have captured our attention, and we appreciate the effort you put into your application. " +
                                "Currently, we are in the process of evaluating all applicants and will be " +
                                "reaching out shortly with an update of your interview schedule. " +
                                "Thank you for your patience!<br/><br/>" +
                                "Best regards,<br/>" +
                                "{3}", nameApplicant, positionApplicant, industryName, industryName);
                            mm.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            NetworkCredential NetworkCred = new NetworkCredential();
                            NetworkCred.UserName = "ctuconnect00@gmail.com";
                            NetworkCred.Password = "diwvlfhaanwwfsid";
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = NetworkCred;
                            smtp.Port = 587;
                            smtp.Send(mm);

                        }
                    }
                }
            }    
        }

        private byte[] GetResumeFileData(int applicantID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT resume FROM APPLICANT WHERE applicantID = @applicantID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@applicantID", applicantID);

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

        protected void saveInterviewDetails(object sender, EventArgs e)
        {
            try
            {
                int applicantID = currentApplicantID;
                //string interviewDetails = txtInterviewDetails.Text;
                string interviewDetails = HttpUtility.HtmlEncode(txtInterviewDetails.Text);
                //string interviewScheduledDate = txtInterviewDate.Text;
                DateTime ScheduledDate = Convert.ToDateTime(txtInterviewDate.Text);

                //Check if the selected date is in the past
                if (ScheduledDate <= DateTime.Now.Date)
                {
                    Response.Write("<script>alert('Invalid Date!'); history.back();</script>");
                    lblinterviewdate.Visible = false;
                }
                else
                {

                    string interviewScheduledDate = txtInterviewDate.Text;
                    using (var db = new SqlConnection(conDB))
                    {
                        db.Open();
                        using (var cmd = db.CreateCommand())
                        {
                            string sql = "UPDATE APPLICANT SET interviewStatus = 'Scheduled', interviewDetails = @InterviewDetails, interviewDate = @InterviewDate, interviewScheduledDate = @InterviewScheduledDate WHERE applicantID = @applicantID";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@applicantID", applicantID);
                            cmd.Parameters.AddWithValue("@InterviewDetails", interviewDetails);
                            cmd.Parameters.AddWithValue("@InterviewDate", DateTime.Now.ToString("yyyy/MM/dd"));
                            cmd.Parameters.AddWithValue("@InterviewScheduledDate", interviewScheduledDate);

                            cmd.ExecuteNonQuery();

                            sendInterviewStatus(applicantID);
                        }

                    }
                }

                this.LoadApplicants();
                ChangeReviewButtonText();
                ChangeScheduleButtonText();
                ChangeApplicantButton();
                endorsementButton();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid Input!'); history.back();</script>" + ex.Message);
            }

        }

        void sendInterviewStatus(int applicantID)
        {
            try
            {

                string industryName = Session["INDUSTRYNAME"].ToString();
                string industryLocation = Session["LOCATION"].ToString();

                using (SqlConnection connection = new SqlConnection(conDB))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM APPLICANT WHERE applicantID = @ApplicantID";
                        command.Parameters.AddWithValue("@ApplicantID", applicantID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string emailApplicant = reader["applicantEmail"].ToString();
                                string positionApplicant = reader["appliedPosition"].ToString();
                                string nameApplicant = reader["applicantFname"].ToString() + " " + reader["applicantLname"].ToString();
                                DateTime interviewScheduledDate = Convert.ToDateTime(reader["interviewScheduledDate"]);
                                string interviewSched = interviewScheduledDate.ToString("MM/dd/yyyy");
                                string interviewDetails = HttpUtility.HtmlDecode(reader["interviewDetails"].ToString());


                                reader.Close();

                                string sendFrom = Session["IndustryEmail"].ToString();
                                MailMessage mm = new MailMessage();
                                mm.From = new MailAddress(sendFrom, "Message from " + industryName);
                                mm.To.Add(emailApplicant);
                                mm.Subject = "Interview Status";
                                mm.Body = string.Format("Dear {0}, <br /><br />" +
                                    "I trust this email finds you well. We are pleased to inform you that your application for <br/>" +
                                    "the {1} position at {2} has progressed successfully," +
                                    "and we would like to invite you for an interview.<br/><br/>" +
                                    "Your interview has been scheduled for:<br/><br/>" +
                                    "Date: {3}<br/>" +
                                    "Details: {4}<br/><br/>" +
                                    "We look forward to discussing your qualifications, experiences, and how they align with the<br/>" +
                                    "requirements of the position. Please be prepared to share more about your skills and insights into <br/>" +
                                    "how you can contribute to our team.<br/><br/>" +
                                    "Best regards,<br/>" +
                                    "{5}", nameApplicant, positionApplicant, industryName, interviewSched, interviewDetails, industryName);
                                mm.IsBodyHtml = true;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential();
                                NetworkCred.UserName = "ctuconnect00@gmail.com";
                                NetworkCred.Password = "diwvlfhaanwwfsid";
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;
                                smtp.Send(mm);

                                Response.Write("<script>alert('Interview is successfully scheduled..')</script>");
                            }
                        }
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong!.');</script>");
            }
        }


        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInterviewDate.Text))
            {

                if (Convert.ToDateTime(txtInterviewDate.Text) <= DateTime.Now.Date)
                {
                    lblinterviewdate.Visible = true;
                    lblinterviewdate.Text = "The selected start date must be a future date. Please choose a different start date.";
                }
                else
                {
                    lblinterviewdate.Visible = false;
                }
            }
            else
            {
                lblinterviewdate.Visible = false;
            }
           

        }

        protected void txtDateStart_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDateStart.Text))
            {
                if (Convert.ToDateTime(txtDateStart.Text) <= DateTime.Now.Date)
                {
                    lblerrordate.Visible = true;
                    lblerrordate.Text = "The selected start date must be a future date. Please choose a different start date.";
                }
                else if (txtDateStart.Text == GetInterviewDateFromDatabase(currentApplicantID))
                {
                    lblerrordate.Visible = true;
                    lblerrordate.Text = "Start date conflicts with interview date. Choose a different start date.";
                }
                else if (Convert.ToDateTime(txtDateStart.Text) <= Convert.ToDateTime(GetInterviewDateFromDatabase(currentApplicantID)))
                {
                    lblerrordate.Visible = true;
                    lblerrordate.Text = "The selected start date must be after the interview date. Please choose a different start date.";
                }
                else
                {
                    lblerrordate.Visible = false;
                }
            }
            else
            {
                // If no date is provided, hide the error message
                lblerrordate.Visible = false;
            }

        }

        private int currentApplicantID;

        protected void btnSchedule_Click(object sender, EventArgs e)
        {
            Button btnSchedule = (Button)sender;
            currentApplicantID = Convert.ToInt32(btnSchedule.CommandArgument);

            string interviewDetails = HttpUtility.HtmlDecode(GetInterviewDetailsFromDatabase(currentApplicantID));
            string interviewScheduledDate = GetInterviewDateFromDatabase(currentApplicantID);


            // Store currentApplicantID in ViewState
            ViewState["CurrentApplicantID"] = currentApplicantID;


            // Open the modal dialog and populate it with existing values
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openModal('{interviewDetails}', '{interviewScheduledDate}');", true);
            
        }

        private string GetInterviewDetailsFromDatabase(int applicantID)
        {
            string interviewDetails = string.Empty;

            using (var connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT interviewDetails FROM APPLICANT WHERE applicantID = @applicantID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@applicantID", applicantID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                interviewDetails = reader.GetString(0);
                                //interviewDetails = HttpUtility.HtmlDecode(reader.GetString(0));

                            }
                        }
                    }
                }
            }

            return interviewDetails;
        }

        private string GetInterviewDateFromDatabase(int applicantID)
        {
            DateTime interviewDate = DateTime.MinValue;
            string formattedInterviewDate = string.Empty;

            using (var connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT interviewScheduledDate FROM APPLICANT WHERE applicantID = @applicantID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@applicantID", applicantID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                interviewDate = reader.GetDateTime(0);
                                formattedInterviewDate = interviewDate.ToString("yyyy-MM-dd");
                            }
                        }
                    }
                }
            }

            return formattedInterviewDate;
        }


        protected void closeEditModal(object sender, EventArgs e)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal();", true);
        }

        protected void closeModal(object sender, EventArgs e)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeModal();", true);
        }

        protected void btnApplication_Click(object sender, EventArgs e)
        {
            Button btnApplication = (Button)sender;
            currentApplicantID = Convert.ToInt32(btnApplication.CommandArgument);
            string requirements = HttpUtility.HtmlDecode(GetRequirementsFromDatabase(currentApplicantID));
            string dateStart = GetDateStartFromDatabase(currentApplicantID);

            // Store currentApplicantID in ViewState
            ViewState["CurrentApplicantID"] = currentApplicantID;

            // Open the modal dialog and populate it with existing values
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openModal2('{requirements}', '{dateStart}');", true);
        }

        protected void Submit_ButtonClick(object sender, EventArgs e)
        {
            try
            {

                int applicantID = currentApplicantID;
                string selectedStatus = drpApplicantStatus.Text;


                if (selectedStatus == "Reject")
                {
                    txtrequirements.Text = string.Empty;
                    txtDateStart.Text = string.Empty;
                    string status = "Rejected";
                    using (var db = new SqlConnection(conDB))
                    {
                        string query = "UPDATE APPLICANT SET applicantStatus = @ApplicantStatus, applicationApprovalDate = @ApplicationDate WHERE applicantID = @applicantID";
                        SqlCommand cmd = new SqlCommand(query, db);
                        cmd.Parameters.AddWithValue("@applicantID", applicantID);
                        cmd.Parameters.AddWithValue("@ApplicantStatus", status);
                        cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now.ToString("yyyy/MM/dd"));

                        db.Open();
                        cmd.ExecuteNonQuery();
                        sendApplicationStatusReject(applicantID);
                        updateApplicant(applicantID);
                    }
                }
                else if (selectedStatus == "Hire")
                {
                    //string requirements = txtrequirements.Text;
                    string requirements = HttpUtility.HtmlEncode(txtrequirements.Text);
                    DateTime dateStart = Convert.ToDateTime(txtDateStart.Text);

                    //Check if the selected date is in the past
                    if (dateStart <= DateTime.Now.Date || txtDateStart.Text == GetInterviewDateFromDatabase(applicantID) || dateStart <= Convert.ToDateTime(GetInterviewDateFromDatabase(applicantID)))
                    {
                        Response.Write("<script>alert('Invalid Date!'); history.back();</script>");
                        lblerrordate.Visible = false;
                        return;
                    }

                    string status = "Hired";
                    using (var db = new SqlConnection(conDB))
                    {
                        string query = "UPDATE APPLICANT SET applicantStatus = @ApplicantStatus, applicationApprovalDate = @ApplicationDate, dateStart = @DateStart, requirements = @Requirements WHERE applicantID = @applicantID";
                        SqlCommand cmd = new SqlCommand(query, db);
                        cmd.Parameters.AddWithValue("@applicantID", applicantID);
                        cmd.Parameters.AddWithValue("@ApplicantStatus", status);
                        cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now.ToString("yyyy/MM/dd"));
                        cmd.Parameters.AddWithValue("@Requirements", requirements);
                        cmd.Parameters.AddWithValue("@DateStart", dateStart);

                        db.Open();
                        cmd.ExecuteNonQuery();

                        if (selectedStatus == "Hire")
                        {
                            using (SqlConnection connection = new SqlConnection(conDB))
                            {
                                connection.Open();
                                using (SqlCommand command = connection.CreateCommand())
                                {
                                    command.CommandType = CommandType.Text;
                                    command.CommandText = "SELECT jobType, student_accID, applicantFname, applicantLname, appliedPosition, resume, jobID, APPLICANT.industry_accID, StudentType, INDUSTRY_ACCOUNT.industryName, dateStart FROM APPLICANT " +
                                        "JOIN INDUSTRY_ACCOUNT ON APPLICANT.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                                        "WHERE applicantID = @ApplicantID";
                                    command.Parameters.AddWithValue("@ApplicantID", applicantID);
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            string jobType = reader["jobType"].ToString();
                                            string student_accID = reader["student_accID"].ToString();
                                            int studentID = Convert.ToInt32(student_accID);
                                            string applicantfname = reader["applicantFname"].ToString();
                                            string applicantlname = reader["applicantLname"].ToString();
                                            string jobID = reader["jobID"].ToString();
                                            int jobid = Convert.ToInt32(jobID);
                                            string industry_accID = reader["industry_accID"].ToString();
                                            int industryID = Convert.ToInt32(industry_accID);
                                            string studentType = reader["StudentType"].ToString();
                                            string WorkedAt = reader["industryName"].ToString();
                                            string position = reader["appliedPosition"].ToString();
                                            string resumefile = reader["resume"].ToString();
                                            object dateStarted = reader["dateStart"].ToString();
                                            DateTime startingDate = Convert.ToDateTime(dateStarted);
                                            reader.Close();

                                            editStudentAccount(studentID);
                                            InsertHiredList(jobType, studentID, applicantfname, applicantlname, jobid, industryID, studentType, WorkedAt, position, resumefile, startingDate);
                                            sendApplicationStatusApprove(applicantID);
                                            updateHiringApplicant(jobid);

                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Input!'); history.back();</script>");
                    return;
                }

                this.LoadApplicants();
                ChangeReviewButtonText();
                ChangeScheduleButtonText();
                ChangeApplicantButton();
                endorsementButton();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid Input!'); history.back();</script>" + ex.Message);
            }

        }

        void sendApplicationStatusReject(int applicantID)
        {
            string industryName = Session["INDUSTRYNAME"].ToString();

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM APPLICANT WHERE applicantID = @ApplicantID";
                    command.Parameters.AddWithValue("@ApplicantID", applicantID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            string emailApplicant = reader["applicantEmail"].ToString();
                            string positionApplicant = reader["appliedPosition"].ToString();
                            string nameApplicant = reader["applicantFname"].ToString() + " " + reader["applicantLname"].ToString();


                            reader.Close();

                            string sendFrom = Session["IndustryEmail"].ToString();
                            MailMessage mm = new MailMessage();
                            mm.From = new MailAddress(sendFrom, "Message from " + industryName);
                            mm.To.Add(emailApplicant);
                            mm.Subject = "Update on Your Application";
                            mm.Body = string.Format("Dear {0}, <br /><br />" +
                                "I hope this message finds you well. Thank you for your interest in the {1} position at {2} <br/>" +
                                "and for participating in our interview process. After careful consideration, we regret <br/>" +
                                "to inform you that we have chosen not to move forward with your application at this time.<br/><br/>" +
                                "We appreciate your time and effort and wish you success in your future endeavors.<br/><br/>" +
                                "Best regards,<br/>" +
                                "{3}", nameApplicant, positionApplicant, industryName, industryName);
                            mm.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            NetworkCredential NetworkCred = new NetworkCredential();
                            NetworkCred.UserName = "ctuconnect00@gmail.com";
                            NetworkCred.Password = "diwvlfhaanwwfsid";
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = NetworkCred;
                            smtp.Port = 587;
                            smtp.Send(mm);

                            Response.Write("<script>alert('Applicant is Rejected.')</script>");

                        }
                    }
                }
            }
        }

        void sendApplicationStatusApprove(int applicantID)
        {
            string industryName = Session["INDUSTRYNAME"].ToString();

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM APPLICANT WHERE applicantID = @ApplicantID";
                    command.Parameters.AddWithValue("@ApplicantID", applicantID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            string emailApplicant = reader["applicantEmail"].ToString();
                            string positionApplicant = reader["appliedPosition"].ToString();
                            string nameApplicant = reader["applicantFname"].ToString() + " " + reader["applicantLname"].ToString();
                            DateTime dateStartApplicant = Convert.ToDateTime(reader["dateStart"]);
                            string dateStart = dateStartApplicant.ToString("MM/dd/yyyy");
                            string requirementApplicant = HttpUtility.HtmlDecode(reader["requirements"].ToString());
                            int student_accID = Convert.ToInt32(reader["student_accID"].ToString());
                            int industryID = Convert.ToInt32(reader["industry_accID"].ToString());
                            object isMatchTo = reader["isMatchToSkills"].ToString();
                            bool isMatchToSkills = Convert.ToBoolean(isMatchTo);



                            reader.Close();

                            string sendFrom = Session["IndustryEmail"].ToString();
                            MailMessage mm = new MailMessage();
                            mm.From = new MailAddress(sendFrom, "Message from " + industryName);
                            mm.To.Add(emailApplicant);
                            mm.Subject = "Update on Your Application";
                            mm.Body = string.Format("Dear {0}, <br /><br />" +
                                "I am delighted to inform you that your application for the {1} position has been approved, <br/>" +
                                "and we are thrilled to welcome you to {2} Company. <br/><br/>" +
                                "Start Date: {3}<br/><br/>" +
                                "Requirements: <br/>" +
                                "{4}. <br/><br/>" +
                                "Best of luck, and we look forward to welcoming you to {5} Company!<br/><br/>" +
                                "Best regards,<br/>" +
                                "{6}", nameApplicant, positionApplicant, industryName, dateStart, requirementApplicant, industryName, industryName);
                            mm.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            NetworkCredential NetworkCred = new NetworkCredential();
                            NetworkCred.UserName = "ctuconnect00@gmail.com";
                            NetworkCred.Password = "diwvlfhaanwwfsid";
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = NetworkCred;
                            smtp.Port = 587;
                            smtp.Send(mm);


                            insertInternshipForm(student_accID, industryID, isMatchToSkills);
                        }
                    }
                }
            }
        }

        void insertInternshipForm(int student_accID, int industryID, bool isMatchToSkills)
        {
            using (SqlConnection connection = new SqlConnection(conDB))
            {
                
                connection.Open();
                using (var dmd = connection.CreateCommand())
                { //SQL Statement
                    dmd.CommandType = CommandType.Text;
                    dmd.CommandText = "INSERT INTO INTERNSHIPFORM (student_accID, industry_accID, isMatchToSkills)  "
                                    + " VALUES (@StudentAccID,@IndustryAccID,@IsMatchToSkills)";

                    dmd.Parameters.AddWithValue("@StudentAccID", student_accID);
                    dmd.Parameters.AddWithValue("@IndustryAccID", industryID);
                    dmd.Parameters.AddWithValue("@IsMatchToSkills", isMatchToSkills);
                    

                    var ctr = dmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        Response.Write("<script>alert('Applicant is successfully Hired.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data is not save'); history.back();</script>");
                    }
                }
            }
        }

        private string GetRequirementsFromDatabase(int applicantID)
        {
            string requirements = string.Empty;

            using (var connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT requirements FROM APPLICANT WHERE applicantID = @applicantID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@applicantID", applicantID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                requirements = reader.GetString(0);
                            }
                        }
                    }
                }
            }

            return requirements;
        }

        private string GetDateStartFromDatabase(int applicantID)
        {
            DateTime dateStart = DateTime.MinValue;
            string formattedDateStart = string.Empty;

            using (var connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT dateStart FROM APPLICANT WHERE applicantID = @applicantID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@applicantID", applicantID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                dateStart = reader.GetDateTime(0);
                                formattedDateStart = dateStart.ToString("yyyy-MM-dd");
                            }
                        }
                    }
                }
            }

            return formattedDateStart;
        }

        private void InsertHiredList(string jobType, int studentID, string fname, string lname, int jobID, int industryID, string studentType, string workedAt, string position, string resumefile, DateTime startingDate)
        {
            using (SqlConnection connection = new SqlConnection(conDB))
            {
                string intershipStatus = "Ongoing";
                string evaluationRequest = "no request";
                string workStatus = "Ongoing";
                connection.Open();
                using (var dmd = connection.CreateCommand())
                { //SQL Statement
                    dmd.CommandType = CommandType.Text;
                    dmd.CommandText = "INSERT INTO HIRED_LIST (student_accID, firstName, lastName, jobID, workedAt, position, dateHired, dateStarted, industry_accID, studentType, jobType, internshipStatus, resumeFile, evaluationRequest, workStatus)  "
                                    + " VALUES (@StudentAccID,@Firstname,@Lastname,@JobID,@workedAt, @position,@dateHired,@dateStarted,@IndustryAccID,@StudentType,@JobType,@InternshipStatus, @ResumeFile, @EvaluationRequest, @WorkStatus)";

                    dmd.Parameters.AddWithValue("@StudentAccID", studentID);
                    dmd.Parameters.AddWithValue("@Firstname", fname);
                    dmd.Parameters.AddWithValue("@Lastname", lname);
                    dmd.Parameters.AddWithValue("@JobID", jobID);
                    dmd.Parameters.AddWithValue("@workedAt", workedAt);
                    dmd.Parameters.AddWithValue("@position", position);
                    dmd.Parameters.AddWithValue("@dateHired", DateTime.Now.ToString("yyyy/MM/dd"));
                    dmd.Parameters.AddWithValue("@dateStarted", startingDate);
                    dmd.Parameters.AddWithValue("@IndustryAccID", industryID);
                    dmd.Parameters.AddWithValue("@StudentType", studentType);
                    dmd.Parameters.AddWithValue("@JobType", jobType);
                    dmd.Parameters.AddWithValue("@InternshipStatus", intershipStatus);
                    dmd.Parameters.AddWithValue("@ResumeFile", resumefile);
                    dmd.Parameters.AddWithValue("@EvaluationRequest", evaluationRequest);
                    dmd.Parameters.AddWithValue("@WorkStatus", workStatus);

                    var ctr = dmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        //Response.Write("<script>alert('Applicant officially hired')</script>");
                        //this.LoadApplicants();
                    }
                    else
                    {
                        Response.Write("<script>alert('Data is not save'); history.back();</script>");
                    }
                }
            }
            if (searchStudentID(studentID) == true)
            {
                using (var db = new SqlConnection(conDB))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE REFERRAL SET ReferralStatus = 'Approved' WHERE student_accID = '" + studentID + "' ";
                        var ctr = cmd.ExecuteNonQuery();
                        //if (ctr > 0)

                    }
                }
            }
        }

        private bool searchStudentID(int studentAcctID)
        {

            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select COUNT(referralID) as referStudent from REFERRAL WHERE student_accID = '" + studentAcctID + "'";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        return true;
                    }
                    reader.Close();
                }
            }
            return false;
        }

        private void editStudentAccount(int studentAcctID)
        {
            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE STUDENT_ACCOUNT SET isHired = 1 WHERE student_accID = '" + studentAcctID + "' ";
                    var ctr = cmd.ExecuteNonQuery();
                    //if (ctr > 0)

                }
            }
        }

        protected void clndrbdate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }

        void filterByJob()
        {
            if (Request.QueryString["jobid"] != null)
            {
                int industryAccID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
                int jobId = int.Parse(Request.QueryString["jobid"].ToString());
                using (var db = new SqlConnection(conDB))
                {
                    string query = "SELECT * FROM APPLICANT WHERE industry_accID = @industryAcctID and jobID = @jobId ORDER BY dateApplied DESC";
                    SqlCommand cmd = new SqlCommand(query, db);
                    cmd.Parameters.AddWithValue("@industryAcctID", industryAccID);
                    cmd.Parameters.AddWithValue("@jobId", jobId);
                    db.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtApplicants);
                }

                rptApplicant.DataSource = dtApplicants;
                rptApplicant.DataBind();
            }
        }
        void filterByStudent()
        {
            if (Request.QueryString["student_accID"] != null)
            {
                int industryAccID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
                int studentId = int.Parse(Request.QueryString["student_accID"].ToString());
                using (var db = new SqlConnection(conDB))
                {
                    string query = "SELECT * FROM APPLICANT WHERE industry_accID = @industryAcctID and student_accID = @studentId ORDER BY dateApplied DESC";
                    SqlCommand cmd = new SqlCommand(query, db);
                    cmd.Parameters.AddWithValue("@studentID", studentId);
                    cmd.Parameters.AddWithValue("@industryAcctID", industryAccID);
                    db.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtApplicants);
                }

                rptApplicant.DataSource = dtApplicants;
                rptApplicant.DataBind();
            }
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }

        protected void rptApplicant_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label jobPostID = e.Item.FindControl("JobPostID") as Label;
            Label studentAccID = e.Item.FindControl("studentAccID") as Label;
            Label applicantID = e.Item.FindControl("applicantID") as Label;
            Label MatchSkillsLabel = e.Item.FindControl("matchSkillsLabel") as Label;
            HtmlGenericControl matchBadge = (HtmlGenericControl)e.Item.FindControl("MatchedBadge");
            HtmlGenericControl skillMatch = (HtmlGenericControl)e.Item.FindControl("skillsMatch");
            int jobID = int.Parse(jobPostID.Text);
            int student_accID = int.Parse(studentAccID.Text);
            int applicant_ID = int.Parse(applicantID.Text);
            if (checkMatchedToSkills(applicant_ID))
            {
                skillMatch.Visible = true;
                matchBadge.Visible = true;
            }
            if(getMatchSkills(jobID, student_accID) != "")
            {
                MatchSkillsLabel.Text = getMatchSkills(jobID, student_accID);
            }
        }
        bool checkMatchedToSkills(int applicant_ID)
        {
            SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
            conDB.Open();
            SqlCommand cmd = new SqlCommand("SELECT isMatchToSkills FROM APPLICANT WHERE applicantID = @applicantID", conDB);
            cmd.Parameters.AddWithValue("@applicantID", applicant_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (bool.Parse(reader["isMatchToSkills"].ToString()) == true)
                {
                    conDB.Close();
                    reader.Close();
                    return true;
                }
            }
            conDB.Close();
            reader.Close();
            return false;
        }
        string getMatchSkills(int jobID, int student_accID)
        {
            SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
            conDB.Open();
            string skills = "";
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT STRING_AGG(skills, ', ') AS ConcatenatedSkills FROM RESUME WHERE EXISTS (SELECT 1 FROM HIRING WHERE CHARINDEX(skills, jobQualifications) > 0 AND jobID = @jobID AND student_accID = student_accID);", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accID);
            cmd.Parameters.AddWithValue("@jobID", jobID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                skills = reader["ConcatenatedSkills"].ToString();
                conDB.Close();
                reader.Close();
                return skills;
            }
            
            conDB.Close();
            reader.Close();
            return skills;
        }

        void updateApplicant(int applicantID)
        {
            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT jobID FROM APPLICANT WHERE applicantID = @ApplicantID";
                    command.Parameters.AddWithValue("@ApplicantID", applicantID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string jobID = reader["jobID"].ToString();
                            int jobid = Convert.ToInt32(jobID);
                            
                            updateHiringApplicant(jobid);

                        }
                    }
                }
            }
        }
        void updateHiringApplicant(int jobID)
        {
            try
            {
                using (var db = new SqlConnection(conDB))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE HIRING SET numberOfApplicant = numberOfApplicant - 1 where jobID = '" + jobID + "' ";
                        var ctr = cmd.ExecuteNonQuery();
                        //if (ctr > 0)

                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='JobPortal.aspx'</script>");
            }
        }
    }
        
}