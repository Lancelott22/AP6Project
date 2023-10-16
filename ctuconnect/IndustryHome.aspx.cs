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
            disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
            disp_accID.Text = Session["ACC_ID"].ToString();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO HIRING( industry_accID, jobTitle, industryName, " +
                    "jobType, jobCourse, jobLocation, jobDescription, jobQualifications, applicationInstruction,salaryRange)" +
                    "VALUES(@industry_accID, @jobTitle, @industryName,@jobType,@jobCourse,@jobLocation,@jobDescription," +
                    "@jobQualifications,@applicationInstruction, @salary)", conDB);
                cmd.Parameters.AddWithValue("@industry_accID", 600000002);
                cmd.Parameters.AddWithValue("@jobTitle", jobTitle);
                cmd.Parameters.AddWithValue("@industryName", industryName);
                cmd.Parameters.AddWithValue("@jobType", jobType);
                cmd.Parameters.AddWithValue("@jobCourse", jobCourse);
                cmd.Parameters.AddWithValue("@jobLocation", jobLocation);
                cmd.Parameters.AddWithValue("@jobDescription", jobDescription);
                cmd.Parameters.AddWithValue("@jobQualifications", jobQualification);
                cmd.Parameters.AddWithValue("@applicationInstruction", jobInstruction);
                cmd.Parameters.AddWithValue("@salary", 10000);
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