using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Caching;

namespace ctuconnect
{
    public partial class IndustryJobPosted : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");

            }
            else
            {
                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;

            }
            if (!IsPostBack)
            {
                IndustryJobPostedBind();
                TotalJob();
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
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select isVerified from INDUSTRY_ACCOUNT where industry_accID = @industry_accID", conDB);
            cmd.Parameters.AddWithValue("@industry_accID", industry_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["isVerified"] == DBNull.Value || bool.Parse(reader["isVerified"].ToString()) == false)
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
        private void IndustryJobPostedBind()
        {
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT HIRING.*,  case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar, jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "' ORDER BY jobPostedDate DESC;", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryJobPostedList.DataSource = ds;
            IndustryJobPostedList.DataBind();
            if (IndustryJobPostedList.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }

        protected void IndustryJobPostedList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HtmlGenericControl jobPostedDate = (HtmlGenericControl)e.Item.FindControl("JobPostedDate");
            DateTime postedDate = Convert.ToDateTime(jobPostedDate.InnerText);
            DateTime currentDate = DateTime.Now;
            TimeSpan timegap = currentDate - postedDate;

            if (timegap.Days < 1)
            {
                HtmlGenericControl Badge = (HtmlGenericControl)e.Item.FindControl("badge");
                Badge.Visible = true;
                /* HtmlGenericControl myApplicationList = (HtmlGenericControl)e.Item.FindControl("myApplicationList");
                 myApplicationList.Style.Add("background-color", "#f0e789");*/
            }         
        }
        protected void IndustryJobPostedList_PagePropertiesChanged(object sender, EventArgs e)
        {
            if (JobTypeSort.SelectedValue != "All" && JobTypeSort.SelectedValue != "0")
            {
                JobBindByType();
            }
            else if (JobStatusSort.SelectedValue != "All" && JobStatusSort.SelectedValue != "0")
            {
                JobBindByStatus();
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
                IndustryJobPostedBind();
            }            
        }

        protected void ViewApplicants_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Applicants.aspx?jobid=" + e.CommandArgument.ToString() + "&jobtitle=" + e.CommandName.ToString());
        }

        protected void UpdateJob_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("IndustryHome.aspx?jobid=" + e.CommandArgument.ToString());
        }

        protected void SearchJob_Click(object sender, EventArgs e)
        {
            JobTypeSort.SelectedValue = "0";
            ddlDateFilter.SelectedValue = "0";
            JobStatusSort.SelectedValue = "0";
            JobBindBySearch();
        }

        protected void JobTypeSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsearchJob.Text = string.Empty;
            ddlDateFilter.SelectedValue = "0";
            JobStatusSort.SelectedValue = "0";
            JobBindByType();
        }

        protected void ddlDateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobTypeSort.SelectedValue = "0";
            txtsearchJob.Text = string.Empty;
            JobStatusSort.SelectedValue = "0";
            FilterJobsByDate();
        }

        protected void JobStatusSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobTypeSort.SelectedValue = "0";
            txtsearchJob.Text = string.Empty;
            ddlDateFilter.SelectedValue = "0";
            JobBindByStatus();
        }
        void JobBindByStatus()
        {
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            SqlCommand cmd = new SqlCommand();
            if (JobStatusSort.SelectedValue == "All")
            {
                cmd = new SqlCommand("SELECT HIRING.*,  case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar, jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "' ORDER BY jobPostedDate DESC;", conDB);
                TotalJob();
            }
            else
            {
                string status = "";
                if (JobStatusSort.SelectedValue == "Active")
                {
                    status = "true";
                }
                else if (JobStatusSort.SelectedValue == "Inactive")
                {
                    status = "false";
                }
                cmd = new SqlCommand("SELECT HIRING.*,  case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar, jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE isActive = '" + status + "' and (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "' ORDER BY jobPostedDate DESC;", conDB);
                TotalJob();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryJobPostedList.DataSource = ds;
            IndustryJobPostedList.DataBind();
            if (IndustryJobPostedList.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
        void JobBindByType()
        {
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            SqlCommand cmd = new SqlCommand();
            if (JobTypeSort.SelectedValue == "All")
            {
                cmd = new SqlCommand("SELECT HIRING.*,  case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar, jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "' ORDER BY jobPostedDate DESC;", conDB);                
                TotalJob();
            }
            else
            {
                cmd = new SqlCommand("SELECT HIRING.*,  case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar, jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE jobType LIKE '%" + JobTypeSort.SelectedValue + "%' and (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "' ORDER BY jobPostedDate DESC;", conDB);               
                TotalJob();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryJobPostedList.DataSource = ds;
            IndustryJobPostedList.DataBind();
            if (IndustryJobPostedList.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
        void JobBindBySearch()
        {
             int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT HIRING.*,  case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar, jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE jobTitle LIKE '%" + txtsearchJob.Text + "%' and (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "' ORDER BY jobPostedDate DESC;", conDB);
            TotalJob();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryJobPostedList.DataSource = ds;
            IndustryJobPostedList.DataBind();
            if (IndustryJobPostedList.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }
        void FilterJobsByDate()
        {
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            SqlCommand cmd = new SqlCommand();
            if (ddlDateFilter.SelectedValue == "All")
            {
                cmd = new SqlCommand("SELECT HIRING.*,  case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar, jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "' ORDER BY jobPostedDate DESC;", conDB);
                TotalJob();
            }
            else
            {
                int days = Convert.ToInt32(ddlDateFilter.SelectedValue);
                DateTime startDate = DateTime.Today.AddDays(-days);
                cmd = new SqlCommand("SELECT HIRING.*,  case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar, jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT WHERE (applicantStatus = 'Pending' or applicantStatus IS Null) GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE jobPostedDate >= '" + startDate + "' and (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "' ORDER BY jobPostedDate DESC;", conDB);
                TotalJob();
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryJobPostedList.DataSource = ds;
            IndustryJobPostedList.DataBind();
            if (IndustryJobPostedList.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
            else
            {
                ListViewPager.Visible = true;
            }
        }

        void TotalJob()
        {
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand();
            if (JobTypeSort.SelectedValue != "All" && JobTypeSort.SelectedValue != "0")
            {
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobType LIKE '%" + JobTypeSort.SelectedValue + "%' and (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "'", conDB);

            }
            else if (JobStatusSort.SelectedValue != "All" && JobStatusSort.SelectedValue != "0")
            {
                string status = "";
                if(JobStatusSort.SelectedValue == "Active")
                {
                    status = "true";
                }
                else if(JobStatusSort.SelectedValue == "Inactive")
                {
                    status = "false";
                }
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE isActive = '" + status + "' and (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "'", conDB);

            }
            else if (ddlDateFilter.SelectedValue != "All" && ddlDateFilter.SelectedValue != "0")
            {
                int days = Convert.ToInt32(ddlDateFilter.SelectedValue);
                DateTime startDate = DateTime.Today.AddDays(-days);
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobPostedDate >= '" + startDate + "' and (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "'", conDB);

            }
            else if (txtsearchJob.Text != string.Empty)
            {
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE jobTitle LIKE '%" + txtsearchJob.Text + "%' and (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "'", conDB);
            }
            else
            {
                cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE (isDeletedByAdmin IS NULL OR isDeletedByAdmin != 1) and HIRING.industry_accID = '" + industryAccID + "'", conDB);
            }
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