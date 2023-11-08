using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.DynamicData;
using System.Runtime.ConstrainedExecution;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Web.Caching;
using System.Threading;
using System.ComponentModel;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using iTextSharp.tool.xml.html;
using Microsoft.Ajax.Utilities;

namespace ctuconnect
{

    public partial class JobPortal : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["StudentEmail"] == null)
            {
                Response.Redirect("LoginStudent.aspx");

            }
            else if (!IsPostBack)
            {
                JobBind();
                TotalJob();
            }
            DisplayStudentInfo();
        }
        void JobBind()
        {
            string studentCourse = Session["Student_COURSE"].ToString();
            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";
            if (Usertype == "Intern")
            {
                jobtype = "internship";
            }
            SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' ORDER BY jobPostedDate DESC", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobHiring.DataSource = ds;
            JobHiring.DataBind();
            if (JobHiring.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
        }
        protected void ApplyJob_Command(object sender, CommandEventArgs e)
        {
            if (!IsAsync)
            {
                requiredError.Visible = false;
                job_Type.SelectedIndex = 0;
            }
            int jobId = int.Parse(e.CommandArgument.ToString());
            if (checkResume())
            {
              /*  if (isCurrentlyHired())
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('You are currently hired in a company. You cannot apply for another job now. Contact your company if there is a problem.');", true);
                    //Response.Write("<script>alert('You are currently hired in a company. You cannot apply for another job now. Contact your company if there is a problem.');</script>");
                }
                else
                {*/
                    if (checkJobApplied(jobId) == true)
                    {
                        SubmitApply.Enabled = true;
                        SubmitApply.Text = "Go to My Application";
                        SubmitApply.CommandName = "Applied";
                        SubmitApply.CssClass = "buttonStyleSubmit";
                        CancelorClose.InnerText = "Close";
                        CancelorClose.Attributes["class"] = "btn btn-secondary";
                        JobApply.Visible = false;
                        AlreadyApplied.Visible = true;
                    }
                    else
                    {
                        SubmitApply.Enabled = true;
                        SubmitApply.Text = "Submit Application";
                        SubmitApply.CommandName = "";
                        SubmitApply.CssClass = "buttonStyleSubmit";
                        CancelorClose.InnerText = "Cancel";
                        CancelorClose.Attributes["class"] = "btn btn-danger";
                        JobApply.Visible = true;
                        AlreadyApplied.Visible = false;
                    }
                    ApplyForJob.Value = e.CommandName.ToString();
                    Name.Value = Session["FNAME"].ToString() + " " + Session["LNAME"].ToString();
                    Resume.Value = Session["ResumeFile"].ToString();
                    applyJobId.Text = jobId.ToString();
                    applyIndustryId.Text = getApplyIndustryId(jobId).ToString();
                    if (Session["STATUSorTYPE"].ToString() == "Intern")
                    {
                        job_Type.SelectedIndex = 1;
                        job_Type.Disabled = true;
                    }
                    if (Session["STATUSorTYPE"].ToString() == "Alumni")
                    {
                        Endorsement_LetterBox.Attributes.Add("style", "display:none");
                    }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showModalFunction();", true);
                //}

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertResume", "alert('Please upload or create resume first before applying job.');document.location='Resume.aspx';", true);
            }

        }
        private int getApplyIndustryId(int jobId)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select industry_accID from HIRING where jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int industryAccId = int.Parse(reader["industry_accID"].ToString());
            reader.Close();
            return industryAccId;
        }

        protected void SubmitApply_Command(object sender, CommandEventArgs e) //submitApplication
        {
            if (SubmitApply.CommandName == "Applied")
            {
                Response.Redirect("MyJobApplication.aspx");
            }
            int alumni_accId = -1;
            int student_accId = -1;

            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";
            if (Usertype == "Alumni")
            {
                alumni_accId = int.Parse(Session["Alumni_accID"].ToString());
                if (job_Type.Value != "" || job_Type.Value != string.Empty)
                {
                    jobtype = job_Type.Value;
                }
                else
                {
                    requiredError.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showModalFunction();", true);
                    return;
                }
            }
            else if (Usertype == "Intern")
            {
                student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
                jobtype = job_Type.Value;
            }
            string position = ApplyForJob.Value.ToString();
            string applicantFName = Session["FNAME"].ToString();
            string applicantLName = Session["LNAME"].ToString();
            DateTime dateApplied = DateTime.Now;
            string resume = Session["ResumeFile"].ToString();
            int jobID = int.Parse(applyJobId.Text.ToString());
            int industry_accId = int.Parse(applyIndustryId.Text.ToString());
            string endorsementLetterFile = "";

            if (EndorsementLetter.HasFile != false)
            {
                endorsementLetterFile = getUploadEndorsementLetter();
                if (endorsementLetterFile == null)
                {
                    return;
                }
            }

            conDB.Open();
            if (Usertype == "Alumni")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (jobType,alumni_accID,applicantFName, appliedPosition, applicantLName, industry_accID, dateApplied, resume,resumeStatus,interviewStatus,applicantStatus, jobID, StudentType) " +
                    "Values( @jobtype, @student_accId, @applicantFName, @applicantLName,@appliedPosition,@industry_accId, @dateApplied, @resume,@resumeStatus,@interviewStatus,@applicantStatus,@jobID,@studentType)", conDB);

                cmd.Parameters.AddWithValue("@jobtype", jobtype);
                cmd.Parameters.AddWithValue("@student_accId", alumni_accId);
                cmd.Parameters.AddWithValue("@applicantFName", applicantFName);
                cmd.Parameters.AddWithValue("@applicantLName", applicantLName);
                cmd.Parameters.AddWithValue("@appliedPosition", position);
                cmd.Parameters.AddWithValue("@industry_accId", industry_accId);
                cmd.Parameters.AddWithValue("@dateApplied", dateApplied);
                cmd.Parameters.AddWithValue("@resume", resume);
                cmd.Parameters.AddWithValue("@resumeStatus", "Pending");
                cmd.Parameters.AddWithValue("@interviewStatus", "Pending");
                cmd.Parameters.AddWithValue("@applicantStatus", "Pending");
                cmd.Parameters.AddWithValue("@jobID", jobID);
                cmd.Parameters.AddWithValue("@studentType", Usertype);
                int ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {

                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully submitted your job application.');document.location='MyJobApplication.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in applying the job. Please try again..');", true);
                }
            }
            else if (Usertype == "Intern")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (jobType,student_accID,applicantFName, applicantLName, appliedPosition, industry_accID,dateApplied, resume,resumeStatus,interviewStatus,applicantStatus, jobID, StudentType, EndorsementLetter) " +
                  "Values(@jobtype, @student_accId, @applicantFName, @applicantLName,@appliedPosition,@industry_accId, @dateApplied, @resume,@resumeStatus,@interviewStatus,@applicantStatus,@jobID, @studentType,@endorsementLetter)", conDB);

                cmd.Parameters.AddWithValue("@jobtype", jobtype);
                cmd.Parameters.AddWithValue("@student_accId", student_accId);
                cmd.Parameters.AddWithValue("@applicantFName", applicantFName);
                cmd.Parameters.AddWithValue("@applicantLName", applicantLName);
                cmd.Parameters.AddWithValue("@appliedPosition", position);
                cmd.Parameters.AddWithValue("@industry_accId", industry_accId);
                cmd.Parameters.AddWithValue("@dateApplied", dateApplied);
                cmd.Parameters.AddWithValue("@resume", resume);
                cmd.Parameters.AddWithValue("@resumeStatus", "Pending");
                cmd.Parameters.AddWithValue("@interviewStatus", "Pending");
                cmd.Parameters.AddWithValue("@applicantStatus", "Pending");
                cmd.Parameters.AddWithValue("@jobID", jobID);
                cmd.Parameters.AddWithValue("@studentType", Usertype);
                cmd.Parameters.AddWithValue("@endorsementLetter", endorsementLetterFile);
                int ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully submitted your job application.');document.location='MyJobApplication.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in applying the job. Please try again..');", true);
                }
            }
            conDB.Close();


            JobBind();
        }
        private string getUploadEndorsementLetter()
        {
            HttpPostedFile endorsementLetterFile = EndorsementLetter.PostedFile; // upload file
            string filename = Path.GetFileName(endorsementLetterFile.FileName); //to check the filename
            string fileExtension = Path.GetExtension(filename).ToLower(); //to get the extension filename
            int filesize = endorsementLetterFile.ContentLength; //to get the filesize

            string logpath = Server.MapPath("~/images/EndorsementLetter/"); //creating a drive to upload or save the image

            string filepath = Path.Combine(logpath, filename);
            if (fileExtension == ".pdf" || fileExtension.Equals(".docx") || fileExtension.Equals(".doc")) //check the filename extension
            {
                if (File.Exists(filepath))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertFileName", "alert('A file with the same name already exists. Please choose a different name.');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showModalFunction();", true);
                    return null;// Return to stop further execution
                }
                else
                {
                    endorsementLetterFile.SaveAs(filepath); //save the file in the folder or drive
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertFileExt", "alert('The file extension of the uploaded file is not acceptable');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showModalFunction();", true);
                return null;
            }

            return filename;
        }

        bool checkResume() //check resume
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select resumeFile from STUDENT_ACCOUNT where student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["resumeFile"] == null || reader["resumeFile"].ToString() == string.Empty)
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

            return false;
        }
        bool checkJobApplied(int jobID) //check if already applied to selected job
        {

            int selectedJobID = jobID;
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select * from APPLICANT Where jobID = @jobId and student_accID = @student_accId", conDB);
            cmd.Parameters.AddWithValue("@jobId", selectedJobID);
            cmd.Parameters.AddWithValue("@student_accId", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                conDB.Close();
                return true;
            }
            conDB.Close();
            return false;
        }

        protected void JobHiring_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label jobPostID = e.Item.FindControl("JobPostID") as Label;
            int JobId = int.Parse(jobPostID.Text);
            Button btn = e.Item.FindControl("ApplyJob") as Button;

            if (checkJobApplied(JobId) == true)
            {
                btn.Text = "Applied";
            }
            else if (checkJobApplied(JobId) == false)
            {
                btn.Text = "Apply";
            }

            Label jobPostedDate = (Label)e.Item.FindControl("JobPostedDate");
            ((Label)e.Item.FindControl("timeAgoMsg")).Text = postedDateTimeAgo(Convert.ToDateTime(jobPostedDate.Text));

            DateTime postedDate = Convert.ToDateTime(jobPostedDate.Text);
            DateTime currentDate = DateTime.Now;
            TimeSpan timegap = currentDate - postedDate;

            if (timegap.Days < 1)
            {
                HtmlGenericControl Badge = (HtmlGenericControl)e.Item.FindControl("badge");
                Badge.Visible = true;
                /* HtmlGenericControl JobList = (HtmlGenericControl)e.Item.FindControl("jobList");
                 JobList.Style.Add("background-color", "#f0e789");*/
            }

        }
        private void DisplayStudentInfo()
        {
            if (!string.IsNullOrEmpty(Session["PROFILE"].ToString()))
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/" + Session["PROFILE"].ToString();
            }
            else
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/defaultprofile.jpg";
            }

            StudentName.Text = Session["FNAME"].ToString() + " " + Session["LNAME"].ToString();
            StudentID.Text = Session["STUDENT_ID"].ToString();
        }
        private bool isCurrentlyHired()
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select isHired from STUDENT_ACCOUNT where student_accID = @student_accId", conDB);
            cmd.Parameters.AddWithValue("@student_accId", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["isHired"].ToString() == null || reader["isHired"].ToString() == string.Empty)
                {
                    reader.Close();
                    conDB.Close();
                    return false;
                }
                else if (bool.Parse(reader["isHired"].ToString()) == true)
                {
                    reader.Close();
                    conDB.Close();
                    return true;

                }
                else
                {
                    reader.Close();
                    conDB.Close();
                    return false;
                }
            }
            conDB.Close();
            return false;
        }
        private string postedDateTimeAgo(DateTime postDateTime) //check the time gap between posted date and current date
        {
            string timeAgoMsg = "";
            DateTime currentDate = DateTime.Now;
            TimeSpan timegap = currentDate - postDateTime;
            if (timegap.Days >= (365 * 2))
            {
                timeAgoMsg = string.Concat((((timegap.Days) / 30) / 12), " years ago");
            }
            else if (timegap.Days >= 365)
            {
                timeAgoMsg = string.Concat((((timegap.Days) / 30) / 12), " year ago");
            }
            else if (timegap.Days >= (30 * 2))
            {
                timeAgoMsg = string.Concat("About ", ((timegap.Days) / 30), " months ago");
            }
            else if (timegap.Days >= 31)
            {
                timeAgoMsg = string.Concat("About ", ((timegap.Days) / 30), " month ago");
            }
            else if (timegap.Days > 1)
            {
                timeAgoMsg = string.Concat(timegap.Days, " days ago");
            }
            else if (timegap.Days == 1)
            {
                timeAgoMsg = "Yesterday";
            }
            else if (timegap.Hours >= 2)
            {
                timeAgoMsg = string.Concat("About ", timegap.Hours, " hours ago");
            }
            else if (timegap.Hours >= 1)
            {
                timeAgoMsg = string.Concat("About ", timegap.Hours, " hour ago");
            }
            else if (timegap.Minutes > 1)
            {
                timeAgoMsg = string.Concat("About ", timegap.Minutes, " minutes ago");
            }
            else if (timegap.Minutes == 1)
            {
                timeAgoMsg = string.Concat("About ", timegap.Minutes, " minute ago");
            }
            else
            {
                timeAgoMsg = "Just Now";
            }

            return timeAgoMsg;
        }

        protected void JobDetails_Command(object sender, CommandEventArgs e)
        {
            System.Threading.Thread.Sleep(700);
            int jobId = int.Parse(e.CommandArgument.ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select *, CONVERT(nvarchar,jobPostedDate, 1) as DatePosted from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID where jobID = @jobID", conDB);
            cmd.Parameters.AddWithValue("@jobID", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Job_ID.Text = reader["jobID"].ToString();
                IndstryLogo.Src = "~/images/IndustryProfile/" + reader["industryPicture"].ToString();
                IndustryName.Text = reader["industryName"].ToString();
                JobTitle.Text = reader["jobTitle"].ToString();
                JobDescription.Text = reader["jobDescription"].ToString();
                JobType.Text = reader["jobType"].ToString();
                JobLocation.Text = reader["jobLocation"].ToString();
                JobCourse.Text = reader["jobCourse"].ToString();
                JobQualification.Text = reader["jobQualifications"].ToString();
                ApplicationInstruction.Text = reader["applicationInstruction"].ToString();
                IndustryID.Text = reader["industry_accID"].ToString();
                DatePosted.Text = reader["DatePosted"].ToString();

                if (reader["salaryRange"] == null || reader["salaryRange"].ToString() == string.Empty)
                {
                    salaryData.Visible = false;
                    SalaryRange.Visible = false;
                    SalaryRange.Attributes["style"] = "display:none";
                    salaryData.Attributes["style"] = "display:none";
                }
                else
                {
                    salaryData.Visible = true;
                    SalaryRange.Text = reader["salaryRange"].ToString();
                    SalaryRange.Visible = true;
                    SalaryRange.Attributes["style"] = "display:inline";
                    salaryData.Attributes["style"] = "display:inline";
                }

            }
            reader.Close();
            conDB.Close();

            JobDetailBox.Visible = true;

            ListViewItem currentItem = (sender as Button).NamingContainer as ListViewItem;
            foreach (ListViewItem item in JobHiring.Items)
            {
                HtmlGenericControl JobBox = item.FindControl("jobList") as HtmlGenericControl;
                if (currentItem.DataItemIndex == item.DataItemIndex)
                {
                    JobBox.Attributes["class"] = "row d-flex align-items-center jobBoxSelected";
                }
                else
                {
                    JobBox.Attributes["class"] = "row d-flex align-items-center jobBox";
                }
            }
        }

        protected void JobHiring_PagePropertiesChanged(object sender, EventArgs e)
        {
            /* DataPager listPager = JobHiring.FindControl("ListViewPager") as DataPager;
            (JobHiring.FindControl("ListViewPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            listPager.SetPageProperties(listPager.PageSize, listPager.TotalRowCount, false);*/
            JobBind();
        }
        void TotalJob()
        {
            string studentCourse = Session["Student_COURSE"].ToString();
            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";
            if (Usertype == "Intern")
            {
                jobtype = "internship";
            }
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
               
                    totalJob.InnerText = "Total " + reader["TotalJob"].ToString() + " jobs found";
            }
            reader.Close();
            conDB.Close();
        }
    }
}