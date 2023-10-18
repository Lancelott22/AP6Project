using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            if (!IsPostBack)
            {
                this.BindGrid();

            }


        }


        void BindGrid()
        {

            using (var db = new SqlConnection(conDB))
            {

                db.Open();
                using (var cmd = db.CreateCommand())
                {

                    cmd.CommandType = CommandType.Text;
                    string sql = "select * from APPLICANT";
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
                    string sql = "UPDATE APPLICANT SET resumeStatus = @ResumeStatus, interviewDetails = @InterviewDetails, interviewStatus = @InterviewStatus, applicantStatus = @ApplicantStatus WHERE applicantID = @ApplicantID";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ApplicantID", applicantID);
                    cmd.Parameters.AddWithValue("@ResumeStatus", resumeStatus);
                    cmd.Parameters.AddWithValue("@InterviewDetails", interviewDetails);
                    cmd.Parameters.AddWithValue("@InterviewStatus", interviewStatus);
                    cmd.Parameters.AddWithValue("@ApplicantStatus", applicantStatus);

                    cmd.ExecuteNonQuery();
                }
            }

            // Close the modal after saving
            //ClientScript.RegisterStartupScript(this.GetType(), "closeModal", "closeEditModal();", true);
            GridView1.EditIndex = -1;
            this.BindGrid();

            if (drpApplicantStatus.SelectedValue == "Approved")
            {

                using (SqlConnection connection = new SqlConnection(conDB))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT type, student_accID, applicantFname, applicantLname, appliedPosition, jobID,APPLICANT.industry_ACCID, StudentType, INDUSTRY_ACCOUNT.industryName FROM APPLICANT " +
                            "JOIN INDUSTRY_ACCOUNT ON APPLICANT.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                            "WHERE applicantID = @ApplicantID";
                        command.Parameters.AddWithValue("@ApplicantID", applicantID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string jobType = reader["type"].ToString();
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
                                /*string alumni_accID = reader["alumni_accID"].ToString();*/
                                /*int alumniID = Convert.ToInt32(alumni_accID);*/
                                string intershipStatus = "Ongoing";

                                reader.Close();

                                using (var dmd = connection.CreateCommand())
                                { //SQL Statement
                                    dmd.CommandType = CommandType.Text;
                                    dmd.CommandText = "INSERT INTO HIRED_LIST (student_accID, firstName, lastName, jobID, workedAt, position,dateHired,  industry_accID, studentType, jobType, internshipStatus)  "
                                                    + " VALUES (@StudentAccID,@Firstname,@Lastname,@JobID,@workedAt, @position,@dateHired, @IndustryAccID,@StudentType,@JobType,@InternshipStatus)";

                                    dmd.Parameters.AddWithValue("@StudentAccID", studentID);
                                    dmd.Parameters.AddWithValue("@Firstname", applicantfname);
                                    dmd.Parameters.AddWithValue("@Lastname", applicantlname);
                                    dmd.Parameters.AddWithValue("@JobID", jobid);
                                    dmd.Parameters.AddWithValue("@IndustryAccID", industryID);
                                    dmd.Parameters.AddWithValue("@StudentType", studentType);
                                    dmd.Parameters.AddWithValue("@workedAt", WorkedAt);
                                    dmd.Parameters.AddWithValue("@position", position);
                                    dmd.Parameters.AddWithValue("@dateHired", DateTime.Now.ToString("yyyy/MM/dd"));
                                    /*dmd.Parameters.AddWithValue("@AlumniAccID", alumniID);*/
                                    dmd.Parameters.AddWithValue("@JobType", jobType);
                                    dmd.Parameters.AddWithValue("@InternshipStatus", intershipStatus);

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
            string resumeStatus = GridView1.Rows[rowIndex].Cells[6].Text;
            string interviewDetails = GridView1.Rows[rowIndex].Cells[7].Text;
            string interviewStatus = GridView1.Rows[rowIndex].Cells[8].Text;
            string applicantStatus = GridView1.Rows[rowIndex].Cells[9].Text;

            string applicantLname = GridView1.Rows[rowIndex].Cells[3].Text;
            string applicantFname = GridView1.Rows[rowIndex].Cells[2].Text;
            string dateAppplied = GridView1.Rows[rowIndex].Cells[4].Text;

            // Additional fields can be retrieved similarly

            // Populate the modal with the data and show it
            ClientScript.RegisterStartupScript(this.GetType(), "openEditModal", $"openEditModal('{resumeStatus}', '{interviewDetails}', '{interviewStatus}', '{applicantStatus}');", true);
            lblName.Text = applicantFname + " " + applicantLname;
            lblapplicantID.Text = id;
            lblDateApplied.Text = dateAppplied;


            GridView1.EditIndex = -1;
            this.BindGrid();




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


    }
}