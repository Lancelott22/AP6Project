using System;
using System.Collections;
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
    public partial class ListOfInterns_Alumni : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        SqlConnection connectionDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

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

                BindCourse();
                BindSchoolYear();
                BindSemester();

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
            int departmentiD = 290000;

            string query = "SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode ,  ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department";


            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentiD);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            CASListview.DataSource = ds;
            CASListview.DataBind();

        }
        void BindTableCCICT()
        {
            int departmentiD = 290001;

            string query = "SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode ,  ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department";



            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentiD);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            CCICTListview.DataSource = ds;
            CCICTListview.DataBind();

        }
        void BindTableCME()
        {
            int departmentID = 290002;

            string query = "SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode , ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department";



            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            CMEListview.DataSource = ds;
            CMEListview.DataBind();

        }
        void BindTableCOE()
        {
            int departmentID = 290003;

            string query = "SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode ,  ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department";



            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            COEListview.DataSource = ds;
            COEListview.DataBind();

        }
        void BindTableCOEd()
        {
            int departmentID = 290004;

            string query = "SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode , ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription , STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode  " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department";



            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            COEdListview.DataSource = ds;
            COEdListview.DataBind();

        }
        void BindTableCOT()
        {
            int departmentID = 290005;

            string query = "SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode ,  ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
            "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
            "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode  " +
            "WHERE STUDENT_ACCOUNT.department_ID = @department";



            /*"FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
       "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
       "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
       "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";*/


            SqlCommand cmd = new SqlCommand(query, connectionDB);
            cmd.Parameters.AddWithValue("@department", departmentID);
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

            ddlSemester.Visible = true;
            ddlSemester2.Visible = false;
            ddlSemester3.Visible = false;
            ddlSemester4.Visible = false;
            ddlSemester5.Visible = false;
            ddlSemester6.Visible = false;

            programList.Visible = true;
            programList2.Visible = false;
            programList3.Visible = false;
            programList4.Visible = false;
            programList5.Visible = false;
            programList6.Visible = false;

            BindSchoolYear();
            BindSemester();
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

            ddlSemester.Visible = false;
            ddlSemester2.Visible = true;
            ddlSemester3.Visible = false;
            ddlSemester4.Visible = false;
            ddlSemester5.Visible = false;
            ddlSemester6.Visible = false;

            programList.Visible = false;
            programList2.Visible = true;
            programList3.Visible = false;
            programList4.Visible = false;
            programList5.Visible = false;
            programList6.Visible = false;

            BindSchoolYear2();
            BindSemester2();
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

            ddlSemester.Visible = false;
            ddlSemester2.Visible = false;
            ddlSemester3.Visible = true;
            ddlSemester4.Visible = false;
            ddlSemester5.Visible = false;
            ddlSemester6.Visible = false;

            programList.Visible = false;
            programList2.Visible = false;
            programList3.Visible = true;
            programList4.Visible = false;
            programList5.Visible = false;
            programList6.Visible = false;

            BindSchoolYear3();
            BindSemester3();
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

            ddlSemester.Visible = false;
            ddlSemester2.Visible = false;
            ddlSemester3.Visible = false;
            ddlSemester4.Visible = true;
            ddlSemester5.Visible = false;
            ddlSemester6.Visible = false;

            programList.Visible = false;
            programList2.Visible = false;
            programList3.Visible = false;
            programList4.Visible = true;
            programList5.Visible = false;
            programList6.Visible = false;

            BindSchoolYear4();
            BindSemester4();
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

            ddlSemester.Visible = false;
            ddlSemester2.Visible = false;
            ddlSemester3.Visible = false;
            ddlSemester4.Visible = false;
            ddlSemester5.Visible = true;
            ddlSemester6.Visible = false;

            programList.Visible = false;
            programList2.Visible = false;
            programList3.Visible = false;
            programList4.Visible = false;
            programList5.Visible = true;
            programList6.Visible = false;

            BindSchoolYear5();
            BindSemester5();
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

            ddlSemester.Visible = false;
            ddlSemester2.Visible = false;
            ddlSemester3.Visible = false;
            ddlSemester4.Visible = false;
            ddlSemester5.Visible = false;
            ddlSemester6.Visible = true;

            programList.Visible = false;
            programList2.Visible = false;
            programList3.Visible = false;
            programList4.Visible = false;
            programList5.Visible = false;
            programList6.Visible = true;

            BindSchoolYear6();
            BindSemester6();
            BindCourse6();

            UpdatePanel1.Update();

        }
/*        protected void ddlacademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("SELECT semCode, semDescription FROM ACADEMIC_YEAR " +
                           "WHERE academicYear = '" + ddlAcademicYear.SelectedValue + "'", connectionDB);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            ddlSemester.DataSource = ds;
            ddlSemester.DataTextField = "semDescription";
            ddlSemester.DataValueField = "semCode";
            ddlSemester.DataBind();
            ddlSemester.Items.Insert(0, new ListItem("All", "0"));

        }*/
        protected void dropdownsforCCICT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSemesterValue2 = Convert.ToInt32(ddlSemester2.SelectedValue);
            string selectedAcademicYearValue2 = ddlAcademicYear2.SelectedValue;

            ShowCCICTListView(selectedSemesterValue2, selectedAcademicYearValue2, programList2.SelectedValue);
        }
        protected void dropdownsforCAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSemesterValue1 = Convert.ToInt32(ddlSemester.SelectedValue);
            string selectedAcademicYearValue1 = ddlAcademicYear.SelectedValue;

            ShowCASListView(selectedSemesterValue1, selectedAcademicYearValue1, programList.SelectedValue);
        }
        protected void dropdownsforCME_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSemesterValue3 = Convert.ToInt32(ddlSemester3.SelectedValue);
            string selectedAcademicYearValue3 = ddlAcademicYear3.SelectedValue;

            ShowCMEListView(selectedSemesterValue3, selectedAcademicYearValue3, programList3.SelectedValue);
        }
        protected void dropdownsforCOE_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSemesterValue4 = Convert.ToInt32(ddlSemester4.SelectedValue);
            string selectedAcademicYearValue4 = ddlAcademicYear4.SelectedValue;

            ShowCOEListView(selectedSemesterValue4, selectedAcademicYearValue4, programList4.SelectedValue);
        }
        protected void dropdownsforCOEd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSemesterValue5 = Convert.ToInt32(ddlSemester5.SelectedValue);
            string selectedAcademicYearValue5 = ddlAcademicYear5.SelectedValue;

            ShowCOEdListView(selectedSemesterValue5, selectedAcademicYearValue5, programList5.SelectedValue);
        }
        protected void dropdownsforCOT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSemesterValue6 = Convert.ToInt32(ddlSemester6.SelectedValue);
            string selectedAcademicYearValue6 = ddlAcademicYear6.SelectedValue;

            ShowCOTListView(selectedSemesterValue6, selectedAcademicYearValue6, programList6.SelectedValue);
        }

        private void ShowCCICTListView(int selectedSemesterValue, string selectedAcademicYearValue, string selectedCourseValue)
        {
            int dept = 290001;

            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode , ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode  " +
                "WHERE STUDENT_ACCOUNT.department_ID = @department", db);

                cmd.Parameters.AddWithValue("@department", dept);

                if (!string.IsNullOrEmpty(selectedAcademicYearValue))
                {
                    cmd.CommandText += " AND ACADEMIC_YEAR.academicYear = @SelectedAcademicYear";
                    cmd.Parameters.AddWithValue("@SelectedAcademicYear", selectedAcademicYearValue);
                }

                if (selectedSemesterValue != 0)
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.semCode = @SemesterValue";
                    cmd.Parameters.AddWithValue("@SemesterValue", selectedSemesterValue);
                }

                // Optional: Filter by course if a specific course is selected
                if (selectedCourseValue != "0")
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.course_ID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourseValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                CCICTListview.DataSource = ds;
                CCICTListview.DataBind();
            }
        }
        private void ShowCASListView(int selectedSemesterValue, string selectedAcademicYearValue, string selectedCourseValue)
        {
            int dept = 290000;

            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode , ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode  " +
                "WHERE STUDENT_ACCOUNT.department_ID = @department", db);

                cmd.Parameters.AddWithValue("@department", dept);

                if (!string.IsNullOrEmpty(selectedAcademicYearValue))
                {
                    cmd.CommandText += " AND ACADEMIC_YEAR.academicYear = @SelectedAcademicYear";
                    cmd.Parameters.AddWithValue("@SelectedAcademicYear", selectedAcademicYearValue);
                }

                if (selectedSemesterValue != 0)
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.semCode = @SemesterValue";
                    cmd.Parameters.AddWithValue("@SemesterValue", selectedSemesterValue);
                }

                // Optional: Filter by course if a specific course is selected
                if (selectedCourseValue != "0")
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.course_ID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourseValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                CASListview.DataSource = ds;
                CASListview.DataBind();
            }
        }
        private void ShowCMEListView(int selectedSemesterValue, string selectedAcademicYearValue, string selectedCourseValue)
        {
            int dept = 290002;

            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course_ID, PROGRAM.course, STUDENT_ACCOUNT.semCode ,  ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode  " +
                "WHERE STUDENT_ACCOUNT.department_ID = @department", db);

                cmd.Parameters.AddWithValue("@department", dept);

                if (!string.IsNullOrEmpty(selectedAcademicYearValue))
                {
                    cmd.CommandText += " AND ACADEMIC_YEAR.academicYear = @SelectedAcademicYear";
                    cmd.Parameters.AddWithValue("@SelectedAcademicYear", selectedAcademicYearValue);
                }

                if (selectedSemesterValue != 0)
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.semCode = @SemesterValue";
                    cmd.Parameters.AddWithValue("@SemesterValue", selectedSemesterValue);
                }

                // Optional: Filter by course if a specific course is selected
                if (selectedCourseValue != "0")
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.course_ID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourseValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                CMEListview.DataSource = ds;
                CMEListview.DataBind();
            }
        }
        private void ShowCOEListView(int selectedSemesterValue, string selectedAcademicYearValue, string selectedCourseValue)
        {
            int dept = 290003;

            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode , ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode  " +
                "WHERE STUDENT_ACCOUNT.department_ID = @department", db);

                cmd.Parameters.AddWithValue("@department", dept);

                if (!string.IsNullOrEmpty(selectedAcademicYearValue))
                {
                    cmd.CommandText += " AND ACADEMIC_YEAR.academicYear = @SelectedAcademicYear";
                    cmd.Parameters.AddWithValue("@SelectedAcademicYear", selectedAcademicYearValue);
                }

                if (selectedSemesterValue != 0)
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.semCode = @SemesterValue";
                    cmd.Parameters.AddWithValue("@SemesterValue", selectedSemesterValue);
                }

                // Optional: Filter by course if a specific course is selected
                if (selectedCourseValue != "0")
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.course_ID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourseValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                COEListview.DataSource = ds;
                COEListview.DataBind();
            }
        }
        private void ShowCOEdListView(int selectedSemesterValue, string selectedAcademicYearValue, string selectedCourseValue)
        {
            int dept = 290004;

            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode , ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode  " +
                "WHERE STUDENT_ACCOUNT.department_ID = @department", db);

                cmd.Parameters.AddWithValue("@department", dept);

                if (!string.IsNullOrEmpty(selectedAcademicYearValue))
                {
                    cmd.CommandText += " AND ACADEMIC_YEAR.academicYear = @SelectedAcademicYear";
                    cmd.Parameters.AddWithValue("@SelectedAcademicYear", selectedAcademicYearValue);
                }

                if (selectedSemesterValue != 0)
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.semCode = @SemesterValue";
                    cmd.Parameters.AddWithValue("@SemesterValue", selectedSemesterValue);
                }

                // Optional: Filter by course if a specific course is selected
                if (selectedCourseValue != "0")
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.course_ID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourseValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                COEdListview.DataSource = ds;
                COEdListview.DataBind();
            }
        }
        private void ShowCOTListView(int selectedSemesterValue, string selectedAcademicYearValue, string selectedCourseValue)
        {
            int dept = 290005;

            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                            "PROGRAM.course, STUDENT_ACCOUNT.semCode , ACADEMIC_YEAR.semDescription + ' of ' + ACADEMIC_YEAR.academicYear AS semDescription, STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email " +
                "FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode  " +
                "WHERE STUDENT_ACCOUNT.department_ID = @department", db);

                cmd.Parameters.AddWithValue("@department", dept);

                if (!string.IsNullOrEmpty(selectedAcademicYearValue))
                {
                    cmd.CommandText += " AND ACADEMIC_YEAR.academicYear = @SelectedAcademicYear";
                    cmd.Parameters.AddWithValue("@SelectedAcademicYear", selectedAcademicYearValue);
                }

                if (selectedSemesterValue != 0)
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.semCode = @SemesterValue";
                    cmd.Parameters.AddWithValue("@SemesterValue", selectedSemesterValue);
                }

                // Optional: Filter by course if a specific course is selected
                if (selectedCourseValue != "0")
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.course_ID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourseValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                COTListview.DataSource = ds;
                COTListview.DataBind();
            }
        }
        



        void BindSchoolYear()
        {
            string query = "SELECT DISTINCT academicYear FROM ACADEMIC_YEAR ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear.DataSource = ds;
                ddlAcademicYear.DataTextField = "academicYear";
                ddlAcademicYear.DataValueField = "academicYear";
                ddlAcademicYear.DataBind();

            }
        }
        void BindSchoolYear2()
        {
            string query = "SELECT DISTINCT academicYear FROM ACADEMIC_YEAR ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear2.DataSource = ds;
                ddlAcademicYear2.DataTextField = "academicYear";
                ddlAcademicYear2.DataValueField = "academicYear";
                ddlAcademicYear2.DataBind();

            }
        }
        void BindSchoolYear3()
        {
            string query = "SELECT DISTINCT academicYear FROM ACADEMIC_YEAR ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear3.DataSource = ds;
                ddlAcademicYear3.DataTextField = "academicYear";
                ddlAcademicYear3.DataValueField = "academicYear";
                ddlAcademicYear3.DataBind();

            }
        }
        void BindSchoolYear4()
        {
            string query = "SELECT DISTINCT academicYear FROM ACADEMIC_YEAR ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear4.DataSource = ds;
                ddlAcademicYear4.DataTextField = "academicYear";
                ddlAcademicYear4.DataValueField = "academicYear";
                ddlAcademicYear4.DataBind();

            }
        }
        void BindSchoolYear5()
        {
            string query = "SELECT DISTINCT academicYear FROM ACADEMIC_YEAR ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear5.DataSource = ds;
                ddlAcademicYear5.DataTextField = "academicYear";
                ddlAcademicYear5.DataValueField = "academicYear";
                ddlAcademicYear5.DataBind();

            }
        }
        void BindSchoolYear6()
        {
            string query = "SELECT DISTINCT academicYear FROM ACADEMIC_YEAR ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                ddlAcademicYear6.DataSource = ds;
                ddlAcademicYear6.DataTextField = "academicYear";
                ddlAcademicYear6.DataValueField = "academicYear";
                ddlAcademicYear6.DataBind();

            }
        }
        void BindSemester()
        {
            SqlCommand cmd = new SqlCommand("SELECT semCode, semDescription FROM ACADEMIC_YEAR " +
                "WHERE academicYear = '" + ddlAcademicYear.SelectedValue + "'", connectionDB);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            ddlSemester.DataSource = ds;
            ddlSemester.DataTextField = "semDescription";
            ddlSemester.DataValueField = "semCode";
            ddlSemester.DataBind();
            ddlSemester.Items.Insert(0, new ListItem("All", "0"));


        }
        void BindSemester2()
        {
            SqlCommand cmd = new SqlCommand("SELECT semCode, semDescription FROM ACADEMIC_YEAR " +
                "WHERE academicYear = '" + ddlAcademicYear2.SelectedValue + "'", connectionDB);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            ddlSemester2.DataSource = ds;
            ddlSemester2.DataTextField = "semDescription";
            ddlSemester2.DataValueField = "semCode";
            ddlSemester2.DataBind();
            ddlSemester2.Items.Insert(0, new ListItem("All", "0"));


        }
        void BindSemester3()
        {
            SqlCommand cmd = new SqlCommand("SELECT semCode, semDescription FROM ACADEMIC_YEAR " +
                "WHERE academicYear = '" + ddlAcademicYear3.SelectedValue + "'", connectionDB);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            ddlSemester3.DataSource = ds;
            ddlSemester3.DataTextField = "semDescription";
            ddlSemester3.DataValueField = "semCode";
            ddlSemester3.DataBind();
            ddlSemester3.Items.Insert(0, new ListItem("All", "0"));


        }
        void BindSemester4()
        {
            SqlCommand cmd = new SqlCommand("SELECT semCode, semDescription FROM ACADEMIC_YEAR " +
                "WHERE academicYear = '" + ddlAcademicYear4.SelectedValue + "'", connectionDB);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            ddlSemester4.DataSource = ds;
            ddlSemester4.DataTextField = "semDescription";
            ddlSemester4.DataValueField = "semCode";
            ddlSemester4.DataBind();
            ddlSemester4.Items.Insert(0, new ListItem("All", "0"));


        }
        void BindSemester5()
        {
            SqlCommand cmd = new SqlCommand("SELECT semCode, semDescription FROM ACADEMIC_YEAR " +
                "WHERE academicYear = '" + ddlAcademicYear5.SelectedValue + "'", connectionDB);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            ddlSemester5.DataSource = ds;
            ddlSemester5.DataTextField = "semDescription";
            ddlSemester5.DataValueField = "semCode";
            ddlSemester5.DataBind();
            ddlSemester5.Items.Insert(0, new ListItem("All", "0"));


        }
        void BindSemester6()
        {
            SqlCommand cmd = new SqlCommand("SELECT semCode, semDescription FROM ACADEMIC_YEAR " +
                "WHERE academicYear = '" + ddlAcademicYear6.SelectedValue + "'", connectionDB);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            ddlSemester6.DataSource = ds;
            ddlSemester6.DataTextField = "semDescription";
            ddlSemester6.DataValueField = "semCode";
            ddlSemester6.DataBind();
            ddlSemester6.Items.Insert(0, new ListItem("All", "0"));


        }
        void BindCourse()
            {
            int departmentID = 290000;
            string query = "SELECT course_ID, course FROM PROGRAM " +
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
                    programList.DataValueField = "course_ID";
                    programList.DataBind();
                    programList.Items.Insert(0, new ListItem("Select Program", "0"));

                }
            }
        void BindCourse2()
        {
            int departmentID = 290001;
            string query = "SELECT course_ID, course FROM PROGRAM " +
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
                programList2.DataValueField = "course_ID";
                programList2.DataBind();
                programList2.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse3()
        {
            int departmentID = 290002;
            string query = "SELECT course_ID, course FROM PROGRAM " +
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
                programList3.DataValueField = "course_ID";
                programList3.DataBind();
                programList3.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse4()
        {
            int departmentID = 290003;
            string query = "SELECT course_ID, course FROM PROGRAM " +
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
                programList4.DataValueField = "course_ID";
                programList4.DataBind();
                programList4.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse5()
        {
            int departmentID = 290004;
            string query = "SELECT course_ID, course FROM PROGRAM " +
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
                programList5.DataValueField = "course_ID";
                programList5.DataBind();
                programList5.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }
        void BindCourse6()
        {
            int departmentID = 290005;
            string query = "SELECT course_ID, course FROM PROGRAM " +
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
                programList6.DataValueField = "course_ID";
                programList6.DataBind();
                programList6.Items.Insert(0, new ListItem("Select Program", "0"));

            }
        }

    }
}