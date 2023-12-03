using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ctuconnect
{
    public partial class ListOfAlumni : System.Web.UI.Page
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
                string imagePath = "~/images/OJTCoordinatorProfile/" + Session["Coord_Picture"].ToString();
                CoordinatorImage.ImageUrl = imagePath;
                BindTable();
            }
            void BindTable()
            {
                int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);

                string query = "SELECT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email, STUDENT_ACCOUNT.yearGraduated " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "lEFT JOIN  COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
            "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID AND STUDENT_ACCOUNT.isGraduated = 1 ";



                SqlCommand cmd = new SqlCommand(query, conDB);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the DataTable to the GridView
                alumniListview.DataSource = ds;
                alumniListview.DataBind();

            }
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