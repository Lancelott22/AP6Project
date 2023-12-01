using Org.BouncyCastle.Asn1.IsisMtt.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.AcroFields;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using Label = System.Web.UI.WebControls.Label;

namespace ctuconnect
{
    public partial class HiredList : System.Web.UI.Page
    {

        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        private int currentStudentID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");


            }
            if (!IsPostBack)
            {

                BindTable1();
                BindTable2();
                myLinkButton1.CssClass += " active";
                listView1.Visible = true;
                listView2.Visible = false;

                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;

                if (ViewState["SelectedStudentIds"] != null)
                {
                    selectedStudentIds = (List<string>)ViewState["SelectedStudentIds"];
                }
                else if (ViewState["SelectedFullName"] != null)
                {
                    selectedInternNames = (List<string>)ViewState["SelectedFullName"];
                }
                else if (ViewState["SelectedPosition"] != null)
                {
                    selectedPosition = (List<string>)ViewState["SelectedPosition"];
                }
                else if (ViewState["SelectedDateHired"] != null)
                {
                    selectedDateHired = (List<string>)ViewState["SelectedDateHired"];
                }
                else if (ViewState["SelectedDateStarted"] != null)
                {
                    selectedDateStarted = (List<string>)ViewState["SelectedDateStarted"];
                }
                else if (ViewState["SelectedDateEnded"] != null)
                {
                    selectedDateEnded = (List<string>)ViewState["SelectedDateEnded"];
                }
                else if (ViewState["SelectedRenderedHours"] != null)
                {
                    selectedHoursRendered = (List<string>)ViewState["SelectedRenderedHours"];
                }
                else if (ViewState["SelectedInternshipStatus"] != null)
                {
                    selectedInternshipStatus = (List<string>)ViewState["SelectedInternshipStatus"];
                }

                foreach (ListViewItem item in listView2.Items)
                {
                    Button EvaluationBtn = item.FindControl("EvaluationBtn") as Button;

                    // Check if EvaluationBtn is found and do something with it
                    if (EvaluationBtn != null)
                    {
                        // Check if the evaluation has been performed
                        bool evaluationPerformed = CheckIfEvaluationPerformed();

                        // Update the button text based on the evaluation status
                        EvaluationBtn.Text = evaluationPerformed ? "View Evaluation" : "Requested";
                    }
                }
            }
            

        }

        private bool CheckIfEvaluationPerformed()
        {
            // Check the session variable or some other indicator to see if the evaluation has been performed
            return Session["EvaluationPerformed"] != null && (bool)Session["EvaluationPerformed"];
        }

        void BindTable1()
        {
            string industry_accID = Session["INDUSTRY_ACC_ID"].ToString();
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT lastName, firstName, dateStarted, position, resumeFile FROM HIRED_LIST WHERE jobType = 'job' AND  industry_accID = '"+industry_accID+"' ORDER BY id DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the DataTable to the GridView
                listView1.DataSource = ds;
                listView1.DataBind();



            }
        }

        void BindTable2()
        {
            string industry_accID = Session["INDUSTRY_ACC_ID"].ToString();
            using (var db = new SqlConnection(conDB))
            {

                string query = "SELECT student_accID,lastName, firstName, position, CONVERT(VARCHAR(10), HIRED_LIST.dateHired, 120) AS dateHired, CONVERT(VARCHAR(10), HIRED_LIST.dateStarted, 120) AS dateStarted, CONVERT(VARCHAR(10), HIRED_LIST.dateEnded, 120) AS dateEnded, internshipStatus, renderedHours, evaluationRequest " +
                    "FROM HIRED_LIST WHERE jobType = 'internship' AND  industry_accID = '"+industry_accID+"' ORDER BY id DESC";
                SqlCommand cmd = new SqlCommand(query, db);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the DataTable to the GridView
                listView2.DataSource = ds;
                listView2.DataBind();

            }
        }



        protected void btnSwitchGrid_Click1(object sender, EventArgs e)
        {
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton1.CssClass += " active";

            listView1.Visible = true;
            listView2.Visible = false;

            UpdatePanel1.Update();
        }
        protected void btnSwitchGrid_Click2(object sender, EventArgs e)
        {
            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("ID", typeof(int));
            //dataTable.Columns.Add("Name", typeof(string));
            //dataTable.Rows.Add(01783, "Robert");
            //dataTable.Rows.Add(0178903, "RYan");

            //GridView2.DataSource = dataTable;
            //GridView2.DataBind();
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton2.CssClass += " active";
            listView1.Visible = false;
            listView2.Visible = true;

            UpdatePanel1.Update();

        }
        /*protected void Evaluate_BtnClick(object sender, EventArgs e)
        {
            // Find the button that triggered the event
            Button EvaluationBtn = (Button)sender;

            // Check if the button's text is "Requested"
            if (EvaluationBtn.Text == "Requested")
            {
                // Redirect to another ASPX page
                Response.Redirect("EvaluationForm.aspx?id=" + e);
            }
        }*/
        protected void ViewResume_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                /* Button btn = (Button)sender;
                 int studentID = Convert.ToInt32(btn.Attributes["data-studentid"]);
 */
                string ResumeFileName = e.CommandArgument.ToString();
                /*string endorsementLetterPath = Server.MapPath("~/images/EndorsementLetter" + endorsementLetterFileName);*/
                // Change the button text to "Reviewed"
                //Button button = (Button)sender;
                //button.Text = "Reviewed";


                // Retrieve and display the resume file
                byte[] ResumeFileData = GetResumeFileData(ResumeFileName);


                if (ResumeFileData != null)
                {
                    // Provide the file data for download in a new browser tab
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf"; // Set the appropriate content type
                    Response.AddHeader("content-disposition", "inline; filename=resume.pdf"); // Open in a new tab
                    Response.BinaryWrite(ResumeFileData);
                    Response.End();
                }
            }
        }
        private byte[] GetResumeFileData(string ResumeFileName)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT resumeFile FROM HIRED_LIST WHERE resumeFile = @ResumeFileName";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ResumeFileName", ResumeFileName);

                db.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Assuming that the result is a file path, read the file content
                    string fileName = result.ToString();
                    string filePath = "~/images/Resume/" + fileName; // Construct the path
                    byte[] fileData = System.IO.File.ReadAllBytes(Server.MapPath(filePath));
                    return fileData;
                }

                return null; // No file found
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }
        protected void SaveMultipleEdit(object sender, EventArgs e)
        {
            List<string> studentIds = ViewState["SelectedStudentIds"] as List<string>;
            string dateended = txtendedDate.Text;
            string status = "Done";

            if (studentIds != null)
            {
                foreach (string studentId in studentIds)
                {

                    int studentaccId = Convert.ToInt32(studentId);

                    using (var db = new SqlConnection(conDB))
                    {
                        db.Open();
                        string query = " UPDATE HIRED_LIST SET dateEnded = @DateEnded , internshipStatus = @internshipstatus WHERE student_accID = @StudentaccountID ";
                        SqlCommand cmd = new SqlCommand(query, db);
                        cmd.Parameters.AddWithValue("@StudentaccountID", studentaccId);
                        cmd.Parameters.AddWithValue("@DateEnded", dateended);
                        cmd.Parameters.AddWithValue("@internshipstatus", status);

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
        protected void saveDatesDetails(object sender, EventArgs e)
        {
            string industryname = Session["INDUSTRYNAME"].ToString();
            List<string> studentIds = ViewState["SelectedStudentIds"] as List<string>;


            string datestarted = txtDateStarted.Text;
            object dateendedValue = string.IsNullOrEmpty(txtDateEnded.Text) ? DBNull.Value : (object)txtDateEnded.Text;
            string feedback = txtFeedback.Text;
            string stat = ddlStatus.SelectedValue;

                foreach (ListViewItem item in listView2.Items)
                {
                    CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        Label lblStudentID = (Label)item.FindControl("lblStudentID");
                        string studentAccID = lblStudentID.Text;
                        Label lblPosition = (Label)item.FindControl("lblPosition");
                        string position = lblPosition.Text;

                        if (studentAccID != null)
                        {
                            int studentaccId = Convert.ToInt32(studentAccID);
                            using (var db = new SqlConnection(conDB))
                            {
                                db.Open();
                                using (var cmd = db.CreateCommand())
                                {
                                    string sql = "UPDATE HIRED_LIST SET dateStarted = @datestarted, dateEnded = @dateended, internshipStatus = @internshipstatus WHERE student_accID = @studentID";
                                    cmd.CommandText = sql;
                                    cmd.Parameters.AddWithValue("@studentID", studentaccId);
                                    cmd.Parameters.AddWithValue("@datestarted", datestarted);
                                    cmd.Parameters.AddWithValue("@dateended", dateendedValue);
                                    cmd.Parameters.AddWithValue("@internshipstatus", stat);

                                    cmd.ExecuteNonQuery();

                                }
                            }
                        if (!string.IsNullOrEmpty(feedback))
                        {
                            using (var db = new SqlConnection(conDB))
                            {
                                db.Open();
                                using (var cmd = db.CreateCommand())
                                {
                                    string sql = "INSERT INTO STUDENT_FEEDBACK (sendfrom, sendto, position,feedbackContent, dateCreated) VALUES (@sendfrom, @sendto, @position,@feedbacks, @datecreated)";
                                    cmd.CommandText = sql;
                                    // Provide appropriate values for sendfrom, sendto, and position
                                    cmd.Parameters.AddWithValue("@sendfrom", industryname);
                                    cmd.Parameters.AddWithValue("@sendto", studentaccId);
                                    cmd.Parameters.AddWithValue("@position", position);
                                    cmd.Parameters.AddWithValue("@feedbacks", feedback);
                                    cmd.Parameters.AddWithValue("@datecreated", DateTime.Now);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('show');", true);
                        }
                        else
                        {
                            //
                        }
                    }
                }

            }
        
            
        


/*                using (var db = new SqlConnection(conDB))
                {
                    db.Open();

                    string query = "SELECT position FROM HIRED_LIST WHERE student_accID = @studentAccID";

                    using (var command = new SqlCommand(query, db))
                    {
                        command.Parameters.AddWithValue("@studentAccID", studentaccId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Check if the database field is not null
                                if (!reader.IsDBNull(0))
                                {
                                    position = reader.GetString(0);
                                }
                            }
                        }
                    }
                }*/

             

        protected void Close_SuccessPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('hide');document.location='HiredList.aspx'", true);
        }
        protected void Close_MultipleEditSuccessPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessMultipleEditPrompt').modal('hide'); document.location='HiredList.aspx'", true);
        }
        protected void Close_MultipleEdit(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript1", "closeModalEdit();", true);
        }
        protected void listView1_DataBound(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                // Display a message or show a placeholder when there is no data
                var placeHolder = listView1.FindControl("itemPlaceHolder") as PlaceHolder;
                if (placeHolder != null)
                {
                    placeHolder.Controls.Add(new LiteralControl("<tr><td colspan='5'>No data available</td></tr>"));
                }
            }
        }
        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDateEnded.Text))
            {

                if (Convert.ToDateTime(txtDateEnded.Text) >= DateTime.Now.Date)
                {
                    lbldate.Visible = true;
                    lbldate.Text = "Interview date must be a recent or past date.";
                }
                else
                {
                    lbldate.Visible = false;
                }
            }
            else
            {
                lbldate.Visible = false;
            }


        }
        protected void dateStarted_TextChanged(object sender, EventArgs e)
        {
            DateTime dateHiredFromDatabase = GetDateHiredFromDatabase();

            if (!string.IsNullOrEmpty(txtDateStarted.Text) && DateTime.TryParse(txtDateStarted.Text, out DateTime dateStarted))
            {
                if (dateStarted < dateHiredFromDatabase)
                {
                    dateStartedlbl.Visible = true;
                    dateStartedlbl.Text = "Date started must be on or after the date hired.";
                }
                else
                {
                    dateStartedlbl.Visible = false;
                }
            }
            else
            {
                // Handle the case where txtDateStarted is empty or not a valid date
                dateStartedlbl.Visible = false;
            }
        }
        private DateTime GetDateHiredFromDatabase(int studentAccountId)
        {
            DateTime dateHired = DateTime.MinValue; // Default value in case of an issue or no result

            using (var connection = new SqlConnection("your_connection_string_here"))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT dateHired FROM YourTableName WHERE studentAccountId = @studentAccountId", connection))
                {
                    command.Parameters.AddWithValue("@studentAccountId", studentAccountId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assuming 'dateHired' is a DateTime column in your database
                            dateHired = reader.GetDateTime(reader.GetOrdinal("dateHired"));
                        }
                    }
                }
            }

            return dateHired;
        }




        private List<string> selectedStudentIds = new List<string>();
        private List<string> selectedInternNames = new List<string>();
        private List<string> selectedPosition = new List<string>();
        private List<string> selectedDateHired = new List<string>();
        private List<string> selectedDateStarted = new List<string>();
        private List<string> selectedDateEnded = new List<string>();
        private List<string> selectedHoursRendered = new List<string>();
        private List<string> selectedInternshipStatus = new List<string>();


        protected void onEditButton_Click(object sender, EventArgs e)
        {
            Button btnEdit = (Button)sender;
            int checkedCount = 0;
            string stat = string.Empty;
            foreach (ListViewItem item in listView2.Items)
            {
                CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");


                if (chkSelect.Checked)
                {

                    Label lblStudentID = (Label)item.FindControl("lblStudentID");
                    Label lblFirstName = (Label)item.FindControl("lblFirstName");
                    Label lblLastName = (Label)item.FindControl("lblLastName");
                    Label lblPosition = (Label)item.FindControl("lblPosition");
                    Label lblDateHired = (Label)item.FindControl("lblDateHired");
                    Label lblDateStarted = (Label)item.FindControl("lblDateStarted");
                    Label lblDateEnded = (Label)item.FindControl("lblDateEnded");
                    Label lblRenderedHours = (Label)item.FindControl("lblRenderedHours");
                    Label lblInternshipStatus = (Label)item.FindControl("lblInternshipStatus");

                    string studentaccountid = lblStudentID.Text;
                    string fname = lblFirstName.Text;
                    string lname = lblLastName.Text;
                    string position = lblPosition.Text;
                    string datehired = lblDateHired.Text;
                    string datestarted = lblDateStarted.Text;
                    string dateended = lblDateEnded.Text;
                    string renderhours = lblRenderedHours.Text;
                    string internshipstatus = lblInternshipStatus.Text;


                    selectedStudentIds.Add(studentaccountid);
                    selectedInternNames.Add($"{fname} {lname}");
                    selectedPosition.Add(position);
                    selectedDateHired.Add(datehired);
                    selectedDateStarted.Add(datestarted);
                    selectedDateEnded.Add(dateended);
                    selectedHoursRendered.Add(renderhours);
                    selectedInternshipStatus.Add(internshipstatus);

                    stat = lblInternshipStatus.Text;



                    // Pass the fname to the openModal JavaScript function

                    checkedCount++;
                }
            }
            ViewState["SelectedFullName"] = selectedInternNames;
            ViewState["SelectedPosition"] = selectedPosition;
            ViewState["SelectedDateHired"] = selectedDateHired;
            ViewState["SelectedDateStarted"] = selectedDateStarted;
            ViewState["SelectedDateEnded"] = selectedDateEnded;
            ViewState["SelectedRenderedHours"] = selectedHoursRendered;
            ViewState["SelectedInternshipStatus"] = selectedInternshipStatus;
            ViewState["SelectedStudentIds"] = selectedStudentIds;

            if (checkedCount > 1)
            {
                bool anyIsDone = selectedInternshipStatus.Any(status => status == "Done");
                if (anyIsDone)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript1", "openModalFailedEdit();", true);
                }
                else
                {
                    string existingname = string.Join(",", selectedInternNames);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript2", $"openModal2('{existingname}');", true);

                }
            }
            else if (checkedCount == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showModal", "$('#NoSelected').modal('show');", true);
            }
            else
            {
                bool anyIsDone = selectedInternshipStatus.Any(status => status == "Done");
                if (anyIsDone)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript1", "openModalFailedEdit();", true);
                }
                else
                {
                    string existingname = string.Join(" ", selectedInternNames);
                    string existingposition = string.Join(" ", selectedPosition);
                    string existingdatehired = string.Join(" ", selectedDateHired);
                    string existingdatestarted = string.Join(" ", selectedDateStarted);
                    string existingdateended = string.Join(" ", selectedDateEnded);
/*                    string existingrenderedhours = string.Join(" ", selectedHoursRendered);
*/                    string existingstatus = string.Join(" ", selectedInternshipStatus);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModalScript", $"openSingleSelectModal('{existingname}','{existingposition}','{existingdatehired}','{existingdatestarted}','{existingdateended}','{existingstatus}');", true);
                }
            }
        }
        protected void Close_NoSelectedPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#NoSelected').modal('hide');document.location='HiredList.aspx'", true);
        }

        private string GetFirstNameFromDatabase(int student_accID)
        {
            string firstname = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();

                string query = "SELECT firstName FROM HIRED_LIST WHERE student_accID = @studentID";

                using (var command = new SqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@studentID", student_accID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                firstname = reader.GetString(0);
                            }
                        }
                    }
                }
            }

            return firstname;
        }
        private string GetLastNameFromDatabase(int student_accID)
        {
            string lastname = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();

                string query = "SELECT lastName FROM HIRED_LIST WHERE student_accID = @studentID";
                SqlCommand command = new SqlCommand(query, db);
                command.Parameters.AddWithValue("@studentID", student_accID);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Check if the database field is not null
                        if (!reader.IsDBNull(0))
                        {
                            lastname = reader.GetString(0);
                        }
                    }
                }

            }

            return lastname;
        }
        private string GetPositionFromDatabase(int student_accID)
        {
            string position = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();

                string query = "SELECT position FROM HIRED_LIST WHERE student_accID = @studentID";

                using (var command = new SqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@studentID", student_accID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                position = reader.GetString(0);
                            }
                        }
                    }
                }
            }

            return position;
        }
        private string GetDateHiredFromDatabase(int student_accID)
        {
            DateTime dateHired = DateTime.MinValue;
            string formattedDateHired = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();

                string query = "SELECT dateHired FROM HIRED_LIST WHERE student_accID = @studentID";

                using (var command = new SqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@studentID", student_accID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                dateHired = reader.GetDateTime(0);
                                formattedDateHired = dateHired.ToString("yyyy-MM-dd");
                            }
                        }
                    }
                }
            }

            return formattedDateHired;
        }
        private string GetDateStartedFromDatabase(int student_accID)
        {
            DateTime dateStarted = DateTime.MinValue;
            string formattedDateStarted = string.Empty;

            using (var db = new SqlConnection(conDB))
            {
                db.Open();

                string query = "SELECT dateStarted FROM HIRED_LIST WHERE student_accID = @studentID";

                using (var command = new SqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@studentID", student_accID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if the database field is not null
                            if (!reader.IsDBNull(0))
                            {
                                dateStarted = reader.GetDateTime(0);
                                formattedDateStarted = dateStarted.ToString("yyyy-MM-dd");
                            }
                        }
                    }
                }
            }

            return formattedDateStarted;
        }
        protected void closeEditModal(object sender, EventArgs e)
        {

           Page.ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal();", true);
        }

        protected void EvaluationBtn_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("EvaluationForm.aspx?student_accID=" + e.CommandArgument.ToString());
        }
    }
}
/*private string GetDateEndedFromDatabase(int student_accID)
{
    DateTime dateEnded = DateTime.MinValue;
    string formattedDateEnded = string.Empty;

    using (conDB)
    {
        conDB.Open();

        string query = "SELECT dateEnded FROM HIRED_LIST WHERE student_accID = @studentID";

        using (var command = new SqlCommand(query, conDB))
        {
            command.Parameters.AddWithValue("@studentID", student_accID);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Check if the database field is not null
                    if (!reader.IsDBNull(0))

                        dateEnded = reader.GetDateTime(0);
                        formattedDateEnded = dateEnded.ToString("yyyy-MM-dd");
                    }
                }
            }
        }
    }

    return formattedDateEnded;
}


}*/
/*protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        string InternshipStatus = DataBinder.Eval(e.Row.DataItem, "InternshipStatus").ToString();
        string EvaluationRequest = DataBinder.Eval(e.Row.DataItem, "EvaluationRequest").ToString();
        TableCell cell = e.Row.Cells[4];
        TableCell cell2 = e.Row.Cells[6];

        if (InternshipStatus == "ongoing")
        {
            cell.ForeColor = System.Drawing.Color.Green;
        }
        else if (InternshipStatus == "done")
        {
            cell.ForeColor = System.Drawing.Color.Red;
        }
        if (EvaluationRequest == "requested")
        {
            cell2.ForeColor = System.Drawing.Color.Red;
        }
        else if (EvaluationRequest == "--")
        {
            cell2.ForeColor = System.Drawing.Color.Black;
        }
    }
}*/
