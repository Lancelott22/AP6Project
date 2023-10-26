using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class ReferralList : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               /* if (Session["USRNAME"] != null)
                {
                    BindGridView1();
                }
                else if (Session["IndustryEmail"] != null) {*/
                    BindGridView2();
                
            }
        }
        /*void BindGridView1()
        {
            string query = "SELECT REFERRAL.referralID, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, COORDINATOR_ACCOUNT.firstName + ' ' + COORDINATOR_ACCOUNT.lastName AS referredBy, REFERRAL.endorsementLetter, REFERRAL.dateReferred, STUDENT_ACCOUNT.resumeFile " +
                "FROM REFERRAL JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
                "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID";
            SqlCommand cmd = new SqlCommand(query, conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }*/
        void BindGridView2()
        {
            int industryID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"]);
            string query = "SELECT REFERRAL.referralID, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, COORDINATOR_ACCOUNT.firstName + ' ' + COORDINATOR_ACCOUNT.lastName AS referredBy, REFERRAL.endorsementLetter, REFERRAL.dateReferred, STUDENT_ACCOUNT.resumeFile " +
                "FROM REFERRAL JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
                "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
                "WHERE INDUSTRY_ACCOUNT.industry_accID = @industryID";
            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@industryID", industryID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
    }
}