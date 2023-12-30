using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class TracerDashboard : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {
            HtmlControl dashboardLink = (HtmlControl)Master.FindControl("dashboard");
            dashboardLink.Attributes.Add("class", "active");
            getTotalInternInIndustry();
            getTotalIndustry();
            getTotalJob();
            getTotalAlumnInIndustry();
                BindHiredPerIndustry();
                BindIndustry();
                BindHiredPerJobInIndustry(int.Parse(IndustryJob.SelectedValue));
                BindDepartment();
                BindAlumniEmployment(int.Parse(Department.SelectedValue),int.Parse(Course.SelectedValue));
                BindIsConnectedToCourse(int.Parse(Department.SelectedValue), int.Parse(Course.SelectedValue));
                BindSalaryRange(int.Parse(Department.SelectedValue), int.Parse(Course.SelectedValue));
                BindAlignedToSkill(int.Parse(Department.SelectedValue), int.Parse(Course.SelectedValue));
                BindIsMatchToSkills(int.Parse(Department_1.SelectedValue), int.Parse(Course_1.SelectedValue));
                BindInternHired(int.Parse(Department_1.SelectedValue), int.Parse(Course_1.SelectedValue));
            }
            else
            {
                BindHiredPerIndustry();
                BindHiredPerJobInIndustry(int.Parse(IndustryJob.SelectedValue));
                BindAlumniEmployment(int.Parse(Department.SelectedValue), int.Parse(Course.SelectedValue));
                BindIsConnectedToCourse(int.Parse(Department.SelectedValue), int.Parse(Course.SelectedValue));
                BindSalaryRange(int.Parse(Department.SelectedValue), int.Parse(Course.SelectedValue));
                BindAlignedToSkill(int.Parse(Department.SelectedValue), int.Parse(Course.SelectedValue));
                BindIsMatchToSkills(int.Parse(Department_1.SelectedValue), int.Parse(Course_1.SelectedValue));
                BindInternHired(int.Parse(Department_1.SelectedValue), int.Parse(Course_1.SelectedValue));
            }            
        }
        private void BindHiredPerIndustry()
        {
            Chart1.Series["Internship"].Points.Clear();
            Chart1.Series["Fulltime"].Points.Clear();
            SqlCommand cmd = new SqlCommand("SELECT INDUSTRY_ACCOUNT.industryName, COUNT(HIRED_LIST.id) AS hiredCount" +
                " FROM INDUSTRY_ACCOUNT" +
                " LEFT JOIN HIRED_LIST ON INDUSTRY_ACCOUNT.industry_accID = HIRED_LIST.industry_accID AND jobType = 'internship'" +
                " GROUP BY INDUSTRY_ACCOUNT.industryName;", conDB);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
            Chart1.Series["Internship"].Points.DataBind(dt.DefaultView, "industryName", "hiredCount", "");
             cmd = new SqlCommand("SELECT INDUSTRY_ACCOUNT.industryName, COUNT(HIRED_LIST.id) AS hiredCount" +
                " FROM INDUSTRY_ACCOUNT" +
                " LEFT JOIN HIRED_LIST ON INDUSTRY_ACCOUNT.industry_accID = HIRED_LIST.industry_accID AND jobType = 'fulltime'" +
                " GROUP BY INDUSTRY_ACCOUNT.industryName;", conDB);
             da = new SqlDataAdapter(cmd);
             dt = new DataTable();
            da.Fill(dt);
            Chart1.Series["Fulltime"].Points.DataBind(dt.DefaultView, "industryName", "hiredCount", "");
        }

        void BindHiredPerJobInIndustry(int industryID)
        {
            Chart2.Series["Internship"].Points.Clear();
            Chart2.Series["Fulltime"].Points.Clear();
            SqlCommand cmd = new SqlCommand("SELECT HIRED_LIST.industry_accID, HIRED_LIST.position as jobPosition, industryName, jobTitle, COUNT(*) AS HiredPerJob FROM HIRING INNER JOIN HIRED_LIST ON HIRING.jobID = HIRED_LIST.jobID AND HIRED_LIST.jobType = 'internship' WHERE HIRED_LIST.industry_accID = '"+ industryID + "' GROUP BY HIRED_LIST.industry_accID, industryName, jobTitle, HIRED_LIST.position", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart2.Series["Internship"].Points.DataBind(dt.DefaultView, "jobPosition", "HiredPerJob", "");
            cmd = new SqlCommand("SELECT HIRED_LIST.industry_accID, HIRED_LIST.position as jobPosition, industryName, jobTitle, COUNT(*) AS HiredPerJob FROM HIRING INNER JOIN HIRED_LIST ON HIRING.jobID = HIRED_LIST.jobID AND HIRED_LIST.jobType = 'fulltime' WHERE HIRED_LIST.industry_accID = '"+ industryID + "' GROUP BY HIRED_LIST.industry_accID, industryName, jobTitle, HIRED_LIST.position", conDB);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            Chart2.Series["Fulltime"].Points.DataBind(dt.DefaultView, "jobPosition", "HiredPerJob", "");

            if(dt.Rows.Count == 0)
            {
                Chart2.Visible = false;
                NoData.Visible = true;
            }
            else
            {
                Chart2.Visible = true;
                NoData.Visible = false;
            }
        }
        void getTotalAlumnInIndustry()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(student_accID) as TotalAlumni from STUDENT_ACCOUNT WHERE EXISTS (SELECT student_accID FROM ALUMNI_EMPLOYMENTFORM WHERE STUDENT_ACCOUNT.student_accID = ALUMNI_EMPLOYMENTFORM.student_accID) and studentStatus = 'Alumni'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalAlumni.InnerText = reader["TotalAlumni"].ToString();
            }        
            reader.Close();
            conDB.Close();
        }
        void getTotalInternInIndustry()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(student_accID) as TotalIntern from STUDENT_ACCOUNT WHERE EXISTS (SELECT student_accID FROM HIRED_LIST WHERE STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID) and isHired = 1 and studentStatus = 'Intern'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalIntern.InnerText = reader["TotalIntern"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void getTotalIndustry()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(industry_accID) as TotalIndustry from INDUSTRY_ACCOUNT", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalIndustry.InnerText = reader["TotalIndustry"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void getTotalJob()
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(jobID) as TotalJobPosted from HIRING", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                totalJobPosted.InnerText = reader["TotalJobPosted"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
        void BindIndustry()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM INDUSTRY_ACCOUNT", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryJob.DataSource = ds;
            IndustryJob.DataValueField = "industry_accID";
            IndustryJob.DataTextField = "industryName";
            IndustryJob.DataBind();
            IndustryJob.SelectedValue = "industry_accID";
        }

        protected void IndustryJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            int industry_accID = int.Parse(IndustryJob.SelectedValue);
            BindHiredPerJobInIndustry(industry_accID);
            BindHiredPerIndustry();
        }
        void BindDepartment()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DEPARTMENT", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Department.DataSource = ds;
            Department.DataValueField = "department_ID";
            Department.DataTextField = "departmentName";
            Department.DataBind();
            Department.Items.Insert(0, new ListItem("All", "0"));
            Department_1.DataSource = ds;
            Department_1.DataValueField = "department_ID";
            Department_1.DataTextField = "departmentName";
            Department_1.DataBind();
            Department_1.Items.Insert(0, new ListItem("All", "0"));
        }
        protected void Department_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if(Department.SelectedValue == "0")
            {
                Response.Redirect("TracerDashboard.aspx");
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM PROGRAM WHERE department_ID = '" + Department.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Course.DataSource = ds;
            Course.DataValueField = "course_ID";
            Course.DataTextField = "course";            
            Course.DataBind();
            Course.Items.Insert(0, new ListItem("All", "0"));
            Course.SelectedIndex = 0;
        }

        protected void Course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BindAlumniEmployment(int departmentid, int course_ID)
        {
            Chart3.Series["EmploymentType"].Points.Clear();
            SqlCommand cmd = new SqlCommand();
            if (departmentid == 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT employmentStatus, COUNT(id) AS employmentCount" +
                " FROM ALUMNI_EMPLOYMENTFORM" +
                " GROUP BY employmentStatus;", conDB);
            }
            else if(departmentid != 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT employmentStatus, COUNT(id) AS employmentCount" +
             " FROM ALUMNI_EMPLOYMENTFORM LEFT JOIN STUDENT_ACCOUNT ON ALUMNI_EMPLOYMENTFORM.student_accID = STUDENT_ACCOUNT.student_accID" +
             " WHERE department_ID = '" + departmentid + "' GROUP BY employmentStatus;", conDB);
            }
            else
            {
                cmd = new SqlCommand("SELECT employmentStatus, COUNT(id) AS employmentCount" +
                " FROM ALUMNI_EMPLOYMENTFORM LEFT JOIN STUDENT_ACCOUNT ON ALUMNI_EMPLOYMENTFORM.student_accID = STUDENT_ACCOUNT.student_accID  " +
                " WHERE department_ID = '" + departmentid + "' and course_ID = '" + course_ID + "' GROUP BY employmentStatus;", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart3.Series["EmploymentType"].Points.DataBind(dt.DefaultView, "employmentStatus", "employmentCount", "");
        }
        private void BindIsConnectedToCourse(int departmentid, int course_ID)
        {

            Chart4.Series["IsConnectedCourse"].Points.Clear();
            SqlCommand cmd = new SqlCommand();
            if (departmentid == 0 && course_ID == 0)
            {
               cmd = new SqlCommand("SELECT isConnectedToCourse, COUNT(id) AS isConnectedCount" +
                " FROM ALUMNI_EMPLOYMENTFORM GROUP BY isConnectedToCourse;", conDB);
            }
            else if (departmentid != 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT isConnectedToCourse, COUNT(id) AS isConnectedCount" +
              " FROM ALUMNI_EMPLOYMENTFORM LEFT JOIN STUDENT_ACCOUNT ON ALUMNI_EMPLOYMENTFORM.student_accID = STUDENT_ACCOUNT.student_accID " +
              " WHERE department_ID = '" + departmentid + "' GROUP BY isConnectedToCourse;", conDB);
            }
            else
            {
                cmd = new SqlCommand("SELECT isConnectedToCourse, COUNT(id) AS isConnectedCount" +
               " FROM ALUMNI_EMPLOYMENTFORM LEFT JOIN STUDENT_ACCOUNT ON ALUMNI_EMPLOYMENTFORM.student_accID = STUDENT_ACCOUNT.student_accID " +
               " WHERE department_ID = '" + departmentid + "' and course_ID = '" + course_ID + "' GROUP BY isConnectedToCourse;", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart4.Series["IsConnectedCourse"].Points.DataBind(dt.DefaultView, "isConnectedToCourse", "isConnectedCount", "");
        }
        private void BindSalaryRange(int departmentid, int course_ID)
        {

            Chart5.Series["SalaryRange"].Points.Clear();
            SqlCommand cmd = new SqlCommand();
            if (departmentid == 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT SalaryRange, COUNT(id) AS SalaryCount" +
                 " FROM ALUMNI_EMPLOYMENTFORM GROUP BY SalaryRange;", conDB);
            }
            else if (departmentid != 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT SalaryRange, COUNT(id) AS SalaryCount" +
               " FROM ALUMNI_EMPLOYMENTFORM LEFT JOIN STUDENT_ACCOUNT ON ALUMNI_EMPLOYMENTFORM.student_accID = STUDENT_ACCOUNT.student_accID " +
               " WHERE department_ID = '" + departmentid + "' GROUP BY SalaryRange;", conDB);
            }
            else
            {
                cmd = new SqlCommand("SELECT SalaryRange, COUNT(id) AS SalaryCount" +
               " FROM ALUMNI_EMPLOYMENTFORM LEFT JOIN STUDENT_ACCOUNT ON ALUMNI_EMPLOYMENTFORM.student_accID = STUDENT_ACCOUNT.student_accID " +
               " WHERE department_ID = '" + departmentid + "' and course_ID = '" + course_ID + "' GROUP BY SalaryRange;", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart5.Series["SalaryRange"].Points.DataBind(dt.DefaultView, "SalaryRange", "SalaryCount", "");
        }
        private void BindAlignedToSkill(int departmentid, int course_ID)
        {
            Chart6.Series["AlignedToSkill"].Points.Clear();
            SqlCommand cmd = new SqlCommand();
            if (departmentid == 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT isAlignedToSkill, COUNT(id) AS AlignedToSkillCount" +
                 " FROM ALUMNI_EMPLOYMENTFORM GROUP BY isAlignedToSkill;", conDB);
            }
            else if (departmentid != 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT isAlignedToSkill, COUNT(id) AS AlignedToSkillCount" +
               " FROM ALUMNI_EMPLOYMENTFORM LEFT JOIN STUDENT_ACCOUNT ON ALUMNI_EMPLOYMENTFORM.student_accID = STUDENT_ACCOUNT.student_accID " +
               " WHERE department_ID = '" + departmentid + "' GROUP BY isAlignedToSkill;", conDB);
            }
            else
            {
                cmd = new SqlCommand("SELECT isAlignedToSkill, COUNT(id) AS AlignedToSkillCount" +
               " FROM ALUMNI_EMPLOYMENTFORM LEFT JOIN STUDENT_ACCOUNT ON ALUMNI_EMPLOYMENTFORM.student_accID = STUDENT_ACCOUNT.student_accID " +
               " WHERE department_ID = '" + departmentid + "' and course_ID = '" + course_ID + "' GROUP BY isAlignedToSkill;", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart6.Series["AlignedToSkill"].Points.DataBind(dt.DefaultView, "isAlignedToSkill", "AlignedToSkillCount", "");
        }

        private void BindIsMatchToSkills(int departmentid, int course_ID)
        {
            Chart7.Series["IsMatchToSkills"].Points.Clear();
            SqlCommand cmd = new SqlCommand();
            if (departmentid == 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT case when isMatchToSkills = 1 then 'Matched' else 'Not Matched' end as MatchToSkills, COUNT(formID) AS MatchToSkillsCount" +
                 " FROM INTERNSHIPFORM GROUP BY CASE WHEN isMatchToSkills = 1 THEN 'Matched' ELSE 'Not Matched' END;", conDB);
            }
            else if (departmentid != 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT case when isMatchToSkills = 1 then 'Matched' else 'Not Matched' end as MatchToSkills, COUNT(formID) AS MatchToSkillsCount" +
                 " FROM INTERNSHIPFORM LEFT JOIN STUDENT_ACCOUNT ON INTERNSHIPFORM.student_accID = STUDENT_ACCOUNT.student_accID" +
                 " WHERE department_ID = '" + departmentid + "' GROUP BY CASE WHEN isMatchToSkills = 1 THEN 'Matched' ELSE 'Not Matched' END;", conDB);
            }
            else
            {
                cmd = new SqlCommand("SELECT case when isMatchToSkills = 1 then 'Matched' else 'Not Matched' end as MatchToSkills, COUNT(formID) AS MatchToSkillsCount" +
                 " FROM INTERNSHIPFORM LEFT JOIN STUDENT_ACCOUNT ON INTERNSHIPFORM.student_accID = STUDENT_ACCOUNT.student_accID" +
                 " WHERE department_ID = '" + departmentid + "' and course_ID = '" + course_ID + "' GROUP BY CASE WHEN isMatchToSkills = 1 THEN 'Matched' ELSE 'Not Matched' END;", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart7.Series["IsMatchToSkills"].Points.DataBind(dt.DefaultView, "MatchToSkills", "MatchToSkillsCount", "");
        }
        private void BindInternHired(int departmentid, int course_ID)
        {
            Chart8.Series["InternHired"].Points.Clear();
            SqlCommand cmd = new SqlCommand();
            if (departmentid == 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT case when isHired = 1 then 'Hired' else 'Not hired' end as Hired, COUNT(student_accID) AS TotalHired" +
                 " FROM STUDENT_ACCOUNT GROUP BY case when isHired = 1 then 'Hired' else 'Not hired' end;", conDB);
            }
            else if (departmentid != 0 && course_ID == 0)
            {
                cmd = new SqlCommand("SELECT  case when isHired = 1 then 'Hired' else 'Not hired' end as Hired, COUNT(student_accID) AS TotalHired" +
                 " FROM STUDENT_ACCOUNT WHERE department_ID = '" + departmentid + "' GROUP BY case when isHired = 1 then 'Hired' else 'Not hired' end;", conDB);
            }
            else
            {
                cmd = new SqlCommand("SELECT  case when isHired = 1 then 'Hired' else 'Not hired' end as Hired, COUNT(student_accID) AS TotalHired" +
                 " FROM STUDENT_ACCOUNT WHERE department_ID = '" + departmentid + "' and course_ID = '" + course_ID + "' GROUP BY case when isHired = 1 then 'Hired' else 'Not hired' end;", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart8.Series["InternHired"].Points.DataBind(dt.DefaultView, "Hired", "TotalHired", "");
        }

        protected void Deparment1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Department_1.SelectedValue == "0")
            {
                Response.Redirect("TracerDashboard.aspx");
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM PROGRAM WHERE department_ID = '" + Department_1.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Course_1.DataSource = ds;
            Course_1.DataValueField = "course_ID";
            Course_1.DataTextField = "course";
            Course_1.DataBind();
            Course_1.Items.Insert(0, new ListItem("All", "0"));
            Course_1.SelectedIndex = 0;


        }

        protected void Course1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}