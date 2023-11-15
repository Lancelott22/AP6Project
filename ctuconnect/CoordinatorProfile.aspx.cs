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
    public partial class CoordinatorProfile : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
            if (!IsPostBack)
            {
                // Create an empty DataTable
                BindTable();
            }
        }
            void BindTable()
            {
                int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);

                string query = "SELECT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                                "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email, HIRED_LIST.renderedHours, HIRED_LIST.evaluationRequest " +
                "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN HIRED_LIST  ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID " +
                "lEFT JOIN  COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID  AND STUDENT_ACCOUNT.isGraduated = 0  ";


                /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
           "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
           "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
           "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


                SqlCommand cmd = new SqlCommand(query, conDB);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the DataTable to the GridView
                dataRepeater.DataSource = ds;
                dataRepeater.DataBind();

            }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }


    }
    }
