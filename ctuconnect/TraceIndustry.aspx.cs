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

namespace ctuconnect
{
    public partial class TraceIndustry : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl traceIndstryLink = (HtmlControl)Master.FindControl("traceIndustry");
            traceIndstryLink.Attributes.Add("class", "active");
            BindIndustryList();
        }
        void BindIndustryList()
        {
            SqlCommand cmd = new SqlCommand("SELECT INDUSTRY_ACCOUNT.*,COALESCE(HIRING_COUNT.TotalJob, 0) as totalJobPosted, COALESCE(HIRED_LIST.TotalHired, 0) as TotalEmployee " +
                "FROM INDUSTRY_ACCOUNT LEFT JOIN (SELECT industry_accID, COUNT(jobID) as TotalJob FROM HIRING WHERE isActive = 1 GROUP BY industry_accID) HIRING_COUNT " +
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
    }
}