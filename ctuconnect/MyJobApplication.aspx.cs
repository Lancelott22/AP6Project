using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

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
            if (checkResumeStatus() == false)
            {
                ResumeStatus.Visible = true;
                if (checkInterviewStatus() == false)
                {
                    InterviewStatus.Visible = false;

                    if (checkApplicantStatus() == false)
                    {
                        applicantStatus.Visible = false;
                    }
                }             
            }
          
        }
        void JobBind()
        {
            int studentAccID = 1;
            SqlCommand cmd = new SqlCommand("select * from APPLICANT JOIN INDUSTRY_ACCOUNT ON APPLICANT.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN HIRING ON APPLICANT.jobID = HIRING.jobID Where student_accID = @Student_accID", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MyApplication.DataSource = ds;
            MyApplication.DataBind();
        }
        bool checkResumeStatus()
        {
            return false;
        }
        bool checkInterviewStatus()
        {
            return false;
        }
        bool checkApplicantStatus()
        {
            return false;
        }
        protected void ViewApplication_Command(object sender, CommandEventArgs e)
        {
            string script = "$('#ViewApplication').modal('show')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }
    }
}