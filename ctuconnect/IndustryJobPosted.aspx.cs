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
            }
        }
        private void IndustryJobPostedBind()
        {
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT HIRING.*, CONVERT(nvarchar,jobPostedDate, 1) as DatePosted , INDUSTRY_ACCOUNT.industryPicture, COALESCE(APPLICANT.NumberOfApplicants, 0) AS NumberOfApplicants" +
                " FROM HIRING LEFT JOIN (SELECT jobID, COUNT(applicantID) AS NumberOfApplicants FROM APPLICANT GROUP BY jobID) APPLICANT ON HIRING.jobID = APPLICANT.jobID" +
                " INNER JOIN INDUSTRY_ACCOUNT ON INDUSTRY_ACCOUNT.industry_accID = HIRING.industry_accID WHERE HIRING.industry_accID = 600000 ORDER BY jobPostedDate DESC;", conDB);
            cmd.Parameters.AddWithValue("@Industry_accID", industryAccID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryJobPostedList.DataSource = ds;
            IndustryJobPostedList.DataBind();
            if (IndustryJobPostedList.Items.Count == 0)
            {
                ListViewPager.Visible = false;
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
            IndustryJobPostedBind();
        }

        protected void ViewApplicants_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Applicants.aspx?jobid=" + e.CommandArgument.ToString());
        }

        protected void UpdateJob_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("IndustryHome.aspx?jobid=" + e.CommandArgument.ToString());
        }
    }
}