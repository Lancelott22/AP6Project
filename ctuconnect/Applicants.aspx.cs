using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Applicants : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] != null)
            {
                this.BindGrid();

            }

        }


        void BindGrid()
        {

            using (var db = new SqlConnection(conDB))
            {
                int industryAccID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"].ToString());
                db.Open();
                using (var cmd = db.CreateCommand())
                {

                    cmd.CommandType = CommandType.Text;
                    string sql = "select * from APPLICANT WHERE industry_accID = '" + industryAccID + "'";
                    cmd.CommandText = sql;
                    cmd.Connection = db;
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt); //Use the Fill method of SqlDataAdapter object to fill the DataSet with the result of query string.
                    GridView1.DataSource = dt; //Create a new row with specified values and add to the data row collection.  
                    GridView1.DataBind(); //Gets or sets the object from which the data-bound control retrieves its list.


                    Response.Write("<script type='text/javascript'> setTimeout('location.reload(true); ', timeout);</script>");

                }
            }

        }

        // Event handler for saving changes within the modal
        protected void SaveRecord(object sender, EventArgs e)
        {
            // Retrieve the edited data from the modal form fields
            string resumeStatus = drpResumeStatus.Text;
            string interviewDetails = txtInterviewDetails.Text;
            string interviewScheduledDate = txtInterviewDate.Text;
            string interviewStatus = drpInterviewStatus.Text;
            string applicantStatus = drpApplicantStatus.Text;
            int applicantID = Convert.ToInt32(lblapplicantID.Text);
            // Additional fields can be retrieved similarly

            // Perform database update logic to save the changes
            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    string sql = "UPDATE APPLICANT SET resumeStatus = @ResumeStatus, interviewDetails = @InterviewDetails, interviewScheduledDate = @InterviewScheduledDate, interviewStatus = @InterviewStatus, applicantStatus = @ApplicantStatus WHERE applicantID = @ApplicantID";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ApplicantID", applicantID);
                    cmd.Parameters.AddWithValue("@ResumeStatus", resumeStatus);
                    cmd.Parameters.AddWithValue("@InterviewDetails", interviewDetails);
                    cmd.Parameters.AddWithValue("@InterviewScheduledDate", interviewScheduledDate);
                    cmd.Parameters.AddWithValue("@InterviewStatus", interviewStatus);
                    cmd.Parameters.AddWithValue("@ApplicantStatus", applicantStatus);

                    cmd.ExecuteNonQuery();
                }
            }


            GridView1.EditIndex = -1;
            this.BindGrid();
            if (drpResumeStatus.SelectedValue == "Reviewed")
            {
                editResumeReviewedDate(applicantID);
            }

            if (drpApplicantStatus.SelectedValue == "Approved")
            {

                using (SqlConnection connection = new SqlConnection(conDB))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT jobType, student_accID, applicantFname, applicantLname, appliedPosition, resume, jobID, APPLICANT.industry_accID, StudentType, INDUSTRY_ACCOUNT.industryName FROM APPLICANT " +
                            "JOIN INDUSTRY_ACCOUNT ON APPLICANT.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                            "WHERE applicantID = @ApplicantID";
                        command.Parameters.AddWithValue("@ApplicantID", applicantID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string jobType = reader["jobType"].ToString();
                                string student_accID = reader["student_accID"].ToString();
                                int studentID = Convert.ToInt32(student_accID);
                                string applicantfname = reader["applicantFname"].ToString();
                                string applicantlname = reader["applicantLname"].ToString();
                                string jobID = reader["jobID"].ToString();
                                int jobid = Convert.ToInt32(jobID);
                                string industry_accID = reader["industry_accID"].ToString();
                                int industryID = Convert.ToInt32(industry_accID);
                                string studentType = reader["StudentType"].ToString();
                                string WorkedAt = reader["industryName"].ToString();
                                string position = reader["appliedPosition"].ToString();
                                string resumefile = reader["resume"].ToString();
                                /*string alumni_accID = reader["alumni_accID"].ToString();*/
                                /*int alumniID = Convert.ToInt32(alumni_accID);*/
                                string intershipStatus = "Ongoing";

                                editStudentAccount(studentID);
                                editApplicationApprovalDate(applicantID);

                                reader.Close();

                                using (var dmd = connection.CreateCommand())
                                { //SQL Statement
                                    dmd.CommandType = CommandType.Text;
                                    dmd.CommandText = "INSERT INTO HIRED_LIST (student_accID, firstName, lastName, jobID, workedAt, position,dateHired,  industry_accID, studentType, jobType, internshipStatus, resumeFile)  "
                                                    + " VALUES (@StudentAccID,@Firstname,@Lastname,@JobID,@workedAt, @position,@dateHired, @IndustryAccID,@StudentType,@JobType,@InternshipStatus, @ResumeFile)";

                                    dmd.Parameters.AddWithValue("@StudentAccID", studentID);
                                    dmd.Parameters.AddWithValue("@Firstname", applicantfname);
                                    dmd.Parameters.AddWithValue("@Lastname", applicantlname);
                                    dmd.Parameters.AddWithValue("@JobID", jobid);
                                    dmd.Parameters.AddWithValue("@workedAt", WorkedAt);
                                    dmd.Parameters.AddWithValue("@position", position);
                                    dmd.Parameters.AddWithValue("@dateHired", DateTime.Now.ToString("yyyy/MM/dd"));
                                    dmd.Parameters.AddWithValue("@IndustryAccID", industryID);
                                    dmd.Parameters.AddWithValue("@StudentType", studentType);
                                    dmd.Parameters.AddWithValue("@JobType", jobType);
                                    dmd.Parameters.AddWithValue("@InternshipStatus", intershipStatus);
                                    dmd.Parameters.AddWithValue("@ResumeFile", resumefile);

                                    var ctr = dmd.ExecuteNonQuery();
                                    if (ctr > 0)
                                    {
                                        Response.Write("<script>alert('Applicant officially hired')</script>");
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Data is not save')</script>");
                                    }
                                }


                            }
                            else
                            {
                                Response.Write("<script>alert('Invalid Credentials')</script>");
                            }
                        }
                    }
                    connection.Close();
                }
            }

        }


        protected void EditRecord(object sender, EventArgs e)
        {
            // Find the index of the row that was clicked
            GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;
            int rowIndex = row.RowIndex;

            // Retrieve the data from the selected row using the row index
            string id = GridView1.Rows[rowIndex].Cells[0].Text;
            string resumeStatus = GridView1.Rows[rowIndex].Cells[8].Text;
            string interviewDetails = GridView1.Rows[rowIndex].Cells[9].Text;
            string interviewStatus = GridView1.Rows[rowIndex].Cells[11].Text;
            string applicantStatus = GridView1.Rows[rowIndex].Cells[12].Text;

            string applicantLname = GridView1.Rows[rowIndex].Cells[4].Text;
            string applicantFname = GridView1.Rows[rowIndex].Cells[3].Text;
            string appliedPosition = GridView1.Rows[rowIndex].Cells[5].Text;
            string dateApplied = GridView1.Rows[rowIndex].Cells[6].Text;

            object interviewDateValue = GridView1.Rows[rowIndex].Cells[10].Text;
            if (interviewDateValue != DBNull.Value)
            {
                DateTime interviewdate = Convert.ToDateTime(interviewDateValue);
                string interviewScheduledDate = interviewdate.ToString("yyyy-MM-dd");

                ClientScript.RegisterStartupScript(this.GetType(), "openEditModal", $"openEditModal('{resumeStatus}', '{interviewDetails}', '{interviewScheduledDate}', '{interviewStatus}', '{applicantStatus}');", true);
            }

            lblName.Text = applicantFname + " " + applicantLname;
            lblapplicantID.Text = id;
            lblDateApplied.Text = dateApplied;
            lblAppliedPosition.Text = appliedPosition;

            GridView1.EditIndex = -1;
            this.BindGrid();


        }

        private void editResumeReviewedDate(int applicantID)
        {
            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE APPLICANT SET resumeReviewedDate = @ResumeReviewedDate WHERE applicantID = '" + applicantID + "' ";
                    cmd.Parameters.AddWithValue("@ResumeReviewedDate", DateTime.Now.ToString("yyyy/MM/dd"));
                    var ctr = cmd.ExecuteNonQuery();
                    //if (ctr > 0)

                }
            }
        }

        private void editStudentAccount(int studentAcctID)
        {
            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE STUDENT_ACCOUNT SET isHired = 1 WHERE student_accID = '" + studentAcctID + "' ";
                    var ctr = cmd.ExecuteNonQuery();
                    //if (ctr > 0)

                }
            }
        }

        private void editApplicationApprovalDate(int applicantID)
        {
            using (var db = new SqlConnection(conDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE APPLICANT SET applicationApprovalDate = @ApplicationApprovalDate WHERE applicantID = '" + applicantID + "' ";
                    cmd.Parameters.AddWithValue("@ApplicationApprovalDate", DateTime.Now.ToString("yyyy/MM/dd"));
                    var ctr = cmd.ExecuteNonQuery();
                    //if (ctr > 0)

                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    cell.CssClass = "center-header";
                }
            }
        }


        protected void closeEditModal(object sender, EventArgs e)
        {
            // Handle the close action here
            // For example, you can hide the modal by setting its visibility to false.
            ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal();", true);
        }

        protected void clndrbdate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }


    }
}