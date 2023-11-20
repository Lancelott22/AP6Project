using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Xml.Linq;
using System.Drawing;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace ctuconnect
{

    public partial class Refer : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
            if (!IsPostBack)
            {
                /*if (Session["Coor_ACC_ID"] != null)
                {
                    // Retrieve the coordinator_accID from the session
                    *//*BindGridView1();*//*
                }
                else
                {
                    // Handle the case where the user is not logged in or doesn't have a coordinator_accID.
                }*/
              

                BindTable();
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT industry_accID, industryName FROM INDUSTRY_ACCOUNT";

                    using (SqlCommand cmd = new SqlCommand(query, conDB))
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

            string query = "SELECT STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.midInitials,  INDUSTRY_ACCOUNT.industryName,   COORDINATOR_ACCOUNT.firstName + ' ' + COORDINATOR_ACCOUNT.lastName AS referredBy , REFERRAL.referralLetter, CONVERT(VARCHAR(10), REFERRAL.dateReferred, 120) AS dateReferred, REFERRAL.ReferralStatus " +
            "FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
            "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
            "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
            "WHERE REFERRAL.coordinator_accID = @CoordinatorID ORDER BY referralID DESC";
            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater.DataSource = ds;
            dataRepeater.DataBind();
            
        }
        protected void addRefer_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#AddReferralModal').modal('show');", true);
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            conDB.Open();
            string query = "SELECT firstName, midInitials, lastName FROM COORDINATOR_ACCOUNT where coordinator_accID = @coordinator_accID";
            SqlCommand command = new SqlCommand(query, conDB);
            command.Parameters.AddWithValue("@coordinator_accID", coordinatorID);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Populate the first name and last name textboxes
                    txtFirstName_coordinator.Text = reader["firstName"].ToString();
                    txtMiddleInitial_coordinator.Text = reader["midInitials"].ToString();
                    txtLastName_coordinator.Text = reader["lastName"].ToString();
                    txtID_coordinator.Text = coordinatorID.ToString();
                }
                else
                {
                    txtFirstName_coordinator.Text = "Not found";
                    txtMiddleInitial_coordinator.Text = "Not found";
                    txtLastName_coordinator.Text = "Not found";
                    txtID_coordinator.Text = "Not found";
                }
            }
        }
        
            protected void findByID_Student(object sender, EventArgs e)
        {
            string enteredID = txtID_student.Text.Trim();

            using (conDB)
            {
                conDB.Open();
                string query = "SELECT firstName, midInitials, lastName, resumeFile FROM STUDENT_ACCOUNT WHERE studentId = @studentId";
                SqlCommand command = new SqlCommand(query, conDB);
                command.Parameters.AddWithValue("@studentId", enteredID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the first name and last name textboxes
                        txtFirstName_student.Text = reader["firstName"].ToString();
                        txtMiddleInitial_student.Text = reader["midInitials"].ToString();
                        txtLastName_student.Text = reader["lastName"].ToString();
                        txtResumeFileName.Text = reader["resumeFile"].ToString();
                        
                    }
                    else
                    {
                        // Handle the case when no matching record is found
                        txtFirstName_student.Text = "Not found";
                        txtMiddleInitial_student.Text = "Not found";
                        txtLastName_student.Text = "Not found";
                        txtResumeFileName.Text = "No resume found";
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#AddReferralModal').modal('show');", true);
        }
        protected void Close_SuccessPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('hide');document.location='Refer.aspx'", true);
        }
        protected void Submit_ButtonClick(object sender, EventArgs e)
        {
            string studentID = txtID_student.Text;
            string industryID = dropdownIndustries.SelectedValue;
            string referralStatus = "Pending";

            HttpPostedFile postedFile = referralUpload.PostedFile;  /// upload file
            string filename = Path.GetFileName(postedFile.FileName);///to check the filename 
            int filesize = postedFile.ContentLength; //to get the filesize
            string logpath = Server.MapPath("~/images/ReferralLetter/"); //creating a drive to upload or save the file
            string filepath = Path.Combine(logpath, filename);

            postedFile.SaveAs(filepath);

            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            int studentAccountID = -1;

           


            using (conDB)
            {
                conDB.Open();
                string query = "SELECT student_accID FROM STUDENT_ACCOUNT WHERE studentID = @studentID";
                SqlCommand command = new SqlCommand(query, conDB);
                command.Parameters.AddWithValue("@studentId", studentID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        studentAccountID = reader.GetInt32(0); // Assuming student_accountID is an int
                    }
                }

                // Add the data to the Referral table in the database
                if (studentAccountID != -1)
                {
                    using (var cmd = conDB.CreateCommand())
                    {
                        // SQL Statement to insert data into the Referral table
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO REFERRAL (student_accID, industry_accID, coordinator_accID, referralLetter, dateReferred, ReferralStatus, isRead, isRemove ) " +
                                          "VALUES (@student_accID, @industryID, @coordinatorID, @referralLetter, @dateReferred, @referralStatus, @isRead, @isRemove)";

                        cmd.Parameters.AddWithValue("@student_accID", studentAccountID);
                        cmd.Parameters.AddWithValue("@industryID", industryID);
                        cmd.Parameters.AddWithValue("@coordinatorID", coordinatorID);
                        cmd.Parameters.AddWithValue("@referralLetter", filename);
                        cmd.Parameters.AddWithValue("@dateReferred", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.AddWithValue("@referralStatus", referralStatus);
                        cmd.Parameters.AddWithValue("@isRead", 0);
                        cmd.Parameters.AddWithValue("@isRemove", 0);
                        cmd.ExecuteNonQuery();
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('show');", true);

                }


                else
                {
                    // Handle the case where the studentID is not found
                    // You can show an error message or take appropriate action here
                }
            }
        }
        /* protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 string ReferralStatus = DataBinder.Eval(e.Row.DataItem, "ReferralStatus").ToString();
                 int cell = GetStatusColumnIndex();

                 if (ReferralStatus == "Pending")
                 {
                     e.Row.Cells[cell].Text = $"<span style='background-color: yellow;'>{ReferralStatus}</span>";
                 }
             }
         }
         private int GetStatusColumnIndex()
         {
             for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
             {
                 if (GridView1.HeaderRow.Cells[i].Text == "ReferralStatus")
                 {
                     return i;
                 }
             }
             return -1; // Return -1 if the column is not found.
         }*/

        protected string GetStatusCssClass(string ReferralStatus)
        {
            string cssClass = "default-status"; // Define a default CSS class

            if (ReferralStatus == "Pending")
            {
                cssClass = "status-pending";
            }
            else if (ReferralStatus == "Approved")
            {
                cssClass = "status-approved";
            }
            // Add more conditions for other status values.

            return cssClass;
        }
        protected void ReviewLetter_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Review")
            {
                /* Button btn = (Button)sender;
                 int studentID = Convert.ToInt32(btn.Attributes["data-studentid"]);
 */
                string referralLetterFileName = e.CommandArgument.ToString();
                /*string endorsementLetterPath = Server.MapPath("~/images/EndorsementLetter" + endorsementLetterFileName);*/
                // Change the button text to "Reviewed"
                //Button button = (Button)sender;
                //button.Text = "Reviewed";


                // Retrieve and display the resume file
                 byte[] referralLetterFileData = GetEndorsementFileData(referralLetterFileName);


                if (referralLetterFileData != null)
                {
                    // Provide the file data for download in a new browser tab
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf"; // Set the appropriate content type
                    Response.AddHeader("content-disposition", "inline; filename=referralLetter.pdf"); // Open in a new tab
                    Response.BinaryWrite(referralLetterFileData);
                    Response.End();
                }
            }
        }
        private byte[] GetEndorsementFileData(string referralLetterFileName)
        {
            using (conDB)
            {
                string query = "SELECT referralLetter FROM REFERRAL WHERE referralLetter = @referralLetterFileName";
                SqlCommand cmd = new SqlCommand(query, conDB);
                cmd.Parameters.AddWithValue("@referralLetterFileName", referralLetterFileName);

                conDB.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Assuming that the result is a file path, read the file content
                    string fileName = result.ToString();
                    string filePath = "~/images/ReferralLetter/" + fileName; // Construct the path
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
            Response.Redirect("LoginOJTCoordinator.aspx");
        }
    }
}
    
