﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.AcroFields;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace ctuconnect
{
    public partial class CoordinatorProfile : System.Web.UI.Page
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
                // Create an empty DataTable
                string imagePath = "~/images/OJTCoordinatorProfile/" + Session["Coord_Picture"].ToString();
                CoordinatorImage.ImageUrl = imagePath;
                BindTable();
                BindCourse();
                BindSchoolYear();
                BindSemester();
                /*BindStatus();*/


                if (ViewState["SelectedStudentIds"] != null)
                {
                    selectedStudentIds = (List<string>)ViewState["SelectedStudentIds"];
                }
                else if (ViewState["SelectedFullName"] != null)
                {
                    selectedInternNames = (List<string>)ViewState["SelectedFullName"];
                }
                else if (ViewState["SelectedProgram"] != null)
                {
                    selectedProgram = (List<string>)ViewState["SelectedProgram"];
                }
                else if (ViewState["SelectedContactNumber"] != null)
                {
                    selectedContactNumber = (List<string>)ViewState["SelectedContactNumber"];
                }
                else if (ViewState["SelectedEmail"] != null)
                {
                    selectedEmail = (List<string>)ViewState["SelectedEmail"];
                }
                else if (ViewState["SelectedRenderedHours"] != null)
                {
                    selectedHoursRendered = (List<string>)ViewState["SelectedRenderedHours"];
                }
                

                using (var db = new SqlConnection(conDB))
                {
                    db.Open();
                    string query = "SELECT industry_accID, industryName FROM INDUSTRY_ACCOUNT";

                    using (SqlCommand cmd = new SqlCommand(query, db))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dropdownIndustries.DataSource = reader;
                            dropdownIndustries.DataTextField = "industryName";
                            dropdownIndustries.DataValueField = "industry_accID";
                            dropdownIndustries.DataBind();
                        }
                    }
                }

            }
        }
        void BindTable()
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT  DISTINCT STUDENT_ACCOUNT.student_accID ,STUDENT_ACCOUNT.studentId, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.midInitials, " +
                                "PROGRAM.course_ID, PROGRAM.course, STUDENT_ACCOUNT.semCode,  ACADEMIC_YEAR.academicYear + ' ' + ACADEMIC_YEAR.semDescription AS semDescription , STUDENT_ACCOUNT.contactNumber, STUDENT_ACCOUNT.email,STUDENT_ACCOUNT.isHired, HIRED_LIST.id, HIRED_LIST.renderedHours, HIRED_LIST.evaluationRequest " +
                "FROM STUDENT_ACCOUNT LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode " +
                "LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN HIRED_LIST  ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID " +
                "LEFT JOIN  COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID AND (HIRED_LIST.jobType = 'internship' OR HIRED_LIST.jobType IS NULL)";


                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                internListView.DataSource = ds;
                internListView.DataBind();

            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowListView();
        }

            protected void ddlacademicYear_SelectedIndexChanged(object sender, EventArgs e)
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

            ShowListView();
        }
        void ShowListView()
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            int selectedSemesterValue = Convert.ToInt32(ddlSemester.SelectedValue);
            string selectedAcademicYearValue = ddlAcademicYear.SelectedValue;
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENT_ACCOUNT " +
                    "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode " +
                    "LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                    "LEFT JOIN HIRED_LIST  ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID " +
                    "LEFT JOIN COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                    "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID " +
                    "AND (HIRED_LIST.jobType = 'internship' OR HIRED_LIST.jobType IS NULL)", db);

                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);

                if (selectedAcademicYearValue != null)
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
                if (programList.SelectedValue != "0")
                {
                    cmd.CommandText += " AND STUDENT_ACCOUNT.course_ID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", programList.SelectedValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                internListView.DataSource = ds;
                internListView.DataBind();
            }
        }


        protected void SaveRefer_Click(object sender, EventArgs e)
        {
            List<string> studentIds = ViewState["SelectedStudentIds"] as List<string>;
            string industryID = dropdownIndustries.SelectedValue;
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            string referralStatus = "Pending";

            HttpPostedFile postedFile = referralUpload.PostedFile;  /// upload file
            string filename = Path.GetFileName(postedFile.FileName);///to check the filename 
            int filesize = postedFile.ContentLength; //to get the filesize
            string logpath = Server.MapPath("~/images/ReferralLetter/"); //creating a drive to upload or save the file
            string filepath = Path.Combine(logpath, filename);

            postedFile.SaveAs(filepath);

            if (studentIds != null)
            {
                foreach (string studentId in studentIds)
                {

                    int studentaccId = Convert.ToInt32(studentId);
                    using (var db = new SqlConnection(conDB))
                    {
                        db.Open();
                        string query = "INSERT INTO REFERRAL (student_accID, industry_accID, coordinator_accID, referralLetter, dateReferred, ReferralStatus, isRead, isRemove, isStudentRead, isStudentRemove ) " +
                                        "VALUES(@StudentaccountID, @IndustryaccountID, @CoordinatoraccountID, @ReferralLetter, @dateReferred, @referralStatus, @isRead, @isRemove, @isStudentRead, @isStudentRemove )";
                        SqlCommand cmd = new SqlCommand(query, db);
                        cmd.Parameters.AddWithValue("@StudentaccountID", studentaccId);
                        cmd.Parameters.AddWithValue("@IndustryaccountID", industryID);
                        cmd.Parameters.AddWithValue("@CoordinatoraccountID", coordinatorID);
                        cmd.Parameters.AddWithValue("@ReferralLetter", filename);
                        cmd.Parameters.AddWithValue("@dateReferred", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@referralStatus", referralStatus);
                        cmd.Parameters.AddWithValue("@isRead", 0);
                        cmd.Parameters.AddWithValue("@isRemove", 0);
                        cmd.Parameters.AddWithValue("@isStudentRead", 0);
                        cmd.Parameters.AddWithValue("@isStudentRemove", 0);

                        cmd.ExecuteNonQuery();
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showModal", "$('#SuccessPrompt').modal('show');", true);
            }
        }
        protected void EvaluationBtn_Command(object sender, CommandEventArgs e)
        {
            Button EvaluationBtn = (Button)sender;

            if (EvaluationBtn.Text == "Evaluation")
            {
                Response.Redirect("ViewEvaluation.aspx?student_accID=" + e.CommandArgument.ToString() + "&hired_id=" + e.CommandName.ToString());
            }
            else
            {
                EvaluationBtn.Enabled = false;
            }
        }
        protected void TraceIntern_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("TraceStudent.aspx?student_accID=" + e.CommandArgument.ToString());
        }
        protected string GetButtonCssClass(object evaluationRequest)
        {
            
            string requestStatus = evaluationRequest.ToString();

            switch (requestStatus)
            {
                case "no request":
                    return "btn-danger"; // Red
                case "Evaluated":
                    return "btn-success"; // Green
                default:
                    return "d-none"; // No CSS class if no request
            }
        }
        protected void SearchInternInfo(object sender, EventArgs e)
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            string student = searchInput.Text;
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                    "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode " +
                    "LEFT JOIN HIRED_LIST  ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID " +
                    "lEFT JOIN  COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                    "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID AND (HIRED_LIST.jobType = 'internship' OR HIRED_LIST.jobType IS NULL) " +
                    "or CAST(STUDENT_ACCOUNT.student_accID as varchar) = '" + student + "' " +
                    "or STUDENT_ACCOUNT.firstName LIKE '%' + @studentinfo + '%' " +
                "or STUDENT_ACCOUNT.lastName LIKE '%' + @studentinfo + '%' " +
                "or STUDENT_ACCOUNT.midInitials LIKE '%' + @studentinfo + '%' " +
                "or PROGRAM.course LIKE '%' + @studentinfo + '%' " +
                "or STUDENT_ACCOUNT.contactNumber LIKE '%' + @studentinfo + '%' " +
                "or STUDENT_ACCOUNT.email LIKE '%' + @studentinfo + '%'", db);
                cmd.Parameters.AddWithValue("@studentinfo", student);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                internListView.DataSource = ds;
                internListView.DataBind();
            }
        }

        protected void SaveMultipleEdit_Click(object sender, EventArgs e)
            {
            List<string> studentIds = ViewState["SelectedStudentIds"] as List<string>;
            int hoursrender = Convert.ToInt32(txtrenderedHours.Text);

            if (studentIds != null)
            {
                foreach (string studentId in studentIds)
                {

                    int studentaccId = Convert.ToInt32(studentId);

                    using (var db = new SqlConnection(conDB))
                    {
                        db.Open();
                        string query = " UPDATE HIRED_LIST SET renderedHours = @HoursRendered WHERE student_accID = @StudentaccountID ";
                        SqlCommand cmd = new SqlCommand(query, db);
                        cmd.Parameters.AddWithValue("@StudentaccountID", studentaccId);
                        cmd.Parameters.AddWithValue("@HoursRendered", hoursrender);

                        cmd.ExecuteNonQuery();
                    }
                    
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showModal", "$('#SuccessMultipleEditPrompt').modal('show');", true);
            }
            else
            {
                //
            }
        }
        protected void SaveSingleEdit_Click(object sender, EventArgs e)
        {
            /*List<string> studentIds = ViewState["SelectedStudentIds"] as List<string>;*/
            int hoursrender = Convert.ToInt32(hoursRenderedtxt.Text);

            foreach (ListViewItem item in internListView.Items)
            {
                CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    Label studentid = (Label)item.FindControl("lblStudentaccId");
                    string studentAccID = studentid.Text;



                    if (studentAccID != null)
                    {
                        using (var db = new SqlConnection(conDB))
                        {
                            db.Open();
                            string query = " UPDATE HIRED_LIST SET renderedHours = @HoursRender WHERE student_accID = @StudentaccountID ";
                            SqlCommand cmd = new SqlCommand(query, db);
                            cmd.Parameters.AddWithValue("@StudentaccountID", studentAccID);
                            cmd.Parameters.AddWithValue("@HoursRender", hoursrender);

                            cmd.ExecuteNonQuery();
                        }

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "showModal", "$('#SuccessSingleEditPrompt').modal('show');", true);
                    }
                }
            }
        }
        
        protected void Close_SuccessPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('hide');document.location='Refer.aspx'", true);
        }
        protected void Close_NoSelectedPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#NoSelected').modal('hide');document.location='CoordinatorProfile.aspx'", true);
        }
        protected void Close_SuccessSingleEditPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessSingleEditPrompt').modal('hide');document.location='CoordinatorProfile.aspx'", true);
        }
        protected void Close_MultipleEditSuccessPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessMultipleEditPrompt').modal('hide');document.location='CoordinatorProfile.aspx'", true);
        }
        

        private List<string> selectedStudentIds = new List<string>();
        private List<string> selectedInternNames = new List<string>();
        private List<string> selectedProgram = new List<string>();
        private List<string> selectedContactNumber = new List<string>();
        private List<string> selectedEmail = new List<string>();
        private List<string> selectedHoursRendered = new List<string>();
        /*   private List<string> studentprogram = new List<string>();*/

        /*
                ViewState["SelectedStudentIds"] = selectedStudentIds;
                    ViewState["SelectedFullName"] = selectedInternNames;
                    ViewState["SelectedProgram"] = selectedProgram;
                    ViewState["SelectedContactNumber"] = selectedContactNumber;
                    ViewState["SelectedEmail"] = selectedEmail;*/
        protected void Edit_Click(object sender, EventArgs e)
        {

            LinkButton btnEdit = (LinkButton)sender;
            int checkedCount = 0;
            List<bool> isHiredList = new List<bool>();
            
            List<string> studentIds = ViewState["SelectedStudentIds"] as List<string>;
            List<string> internfullname = ViewState["SelectedFullName"] as List<string>;
            List<string> programenrolled = ViewState["SelectedProgram"] as List<string>;
            List<string> contactnumber = ViewState["selectedContactNumber"] as List<string>;
            List<string> internemail = ViewState["selectedEmail"] as List<string>;
            List<string> hoursrendered = ViewState["SelectedRenderedHours"] as List<string>;
            /* List<string> studentprogram = ViewState["SelectedProgram"] as List<string>;*/

            foreach (ListViewItem item in internListView.Items)
            {
                // Find the CheckBox control in the current row
                CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");

                if (chkSelect.Checked)
                {
                    Label lblIsHired = (Label)item.FindControl("lblIsHired");
                    bool isHired = Convert.ToBoolean(lblIsHired.Text);

                    /* Label lblStudentaccId = (Label)item.FindControl("lblStudentaccId");
                     string studentaccountId = lblStudentaccId.Text;*/

                    Label lblStudentaccId = (Label)item.FindControl("lblStudentaccId");
                    
                    Label courseLabel = (Label)item.FindControl("courseLabel");
                    Label contactLabel = (Label)item.FindControl("contactLabel");
                    Label emailLabel = (Label)item.FindControl("emailLabel");
                    Label lblFirstName = (Label)item.FindControl("lblFirstName");
                    Label lblLastName = (Label)item.FindControl("lblLastName");
                    Label hourslabel = (Label)item.FindControl("hourslabel");


                    string program = courseLabel.Text;
                    string contact = contactLabel.Text;
                    string email = emailLabel.Text;
                    string firstName = lblFirstName.Text;
                    string lastName = lblLastName.Text;
                    string renderedhours = hourslabel.Text;
                    string studentaccountid = lblStudentaccId.Text;

                    isHiredList.Add(isHired);
                    selectedProgram.Add(program);
                    selectedContactNumber.Add(contact);
                    selectedEmail.Add(email);
                    selectedInternNames.Add($"{firstName} {lastName}");
                    selectedHoursRendered.Add(renderedhours);
                    selectedStudentIds.Add(studentaccountid);


                    /*studentprogram.Add(lblprogram);*/

                    // Pass the fname to the openModal JavaScript function

                    checkedCount++;
                }
            }
            ViewState["SelectedProgram"] = selectedProgram;
            ViewState["SelectedContactNumber"] = selectedContactNumber;
            ViewState["SelectedEmail"] = selectedEmail;
            ViewState["SelectedRenderedHours"] = selectedHoursRendered;
            /* ViewState["SelectedProgram"] = studentprogram;*/
            if (checkedCount > 1)
            {
                bool allAreNotHired = isHiredList.All(isHired => !isHired);

                if (allAreNotHired)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript5", "openFailedEditAllNotHired();", true);
                }
                else
                {
                    bool anyIsNotHired = isHiredList.Any(isHired => !isHired);
                    if (anyIsNotHired)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript1", "openModalFailedEdit();", true);
                    }
                    else
                    {
                        string existingname = string.Join(",", selectedInternNames);
                        ViewState["SelectedStudentIds"] = selectedStudentIds;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript1", $"openModalMultipleEdit('{existingname}');", true);
                    }
                }
            }
            else if (checkedCount == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showModal", "$('#NoSelected').modal('show');", true);
            }
            else if (checkedCount == 1) {
                bool isHired = isHiredList.First();
                if (isHired)
                {
                    string existingname = string.Join(" ", selectedInternNames);
                    string existingprogram = string.Join(" ", selectedProgram);
                    string existingcontact = string.Join(" ", selectedContactNumber);
                    string existingemail = string.Join(" ", selectedEmail);
                    string existingrenderedhours = string.Join(" ", selectedHoursRendered);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openEditModal('{existingname}','{existingprogram}','{existingcontact}','{existingemail}','{existingrenderedhours}');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript5", "openFailedEditAllNotHired();", true);
                }
            }

        }
    

/*        private string GetStatusFromDatabase(int studentaccId)
        {
            string existingStatus = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                string query = " SELECT isHired from STUDENT_ACCOUNT WHERE student_accID = @StudentId";
                using (SqlCommand command = new SqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@StudentId", studentaccId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            // If a match is found, add the name to the list\
                            existingStatus = reader.GetString(0);

                        }
                    }
                }
            }
            return existingStatus;
        }

        private string GetEmailFromDatabase(int studentaccId)
        {
            string existingEmail = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                string query = " SELECT email from STUDENT_ACCOUNT WHERE student_accID = @StudentId";
                using (SqlCommand command = new SqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@StudentId", studentaccId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            // If a match is found, add the name to the list\
                            existingEmail = reader.GetString(0);

                        }
                    }
                }
            }
            return existingEmail;
        }

        private string GetContactFromDatabase(int studentaccId)
        {
            string existingContact = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                string query = " SELECT contactNumber from STUDENT_ACCOUNT WHERE student_accID = @StudentId";
                using (SqlCommand command = new SqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@StudentId", studentaccId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            // If a match is found, add the name to the list\
                            existingContact = reader.GetString(0);

                        }
                    }
                }
            }
            return existingContact;
        }

        private string GetProgramFromDatabase(int studentaccId)
        {

            string existingProgram = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                    string query = " SELECT program from PROGRAM  WHERE student_accID = @StudentId";
                    using (SqlCommand command = new SqlCommand(query, db))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentaccId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                            // If a match is found, add the name to the list\
                            existingProgram = reader.GetString(0);

                        }
                        }
                    }
                }
            return existingProgram;
        }

        private string GetFirstNameFromDatabase(int studentaccId)
        {

            string existingFullName = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                    string query = " SELECT firstName, lastName from  STUDENT_ACCOUNT WHERE student_accID = @StudentId";
                    using (SqlCommand command = new SqlCommand(query, db))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentaccId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                // If a match is found, add the name to the list\
                                string firstName = reader["firstName"].ToString();
                                string lastName = reader["lastName"].ToString();
                                existingFullName = $"{firstName} {lastName}";
                            }
                        }
                    }
                }
            return existingFullName;
        }*/

        protected void referIntern_Click(object sender, EventArgs e)
        {
            List<bool> isHiredList = new List<bool>();
            int checkedCount = 0;

            foreach (ListViewItem item in internListView.Items)
            {
                // Find the CheckBox control in the current row
                CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");

                if (chkSelect.Checked)
                {
                    // If the CheckBox is checked, get the isHired value
                    Label lblIsHired = (Label)item.FindControl("lblIsHired");
                    bool isHired = Convert.ToBoolean(lblIsHired.Text); // Assuming the isHired value is stored in a Label named lblIsHired

                    Label lblStudentaccId = (Label)item.FindControl("lblStudentaccId");
                    Label lblFirstName = (Label)item.FindControl("lblFirstName");
                    Label lblLastName = (Label)item.FindControl("lblLastName");


                    string studentaccountId = lblStudentaccId.Text;
                    string firstName = lblFirstName.Text;
                    string lastName = lblLastName.Text;


                    isHiredList.Add(isHired);
                    selectedInternNames.Add($"{firstName} {lastName}");
                    selectedStudentIds.Add(studentaccountId);

                    checkedCount ++;
                }
            }
            ViewState["SelectedStudentIds"] = selectedStudentIds;
            ViewState["SelectedFullName"] = selectedInternNames;

            if (checkedCount >= 1)
            {

                bool anyIsHired = isHiredList.Any(isHired => isHired);
                if (anyIsHired)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript1", "openModal1();", true);
                }
                else
                {
                    List<string> anyExistInReferralTable = CheckIfAnyExistInReferralTable(selectedStudentIds);

                    if (anyExistInReferralTable.Count > 0)
                    {
                        // If any selected student ID exists in the REFERRAL table, show modal3
                        string existinginternNamesString = string.Join(", ", anyExistInReferralTable);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript3", $"openModal3('{existinginternNamesString}');", true);
                    }
                    else
                    {
                        string internNamesString = string.Join(",", selectedInternNames);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript2", $"openModal2('{internNamesString}');", true);
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showModal", "$('#NoSelected').modal('show');", true);
            }
        }
        private List<string> CheckIfAnyExistInReferralTable(List<string> selectedStudentIds)
        {
            List<string> studentIds = ViewState["SelectedStudentIds"] as List<string>;

            List<string> existingAccID = new List<string>();

            using (var db = new SqlConnection(conDB))
            {
                db.Open();

                foreach (string studentId in studentIds)
                {
                    int studentaccId = Convert.ToInt32(studentId);
                    string query = @" SELECT REFERRAL.student_accID, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.lastName FROM REFERRAL 
                                    INNER JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID WHERE REFERRAL.student_accID = @StudentId";
                    using (SqlCommand command = new SqlCommand(query, db))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentaccId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                // If a match is found, add the name to the list
                                string accID = reader["student_accID"].ToString();
                                string firstName = reader["firstName"].ToString();
                                string lastName = reader["lastName"].ToString();
                                existingAccID.Add($"{firstName} {lastName}");
                            }
                        }
                    }
                }

            }
            return existingAccID;
        }
        /*        private string GetInternNamesByStudentIds(List<string> studentIds)
                {
                    List<string> internNames = new List<string>();

                    using (var db = new SqlConnection(conDB))
                    {
                        db.Open();
                        string query = "SELECT firstName FROM STUDENT_ACCOUNT WHERE studentId IN (@StudentIds)";
                        using (var command = new SqlCommand(query, db))
                        {
                            command.Parameters.AddWithValue("@StudentIds", string.Join(",", studentIds));

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string fetchedInternName = reader["firstName"].ToString();
                                    internNames.Add(fetchedInternName);

                                }
                            }
                        }
                    }
                    string concatenatedInternNames = string.Join(", ", internNames);

                    return concatenatedInternNames;
                }*/

        void BindCourse()
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            string query = "SELECT course_ID, course FROM PROGRAM " +
                        "lEFT JOIN  COORDINATOR_ACCOUNT ON PROGRAM.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                        "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID  ";
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
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


        /*        void BindStatus()
                {
                    int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
                    string query = "SELECT isHired FROM STUDENT_ACCOUNT " +
                        "lEFT JOIN  COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                                "WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID  ";
                    using (var db = new SqlConnection(conDB))
                    {
                        SqlCommand cmd = new SqlCommand(query, db);
                        cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable ds = new DataTable();
                        da.Fill(ds);

                        ds.Columns["isHired"].DataType = typeof(bool);
                        statusList.DataSource = ds;
                        statusList.DataValueField = "isHired";
                        statusList.DataTextField = "isHired";  // Display the boolean values as text
                        statusList.DataBind();
                        statusList.Items.Insert(0, new ListItem("Select Status", "0"));

                    }
                }*/
        protected void program_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowListView();

        }
/*        void ShowByCourse()
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            using (var db = new SqlConnection(conDB))
            {
                SqlCommand cmd = new SqlCommand("select * FROM STUDENT_ACCOUNT " +
                    "LEFT JOIN ACADEMIC_YEAR ON STUDENT_ACCOUNT.semCode = ACADEMIC_YEAR.semCode " +
                    "LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                "LEFT JOIN HIRED_LIST  ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID " +
                "lEFT JOIN  COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                " WHERE COORDINATOR_ACCOUNT.coordinator_accID = @CoordinatorID AND (HIRED_LIST.jobType = 'internship' OR HIRED_LIST.jobType IS NULL) AND STUDENT_ACCOUNT.course_ID = '" + programList.SelectedValue + "' ", db);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
                DataTable ds = new DataTable();
                da.Fill(ds);
                internListView.DataSource = ds;
                internListView.DataBind();
            }
        }*/
        /*        protected void status_SelectedIndexChanged(object sender, EventArgs e)
                {
                    ShowByStatus();

                }
                void ShowByStatus()
                {
                    using (var db = new SqlConnection(conDB))
                    {
                        SqlCommand cmd = new SqlCommand("select * FROM STUDENT_ACCOUNT  LEFT JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID " +
                        "LEFT JOIN HIRED_LIST  ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID " +
                        "lEFT JOIN  COORDINATOR_ACCOUNT ON STUDENT_ACCOUNT.department_ID = COORDINATOR_ACCOUNT.department_ID " +
                        " WHERE STUDENT_ACCOUNT.isHired = @IsHired", db);
                        cmd.Parameters.AddWithValue("@IsHired", Convert.ToBoolean(statusList.SelectedValue));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable ds = new DataTable();
                        da.Fill(ds);
                        internListView.DataSource = ds;
                        internListView.DataBind();
                    }
                }*/
    }
    }
