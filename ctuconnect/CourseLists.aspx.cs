using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class CourseLists : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
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

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT PROGRAM.course_ID, DEPARTMENT.departmentName, PROGRAM.course, PROGRAM.courseName, PROGRAM.major, PROGRAM.hoursNeeded FROM PROGRAM " +
                "LEFT JOIN COORDINATOR_ACCOUNT ON PROGRAM.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                "LEFT JOIN DEPARTMENT ON PROGRAM.department_ID = DEPARTMENT.department_ID " +
                "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID ";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the DataTable to the GridView
                programListView.DataSource = ds;
                programListView.DataBind();

            }

        }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }
        protected void CreateNewProgram_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#GenerateNewProgram').modal('show');", true);
        }
        protected void SaveNewProgram_Click(object sender, EventArgs e)
        {
            string  coord_ID = Session["Coor_ACC_ID"].ToString();
            string code = txtCoursecode.Text;
            string name = txtCourseName.Text;
            string major = txtMajor.Text;
            string hours = txtHoursNeeded.Text;


            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmdDept = db.CreateCommand())
                {
                    string query = "SELECT department_ID FROM COORDINATOR_ACCOUNT WHERE coordinator_accID = @Coord_ID ";
                    cmdDept.CommandText = query;
                    cmdDept.Parameters.AddWithValue("@Coord_ID", coord_ID);

                    /*cmdDept.ExecuteNonQuery();*/

                    int departmentId = Convert.ToInt32(cmdDept.ExecuteScalar());

                    using (var cmdProgram = db.CreateCommand())
                    {
                        string query2 = "INSERT PROGRAM (department_ID, course, courseNAme, major, hoursNeeded) VALUES (@departmentID, @coursecode, @coursename, @major, @hoursneeded)";
                        cmdProgram.CommandText = query2;
                        cmdProgram.Parameters.AddWithValue("@departmentID", departmentId);
                        cmdProgram.Parameters.AddWithValue("@coursecode", code);
                        cmdProgram.Parameters.AddWithValue("@coursename", name);
                        cmdProgram.Parameters.AddWithValue("@major", major);
                        cmdProgram.Parameters.AddWithValue("@hoursneeded", hours);

                        cmdProgram.ExecuteNonQuery();
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('show');", true);
        }

        
    }
}