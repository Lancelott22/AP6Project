using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Antlr.Runtime;

namespace ctuconnect
{
    public partial class WebForm1 : System.Web.UI.Page
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
            int studentAccID = 100000000;
            SqlCommand cmd = new SqlCommand("select * from APPLICANT JOIN INDUSTRY_ACCOUNT ON APPLICANT.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN HIRING ON APPLICANT.jobID = HIRING.jobID Where student_accID = @Student_accID", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MyApplication.DataSource = ds;
            MyApplication.DataBind();
        }
        bool checkResumeStatus(int applicantID, int jobId)
        {
            int studentAccID = 100000000; //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select resumeStatus from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int resumeStatus = Convert.ToInt32(reader["resumeStatus"].ToString());
                if (resumeStatus == 1)
                {
                    conDB.Close();
                    return true;
                }
                else
                {
                    conDB.Close();
                    return false;
                }
            }
            conDB.Close();
            return false;
        }
        bool checkInterviewStatus(int applicantID, int jobId)
        {
            int studentAccID = 100000000; //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select interviewStatus from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int interviewStatus = Convert.ToInt32(reader["interviewStatus"].ToString());
                if (interviewStatus == 1)
                {
                    conDB.Close();
                    return true;
                }
                else
                {
                    conDB.Close();
                    return false;
                }
            }
            conDB.Close();
            return false;
        }
        bool checkApplicantStatus(int applicantID, int jobId)
        {
            int studentAccID = 100000000; //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select applicantStatus from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int applicantStatus = Convert.ToInt32(reader["applicantStatus"].ToString());
                if (applicantStatus == 1)
                {
                    conDB.Close();
                    return true;
                }
                else
                {
                    conDB.Close();
                    return false;
                }
            }
            conDB.Close();
            return false;
        }
        protected void ViewApplication_Command(object sender, CommandEventArgs e)
        { int jobId = int.Parse(e.CommandName.ToString());
            int applicantID = int.Parse(e.CommandArgument.ToString());
            if (checkResumeStatus(applicantID, jobId) == true)
            {
                resumeStatusCheck.Text = "Your resume has been reviewed.";
                statusResume.Visible = true;
                InterviewStatus.Visible = true;
                if (checkInterviewStatus(applicantID, jobId) == true)
                {
                    StatusOrDetails.InnerText =  "Interview Details: ";

                    interviewStatusCheck.Text = showInterviewDetails(applicantID, jobId);
                    statusInterview.Visible = true;
                }
                else
                {
                    interviewStatusCheck.Text = "Waiting for your interview schedule...";
                    statusInterview.Visible = false;
                    StatusOrDetails.InnerText = "Status: ";
                }
            }
            else
            {
                statusResume.Visible = false;
                resumeStatusCheck.Text = "Waiting for your resume review status...";
                InterviewStatus.Visible = false;

            }
            if ((checkInterviewStatus(applicantID, jobId) == true && checkResumeStatus(applicantID, jobId) == true))

            {  
                applicantStatus.Visible = true;
               if(checkApplicantStatus(applicantID, jobId) == true)
                {

                    statusApplication.InnerText = "Approved";
                    applicationStatusCheck.Text = "Congratulations! Your application has been approved.";
                    statusApplication.Visible = true;
                }
                else
                {

                    applicationStatusCheck.Text = "Waiting for your application approval...";
                    statusApplication.Visible = false;
                    statusApplication.InnerText = "Rejected";
                }  
            }
            else
            {
                applicantStatus.Visible = false;
            }
            string script = "$('#ViewApplication').modal('show')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
            
        }

        string showInterviewDetails(int applicantID, int jobId)
        {
            string interviewDetail = "";
            int studentAccID = 100000000; //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select interviewDetails from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                interviewDetail = reader["interviewDetails"].ToString();
                conDB.Close();
                return interviewDetail;
            }
            conDB.Close();
            return interviewDetail;
        }
    }
}