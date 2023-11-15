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
    public partial class ListOfInterns_Alumni : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create an empty DataTable
                BindTableCAS();
                BindTableCCICT();
                BindTableCME();
                BindTableCOE();
                BindTableCOEd();
                BindTableCOT();
                myLinkButton1.CssClass += " active";
                dataRepeater1.Visible = true;
                dataRepeater2.Visible = false;
                dataRepeater3.Visible = false;
                dataRepeater4.Visible = false;
                dataRepeater5.Visible = false;
                dataRepeater6.Visible = false;
            }
        }
        void BindTableCAS()
        {
            int departmentiD = 290000;

            string query = "SELECT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department AND STUDENT_ACCOUNT.isGraduated = 0 ";


            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@department", departmentiD);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater1.DataSource = ds;
            dataRepeater1.DataBind();

        }
        void BindTableCCICT()
        {
            int departmentiD = 290001;

            string query = "SELECT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department AND STUDENT_ACCOUNT.isGraduated = 0 ";


            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@department", departmentiD);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater2.DataSource = ds;
            dataRepeater2.DataBind();

        }
        void BindTableCME()
        {
            int departmentID = 290002;

            string query = "SELECT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department AND STUDENT_ACCOUNT.isGraduated = 0 ";


            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@department", departmentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater3.DataSource = ds;
            dataRepeater3.DataBind();

        }
        void BindTableCOE()
        {
            int departmentID = 290003;

            string query = "SELECT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department AND STUDENT_ACCOUNT.isGraduated = 0 ";


            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@department", departmentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater4.DataSource = ds;
            dataRepeater4.DataBind();

        }
        void BindTableCOEd()
        {
            int departmentID = 290004;

            string query = "SELECT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department AND STUDENT_ACCOUNT.isGraduated = 0 ";


            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@department", departmentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater5.DataSource = ds;
            dataRepeater5.DataBind();

        }
        void BindTableCOT()
        {
            int departmentID = 290005;

            string query = "SELECT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department AND STUDENT_ACCOUNT.isGraduated = 0 ";


            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@department", departmentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater6.DataSource = ds;
            dataRepeater6.DataBind();

        }
        protected void btnSwitchGrid_CAS(object sender, EventArgs e)
        {
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton1.CssClass += " active";

            dataRepeater1.Visible = true;
            dataRepeater2.Visible = false;
            dataRepeater3.Visible = false;
            dataRepeater4.Visible = false;
            dataRepeater5.Visible = false;
            dataRepeater6.Visible = false;

            UpdatePanel1.Update();
        }
        protected void btnSwitchGrid_CCICT(object sender, EventArgs e)
        {
            
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton2.CssClass += " active";
            dataRepeater1.Visible = false;
            dataRepeater2.Visible = true;
            dataRepeater3.Visible = false;
            dataRepeater4.Visible = false;
            dataRepeater5.Visible = false;
            dataRepeater6.Visible = false;

            UpdatePanel1.Update();

        }
        protected void btnSwitchGrid_CME(object sender, EventArgs e)
        {
            
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton3.CssClass += " active";
            dataRepeater1.Visible = false;
            dataRepeater2.Visible = false;
            dataRepeater3.Visible = true;
            dataRepeater4.Visible = false;
            dataRepeater5.Visible = false;
            dataRepeater6.Visible = false;

            UpdatePanel1.Update();

        }
        protected void btnSwitchGrid_COE(object sender, EventArgs e)
        {

            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton4.CssClass += " active";
            dataRepeater1.Visible = false;
            dataRepeater2.Visible = false;
            dataRepeater3.Visible = false;
            dataRepeater4.Visible = true;
            dataRepeater5.Visible = false;
            dataRepeater6.Visible = false;

            UpdatePanel1.Update();

        }
        protected void btnSwitchGrid_COEd(object sender, EventArgs e)
        {

            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton5.CssClass += " active";
            dataRepeater1.Visible = false;
            dataRepeater2.Visible = false;
            dataRepeater3.Visible = false;
            dataRepeater4.Visible = false;
            dataRepeater5.Visible = true;
            dataRepeater6.Visible = false;

            UpdatePanel1.Update();

        }
        protected void btnSwitchGrid_COT(object sender, EventArgs e)
        {

            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton6.CssClass += " active";
            dataRepeater1.Visible = false;
            dataRepeater2.Visible = false;
            dataRepeater3.Visible = false;
            dataRepeater4.Visible = false;
            dataRepeater5.Visible = false;
            dataRepeater6.Visible = true;

            UpdatePanel1.Update();

        }

    }
}