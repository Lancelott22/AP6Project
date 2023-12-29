using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using Org.BouncyCastle.Asn1.X509;

namespace ctuconnect
{
    public partial class TraceIndustry : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl traceIndstryLink = (HtmlControl)Master.FindControl("traceIndustry");
            traceIndstryLink.Attributes.Add("class", "active");
            if(!IsPostBack)
            {
                BindIndustryList();
            }          
            if (!IsPostBack && Request.QueryString["IndustryID"] != null && Request.QueryString["IndustryName"] != null)
            {
                NameOfIndustry.InnerText = "All job posts from " + Request.QueryString["IndustryName"].ToString();
                NameOfIndustry.Visible = true;
                showIndustryList.Visible = false;
                showIndustryList.Attributes["class"] = "d-none";
                showJobPosted.Visible = true;
                showJobPosted.Attributes["class"] = "row";
                getJobPosted();
            }
        }
        void BindIndustryList()
        {
            SqlCommand cmd = new SqlCommand("SELECT INDUSTRY_ACCOUNT.*,COALESCE(HIRING_COUNT.TotalJob, 0) as totalJobPosted, COALESCE(HIRED_LIST.TotalHired, 0) as TotalEmployee " +
                "FROM INDUSTRY_ACCOUNT LEFT JOIN (SELECT industry_accID, COUNT(jobID) as TotalJob FROM HIRING GROUP BY industry_accID) HIRING_COUNT " +
                "ON INDUSTRY_ACCOUNT.industry_accID = HIRING_COUNT.industry_accID LEFT JOIN (SELECT industry_accID, COUNT(id) as TotalHired FROM HIRED_LIST " +
                "WHERE internshipStatus = 'Ongoing' or workStatus = 'Ongoing' GROUP BY industry_accID) HIRED_LIST " +
                "ON INDUSTRY_ACCOUNT.industry_accID = HIRED_LIST.industry_accID", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryListView.DataSource = ds;
            IndustryListView.DataBind();
            if (IndustryListView.Items.Count == 0)
            {
                /*ListViewPager.Visible = false;*/
            }
        }
        void SearchByIndustryName(string industryName)
        {
            SqlCommand cmd = new SqlCommand("SELECT INDUSTRY_ACCOUNT.*,COALESCE(HIRING_COUNT.TotalJob, 0) as totalJobPosted, COALESCE(HIRED_LIST.TotalHired, 0) as TotalEmployee " +
                "FROM INDUSTRY_ACCOUNT LEFT JOIN (SELECT industry_accID, COUNT(jobID) as TotalJob FROM HIRING WHERE isActive = 1 GROUP BY industry_accID) HIRING_COUNT " +
                "ON INDUSTRY_ACCOUNT.industry_accID = HIRING_COUNT.industry_accID LEFT JOIN (SELECT industry_accID, COUNT(id) as TotalHired FROM HIRED_LIST " +
                "WHERE internshipStatus = 'Ongoing' or workStatus = 'Ongoing' GROUP BY industry_accID) HIRED_LIST " +
                "ON INDUSTRY_ACCOUNT.industry_accID = HIRED_LIST.industry_accID WHERE industryName LIKE '%" + industryName + "%'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryListView.DataSource = ds;
            IndustryListView.DataBind();
        }

        protected void SearchIndustry_Click(object sender, EventArgs e)
        {
            string industryName = IndustryName.Text; 
            SearchByIndustryName(industryName);
        }
        void SearchByIndustryAddress(string industryAddress)
        {
            SqlCommand cmd = new SqlCommand("SELECT INDUSTRY_ACCOUNT.*,COALESCE(HIRING_COUNT.TotalJob, 0) as totalJobPosted, COALESCE(HIRED_LIST.TotalHired, 0) as TotalEmployee " +
                "FROM INDUSTRY_ACCOUNT LEFT JOIN (SELECT industry_accID, COUNT(jobID) as TotalJob FROM HIRING WHERE isActive = 1 GROUP BY industry_accID) HIRING_COUNT " +
                "ON INDUSTRY_ACCOUNT.industry_accID = HIRING_COUNT.industry_accID LEFT JOIN (SELECT industry_accID, COUNT(id) as TotalHired FROM HIRED_LIST " +
                "WHERE internshipStatus = 'Ongoing' or workStatus = 'Ongoing' GROUP BY industry_accID) HIRED_LIST " +
                "ON INDUSTRY_ACCOUNT.industry_accID = HIRED_LIST.industry_accID WHERE location LIKE '%" + industryAddress + "%'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryListView.DataSource = ds;
            IndustryListView.DataBind();
        }
        protected void IndustryAdress_Click(object sender, EventArgs e)
        {
            string industryAddress = Address.Text;
            SearchByIndustryAddress(industryAddress);
        }

        void getDetails(int industry_accID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select * from INDUSTRY_ACCOUNT JOIN CONTACT_PERSON ON INDUSTRY_ACCOUNT.industry_accID = CONTACT_PERSON.industry_accID WHERE INDUSTRY_ACCOUNT.industry_accID = @industry_accId", conDB);
            cmd.Parameters.AddWithValue("@industry_accId", industry_accID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IndustryLogo.Src = "~/images/IndustryProfile/" + reader["industryPicture"].ToString();
                Industry_Name.InnerText = reader["industryName"].ToString();
                IndustryEmail.InnerText = reader["email"].ToString();
                Location.InnerText = reader["location"].ToString();
                ContactName.InnerText = reader["fName"].ToString() + " " + reader["LName"].ToString();
                jobPosition.InnerText = reader["position"].ToString();
                contactEmail.InnerText = reader["contactEmail"].ToString();
                contactNumber.InnerText = reader["contactNumber"].ToString();
            }
        }
        protected void ViewDetails_Command(object sender, CommandEventArgs e)
        {

            int industry_accID = int.Parse(e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showIndustry();", true);
            getDetails(industry_accID);
        }

        protected void ViewJobPost_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("TraceIndustry.aspx?IndustryID=" + e.CommandArgument.ToString() + "&IndustryName=" + e.CommandName.ToString());
        }

        void getJobPosted()
        {
            if (Request.QueryString["IndustryID"] != null)
            {
                int industry_accID = int.Parse(Request.QueryString["IndustryID"].ToString());
                SqlCommand cmd = new SqlCommand("SELECT HIRING.*,case when isActive = 1 then 'Active' else 'Inactive' end as JobStatus, CONVERT(nvarchar,jobPostedDate, 1) as Job_PostedDate, COALESCE(HIRED_LIST.totalEmployee, 0) AS TotalJobEmployee " +
                    "FROM HIRING LEFT JOIN (SELECT jobID, COUNT(id) AS totalEmployee FROM HIRED_LIST WHERE internshipStatus = 'Ongoing' or workStatus = 'Ongoing' GROUP BY jobID) HIRED_LIST ON HIRING.jobID = HIRED_LIST.jobID " +
                    "WHERE HIRING.industry_accID = @industry_accID", conDB);
                cmd.Parameters.AddWithValue("@industry_accID", industry_accID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                JobPostListView.DataSource = ds;
                JobPostListView.DataBind();
            }
        }
    }
}