﻿using System;
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
using iText.Layout.Font;

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
            else if (!IsPostBack && Session["StudentEmail"] != null && Session["STATUSorTYPE"].ToString() == "Alumni" && bool.Parse(Session["IsAnswered"].ToString()) == false)
            {
                Response.Redirect("Alumni_Employment_Form.aspx");
            }
            else if (!IsPostBack)
            {
                JobBind();
                TotalJob();
                DisplayStudentInfo();
                if(Session["STATUSorTYPE"].ToString() == "Intern")
                {
                    JobTypeSort.Enabled = false;
                    JobTypeSort.SelectedValue = "internship";
                }
            }
            if (checkResume())
            {
                resumeIcon.Attributes.Add("title", "Resume Uploaded");
                resumeIcon.Attributes.Add("class", "fa fa-address-card-o m-1 text-success");
            }
            else
            {
                resumeIcon.Attributes.Add("title", "No Resume");
                resumeIcon.Attributes.Add("class", "fa fa-address-card-o m-1 text-danger");
            }
           
        }
        void JobBind()
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            string studentCourse = Session["Student_COURSE"].ToString();
            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";
            SqlCommand cmd = new SqlCommand();
            if (Usertype == "Intern")
            {
                jobtype = "internship";
                cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' " +
               "and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ORDER BY jobPostedDate DESC", conDB);

            }else if (Usertype == "Alumni")
            {
                cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE " +
                "isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ORDER BY jobPostedDate DESC", conDB);

            }
            cmd.Parameters.AddWithValue("@studentAccID", student_accId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobHiring.DataSource = ds;
            JobHiring.DataBind();
            if (JobHiring.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
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
            ApplyForJob.Value = e.CommandName.ToString();
            if (checkResume())
            {
                /*  if (isCurrentlyHired())
                  {
                      ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('You are currently hired in a company. You cannot apply for another job now. Contact your company if there is a problem.');", true);
                      //Response.Write("<script>alert('You are currently hired in a company. You cannot apply for another job now. Contact your company if there is a problem.');</script>");
                  }
                  else
                  {*/
                if (checkApplicantNeeded(jobId))
                {
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
                    Name.Value = Session["STUD_FNAME"].ToString() + " " + Session["STUD_LNAME"].ToString();
                    Resume.Value = getResume();
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
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertJobError", "alert('Sorry! "+ ApplyForJob.Value + " Position is Currently Unavailable due to Reached Applicant Limit.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertResume", "alert('Please upload or create resume first before applying job.');document.location='Resume.aspx';", true);
            }

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
        bool checkApplicantNeeded(int jobId)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select totalPositionNeeded, numberOfApplicant from HIRING Where jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int currentApplied = int.Parse(reader["numberOfApplicant"].ToString());
                int totalNeeded = int.Parse(reader["totalPositionNeeded"].ToString());
                if (currentApplied != totalNeeded)
                {
                    conDB.Close();
                    return true;
                }
                else
                {
                    conDB.Close();
                    return false;
                }              
            }

            conDB.Close();
            return false;
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
            conDB.Close();
            return industryAccId;
          
        }

        protected void SubmitApply_Command(object sender, CommandEventArgs e) //submitApplication
        {
            if (SubmitApply.CommandName == "Applied")
            {
                Response.Redirect("MyJobApplication.aspx");
            }
           /* int alumni_accId = -1;*/
            int student_accId = -1;

            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";
            string applicantEmail = getPersonalEmail();
            if (Usertype == "Alumni")
            {
                
                
                if (job_Type.Value != "" || job_Type.Value != string.Empty)
                {
                    student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
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
            string applicantFName = Session["STUD_FNAME"].ToString();
            string applicantLName = Session["STUD_LNAME"].ToString();
            DateTime dateApplied = DateTime.Now;
            string resume = getResume();
            int jobID = int.Parse(applyJobId.Text.ToString());
            int industry_accId = int.Parse(applyIndustryId.Text.ToString());
            string endorsementLetterFile = "";
            bool isMatchSkills = checkMatch(jobID);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (jobType,student_accId,applicantFName, applicantLName, appliedPosition, industry_accID, dateApplied, resume,resumeStatus,interviewStatus,applicantStatus, jobID, StudentType, isRead, isRemove,applicantEmail, isMatchToSkills) " +
                    "Values( @jobtype, @student_accId, @applicantFName, @applicantLName,@appliedPosition,@industry_accId, @dateApplied, @resume,@resumeStatus,@interviewStatus,@applicantStatus,@jobID,@studentType, @isRead, @isRemove,@applicantEmail, @isMatchToSkills)", conDB);

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
                cmd.Parameters.AddWithValue("@isRead", 0);
                cmd.Parameters.AddWithValue("@isRemove", 0);
                cmd.Parameters.AddWithValue("@applicantEmail", applicantEmail);
                cmd.Parameters.AddWithValue("@isMatchToSkills", isMatchSkills);
                int ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    updateHiringApplicant(jobID);
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully submitted your job application for "+ position + " position.');document.location='MyJobApplication.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in applying the job. Please try again..');", true);
                }
            }
            else if (Usertype == "Intern")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (jobType,student_accID,applicantFName, applicantLName, appliedPosition, industry_accID,dateApplied, resume,resumeStatus,interviewStatus,applicantStatus, jobID, StudentType, EndorsementLetter, isRead, isRemove,applicantEmail,isMatchToSkills) " +
                  "Values(@jobtype, @student_accId, @applicantFName, @applicantLName,@appliedPosition,@industry_accId, @dateApplied, @resume,@resumeStatus,@interviewStatus,@applicantStatus,@jobID, @studentType,@endorsementLetter, @isRead, @isRemove,@applicantEmail, @isMatchToSkills)", conDB);

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
                cmd.Parameters.AddWithValue("@isRead", 0);
                cmd.Parameters.AddWithValue("@isRemove", 0);
                cmd.Parameters.AddWithValue("@applicantEmail", applicantEmail);
                cmd.Parameters.AddWithValue("@isMatchToSkills", isMatchSkills);
                int ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    updateHiringApplicant(jobID);
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully submitted your job application for "+ position + " position.');document.location='MyJobApplication.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in applying the job. Please try again..');", true);
                }
            }
            conDB.Close();


            JobBind();
        }
        void updateHiringApplicant(int jobID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE HIRING SET numberOfApplicant = numberOfApplicant + 1 where jobID = '" + jobID + "'", conDB);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='JobPortal.aspx'</script>");
            }
        }
        string getPersonalEmail()
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            string email = "";
           conDB.Open();
            SqlCommand cmd = new SqlCommand("select personalEmail,email from STUDENT_ACCOUNT where student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {   
                if (reader["personalEmail"] == DBNull.Value)
                {
                    email = reader["email"].ToString();
                    conDB.Close();
                    reader.Close(); 
                    return email;
                }
                else if(reader["personalEmail"].ToString() == "")
                {
                    email = reader["email"].ToString();
                    conDB.Close();
                    reader.Close();
                    return email;
                }
                else
                {    
                    email = reader["personalEmail"].ToString();
                    conDB.Close();
                    reader.Close();
                    return email;
                }
            }
            conDB.Close();
            reader.Close();
            return email;
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
            reader.Close();
            conDB.Close();
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
            HtmlGenericControl matchBadge = (HtmlGenericControl)e.Item.FindControl("MatchedBadge");
            HtmlGenericControl Badge = (HtmlGenericControl)e.Item.FindControl("badge");
            if (timegap.Days < 1)
            {
               
                Badge.Visible = true;
                /* HtmlGenericControl JobList = (HtmlGenericControl)e.Item.FindControl("jobList");
                 JobList.Style.Add("background-color", "#f0e789");*/
            }

            if(checkMatch(JobId))
            {
                
                matchBadge.Visible = true;
            }

            if (Badge.Visible == true && matchBadge.Visible == true)
            {
                matchBadge.Attributes["style"] = "left:55px";
            }
        }
        private void DisplayStudentInfo()
        {
                       
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select firstName, lastName, studentPicture, course from STUDENT_ACCOUNT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID where student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["STUD_FNAME"] = reader["firstName"];
                Session["STUD_LNAME"] = reader["lastName"];
                Session["PROFILE"] = reader["studentPicture"];
                StudentCourse.Text = reader["course"].ToString();
            }
            conDB.Close();
            reader.Close();

            StudentName.Text = Session["STUD_FNAME"].ToString() + " " + Session["STUD_LNAME"].ToString();
            StudentID.Text = Session["STUDENT_ID"].ToString();

            if (!string.IsNullOrEmpty(Session["PROFILE"].ToString()))
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/" + Session["PROFILE"].ToString();
            }
            else
            {
                profileImage.ImageUrl = "~/images/StudentProfiles/defaultprofile.jpg";
            }
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
                JobDescription.Text = HttpUtility.HtmlDecode(reader["jobDescription"].ToString());
                JobType.Text = reader["jobType"].ToString();
                JobLocation.Text = reader["jobLocation"].ToString();
                JobCourse.Text = reader["jobCourse"].ToString();
                JobQualification.Text = HttpUtility.HtmlDecode(reader["jobQualifications"].ToString());
                ApplicationInstruction.Text = reader["applicationInstruction"].ToString();
                IndustryID.Text = reader["industry_accID"].ToString();
                DatePosted.Text = reader["DatePosted"].ToString();
                TotalApplicantsNeeded.Text = reader["numberOfApplicant"].ToString() + " Applied" + " / " + reader["totalPositionNeeded"].ToString() + " Needed";

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

            string url = "ViewIndustryProfile.aspx?industry_accID=" + Server.UrlEncode(IndustryID.Text);
            viewIndustryProfileLink.HRef = url;
        }

        protected void JobHiring_PagePropertiesChanged(object sender, EventArgs e)
        {
            string Usertype = Session["STATUSorTYPE"].ToString();
            /* DataPager listPager = JobHiring.FindControl("ListViewPager") as DataPager;
            (JobHiring.FindControl("ListViewPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            listPager.SetPageProperties(listPager.PageSize, listPager.TotalRowCount, false);*/
            if (Usertype == "Intern")
            {
                if (txtsearchJob.Text != string.Empty)
                {
                    JobBindBySearch();
                }
                else if(ddlDateFilter.SelectedValue != "All" && ddlDateFilter.SelectedValue != "0")
                {
                    FilterJobsByDate();
                }
                else
                {
                    JobBind();
                }
                
            }
           
            else if (Usertype == "Alumni")
            {
                if (JobTypeSort.SelectedValue != "All" && JobTypeSort.SelectedValue != "0")
                {
                    JobBindByType();
                }
                else if (ddlDateFilter.SelectedValue != "All" && ddlDateFilter.SelectedValue != "0")
                {
                    FilterJobsByDate();
                }
                else if(txtsearchJob.Text != string.Empty)
                {
                    JobBindBySearch();
                }
                else
                {
                    JobBind();
                }
            }       
        }
        void TotalJob()
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            string studentCourse = Session["Student_COURSE"].ToString();
            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";
            
            conDB.Open();
            SqlCommand cmd = new SqlCommand();
            if (Usertype == "Intern")
            {
                jobtype = "internship";
                if(txtsearchJob.Text != string.Empty)
                {
                    cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' and " +
                    " jobTitle LIKE '%" + txtsearchJob.Text + "%' and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID)", conDB);

                }
                else if(ddlDateFilter.SelectedValue != "All" && ddlDateFilter.SelectedValue != "0")
                {
                    int days = Convert.ToInt32(ddlDateFilter.SelectedValue);
                    DateTime startDate = DateTime.Today.AddDays(-days);
                    cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' and " +
                   " jobPostedDate >= '"+ startDate + "' and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID)", conDB);
                }
                else
                {
                    cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' " +
                    " and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID)", conDB);

                }
            }
            else if(Usertype == "Alumni")
            {
                if(JobTypeSort.SelectedValue != "All" && JobTypeSort.SelectedValue != "0")
                {
                    cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobType LIKE '%" + JobTypeSort.SelectedValue + "%' " +
                    "and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID)", conDB);

                }
                else if (ddlDateFilter.SelectedValue != "All" && ddlDateFilter.SelectedValue != "0")
                {
                    int days = Convert.ToInt32(ddlDateFilter.SelectedValue);
                    DateTime startDate = DateTime.Today.AddDays(-days);
                    cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobPostedDate >= '" + startDate + "' " +
                  " and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ", conDB);
                }
                else if(txtsearchJob.Text != string.Empty)
                {
                    cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobTitle LIKE '%" + txtsearchJob.Text + "%' " +
                   " and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ", conDB);
                }
                else
                {
                    cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE " +
                 " isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ", conDB);
                }

            }
            cmd.Parameters.AddWithValue("@studentAccID", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {              
                    totalJob.InnerText = "Total " + reader["TotalJob"].ToString() + " jobs found";
            }
            reader.Close();
            conDB.Close();
        }

        string getResume()
        {
            string resume = "";
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select resumeFile from STUDENT_ACCOUNT where student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                resume = reader["resumeFile"].ToString();
                conDB.Close();
                reader.Close();
                return resume;
            }
            conDB.Close();
            reader.Close();
            return resume;
        }

        protected void ReportJob_Command(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showReportModal();", true);
            report_jobID.Text = Job_ID.Text;
            Report_JobTitle.InnerText = JobTitle.Text;
            Report_IndustryName.InnerText = IndustryName.Text;

            if (!IsAsync)
            {
                submitErrorMsg.Visible = false;
                problemType.Value = string.Empty;
                reportDetails.Value = string.Empty;
            }
        }
        bool checkMatch(int jobID)
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT skills FROM RESUME WHERE student_accID = @student_accID AND EXISTS (SELECT 1 FROM HIRING WHERE CHARINDEX(skills, jobQualifications) > 0 AND jobID = @jobID);", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accId);
            cmd.Parameters.AddWithValue("@jobID", jobID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["skills"] == DBNull.Value)
                {
                    conDB.Close();
                    reader.Close();
                    return false;
                }else if (reader.HasRows)
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
        protected void SubmitReport_Command(object sender, CommandEventArgs e)
        {
            int reportJobId = int.Parse(report_jobID.Text);
            string problem_Type = problemType.Value;
            string report_Details = reportDetails.Value;
            string Usertype = Session["STATUSorTYPE"].ToString();
            int user_accID = -1;
            if(Usertype == "Alumni")
            {
                user_accID = int.Parse(Session["Student_ACC_ID"].ToString());
            }
            else if (Usertype == "Intern")
            {
                user_accID = int.Parse(Session["Student_ACC_ID"].ToString());
            }

            if (string.IsNullOrEmpty(problemType.Value) || string.IsNullOrEmpty(reportDetails.Value))
            {
                submitErrorMsg.Visible = true;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showReportModal();", true);
                return;
            }
            else
            {
                conDB.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO REPORT_JOB (user_accID, jobID, problemType, reportDetails, reportDate) " +
                  "Values(@user_accID, @jobID, @problemType, @reportDetails, @reportDate)", conDB);

                cmd.Parameters.AddWithValue("@user_accID", user_accID);
                cmd.Parameters.AddWithValue("@jobID", reportJobId);
                cmd.Parameters.AddWithValue("@problemType", problem_Type);
                cmd.Parameters.AddWithValue("@reportDetails", report_Details);
                cmd.Parameters.AddWithValue("@reportDate", DateTime.Now);
                int ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully submitted your report.');$('.modal-backdrop').removeClass('modal-backdrop');$('body').removeClass('modal-open');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in reporting the job. Please try again later..');$('.modal-backdrop').removeClass('modal-backdrop');$('body').removeClass('modal-open');", true);
                }
            }
        }

        protected void JobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Usertype = Session["STATUSorTYPE"].ToString();
            if (Usertype == "Alumni")
            {
                txtsearchJob.Text = string.Empty;
                ddlDateFilter.SelectedValue = "0";
            }
            
            JobBindByType();
            
        }
        void JobBindByType()
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            string studentCourse = Session["Student_COURSE"].ToString();
            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";

            SqlCommand cmd = new SqlCommand();
            /*if (Usertype == "Intern")
            {
                if(JobTypeSort.SelectedValue != "All")
                {
                    cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' " +
                   "and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ORDER BY jobPostedDate DESC", conDB);
                    
                }else
                {
                    jobtype = "internship";
                    cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' " +
                   "and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) and jobType LIKE '%" + JobTypeSort.SelectedValue + "%' ORDER BY jobPostedDate DESC", conDB);
                }

            }*/
            /* else*/
            if (Usertype == "Alumni")
            {
                if (JobTypeSort.SelectedValue == "All")
                {
                    cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE " +
                "isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ORDER BY jobPostedDate DESC", conDB);
                    TotalJob();
                }
                else
                {
                    
                    cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE " +
                "isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) and jobType LIKE '%" + JobTypeSort.SelectedValue + "%' ORDER BY jobPostedDate DESC", conDB);
                    TotalJob();
                }
            }
            cmd.Parameters.AddWithValue("@studentAccID", student_accId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobHiring.DataSource = ds;
            JobHiring.DataBind();
            if (JobHiring.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
        protected void SearchJob_Click(object sender, EventArgs e)
        {
            string Usertype = Session["STATUSorTYPE"].ToString();
            if (Usertype == "Alumni")
            {
                JobTypeSort.SelectedValue = "0";
            }
            ddlDateFilter.SelectedValue = "0";
            JobBindBySearch();           
        }

        void JobBindBySearch()
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            string studentCourse = Session["Student_COURSE"].ToString();
            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";

            SqlCommand cmd = new SqlCommand();
            if (Usertype == "Intern")
            {
                jobtype = "internship";
                cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' " +
               "and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) and jobTitle LIKE '%" + txtsearchJob.Text + "%' ORDER BY jobPostedDate DESC", conDB);
                TotalJob();
            }
            else if (Usertype == "Alumni")
            {
                cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE " +
                "isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) and jobTitle LIKE '%" + txtsearchJob.Text + "%' ORDER BY jobPostedDate DESC", conDB);
                TotalJob();
            }
            cmd.Parameters.AddWithValue("@studentAccID", student_accId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobHiring.DataSource = ds;
            JobHiring.DataBind();
            if (JobHiring.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }

        protected void ddlDateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Usertype = Session["STATUSorTYPE"].ToString();
            if (Usertype == "Alumni")
            {
                JobTypeSort.SelectedValue = "0";
                txtsearchJob.Text = string.Empty;
            }else
            {
                txtsearchJob.Text = string.Empty;
            }
            FilterJobsByDate();
        }
        void FilterJobsByDate()
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            string studentCourse = Session["Student_COURSE"].ToString();
            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";
            
            SqlCommand cmd = new SqlCommand();
            if (Usertype == "Intern")
            {
                if (ddlDateFilter.SelectedValue == "All")
                {
                    jobtype = "internship";
                    cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' " +
                   "and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ORDER BY jobPostedDate DESC", conDB);
                  
                    TotalJob();
                }else
                {
                    int days = Convert.ToInt32(ddlDateFilter.SelectedValue);
                    DateTime startDate = DateTime.Today.AddDays(-days);
                    jobtype = "internship";
                    cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse LIKE '%" + studentCourse + "%' and jobType LIKE '%" + jobtype + "%' " +
                   "and isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) and jobPostedDate >= '" + startDate + "' ORDER BY jobPostedDate DESC", conDB);
                    TotalJob();
                }
              
            }
            else if (Usertype == "Alumni")
            {

                if (ddlDateFilter.SelectedValue == "All")
                {
                    cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE " +
                   "isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) ORDER BY jobPostedDate DESC", conDB);
                    TotalJob();
                }
                else
                {
                    int days = Convert.ToInt32(ddlDateFilter.SelectedValue);
                    DateTime startDate = DateTime.Today.AddDays(-days);
                    cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE " +
                    "isActive = 'true' and NOT EXISTS (SELECT 1 from APPLICANT WHERE APPLICANT.jobID = HIRING.jobID AND APPLICANT.student_accID = @studentAccID) and jobPostedDate >= '" + startDate + "' ORDER BY jobPostedDate DESC", conDB);
                    TotalJob();
                }
            }
            cmd.Parameters.AddWithValue("@studentAccID", student_accId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobHiring.DataSource = ds;
            JobHiring.DataBind();
            if (JobHiring.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
    }
}