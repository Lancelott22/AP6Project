using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ctuconnect
{
    public partial class TraceStudent : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl traceStudentLink = (HtmlControl)Master.FindControl("traceStudent");
            traceStudentLink.Attributes.Add("class", "active");

            if (!IsPostBack)
            {
                BindInternList();
                BindDepartment();
                BindIndustry();
                /* if (ViewState["selectedCourse"] != null)
                 {
                     course.SelectedValue = ViewState["selectedCourse"].ToString();
                     ShowByCourse();
                 }*/
            }

        }
        void BindInternList()
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID JOIN DEPARTMENT ON STUDENT_ACCOUNT.department_ID = DEPARTMENT.department_ID WHERE HIRED_LIST.studentType = 'Intern'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
            if (InternListView.Items.Count == 0)
            {
                /*  ListViewPager.Visible = false;*/
            }
        }
        void SearchByStudentNameOrID(string student)
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID JOIN DEPARTMENT ON STUDENT_ACCOUNT.department_ID = DEPARTMENT.department_ID WHERE  HIRED_LIST.studentType = 'Intern' and (STUDENT_ACCOUNT.firstName LIKE '%" + student + "%' " +
                "or STUDENT_ACCOUNT.lastName LIKE '%" + student + "%' or CAST(STUDENT_ACCOUNT.studentId as varchar) = '" + student + "') ", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
        }
        protected void SearchStudent_Click(object sender, EventArgs e)
        {
            string student = StudentNameOrID.Text;
            SearchByStudentNameOrID(student);
        }
        void BindDepartment()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DEPARTMENT", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            department.DataSource = ds;
            department.DataValueField = "department_ID";
            department.DataTextField = "departmentName";
            department.DataBind();
            department.Items.Insert(0, new ListItem("All", "0"));
            course.Items.Insert(0, new ListItem("All", "0"));
            course.SelectedIndex = 0;
        }
        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (department.SelectedValue == "0")
            {
                Response.Redirect("TraceStudent.aspx");
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM PROGRAM WHERE department_ID = '" + department.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            course.DataSource = ds;
            course.DataValueField = "course_ID";
            course.DataTextField = "course";
            course.DataBind();
            course.Items.Insert(0, new ListItem("All", "0"));
            course.SelectedIndex = 0;
            ShowByCourse(int.Parse(department.SelectedValue), int.Parse(course.SelectedValue));
        }
        void ShowByCourse(int departmentid, int course_ID)
        {
            SqlCommand cmd = new SqlCommand();

            if (departmentid != 0 && course_ID == 0)
            {
                cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                    " JOIN DEPARTMENT ON STUDENT_ACCOUNT.department_ID = DEPARTMENT.department_ID WHERE STUDENT_ACCOUNT.department_ID = '" + departmentid + "' and HIRED_LIST.studentType = 'Intern'", conDB);
            }
            else
            {
                cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                    " JOIN DEPARTMENT ON STUDENT_ACCOUNT.department_ID = DEPARTMENT.department_ID WHERE STUDENT_ACCOUNT.department_ID = '" + departmentid + "' and STUDENT_ACCOUNT.course_ID = '" + course_ID + "' and HIRED_LIST.studentType = 'Intern'", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
        }
        protected void course_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowByCourse(int.Parse(department.SelectedValue), int.Parse(course.SelectedValue));
            /*ViewState["selectedCourse"] = course.SelectedValue;*/
        }

        void BindIndustry()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM INDUSTRY_ACCOUNT", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            industry.DataSource = ds;
            industry.DataValueField = "industry_accID";
            industry.DataTextField = "industryName";
            industry.DataBind();
            industry.Items.Insert(0, new ListItem("All", "0"));
        }
        void ShowByIndustry()
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID JOIN DEPARTMENT ON STUDENT_ACCOUNT.department_ID = DEPARTMENT.department_ID WHERE HIRED_LIST.industry_accID = '" + industry.SelectedValue + "' and HIRED_LIST.studentType = 'Intern'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
        }
        protected void industry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (industry.SelectedValue == "0")
            {
                Response.Redirect("TraceStudent.aspx");
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM HIRING WHERE industry_accID = '" + industry.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            position.DataSource = ds;

            position.DataValueField = "jobID";
            position.DataTextField = "jobTitle";
            position.DataBind();
            position.Items.Insert(0, new ListItem("All", "0"));

            ShowByIndustry();
        }

        protected void position_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (position.SelectedValue == "0")
            {
                ShowByIndustry();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID JOIN DEPARTMENT ON STUDENT_ACCOUNT.department_ID = DEPARTMENT.department_ID WHERE HIRED_LIST.jobID = '" + position.SelectedValue + "' and HIRED_LIST.studentType = 'Intern'", conDB);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                InternListView.DataSource = ds;
                InternListView.DataBind();
            }
        }

        void getDetails(int hired_ID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select * from HIRED_LIST JOIN STUDENT_ACCOUNT ON HIRED_LIST.student_accID = STUDENT_ACCOUNT.student_accID JOIN INDUSTRY_ACCOUNT " +
                "ON HIRED_LIST.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID JOIN DEPARTMENT ON STUDENT_ACCOUNT.department_ID = DEPARTMENT.department_ID WHERE HIRED_LIST.id = @hired_id", conDB);
            cmd.Parameters.AddWithValue("@hired_id", hired_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                studentPic.Src = "~/images/StudentProfiles/" + reader["studentPicture"].ToString();
                Name.InnerText = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                StudCourse.InnerText = reader["course"].ToString();
                Email.InnerText = reader["email"].ToString();
                Address.InnerText = reader["address"].ToString();
                CNumber.InnerText = reader["contactNumber"].ToString();
                industryLogo.Src = "~/images/IndustryProfile/" + reader["industryPicture"].ToString();
                JobPosition.InnerText = reader["position"].ToString();
                jobType.InnerText = reader["jobType"].ToString();
                IndustryName.InnerText = reader["workedAt"].ToString();
                IndustryAddress.InnerText = reader["location"].ToString();
                InternshipStatus.InnerText = reader["internshipStatus"].ToString();
            }
        }
        protected void viewProfile_Command(object sender, CommandEventArgs e)
        {

            int hired_ID = int.Parse(e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showIntern();", true);
            getDetails(hired_ID);
        }

        protected void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (Status.SelectedValue == "0")
            {
                Response.Redirect("TraceStudent.aspx");
            }
            else
            {
                cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID JOIN DEPARTMENT ON STUDENT_ACCOUNT.department_ID = DEPARTMENT.department_ID WHERE HIRED_LIST.internshipStatus = '" + Status.SelectedValue + "' and HIRED_LIST.studentType = 'Intern'", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
        }
    }
}