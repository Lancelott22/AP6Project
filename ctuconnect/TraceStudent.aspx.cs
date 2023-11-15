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
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID", conDB);
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
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE STUDENT_ACCOUNT.firstName LIKE '%" + student + "%' " +
                "or STUDENT_ACCOUNT.lastName LIKE '%" + student + "%' or CAST(STUDENT_ACCOUNT.studentId as varchar) = '" + student + "' ", conDB);
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
            department.Items.Insert(0, new ListItem("Select Department", "0"));
        }
        protected void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PROGRAM WHERE department_ID = '" + department.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            course.DataSource = ds;

            course.DataValueField = "course_ID";
            course.DataTextField = "course";
            course.DataBind();
            course.Items.Insert(0, new ListItem("Select Course", "0"));
        }
        void ShowByCourse()
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE STUDENT_ACCOUNT.course_ID = '" + course.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
        }
        protected void course_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowByCourse();
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
            industry.Items.Insert(0, new ListItem("Select Industry", "0"));
        }
        void ShowByIndustry()
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE HIRED_LIST.industry_accID = '" + industry.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
        }
        protected void industry_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM HIRING WHERE industry_accID = '" + industry.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            position.DataSource = ds;

            position.DataValueField = "jobID";
            position.DataTextField = "jobTitle";
            position.DataBind();
            position.Items.Insert(0, new ListItem("Select Position", "0"));

            ShowByIndustry();
        }

        protected void position_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE HIRED_LIST.jobID = '" + position.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
        }
    }
}