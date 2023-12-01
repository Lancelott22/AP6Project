using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getTotalIndustry();
                getTotalIntern();
                getTotalAlumni();

            }
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");

        }

        void getTotalIndustry()
        {
            
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(industry_accID) as TotalIndustry from INDUSTRY_ACCOUNT ", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalIndustry.InnerText = reader["TotalIndustry"].ToString();
            }
            reader.Close();
            conDB.Close();
        }

        void getTotalIntern()
        {

            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(student_accID) as TotalIntern from STUDENT_ACCOUNT WHERE studentStatus = 'Intern'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalInterns.InnerText = reader["TotalIntern"].ToString();
            }
            reader.Close();
            conDB.Close();
        }

        void getTotalAlumni()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(student_accID) as TotalAlumni from STUDENT_ACCOUNT WHERE studentStatus = 'Alumni'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalAlumni.InnerText = reader["TotalAlumni"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
    }
}