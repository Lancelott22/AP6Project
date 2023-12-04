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
            JobPostedBind();
        }
        void TotalJob()
        {
            
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE isActive = 'true'", conDB);
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
        }
        void getJobDetails(int delete_jobId)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select jobTitle, industryName from HIRING WHERE jobID = '" + delete_jobId + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Delete_JobTitle.InnerText = reader["jobTitle"].ToString();
                Delete_IndustryName.InnerText = reader["industryName"].ToString();
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
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully deleted the job.');document.location='Admin_JobPosted.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in deleting the job. Please try again later..');document.location='Admin_JobPosted.aspx';", true);
                }
                conDB.Close();
            }
        }
        protected void SearchJob_Click(object sender, EventArgs e)
        {

           
            SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "WHERE isActive = 'true' and jobTitle LIKE '%" + txtsearchJob.Text + "%'  ORDER BY jobPostedDate DESC", conDB);
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