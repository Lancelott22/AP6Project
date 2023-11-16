using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            HtmlControl dashboardLink = (HtmlControl)Master.FindControl("dashboard");
            dashboardLink.Attributes.Add("class", "active");
            getTotalInternInIndustry();
            getTotalIndustry();
            getTotalJob();
            getTotalAlumnInIndustry();
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
    }
}