using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using Antlr.Runtime.Tree;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

namespace ctuconnect
{
    public partial class Admin_JobPosted : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
                JobPostedBind();
                TotalJob();
           }
           
        }

        void JobPostedBind()
        {
            SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "WHERE isActive = 'true' ORDER BY jobPostedDate DESC", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobPosted.DataSource = ds;
            JobPosted.DataBind();
            if (JobPosted.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
        protected void JobPosted_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
           
            Label jobPostedDate = (Label)e.Item.FindControl("JobPostedDate");
            Label jobID = (Label)e.Item.FindControl("JobPostID");
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
            Button ViewReportBtn = (Button)e.Item.FindControl("ViewReport");
            int jobPostID = int.Parse(jobID.Text);
            if (checkReportJob(jobPostID))
            {
                string countReport = countJobReport(jobPostID);
                if(int.Parse(countReport) > 1)
                {
                    ViewReportBtn.Text = "View " + countReport + " Reports";
                }
                else
                {
                    ViewReportBtn.Text = "View " + countReport + " Report";
                }
                
            }
            else
            {
                ViewReportBtn.Text = "View 0 Report";
            }

        }
        string countJobReport(int jobPostID)
        {
            string countReport = "0";
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(id) as totalReport from REPORT_JOB WHERE jobID = '" + jobPostID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                countReport = reader["totalReport"].ToString();
                reader.Close();
                conDB.Close();
                return countReport;
            }
            reader.Close();
            conDB.Close();
            return countReport;
        }
        bool checkReportJob(int jobPostID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(1) from REPORT_JOB WHERE jobID = '" + jobPostID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                reader.Close();
                conDB.Close();
                return true;
            }
            reader.Close();
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
        protected void JobPosted_PagePropertiesChanged(object sender, EventArgs e)
        {
            if (JobTypeSort.SelectedValue != "All" && JobTypeSort.SelectedValue != "0")
            {
                JobBindByType();
            }
            else if (ddlDateFilter.SelectedValue != "All" && ddlDateFilter.SelectedValue != "0")
            {
                FilterJobsByDate();
            }
            else if (txtsearchJob.Text != string.Empty)
            {
                JobBindBySearch();
            }
            else
            {
                JobPostedBind();
            }
            
        }
        void TotalJob()
        {           
            conDB.Open();
            SqlCommand cmd = new SqlCommand();
            if (JobTypeSort.SelectedValue != "All" && JobTypeSort.SelectedValue != "0")
            {
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobType LIKE '%" + JobTypeSort.SelectedValue + "%' and isActive = 'true'", conDB);

            }
            else if (ddlDateFilter.SelectedValue != "All" && ddlDateFilter.SelectedValue != "0")
            {
                int days = Convert.ToInt32(ddlDateFilter.SelectedValue);
                DateTime startDate = DateTime.Today.AddDays(-days);
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobPostedDate >= '" + startDate + "' and isActive = 'true'", conDB);
            }
            else if (txtsearchJob.Text != string.Empty)
            {
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobTitle LIKE '%" + txtsearchJob.Text + "%' and isActive = 'true'", conDB);
            }
            else
            {
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE isActive = 'true'", conDB);
            }
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalJob.InnerText = "Total " + reader["TotalJob"].ToString() + " jobs found";
            }
            reader.Close();
            conDB.Close();
        }

        protected void ViewReport_Command(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showReportList();", true);
            int reported_JobID = int.Parse(e.CommandArgument.ToString());
            getJobReportList(reported_JobID);

            ListViewItem currentItem = (sender as Button).NamingContainer as ListViewItem;
            foreach (ListViewItem item in JobPosted.Items)
            {
                HtmlGenericControl jobPosted = item.FindControl("jobList") as HtmlGenericControl;
                if (currentItem.DataItemIndex == item.DataItemIndex)
                {
                    jobPosted.Attributes["class"] = "row d-flex align-items-center jobBoxSelected";
                }
                else
                {
                    jobPosted.Attributes["class"] = "row d-flex align-items-center jobBox";
                }
            }
        }
        private void getJobReportList(int jobID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select * from REPORT_JOB JOIN HIRING ON REPORT_JOB.jobID = HIRING.jobID " +
                "WHERE REPORT_JOB.jobID = '" + jobID + "' ORDER BY reportDate DESC", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            ReportListView.DataSource = ds;
            ReportListView.DataBind();
            /* if (ReportListView.Items.Count == 0)
             {
                 ListViewPager.Visible = false;
             }*/
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {               
                Reported_JobTitle.InnerText = reader["jobTitle"].ToString();
                Reported_IndustryName.InnerText = reader["industryName"].ToString();              
            }
            else
            {
                Reported_JobTitle.InnerText = string.Empty;
                Reported_IndustryName.InnerText = string.Empty;
            }
            reader.Close();
            conDB.Close();
            reported_jobID.Text = jobID.ToString();          
        }
        protected void DeleteJob_Command(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showDeleteJob();", true);
            delete_jobID.Text = e.CommandArgument.ToString();
            int delete_jobId = int.Parse(e.CommandArgument.ToString());
            getJobDetails(delete_jobId);
            errorText.Visible = false;
            deleteReason.Value = string.Empty;

            ListViewItem currentItem = (sender as Button).NamingContainer as ListViewItem;
            foreach (ListViewItem item in JobPosted.Items)
            {
                HtmlGenericControl jobPosted = item.FindControl("jobList") as HtmlGenericControl;
                if (currentItem.DataItemIndex == item.DataItemIndex)
                {
                    jobPosted.Attributes["class"] = "row d-flex align-items-center jobBoxSelected";
                }
                else
                {
                    jobPosted.Attributes["class"] = "row d-flex align-items-center jobBox";
                }
            }
        }
        void getJobDetails(int delete_jobId)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select jobTitle, INDUSTRY_ACCOUNT.industryName, email from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobID = '" + delete_jobId + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Delete_JobTitle.InnerText = reader["jobTitle"].ToString();
                Delete_IndustryName.InnerText = reader["industryName"].ToString();
                Delete_IndustryEmail.InnerText = reader["email"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        protected void ConfirmDeletion_Command(object sender, CommandEventArgs e)
        {
            int jobID = int.Parse(delete_jobID.Text);
            string reason = deleteReason.Value;

            if (string.IsNullOrEmpty(deleteReason.Value))
            {
                errorText.Visible = true;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showDeleteJob();", true);
            }
            else
            {
                conDB.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HIRING SET isActive = 0, isDeletedByAdmin = 1, reasonForDeletion = @reason, deletedDate = @dateDeleted WHERE jobID = @jobID", conDB);

                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@dateDeleted", DateTime.Now);
                cmd.Parameters.AddWithValue("@jobID", jobID);
                int ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    string jobTitle = Delete_JobTitle.InnerText;
                    string industryName = Delete_IndustryName.InnerText;
                    string email = Delete_IndustryEmail.InnerText;
                    SendEmail(jobTitle, industryName, email, reason);
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully deleted the job.');document.location='Admin_JobPosted.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in deleting the job. Please try again later..');document.location='Admin_JobPosted.aspx';", true);
                }
                conDB.Close();
            }
        }
        private void SendEmail(string jobTitle, string industryName, string email, string reason)
        {
            try
            {
                
                string sendToEmail = email;
                string sendFrom = "ctuconnect00@gmail.com";
                string sendMessage = $"Dear <b>{industryName}</b>, <br/><br/>" +
                    $"We regret to inform you that your recent job post on our platform has been deleted.<br/><br/>" +
                    $"Job Title: {jobTitle}<br/>" +
                    $"Reason: {reason}<br/>" +
                    $"Date Deleted: {DateTime.Now}<br/><br/>" +
                    $"We hope you understand and thank you for your continued engagement with CTU Connect.<br/><br/>" +
                    $"Best regards,<br/><br/>" +
                    $"<b>CTU Connect</b>";
                string subject = "Deletion of Job Post";
                using (MailMessage mm = new MailMessage())
                {
                    mm.From = new MailAddress(sendFrom, "CTU Connect");
                    mm.To.Add(sendToEmail);
                    mm.Subject = subject;
                    mm.Body = sendMessage;
                    mm.IsBodyHtml = true;
                    mm.ReplyToList.Add(new MailAddress(sendFrom));
                    using (SmtpClient smtp = new SmtpClient())
                    {
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
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Admin_JobPosted.aspx'</script>");
            }
        }
        protected void SearchJob_Click(object sender, EventArgs e)
        {
            JobTypeSort.SelectedValue = "0";   
            ddlDateFilter.SelectedValue = "0";
            JobBindBySearch();
        }
        void JobBindBySearch()
        {
            
            SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "WHERE isActive = 'true' and jobTitle LIKE '%" + txtsearchJob.Text + "%'  ORDER BY jobPostedDate DESC", conDB);
            TotalJob();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobPosted.DataSource = ds;
            JobPosted.DataBind();
            if (JobPosted.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
        protected void JobDetail_Command(object sender, CommandEventArgs e)
        {
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

            string url = "ViewIndustryProfile_Admin.aspx?industry_accID=" + Server.UrlEncode(IndustryID.Text);
            viewIndustryProfileLink.HRef = url;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showJobDetails();", true);

            ListViewItem currentItem = (sender as LinkButton).NamingContainer as ListViewItem;
            foreach (ListViewItem item in JobPosted.Items)
            {
                HtmlGenericControl jobPosted = item.FindControl("jobList") as HtmlGenericControl;
                if (currentItem.DataItemIndex == item.DataItemIndex)
                {
                    jobPosted.Attributes["class"] = "row d-flex align-items-center jobBoxSelected";
                }
                else
                {
                    jobPosted.Attributes["class"] = "row d-flex align-items-center jobBox";
                }
            }
        }

        protected void ddlDateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobTypeSort.SelectedValue = "0";
            txtsearchJob.Text = string.Empty;
            FilterJobsByDate();
        }
        void FilterJobsByDate()
        {
            SqlCommand cmd = new SqlCommand();
            if (ddlDateFilter.SelectedValue == "All")
            {
                 cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "WHERE isActive = 'true' ORDER BY jobPostedDate DESC", conDB);
                TotalJob();
            } else
            {
                int days = Convert.ToInt32(ddlDateFilter.SelectedValue);
                DateTime startDate = DateTime.Today.AddDays(-days);
                cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "WHERE jobPostedDate >= '" + startDate + "' and isActive = 'true' ORDER BY jobPostedDate DESC", conDB);
                TotalJob();
            }
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobPosted.DataSource = ds;
            JobPosted.DataBind();
            if (JobPosted.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
        protected void JobTypeSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsearchJob.Text = string.Empty;
            ddlDateFilter.SelectedValue = "0";
            JobBindByType();
        }
        void JobBindByType()
        {
            SqlCommand cmd = new SqlCommand();
            if (JobTypeSort.SelectedValue == "All")
            {
                cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
               "WHERE isActive = 'true' ORDER BY jobPostedDate DESC", conDB);
                TotalJob();
            }
            else
            {
                cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                 "WHERE jobType LIKE '%" + JobTypeSort.SelectedValue + "%' and isActive = 'true' ORDER BY jobPostedDate DESC", conDB);
                TotalJob();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            JobPosted.DataSource = ds;
            JobPosted.DataBind();
            if (JobPosted.Items.Count == 0)
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