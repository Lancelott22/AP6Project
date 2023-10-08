using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.DynamicData;

namespace ctuconnect
{
    
    public partial class JobPortal : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                JobBind();
            }
            
        }
        void JobBind()
        {
            string studentCourse = "IT";
            /*SqlCommand cmd = new SqlCommand("select * from HIRING WHERE jobCourse = @studCourse", conDB);
            cmd.Parameters.AddWithValue("@studCourse", studentCourse);*/
            SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            JobHiring.DataSource = ds;
            JobHiring.DataBind();
           
        }
        protected void ApplyJob_Command(object sender, CommandEventArgs e)
        {           
            int jobId = int.Parse(e.CommandArgument.ToString());
            if (checkJobApplied(jobId) == true)
            {
                SubmitApply.Enabled = false;
                SubmitApply.Text = "Applied";
                SubmitApply.CssClass = "buttonStyle";
            } else
            {
                SubmitApply.Enabled = true;
                SubmitApply.Text = "Submit Application";
               
            }
                conDB.Open();
                SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID where jobID = @jobID", conDB);
                cmd.Parameters.AddWithValue("@jobID", jobId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    JobId.Text = reader["jobID"].ToString();
                    IndstryLogo.Src = "images/" + reader["IndustryLogo"].ToString();
                    IndustryName.Text = reader["industryName"].ToString();
                    JobTitle.Text = reader["jobTitle"].ToString();
                    JobDetail.Text = reader["jobDescription"].ToString();
                    JobType.Text = reader["jobType"].ToString();
                    JobLocation.Text = reader["jobLocation"].ToString();
                    JobCourse.Text = reader["jobCourse"].ToString();
                    JobQualification.Text = reader["jobQualifications"].ToString();
                    ApplicationInstruction.Text = reader["applicationInstruction"].ToString();
                    SalaryRange.Text = reader["salaryRange"].ToString();
                }
                reader.Close();
                conDB.Close();
                string script = "$('#ApplyJobModal').modal('show')";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);

            
        }

        protected void SubmitApply_Command(object sender, CommandEventArgs e) //submitApplication
        {
            /*  if (checkResume())
              {

              }*/
            /* string Usertype = Session["UserType"].ToString();
             string type = e.CommandName.ToString();
             int student_accId = int.Parse(Session["Student_accID"].ToString());
             int alumni_accId = int.Parse(Session["Alumni_accID"].ToString());
             string applicantFName = Session["Fname"].ToString();
             string applicantLName = Session["Lname"].ToString();
             string dateApplied = DateTime.Now.ToString("dd MMMM yyyy");
             string resume = Session["ResumeFile"].ToString();
             int jobID = int.Parse(e.CommandArgument.ToString());
             int industry_accId = int.Parse(Session["industry_accID"].ToString());*/
            string Usertype = "Student";
            string type = "Intern";
            int student_accId = 1;
            int alumni_accId = 1;
             string applicantFName = "AKosi";
             string applicantLName = "MYLastName";
             string dateApplied = DateTime.Now.ToString("dd MMMM yyyy");
             string resume = "resume";
            int jobID = int.Parse(JobId.Text);
            int industry_accId = 11111;

            conDB.Open();
            if (Usertype == "Alumni")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (applicantID,type,alumni_accID,firstName, lastName, industry_accID,dateApplied, resume, jobID  ) " +
                    "Values(@applicantID, @type, @student_accId, @applicantFName, @applicantLName,@industry_accId, @dateApplied, @resume,@jobID)", conDB);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@student_accId", student_accId);
                cmd.Parameters.AddWithValue("@applicantFName", applicantFName);
                cmd.Parameters.AddWithValue("@applicantLName", applicantLName);
                cmd.Parameters.AddWithValue("@industry_accId", industry_accId);
                cmd.Parameters.AddWithValue("@dateApplied", dateApplied);
                cmd.Parameters.AddWithValue("@resume", resume);
                cmd.Parameters.AddWithValue("@jobID", jobID);
                cmd.ExecuteNonQuery();
            }
            else if (Usertype == "Student")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (applicantID,type,student_accID,firstName, lastName, industry_accID,dateApplied, resume, jobID  ) " +
                  "Values(@applicantID, @type, @student_accId, @applicantFName, @applicantLName,@industry_accId, @dateApplied, @resume,@jobID)", conDB);
                cmd.Parameters.AddWithValue("@applicantID", 116);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@student_accId", student_accId);
                cmd.Parameters.AddWithValue("@applicantFName", applicantFName);
                cmd.Parameters.AddWithValue("@applicantLName", applicantLName);
                cmd.Parameters.AddWithValue("@industry_accId", industry_accId);
                cmd.Parameters.AddWithValue("@dateApplied", dateApplied);
                cmd.Parameters.AddWithValue("@resume", resume);
                cmd.Parameters.AddWithValue("@jobID", jobID);
                 cmd.ExecuteNonQuery();
            }
            conDB.Close();


        }
        bool checkResume() //check resume
        {
            int student_accId = int.Parse(Session["Student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select ResumeFile from STUDENT_ACCOUNT where student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                if(reader["ResumeFile"].ToString() == null)
                {
                    conDB.Close();
                    return false;
                }
                reader.Close();
               
            }

            else 
            {
                conDB.Close();
                return false;
            }
            return true;
        }
        bool checkJobApplied(int jobID) //check if already applied to selected job
        {
            /*int student_accId = int.Parse(Session["Student_accID"].ToString());*/
            int selectedJobID = jobID;
            int student_accId = 1;
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select * from APPLICANT Where jobID = @jobId and student_accID = @student_accId", conDB);
            cmd.Parameters.AddWithValue("@jobId", selectedJobID);
            cmd.Parameters.AddWithValue("@student_accId", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                conDB.Close();
                return true;
            }
            conDB.Close();
            return false;
        }

        /*protected void JobHiring_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
            Button button = e.Item.FindControl("ApplyJob") as Button;
            button.Text = "Applied";
        }*/
    }
}  