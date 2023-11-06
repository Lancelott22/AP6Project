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
            SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse LIKE '%"+ studentCourse + "%' and jobType LIKE '%"+ jobtype + "%' ORDER BY jobPostedDate DESC", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            JobHiring.DataSource = ds;
            JobHiring.DataBind();
            if(JobHiring.Items.Count == 0)
            {
                lblNoPost.Visible = true;
            }
        }
        protected void ApplyJob_Command(object sender, CommandEventArgs e)
        {
            string script = "$('#ApplyJobModal').modal('show')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);  
            
            int jobId = int.Parse(e.CommandArgument.ToString());
            if (checkJobApplied(jobId) == true)
            {
                SubmitApply.Enabled = false;
                SubmitApply.Text = "Applied";
                SubmitApply.CssClass = "buttonStyleSubmitDisable";
            } else
            {
                SubmitApply.Enabled = true;
                SubmitApply.Text = "Submit Application";
                SubmitApply.CssClass = "buttonStyleSubmit";
            }
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
                }
                else
                {
                    salaryData.Visible = true;
                    SalaryRange.Text = reader["salaryRange"].ToString();
                    SalaryRange.Visible = true;
                }
                   
                }
                reader.Close();
                conDB.Close();
               

            
        }

        protected void SubmitApply_Command(object sender, CommandEventArgs e) //submitApplication
        {
            int alumni_accId = -1;
            int student_accId = -1; 
            
            string Usertype = Session["STATUSorTYPE"].ToString();
            string jobtype = "";
            if(Usertype == "Alumni")
            {
                alumni_accId = int.Parse(Session["Alumni_accID"].ToString());
                jobtype = "";
            }
            else if (Usertype == "Intern")
            {
                 student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
                jobtype = "internship";
            }          
             string position = JobTitle.Text.ToString();
             string applicantFName = Session["FNAME"].ToString();
             string applicantLName = Session["LNAME"].ToString();
             DateTime dateApplied = DateTime.Now;
             string resume = Session["ResumeFile"].ToString();
            int jobID = int.Parse(Job_ID.Text.ToString());
            int industry_accId = int.Parse(IndustryID.Text.ToString());

            if (checkResume())
            {
                if(isCurrentlyHired())
                {
                    Response.Write("<script>alert('You are currently hired in a company. You cannot apply for another job now. Contact your company if there is a problem.');</script>");
                }else
                {

                conDB.Open();
                if (Usertype == "Alumni")
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (jobType,alumni_accID,applicantFName, appliedPosition, applicantLName, industry_accID, dateApplied, resume,resumeStatus,interviewStatus,applicantStatus, jobID, StudentType) " +
                        "Values( @jobtype, @student_accId, @applicantFName, @applicantLName,@appliedPosition,@industry_accId, @dateApplied, @resume,@resumeStatus,@interviewStatus,@applicantStatus,@jobID,@studentType)", conDB);

                    cmd.Parameters.AddWithValue("@jobtype", jobtype);
                    cmd.Parameters.AddWithValue("@student_accId", alumni_accId);
                    cmd.Parameters.AddWithValue("@applicantFName", applicantFName);
                    cmd.Parameters.AddWithValue("@applicantLName", applicantLName);
                    cmd.Parameters.AddWithValue("@appliedPosition",position);
                    cmd.Parameters.AddWithValue("@industry_accId", industry_accId);
                    cmd.Parameters.AddWithValue("@dateApplied", dateApplied);
                    cmd.Parameters.AddWithValue("@resume", resume);
                    cmd.Parameters.AddWithValue("@resumeStatus", "Pending");
                    cmd.Parameters.AddWithValue("@interviewStatus", "Pending");
                    cmd.Parameters.AddWithValue("@applicantStatus", "Pending");
                    cmd.Parameters.AddWithValue("@jobID", jobID);
                        cmd.Parameters.AddWithValue("@studentType", Usertype);
                        int ctr = cmd.ExecuteNonQuery();
                    if(ctr > 0)
                    {
                       
                        Response.Write("<script>alert('You have successfully submitted your job application.');document.location='MyJobApplication.aspx';</script>");
                    } else
                    {
                        Response.Write("<script>alert('Sorry! There is something wrong in applying the job. Please try again..');</script>");
                    }
                }
                else if (Usertype == "Intern")
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (jobType,student_accID,applicantFName, applicantLName, appliedPosition, industry_accID,dateApplied, resume,resumeStatus,interviewStatus,applicantStatus, jobID, StudentType) " +
                      "Values(@jobtype, @student_accId, @applicantFName, @applicantLName,@appliedPosition,@industry_accId, @dateApplied, @resume,@resumeStatus,@interviewStatus,@applicantStatus,@jobID, @studentType)", conDB);

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
                    int ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                       
                            Response.Write("<script>alert('You have successfully submitted your job application.');document.location='MyJobApplication.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry! There is something wrong in applying the job. Please try again..');</script>");
                    }
                }
                conDB.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Please upload or create resume first before applying job.');document.location='Resume.aspx'</script>");
            }
            JobBind();
        }
        bool checkResume() //check resume
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select resumeFile from STUDENT_ACCOUNT where student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                if(reader["resumeFile"] == null || reader["resumeFile"].ToString() == string.Empty)
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

        protected void JobHiring_ItemDataBound(object sender, DataListItemEventArgs e)
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
            if (timegap.Days >= (365*2))
            {
                timeAgoMsg = string.Concat((((timegap.Days) / 30) / 12), " years ago");
            }
            else if (timegap.Days >= 365)
            {
                timeAgoMsg = string.Concat((((timegap.Days) / 30) / 12), " year ago");
            }
            else if (timegap.Days >= (30*2))
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
    }
}  