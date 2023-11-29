using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class TracerDashboard : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {
            HtmlControl dashboardLink = (HtmlControl)Master.FindControl("dashboard");
            dashboardLink.Attributes.Add("class", "active");
            getTotalInternInIndustry();
            getTotalIndustry();
            getTotalJob();
            getTotalAlumnInIndustry();
                BindHiredPerIndustry();
                BindIndustry();
                BindHiredPerJobInIndustry(int.Parse(IndustryJob.SelectedValue));
                
            }
        }
        private void BindHiredPerIndustry()
        {
            Chart1.Series["Internship"].Points.Clear();
            Chart1.Series["Fulltime"].Points.Clear();
            SqlCommand cmd = new SqlCommand("SELECT INDUSTRY_ACCOUNT.industryName, COUNT(HIRED_LIST.id) AS hiredCount" +
                " FROM INDUSTRY_ACCOUNT" +
                " LEFT JOIN HIRED_LIST ON INDUSTRY_ACCOUNT.industry_accID = HIRED_LIST.industry_accID AND jobType = 'internship'" +
                " GROUP BY INDUSTRY_ACCOUNT.industryName;", conDB);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
            Chart1.Series["Internship"].Points.DataBind(dt.DefaultView, "industryName", "hiredCount", "");
             cmd = new SqlCommand("SELECT INDUSTRY_ACCOUNT.industryName, COUNT(HIRED_LIST.id) AS hiredCount" +
                " FROM INDUSTRY_ACCOUNT" +
                " LEFT JOIN HIRED_LIST ON INDUSTRY_ACCOUNT.industry_accID = HIRED_LIST.industry_accID AND jobType = 'fulltime'" +
                " GROUP BY INDUSTRY_ACCOUNT.industryName;", conDB);
             da = new SqlDataAdapter(cmd);
             dt = new DataTable();
            da.Fill(dt);
            Chart1.Series["Fulltime"].Points.DataBind(dt.DefaultView, "industryName", "hiredCount", "");
        }

        void BindHiredPerJobInIndustry(int industryID)
        {
            Chart2.Series["Internship"].Points.Clear();
            Chart2.Series["Fulltime"].Points.Clear();
            SqlCommand cmd = new SqlCommand("SELECT HIRED_LIST.industry_accID, HIRED_LIST.position as jobPosition, industryName, jobTitle, COUNT(*) AS HiredPerJob FROM HIRING INNER JOIN HIRED_LIST ON HIRING.jobID = HIRED_LIST.jobID AND HIRED_LIST.jobType = 'internship' WHERE HIRED_LIST.industry_accID = '"+ industryID + "' GROUP BY HIRED_LIST.industry_accID, industryName, jobTitle, HIRED_LIST.position", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart2.Series["Internship"].Points.DataBind(dt.DefaultView, "jobPosition", "HiredPerJob", "");
            cmd = new SqlCommand("SELECT HIRED_LIST.industry_accID, HIRED_LIST.position as jobPosition, industryName, jobTitle, COUNT(*) AS HiredPerJob FROM HIRING INNER JOIN HIRED_LIST ON HIRING.jobID = HIRED_LIST.jobID AND HIRED_LIST.jobType = 'fulltime' WHERE HIRED_LIST.industry_accID = '"+ industryID + "' GROUP BY HIRED_LIST.industry_accID, industryName, jobTitle, HIRED_LIST.position", conDB);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            Chart2.Series["Fulltime"].Points.DataBind(dt.DefaultView, "jobPosition", "HiredPerJob", "");

            if(dt.Rows.Count == 0)
            {
                Chart2.Visible = false;
                NoData.Visible = true;
            }
            else
            {
                Chart2.Visible = true;
                NoData.Visible = false;
            }
        }
        void getTotalAlumnInIndustry()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(alumni_accID) as TotalAlumni from ALUMNI_ACCOUNT WHERE EXISTS (SELECT alumni_accID FROM HIRED_LIST WHERE ALUMNI_ACCOUNT.alumni_accID = HIRED_LIST.alumni_accID)", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalAlumni.InnerText = reader["TotalAlumni"].ToString();
            }        
            reader.Close();
            conDB.Close();
        }
        void getTotalInternInIndustry()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(student_accID) as TotalIntern from STUDENT_ACCOUNT WHERE EXISTS (SELECT student_accID FROM HIRED_LIST WHERE STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID) and isHired = 1", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalIntern.InnerText = reader["TotalIntern"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void getTotalIndustry()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(industry_accID) as TotalIndustry from INDUSTRY_ACCOUNT", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalIndustry.InnerText = reader["TotalIndustry"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void getTotalJob()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(jobID) as TotalJobPosted from HIRING", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalJobPosted.InnerText = reader["TotalJobPosted"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void BindIndustry()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM INDUSTRY_ACCOUNT", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryJob.DataSource = ds;
            IndustryJob.DataValueField = "industry_accID";
            IndustryJob.DataTextField = "industryName";
            IndustryJob.DataBind();
            IndustryJob.SelectedValue = "industry_accID";
        }

        protected void IndustryJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            int industry_accID = int.Parse(IndustryJob.SelectedValue);
            BindHiredPerJobInIndustry(industry_accID);
            BindHiredPerIndustry();
        }
    }
}