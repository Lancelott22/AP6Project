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
using Antlr.Runtime.Tree;

namespace ctuconnect
{
    public partial class TraceAlumni : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl traceAlumniLink = (HtmlControl)Master.FindControl("traceAlumni");
            traceAlumniLink.Attributes.Add("class", "active");
           
            if(!IsPostBack)
            {
                BindAlumniList();
                BindDepartment();
               /* BindIndustry();*/
               /* if (ViewState["selectedCourse"] != null)
                {
                    course.SelectedValue = ViewState["selectedCourse"].ToString();
                    ShowByCourse();
                }*/
            }
          

        }
        void BindAlumniList()
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN ALUMNI_EMPLOYMENTFORM ON STUDENT_ACCOUNT.student_accID = ALUMNI_EMPLOYMENTFORM.student_accID JOIN PROGRAM ON " +
                "STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE studentStatus = 'Alumni'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            AlumniListView.DataSource = ds;
            AlumniListView.DataBind();
            if (AlumniListView.Items.Count == 0)
            {
                /*  ListViewPager.Visible = false;*/
            }
        }
        void SearchByAlumniNameorID(string alumni)
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN ALUMNI_EMPLOYMENTFORM ON STUDENT_ACCOUNT.student_accID = ALUMNI_EMPLOYMENTFORM.student_accID JOIN PROGRAM ON " +
                "STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE studentStatus = 'Alumni' and  STUDENT_ACCOUNT.firstName LIKE '%" + alumni + "%' " +
                "or STUDENT_ACCOUNT.lastName LIKE '%" + alumni + "%' or CAST(STUDENT_ACCOUNT.studentId as varchar) = '" + alumni + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            AlumniListView.DataSource = ds;
            AlumniListView.DataBind();
        }
        protected void SearchAlumni_Click(object sender, EventArgs e)
        {
            string alumni = AlumniNameOrID.Text;
            SearchByAlumniNameorID(alumni);
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
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN ALUMNI_EMPLOYMENTFORM ON STUDENT_ACCOUNT.student_accID = ALUMNI_EMPLOYMENTFORM.student_accID JOIN PROGRAM ON " +
                "STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE STUDENT_ACCOUNT.course_ID = '" + course.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            AlumniListView.DataSource = ds;
            AlumniListView.DataBind();
        }
        protected void course_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowByCourse();
            /*ViewState["selectedCourse"] = course.SelectedValue;*/
        }

        /*void BindIndustry()
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
        }*/
        /* void ShowByIndustry()
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = ALUMNI_EMPLOYMENTFORM.student_accID JOIN PROGRAM ON " +
                "STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE HIRED_LIST.industry_accID = '" + industry.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            AlumniListView.DataSource = ds;
            AlumniListView.DataBind();
        }*/
        /*protected void industry_SelectedIndexChanged(object sender, EventArgs e)
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
        }*/

        /* protected void position_SelectedIndexChanged(object sender, EventArgs e)
         {
             SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON " +
                 "STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE HIRED_LIST.jobID = '" + position.SelectedValue + "'", conDB);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable ds = new DataTable();
             da.Fill(ds);
             AlumniListView.DataSource = ds;
             AlumniListView.DataBind();
         }*/

        void getDetails(int studentID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN ALUMNI_EMPLOYMENTFORM ON STUDENT_ACCOUNT.student_accID = ALUMNI_EMPLOYMENTFORM.student_accID JOIN PROGRAM ON " +
                "STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID WHERE studentStatus = 'Alumni' and STUDENT_ACCOUNT.studentID = @studentID ", conDB);
            cmd.Parameters.AddWithValue("@studentID", studentID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                studentPic.Src = "~/images/StudentProfiles/" + reader["studentPicture"].ToString();
                Name.InnerText = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                StudCourse.InnerText = reader["course"].ToString();
                Email.InnerText = reader["email"].ToString();
                Address.InnerText = reader["address"].ToString();
                CNumber.InnerText = reader["contactNumber"].ToString();
                EmploymentStatus.InnerText = reader["employmentStatus"].ToString();
                CompanyOrBusinessName.InnerText = reader["CompanyOrBusinessName"].ToString();
                DepartmentName.InnerText = reader["Department"].ToString();
                Position.InnerText = reader["Position"].ToString();
                typeOfEmployment.InnerText = reader["TypeOfEmployement"].ToString();
                SalaryRange.InnerText = reader["SalaryRange"].ToString();
                dateHired.InnerText = reader["DateHired"].ToString();
                connectedToCourse.InnerText = reader["isConnectedToCourse"].ToString();
                alignedToSkills.InnerText = reader["isAlignedToSkill"].ToString();
            }
        }
        protected void viewProfile_Command(object sender, CommandEventArgs e)
        {         
            int studentID = int.Parse(e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showAlumni();", true);
           getDetails(studentID);
        }
    }
}