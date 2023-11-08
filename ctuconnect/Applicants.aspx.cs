using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Applicants : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtApplicants = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Session["IndustryEmail"] == null)
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
                DropdownApplicant();


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
                    DropDownList drpApplicantStatus = (DropDownList)item.FindControl("drpApplicantStatus");

                    if (lblresumeStatus != null)
                    {

                        string resumeStatusText = lblresumeStatus.Text;

                        if (resumeStatusText == "Reviewed")
                        {
                            btnReview.Text = "Reviewed";
                            lblresumeStatus.BackColor = System.Drawing.Color.GreenYellow;
                            lblresumeStatus.Style["width"] = "85px";
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
                            drpApplicantStatus.Visible = false;
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

                    Button btnSchedule = (Button)item.FindControl("btnSchedule");
                    Label lblinterviewStatus = (Label)item.FindControl("lblinterviewStatus");
                    DropDownList drpApplicantStatus = (DropDownList)item.FindControl("drpApplicantStatus");

                    if (lblinterviewStatus != null)
                    {

                        string interviewStatusText = lblinterviewStatus.Text;

                        if (interviewStatusText == "Scheduled")
                        {
                            btnSchedule.Text = "Reschedule";
                            lblinterviewStatus.BackColor = System.Drawing.Color.GreenYellow;
                            lblinterviewStatus.Style["width"] = "90px";
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
                            drpApplicantStatus.Visible = false;
                        }
                    }

                }
            }
        }

        void DropdownApplicant()
        {
            foreach (RepeaterItem item in rptApplicant.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList drpApplicantStatus = (DropDownList)item.FindControl("drpApplicantStatus");
                    Label lblapplicantStatus = (Label)item.FindControl("lblapplicantStatus");
                    Button btnSchedule = (Button)item.FindControl("btnSchedule");

                    if (lblapplicantStatus != null)
                    {

                        string applicantStatusText = lblapplicantStatus.Text;

                        if (applicantStatusText == "Approved")
                        {
                            btnSchedule.Visible = false;
                            drpApplicantStatus.Visible = false;
                            lblapplicantStatus.BackColor = System.Drawing.Color.GreenYellow;
                            lblapplicantStatus.Style["width"] = "90px";
                            lblapplicantStatus.Style["padding-left"] = "0.5em";
                            lblapplicantStatus.Style["height"] = "20px";
                            lblapplicantStatus.Style["border-radius"] = "15px";

                        }
                        else if (applicantStatusText == "Rejected")
                        {
                            btnSchedule.Visible = false;
                            drpApplicantStatus.Visible = false;
                            lblapplicantStatus.BackColor = System.Drawing.Color.Red;
                            lblapplicantStatus.Style["width"] = "80px";
                            lblapplicantStatus.Style["padding-left"] = "0.5em";
                            lblapplicantStatus.Style["height"] = "20px";
                            lblapplicantStatus.Style["border-radius"] = "15px";
                        }
                        else
                        {
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


        protected void ReviewButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Review")
            {
                int applicantID = Convert.ToInt32(e.CommandArgument);

                // Update the resumeStatus to "Reviewed" in the database
                UpdateResumeStatus(applicantID);

                // Change the button text to "Reviewed"
                //Button button = (Button)sender;
                //button.Text = "Reviewed";


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
                string query = "UPDATE APPLICANT SET resumeStatus = 'Reviewed', resumeReviewedDate = @ResumeReviewDate WHERE applicantID = @applicantID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@applicantID", applicantID);
                cmd.Parameters.AddWithValue("@ResumeReviewDate", DateTime.Now.ToString("yyyy/MM/dd"));

                db.Open();
                cmd.ExecuteNonQuery();
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

            int applicantID = currentApplicantID;
            string interviewDetails = txtInterviewDetails.Text;
            string interviewScheduledDate = txtInterviewDate.Text;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    string sql = "UPDATE APPLICANT SET interviewStatus = 'Scheduled', interviewDetails = @InterviewDetails, interviewScheduledDate = @InterviewDate WHERE applicantID = @applicantID";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@applicantID", applicantID);
                    cmd.Parameters.AddWithValue("@InterviewDetails", interviewDetails);
                    cmd.Parameters.AddWithValue("@InterviewDate", interviewScheduledDate);

                    cmd.ExecuteNonQuery();

                }

            }
            this.LoadApplicants();
            ChangeReviewButtonText();
            ChangeScheduleButtonText();
            DropdownApplicant();

        }

        private int currentApplicantID;

        protected void btnSchedule_Click(object sender, EventArgs e)
        {
            Button btnSchedule = (Button)sender;
            currentApplicantID = Convert.ToInt32(btnSchedule.CommandArgument);

            string interviewDetails = GetInterviewDetailsFromDatabase(currentApplicantID);
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

        protected void rptApplicant_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList drpApplicantStatus = e.Item.FindControl("drpApplicantStatus") as DropDownList;

                if (drpApplicantStatus != null)
                {
                    DataRowView rowView = (DataRowView)e.Item.DataItem;
                    int applicantID = Convert.ToInt32(rowView["applicantID"]);

                    drpApplicantStatus.Attributes["applicant-id"] = applicantID.ToString();
                }
            }
        }

        protected void drpApplicantStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropdown = (DropDownList)sender;
            string selectedStatus = dropdown.SelectedValue;
            int applicantID = Convert.ToInt32(dropdown.Attributes["applicant-id"]);

            using (var db = new SqlConnection(conDB))
            {
                string query = "UPDATE APPLICANT SET applicantStatus = @ApplicantStatus, applicationApprovalDate = @ApplicationDate WHERE applicantID = @applicantID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@applicantID", applicantID);
                cmd.Parameters.AddWithValue("@ApplicantStatus", selectedStatus);
                cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now.ToString("yyyy/MM/dd"));

                db.Open();
                cmd.ExecuteNonQuery();

                if (selectedStatus == "Approved")
                {
                    using (SqlConnection connection = new SqlConnection(conDB))
                    {
                        connection.Open();
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = "SELECT jobType, student_accID, applicantFname, applicantLname, appliedPosition, resume, jobID, APPLICANT.industry_accID, StudentType, INDUSTRY_ACCOUNT.industryName FROM APPLICANT " +
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
                                    reader.Close();

                                    editStudentAccount(studentID);
                                    InsertHiredList(jobType, studentID, applicantfname, applicantlname, jobid, industryID, studentType, WorkedAt, position, resumefile);

                                }
                            }
                        }
                    }

                }
            }
            this.LoadApplicants();
            ChangeReviewButtonText();
            ChangeScheduleButtonText();
            DropdownApplicant();
        }

        private void InsertHiredList(string jobType, int studentID, string fname, string lname, int jobID, int industryID, string studentType, string workedAt, string position, string resumefile)
        {
            using (SqlConnection connection = new SqlConnection(conDB))
            {
                string intershipStatus = "Ongoing";
                string evaluationRequest = "no request";
                connection.Open();
                using (var dmd = connection.CreateCommand())
                { //SQL Statement
                    dmd.CommandType = CommandType.Text;
                    dmd.CommandText = "INSERT INTO HIRED_LIST (student_accID, firstName, lastName, jobID, workedAt, position,dateHired,  industry_accID, studentType, jobType, internshipStatus, resumeFile, evaluationRequest)  "
                                    + " VALUES (@StudentAccID,@Firstname,@Lastname,@JobID,@workedAt, @position,@dateHired, @IndustryAccID,@StudentType,@JobType,@InternshipStatus, @ResumeFile, @EvaluationRequest)";

                    dmd.Parameters.AddWithValue("@StudentAccID", studentID);
                    dmd.Parameters.AddWithValue("@Firstname", fname);
                    dmd.Parameters.AddWithValue("@Lastname", lname);
                    dmd.Parameters.AddWithValue("@JobID", jobID);
                    dmd.Parameters.AddWithValue("@workedAt", workedAt);
                    dmd.Parameters.AddWithValue("@position", position);
                    dmd.Parameters.AddWithValue("@dateHired", DateTime.Now.ToString("yyyy/MM/dd"));
                    dmd.Parameters.AddWithValue("@IndustryAccID", industryID);
                    dmd.Parameters.AddWithValue("@StudentType", studentType);
                    dmd.Parameters.AddWithValue("@JobType", jobType);
                    dmd.Parameters.AddWithValue("@InternshipStatus", intershipStatus);
                    dmd.Parameters.AddWithValue("@ResumeFile", resumefile);
                    dmd.Parameters.AddWithValue("@EvaluationRequest", evaluationRequest);

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

    }
}