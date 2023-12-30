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
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        SqlConnection connectionDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

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
                BindAcademicYear();
                BindCourse();
            }
            void BindTable()
            {
                int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);


                string query = "SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE department = (SELECT departmentName FROM DEPARTMENT WHERE department_ID = " +
                               "(SELECT department_ID FROM COORDINATOR_ACCOUNT WHERE coordinator_accID = @CoordinatorID))";


                /*"SELECT STUDENT_ACCOUNT.student_accID, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                        "PROGRAM.course, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email, STUDENT_ACCOUNT.yearGraduated " +
        "FROM STUDENT_ACCOUNT LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
        "LEFT JOIN  COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
        "INNER JOIN  GRADUATES_TABLE ON STUDENT_ACCOUNT.student_accID = GRADUATES_TABLE.student_accID " +
        "WHERE GRADUATES_TABLE.department = @Coordinatordept ";*/



                SqlCommand cmd = new SqlCommand(query, connectionDB);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the DataTable to the GridView
                alumniListview.DataSource = ds;
                alumniListview.DataBind();

            }
        }
        void BindAcademicYear()
        {
            string query = "SELECT DISTINCT yearGraduated FROM GRADUATES_TABLE ";
                SqlCommand cmd = new SqlCommand(query, connectionDB);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);

            ds.Columns.Add("YearGraduatedInt", typeof(int));
            foreach (DataRow row in ds.Rows)
            {
                string[] years = row["yearGraduated"].ToString().Split('-');
                if (years.Length == 2)
                {
                    int startYear, endYear;
                    if (int.TryParse(years[0], out startYear) && int.TryParse(years[1], out endYear))
                    {
                        row["YearGraduatedInt"] = endYear;
                    }
                }
            }

            // Reverse the order of the rows in the DataTable
            ds.DefaultView.Sort = "YearGraduatedInt DESC";
            ds = ds.DefaultView.ToTable();

            ddlAcademicYear.DataSource = ds;
                ddlAcademicYear.DataTextField = "yearGraduated";
                ddlAcademicYear.DataValueField = "yearGraduated";
                ddlAcademicYear.DataBind();

            
        }
        void BindCourse()
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);

            string query = "SELECT course FROM PROGRAM " +
                        "lEFT JOIN  COORDINATOR_ACCOUNT ON PROGRAM.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                        "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID  ";
            
                SqlCommand cmd = new SqlCommand(query, connectionDB);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                programList.DataSource = ds;
                programList.DataTextField = "course";
                programList.DataValueField = "course";
                programList.DataBind();
                programList.Items.Insert(0, new ListItem("Select Program", "0"));

            
        }
        protected void ddlacademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowListView();

        }
        protected void program_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowListView();

        }
        void ShowListView()
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            string selectedAcademicYearValue = ddlAcademicYear.SelectedValue;
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE department = (SELECT departmentName FROM DEPARTMENT WHERE department_ID = " +
                               "(SELECT department_ID FROM COORDINATOR_ACCOUNT WHERE coordinator_accID = @CoordinatorID))", db);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);

                if (selectedAcademicYearValue != null)
                {
                    cmd.CommandText += " AND GRADUATES_TABLE.yearGraduated = @SelectedAcademicYear";
                    cmd.Parameters.AddWithValue("@SelectedAcademicYear", selectedAcademicYearValue);
                }
                if (programList.SelectedValue != "0")
                {
                    cmd.CommandText += " AND GRADUATES_TABLE.course = @CourseName";
                    cmd.Parameters.AddWithValue("@CourseName", programList.SelectedValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
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