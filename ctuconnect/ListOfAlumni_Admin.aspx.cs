using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class ListOfAlumni_Admin : System.Web.UI.Page
    {
        SqlConnection connectionDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create an empty DataTable
                BindTableCAS();
                BindTableCCICT();
                BindTableCME();
                BindTableCOE();
                BindTableCOEd();
                BindTableCOT();

                BindSchoolYear();
                BindCourse();

                myLinkButton1.CssClass += " active";
                CASListview.Visible = true;
                CCICTListview.Visible = false;
                CMEListview.Visible = false;
                COEListview.Visible = false;
                COEdListview.Visible = false;
                COTListview.Visible = false;
            }
        }
        void BindTableCAS()
        {
            string departmentName ="CAS";

            string query = "SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE department = @department";

            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            CASListview.DataSource = ds;
            CASListview.DataBind();

        }
        void BindTableCCICT()
        {
            string departmentName = "CCICT";

            string query = "SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE department = @department";


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            CCICTListview.DataSource = ds;
            CCICTListview.DataBind();

        }
        void BindTableCME()
        {
            string departmentName = "CME";

            string query = "SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE department = @department";


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            CMEListview.DataSource = ds;
            CMEListview.DataBind();

        }
        void BindTableCOE()
        {
            string departmentName = "COE";

            string query = "SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE department = @department";


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            COEListview.DataSource = ds;
            COEListview.DataBind();

        }
        void BindTableCOEd()
        {
            string departmentName = "COEd";

            string query = "SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE department = @department";


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            COEdListview.DataSource = ds;
            COEdListview.DataBind();

        }
        void BindTableCOT()
        {
            string departmentName = "COT";

            string query = "SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE department = @department";


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            COTListview.DataSource = ds;
            COTListview.DataBind();

        }
        protected void btnSwitchGrid_CAS(object sender, EventArgs e)
        {
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton1.CssClass += " active";

            CASListview.Visible = true;
            CCICTListview.Visible = false;
            CMEListview.Visible = false;
            COEListview.Visible = false;
            COEdListview.Visible = false;
            COTListview.Visible = false;

            ddlAcademicYear.Visible = true;
            ddlAcademicYear2.Visible = false;
            ddlAcademicYear3.Visible = false;
            ddlAcademicYear4.Visible = false;
            ddlAcademicYear5.Visible = false;
            ddlAcademicYear6.Visible = false;

            programList.Visible = true;
            programList2.Visible = false;
            programList3.Visible = false;
            programList4.Visible = false;
            programList5.Visible = false;
            programList6.Visible = false;

            BindSchoolYear();
            BindCourse();

            UpdatePanel1.Update();
        }
        protected void btnSwitchGrid_CCICT(object sender, EventArgs e)
        {

            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton2.CssClass += " active";

            CASListview.Visible = false;
            CCICTListview.Visible = true;
            CMEListview.Visible = false;
            COEListview.Visible = false;
            COEdListview.Visible = false;
            COTListview.Visible = false;

            ddlAcademicYear.Visible = false;
            ddlAcademicYear2.Visible = true;
            ddlAcademicYear3.Visible = false;
            ddlAcademicYear4.Visible = false;
            ddlAcademicYear5.Visible = false;
            ddlAcademicYear6.Visible = false;

            programList.Visible = false;
            programList2.Visible = true;
            programList3.Visible = false;
            programList4.Visible = false;
            programList5.Visible = false;
            programList6.Visible = false;


            BindSchoolYear2();
            BindCourse2();
            UpdatePanel1.Update();

        }
        protected void btnSwitchGrid_CME(object sender, EventArgs e)
        {

            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton3.CssClass += " active";

            CASListview.Visible = false;
            CCICTListview.Visible = false;
            CMEListview.Visible = true;
            COEListview.Visible = false;
            COEdListview.Visible = false;
            COTListview.Visible = false;

            ddlAcademicYear.Visible = false;
            ddlAcademicYear2.Visible = false;
            ddlAcademicYear3.Visible = true;
            ddlAcademicYear4.Visible = false;
            ddlAcademicYear5.Visible = false;
            ddlAcademicYear6.Visible = false;

            programList.Visible = false;
            programList2.Visible = false;
            programList3.Visible = true;
            programList4.Visible = false;
            programList5.Visible = false;
            programList6.Visible = false;

            BindSchoolYear3();
            BindCourse3();
            UpdatePanel1.Update();

        }
        protected void btnSwitchGrid_COE(object sender, EventArgs e)
        {

            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton4.CssClass += " active";
            CASListview.Visible = false;
            CCICTListview.Visible = false;
            CMEListview.Visible = false;
            COEListview.Visible = true;
            COEdListview.Visible = false;
            COTListview.Visible = false;

            ddlAcademicYear.Visible = false;
            ddlAcademicYear2.Visible = false;
            ddlAcademicYear3.Visible = false;
            ddlAcademicYear4.Visible = true;
            ddlAcademicYear5.Visible = false;
            ddlAcademicYear6.Visible = false;

            programList.Visible = false;
            programList2.Visible = false;
            programList3.Visible = false;
            programList4.Visible = true;
            programList5.Visible = false;
            programList6.Visible = false;

            BindSchoolYear4();
            BindCourse4();
            UpdatePanel1.Update();

        }
        protected void btnSwitchGrid_COEd(object sender, EventArgs e)
        {

            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton5.CssClass += " active";

            CASListview.Visible = false;
            CCICTListview.Visible = false;
            CMEListview.Visible = false;
            COEListview.Visible = false;
            COEdListview.Visible = true;
            COTListview.Visible = false;

            ddlAcademicYear.Visible = false;
            ddlAcademicYear2.Visible = false;
            ddlAcademicYear3.Visible = false;
            ddlAcademicYear4.Visible = false;
            ddlAcademicYear5.Visible = true;
            ddlAcademicYear6.Visible = false;

            programList.Visible = false;
            programList2.Visible = false;
            programList3.Visible = false;
            programList4.Visible = false;
            programList5.Visible = true;
            programList6.Visible = false;


            BindSchoolYear5();
            BindCourse5();
            UpdatePanel1.Update();

        }
        protected void btnSwitchGrid_COT(object sender, EventArgs e)
        {

            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";
            myLinkButton3.CssClass = "linkbutton";
            myLinkButton4.CssClass = "linkbutton";
            myLinkButton5.CssClass = "linkbutton";
            myLinkButton6.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton6.CssClass += " active";

            CASListview.Visible = false;
            CCICTListview.Visible = false;
            CMEListview.Visible = false;
            COEListview.Visible = false;
            COEdListview.Visible = false;
            COTListview.Visible = true;

            ddlAcademicYear.Visible = false;
            ddlAcademicYear2.Visible = false;
            ddlAcademicYear3.Visible = false;
            ddlAcademicYear4.Visible = false;
            ddlAcademicYear5.Visible = false;
            ddlAcademicYear6.Visible = true;

            programList.Visible = false;
            programList2.Visible = false;
            programList3.Visible = false;
            programList4.Visible = false;
            programList5.Visible = false;
            programList6.Visible = true;

            BindSchoolYear6();
            BindCourse6();
            UpdatePanel1.Update();

        }

        protected void dropdownsforCCICT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departmentName2 = "CCICT";

            ShowListView(departmentName2, ddlAcademicYear2.SelectedValue, programList2.SelectedValue, CCICTListview);
        }
        protected void dropdownsforCAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departmentName = "CAS";

            ShowListView(departmentName, ddlAcademicYear.SelectedValue, programList.SelectedValue, CASListview);
        }
        protected void dropdownsforCME_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departmentName3 = "CME";

            ShowListView(departmentName3, ddlAcademicYear3.SelectedValue, programList3.SelectedValue, CMEListview);
        }
        protected void dropdownsforCOE_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departmentName4 = "COE";

            ShowListView(departmentName4, ddlAcademicYear4.SelectedValue, programList4.SelectedValue, COEListview);
        }
        protected void dropdownsforCOEd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departmentName5 = "COEd";

            ShowListView(departmentName5, ddlAcademicYear5.SelectedValue, programList5.SelectedValue, COEdListview);
        }
        protected void dropdownsforCOT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departmentName6 = "COT";

            ShowListView(departmentName6, ddlAcademicYear6.SelectedValue, programList6.SelectedValue, COTListview);
        }

        private void ShowListView(string departmentName , string selectedAcademicYearValue, string selectedCourseValue, ListView listview)
        {


            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT GRADUATES_TABLE.* , " +
                                "STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                                "FROM GRADUATES_TABLE " +
                                "LEFT JOIN STUDENT_ACCOUNT ON GRADUATES_TABLE.studentID = STUDENT_ACCOUNT.studentID " +
                               "WHERE GRADUATES_TABLE.department = '" + departmentName + "' ", db);

                if (!string.IsNullOrEmpty(selectedAcademicYearValue))
                {
                    cmd.CommandText += " AND GRADUATES_TABLE.yearGraduated = @SelectedAcademicYear";
                    cmd.Parameters.AddWithValue("@SelectedAcademicYear", selectedAcademicYearValue);
                }
                if (selectedCourseValue != "0")
                {
                    cmd.CommandText += " AND GRADUATES_TABLE.course = @CourseName";
                    cmd.Parameters.AddWithValue("@CourseName", selectedCourseValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                listview.DataSource = ds;
                listview.DataBind();
            }
        }

        void BindSchoolYear()
        {
            string query = "SELECT DISTINCT yearGraduated FROM GRADUATES_TABLE ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear.DataSource = ds;
                ddlAcademicYear.DataTextField = "yearGraduated";
                ddlAcademicYear.DataValueField = "yearGraduated";
                ddlAcademicYear.DataBind();

            }
        }
        void BindSchoolYear2()
        {
            string query = "SELECT DISTINCT yearGraduated FROM GRADUATES_TABLE ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear2.DataSource = ds;
                ddlAcademicYear2.DataTextField = "yearGraduated";
                ddlAcademicYear2.DataValueField = "yearGraduated";
                ddlAcademicYear2.DataBind();

            }
        }
        void BindSchoolYear3()
        {
            string query = "SELECT DISTINCT yearGraduated FROM GRADUATES_TABLE ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear3.DataSource = ds;
                ddlAcademicYear3.DataTextField = "yearGraduated";
                ddlAcademicYear3.DataValueField = "yearGraduated";
                ddlAcademicYear3.DataBind();

            }
        }
        void BindSchoolYear4()
        {
            string query = "SELECT DISTINCT yearGraduated FROM GRADUATES_TABLE ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear4.DataSource = ds;
                ddlAcademicYear4.DataTextField = "yearGraduated";
                ddlAcademicYear4.DataValueField = "yearGraduated";
                ddlAcademicYear4.DataBind();

            }
        }
        void BindSchoolYear5()
        {
            string query = "SELECT DISTINCT yearGraduated FROM GRADUATES_TABLE ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear5.DataSource = ds;
                ddlAcademicYear5.DataTextField = "yearGraduated";
                ddlAcademicYear5.DataValueField = "yearGraduated";
                ddlAcademicYear5.DataBind();

            }
        }
        void BindSchoolYear6()
        {
            string query = "SELECT DISTINCT yearGraduated FROM GRADUATES_TABLE ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear6.DataSource = ds;
                ddlAcademicYear6.DataTextField = "yearGraduated";
                ddlAcademicYear6.DataValueField = "yearGraduated";
                ddlAcademicYear6.DataBind();

            }
        }

        void BindCourse()
        {
            int departmentID = 290000;
            string query = "SELECT course FROM PROGRAM " +
                        "WHERE department_ID = @deptID  ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@deptID", departmentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                programList.DataSource = ds;
                programList.DataTextField = "course";
                programList.DataValueField = "course";
                programList.DataBind();
                programList.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse2()
        {
            int departmentID = 290001;
            string query = "SELECT course FROM PROGRAM " +
                        "WHERE department_ID = @deptID  ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@deptID", departmentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                programList2.DataSource = ds;
                programList2.DataTextField = "course";
                programList2.DataValueField = "course";
                programList2.DataBind();
                programList2.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse3()
        {
            int departmentID = 290002;
            string query = "SELECT course FROM PROGRAM " +
                        "WHERE department_ID = @deptID  ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@deptID", departmentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                programList3.DataSource = ds;
                programList3.DataTextField = "course";
                programList3.DataValueField = "course";
                programList3.DataBind();
                programList3.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse4()
        {
            int departmentID = 290003;
            string query = "SELECT course FROM PROGRAM " +
                        "WHERE department_ID = @deptID  ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@deptID", departmentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                programList4.DataSource = ds;
                programList4.DataTextField = "course";
                programList4.DataValueField = "course";
                programList4.DataBind();
                programList4.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse5()
        {
            int departmentID = 290004;
            string query = "SELECT course FROM PROGRAM " +
                        "WHERE department_ID = @deptID  ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@deptID", departmentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                programList5.DataSource = ds;
                programList5.DataTextField = "course";
                programList5.DataValueField = "course";
                programList5.DataBind();
                programList5.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse6()
        {
            int departmentID = 290005;
            string query = "SELECT course FROM PROGRAM " +
                        "WHERE department_ID = @deptID  ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@deptID", departmentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                programList6.DataSource = ds;
                programList6.DataTextField = "course";
                programList6.DataValueField = "course";
                programList6.DataBind();
                programList6.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }

    }
}