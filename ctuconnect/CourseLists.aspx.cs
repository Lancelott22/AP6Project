using Org.BouncyCastle.Asn1.Cmp;
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

                if (ViewState["SelectedcourseID"] != null)
                {
                    selectedcourseID = (List<string>)ViewState["SelectedcourseID"];
                }
                else if (ViewState["SelectedDepartment"] != null)
                {
                    selectedDepartment = (List<string>)ViewState["SelectedDepartment"];
                }
                else if (ViewState["SelectedCourse"] != null)
                {
                    selectedCourse = (List<string>)ViewState["SelectedCourse"];
                }
                else if (ViewState["SelectedCourseName"] != null)
                {
                    selectedCourseName = (List<string>)ViewState["SelectedCourseName"];
                }
                else if (ViewState["SelectedMajor"] != null)
                {
                    selectedMajor = (List<string>)ViewState["SelectedMajor"];
                }
                else if (ViewState["SelectedHours"] != null)
                {
                    selectedHours = (List<string>)ViewState["SelectedHours"];
                }
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
            string coord_ID = Session["Coor_ACC_ID"].ToString();
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

        private List<string> selectedcourseID = new List<string>();
        private List<string> selectedDepartment = new List<string>();
        private List<string> selectedCourse = new List<string>();
        private List<string> selectedCourseName = new List<string>();
        private List<string> selectedMajor = new List<string>();
        private List<string> selectedHours = new List<string>();

        protected void EditCourse_Click(object sender, EventArgs e)
        {
            LinkButton editbtn = (LinkButton)sender;
            int checkedCount = 0;


            foreach (ListViewItem item in programListView.Items)
            {
                CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    Label courseIDlbl = (Label)item.FindControl("courseIDlbl");
                    Label depNamelbl = (Label)item.FindControl("depNamelbl");
                    Label courselbl = (Label)item.FindControl("courselbl");
                    Label courseNamelbl = (Label)item.FindControl("courseNamelbl");
                    Label majorlbl = (Label)item.FindControl("majorlbl");
                    Label hourslbl = (Label)item.FindControl("hourslbl");

                    string courseid = courseIDlbl.Text;
                    string dept = depNamelbl.Text;
                    string course = courselbl.Text;
                    string coursename = courseNamelbl.Text;
                    string major = majorlbl.Text;
                    string hours = hourslbl.Text;


                    selectedcourseID.Add(courseid);
                    selectedDepartment.Add(dept);
                    selectedCourse.Add(course);
                    selectedCourseName.Add(coursename);
                    selectedMajor.Add(major);
                    selectedHours.Add(hours);

                    checkedCount++;
                }
            }
            ViewState["SelectedcourseID"] = selectedcourseID;
            ViewState["SelectedDepartment"] = selectedDepartment;
            ViewState["SelectedCourse"] = selectedCourse;
            ViewState["SelectedCourseName"] = selectedCourseName;
            ViewState["SelectedMajor"] = selectedMajor;
            ViewState["SelectedHours"] = selectedHours;

            if (checkedCount > 1)
            {
                string courseName = string.Join(" ", selectedCourseName);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openMultipleSelectModal('{courseName}');", true);

            }
            else if (checkedCount == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showModal", "$('#NoSelected').modal('show');", true);
            }
            else if (checkedCount == 1)
            {
                string existingCourse = string.Join(" ", selectedCourse);
                string existingCourseName = string.Join(" ", selectedCourseName);
                string existingMajor = string.Join(" ", selectedMajor);
                string existingHours = string.Join(" ", selectedHours);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openSingleSelectModal('{existingCourse}','{existingCourseName}','{existingMajor}','{existingHours}');", true);

            }
        }
        protected void UpdateProgram_Click(object sender, EventArgs e)
        {
            List<string> courseIds = ViewState["SelectedcourseID"] as List<string>;
            string render = rendertext.Text;

            if (courseIds != null)
            {
                foreach (string courseId in courseIds)
                {

                    int programId = Convert.ToInt32(courseId);

                    using (var db = new SqlConnection(conDB))
                    {
                        db.Open();
                        string query = " UPDATE PROGRAM SET hoursNeeded = @renderhrs WHERE course_ID = @courseID ";
                        SqlCommand cmd = new SqlCommand(query, db);
                        cmd.Parameters.AddWithValue("@courseID", programId);
                        cmd.Parameters.AddWithValue("@renderhrs", render);

                        cmd.ExecuteNonQuery();
                    }

                }

                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessMultipleEditPrompt').modal('show');", true);
            }
            else
            {
                //
            }
        }

        protected void SaveProgramUpdate_Click(object sender, EventArgs e)
        {

            string code = ccodetxt.Text;
            string name = cnametxt.Text;
            string major = majortxt.Text;
            string hours = hrstxt.Text;

            foreach (ListViewItem item in programListView.Items)
            {
                CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    Label courseIDlbl = (Label)item.FindControl("courseIDlbl");

                    string courseid = courseIDlbl.Text;
                    if (courseid != null)
                    {
                        int programID = Convert.ToInt32(courseid);
                        // Proceed with saving

                        using (var db = new SqlConnection(conDB))
                        {
                            db.Open();
                            using (var cmd = db.CreateCommand())
                            {
                                string sql = "UPDATE PROGRAM SET  course = @coursee, courseName = @coursename, major = @majorname , hoursNeeded = @hoursrender WHERE course_ID = @courseID";
                                cmd.CommandText = sql;
                                cmd.Parameters.AddWithValue("@courseID", programID);
                                cmd.Parameters.AddWithValue("@coursee", code);
                                cmd.Parameters.AddWithValue("@coursename", name);
                                cmd.Parameters.AddWithValue("@majorname", major);
                                cmd.Parameters.AddWithValue("@hoursrender", hours);

                                cmd.ExecuteNonQuery();
                            }
                            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessSingleEditPrompt').modal('show');", true);

                        }
                    }
                }
            }
        }
        protected void closeGenerateModal(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#GenerateNewProgram').modal('hide');document.location='CourseLists.aspx'", true);
        }
        protected void closeModalRender(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#RenderHours').modal('hide');document.location='CourseLists.aspx'", true);
        }
        protected void close_Modal(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('hide');document.location='CourseLists.aspx'", true);
        }
        protected void close_SuccesSingleEdit(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessSingleEditPrompt').modal('hide');document.location='CourseLists.aspx'", true);
        }
        protected void CloseModal_multiple(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessMultipleEditPrompt').modal('hide');document.location='CourseLists.aspx'", true);
        }
        protected void closeModalUpdate(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#UpdateProgram').modal('hide');document.location='CourseLists.aspx'", true);
        }


    }
}