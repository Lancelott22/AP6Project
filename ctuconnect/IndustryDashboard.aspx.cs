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
    public partial class IndustryDashboard : System.Web.UI.Page
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
                getTotalHired();
                getTotalApplicant();
                getTotalJob();
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }
        void getTotalHired()
        {   
            int industryID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(id) as TotalHired from HIRED_LIST WHERE industry_accID = '" + industryID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
               totalHired.InnerText = reader["TotalHired"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void getTotalApplicant()
        {
            int industryID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(applicantID) as TotalApplicant from APPLICANT WHERE industry_accID = '" + industryID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalApplicant.InnerText = reader["TotalApplicant"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void getTotalJob()
        {
            int industryID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(jobID) as TotalJob from HIRING WHERE industry_accID = '" + industryID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalJobs.InnerText = reader["TotalJob"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
    }
}