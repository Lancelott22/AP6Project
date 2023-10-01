using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace ctuconnect
{
    public partial class IndustryHome : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void PostJob_Click(object sender, EventArgs e)
        {
            try
            {
                string jobTitle = JobTitle.Text;
                string industryName = IndName.Text;
                string jobType = jobtype.Value.ToString();
                string jobCourse = course.Value.ToString();
                string jobLocation = jobLoc.Text;
                string jobDescription = jobDescript.Text;
                string jobQualification = jobQuali.Text;
                string jobInstruction = jobInstruct.Text;
                conDB.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO HIRING(jobID, industry_accID, jobTitle, industryName, " +
                    "jobType, jobCourse, jobLocation, jobDescription, jobQualifications, applicationInstruction)" +
                    "VALUES(@jobID,@industry_accID, @jobTitle, @industryName,@jobType,@jobCourse,@jobLocation,@jobDescription," +
                    "@jobQualifications,@applicationInstruction)", conDB);
                cmd.Parameters.AddWithValue("@jobID", 100000000);
                cmd.Parameters.AddWithValue("@industry_accID", 11111);
                cmd.Parameters.AddWithValue("@jobTitle", jobTitle);
                cmd.Parameters.AddWithValue("@industryName", industryName);
                cmd.Parameters.AddWithValue("@jobType", jobType);
                cmd.Parameters.AddWithValue("@jobCourse", jobCourse);
                cmd.Parameters.AddWithValue("@jobLocation", jobLocation);
                cmd.Parameters.AddWithValue("@jobDescription", jobDescription);
                cmd.Parameters.AddWithValue("@jobQualifications", jobQualification);
                cmd.Parameters.AddWithValue("@applicationInstruction", jobInstruction);
                var ctr = cmd.ExecuteNonQuery();

                if(ctr > 0 )
                {
                    Response.Write("<script>alert('The job has been posted successfully.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Cannot post a job now! Please try again later.')</script>");
                }
                conDB.Close();
            }
            catch 
            {
                Response.Write("<script>alert('Cannot post a job now! Please try again later.')</script>");
            }
        }
    }
}