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
            if (!IsPostBack && Session["StudentEmail"] == null)
            {
                Response.Redirect("LoginStudent.aspx");

            }
            else if (!IsPostBack)
            {
                JobBind();
            }

        }
        void JobBind()
        {
            string studentCourse = Session["Student_COURSE"].ToString();
            /*SqlCommand cmd = new SqlCommand("select * from HIRING WHERE jobCourse = @studCourse", conDB);
            cmd.Parameters.AddWithValue("@studCourse", studentCourse);*/
            SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE jobCourse = @studCourse", conDB);
            cmd.Parameters.AddWithValue("@studCourse", studentCourse);
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
                SubmitApply.CssClass = "buttonStyleSubmitDisable";
            } else
            {
                SubmitApply.Enabled = true;
                SubmitApply.Text = "Submit Application";
                SubmitApply.CssClass = "buttonStyleSubmit";
            }
                conDB.Open();
                SqlCommand cmd = new SqlCommand("select * from HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.industry_accID = INDUSTRY_ACCOUNT.industry_accID where jobID = @jobID", conDB);
                cmd.Parameters.AddWithValue("@jobID", jobId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Job_ID.Text = reader["jobID"].ToString();
                    IndstryLogo.Src = "images/" + reader["industryPicture"].ToString();
                    IndustryName.Text = reader["industryName"].ToString();
                    JobTitle.Text = reader["jobTitle"].ToString();
                    JobDescription.Text = reader["jobDescription"].ToString();
                    JobType.Text = reader["jobType"].ToString();
                    JobLocation.Text = reader["jobLocation"].ToString();
                    JobCourse.Text = reader["jobCourse"].ToString();
                    JobQualification.Text = reader["jobQualifications"].ToString();
                    ApplicationInstruction.Text = reader["applicationInstruction"].ToString();
                IndustryID.Text = reader["industry_accID"].ToString();
                    
                if (reader["salaryRange"] == null || reader["salaryRange"].ToString() == string.Empty)
                {                
                    salaryData.Visible = false;
                    SalaryRange.Visible = false;
                }
                else
                {
                    salaryData.Visible = true;
                    SalaryRange.Text = reader["salaryRange"].ToString();
                    SalaryRange.Visible = true;
                }
                   
                }
                reader.Close();
                conDB.Close();
                string script = "$('#ApplyJobModal').modal('show')";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);

            
        }

        protected void SubmitApply_Command(object sender, CommandEventArgs e) //submitApplication
        {
            int alumni_accId = -1;
            int student_accId = -1; ;
            
             string Usertype = Session["STATUSorTYPE"].ToString();
                string jobtype = JobType.Text.ToString();
            if(Usertype == "Alumni")
            {
                alumni_accId = int.Parse(Session["Alumni_accID"].ToString());
            }
            else if (Usertype == "Student")
            {
                 student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            }          
             string position = JobTitle.Text.ToString();
             string applicantFName = Session["FNAME"].ToString();
             string applicantLName = Session["LNAME"].ToString();
             string dateApplied = DateTime.Now.ToString("dd MMMM yyyy");
             string resume = Session["ResumeFile"].ToString();
             int jobID = int.Parse(Job_ID.Text.ToString());
            int industry_accId = int.Parse(IndustryID.Text.ToString());

            if (checkResume())
            {


                conDB.Open();
                if (Usertype == "Alumni")
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (jobType,alumni_accID,applicantFName, applicantLName, industry_accID,dateApplied, resume, jobID  ) " +
                        "Values( @jobtype, @student_accId, @applicantFName, @applicantLName,@industry_accId, @dateApplied, @resume,@jobID)", conDB);

                    cmd.Parameters.AddWithValue("@jobtype", jobtype);
                    cmd.Parameters.AddWithValue("@student_accId", alumni_accId);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO APPLICANT (jobType,student_accID,applicantFName, applicantLName, industry_accID,dateApplied, resume, jobID  ) " +
                      "Values(@jobtype, @student_accId, @applicantFName, @applicantLName,@industry_accId, @dateApplied, @resume,@jobID)", conDB);

                    cmd.Parameters.AddWithValue("@jobtype", jobtype);
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
            }else
            {
                Response.Write("<script>alert('Please upload or create resume first before applying job.');document.location='Resume.aspx'</script>");
            }
           
        }
        bool checkResume() //check resume
        {
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select resumeFile from STUDENT_ACCOUNT where student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                if(reader["resumeFile"] == null || reader["resumeFile"].ToString() == string.Empty)
                {
                    reader.Close();
                    conDB.Close();
                    return false;
                    
                }
                else
                {
                    conDB.Close();
                    return true;
                }
               
               
            }

           
            return false;
        }
        bool checkJobApplied(int jobID) //check if already applied to selected job
        {
          
            int selectedJobID = jobID;
            int student_accId = int.Parse(Session["Student_ACC_ID"].ToString());
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

        protected void JobHiring_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label jobID = e.Item.FindControl("JobID") as Label;
            int JobId = int.Parse(jobID.Text);
            Button btn = e.Item.FindControl("ApplyJob") as Button;

            if (checkJobApplied(JobId) == true)
            {
                btn.Text = "Applied";
            }
            else if (checkJobApplied(JobId) == false)
            {
                btn.Text = "Apply";
            }
            JobBind();
        }

    }
}  