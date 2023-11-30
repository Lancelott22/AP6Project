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
    public partial class CourseLists : System.Web.UI.Page
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
                BindListView1();
            }
        }
        void BindListView1()
        {
             int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);

            string query = "SELECT PROGRAM.course_ID, DEPARTMENT.departmentName, PROGRAM.course, PROGRAM.major, PROGRAM.hoursNeeded FROM PROGRAM " +
                "LEFT JOIN COORDINATOR_ACCOUNT ON PROGRAM.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                "LEFT JOIN DEPARTMENT ON PROGRAM.department_ID = DEPARTMENT.department_ID " +
                "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID ";
            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            programListView.DataSource = ds;
            programListView.DataBind();



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