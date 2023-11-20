using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Org.BouncyCastle.Asn1.Ocsp;
using Microsoft.Ajax.Utilities;
using iTextSharp.tool.xml.html;
using iTextSharp.text.html;

namespace ctuconnect
{
    public partial class IndustryHome : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");

            }
            else
            {
                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;

            }

            IndName.Text = Session["INDUSTRYNAME"].ToString();
            IndName.Enabled = false;
            jobLoc.Text = Session["LOCATION"].ToString();
            jobLoc.Enabled = false;
            if (!IsPostBack)
            {
                fillJobDetails();
            }
        
        }
        void fillJobDetails()
        {
            if (Request.QueryString["jobid"] != null)
            {
                int jobId = int.Parse(Request.QueryString["jobid"].ToString());
                conDB.Open();
                SqlCommand cmd = new SqlCommand("select * from HIRING where jobID = @jobID", conDB);
                cmd.Parameters.AddWithValue("@jobID", jobId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    JobTitle.Text = reader["jobTitle"].ToString();
                    string jobTypes = reader["jobType"].ToString();
                    string[] jobTypeValues = jobTypes.Split(',');

                    foreach (ListItem item in jobtype.Items)
                    {
                        if (jobTypeValues.Contains(item.Value))
                        {
                            item.Selected = true;
                        }
                    }
                    string jobcourse = reader["jobCourse"].ToString();
                    string[] courseValues = jobcourse.Split(',');

                    foreach (ListItem item in course.Items)
                    {
                        if (courseValues.Contains(item.Value))
                        {
                            item.Selected = true;
                        }
                    }

                    jobDescript.Text = HttpUtility.HtmlDecode(reader["jobDescription"].ToString());
                    jobQuali.Text = HttpUtility.HtmlDecode(reader["jobQualifications"].ToString());
                    jobInstruct.Text = reader["applicationInstruction"].ToString();
                    salary.Text = reader["salaryRange"].ToString();
                    PostJob.Text = "Update Post";
                    JobTitle.Enabled = false;
                    if (bool.Parse(reader["isActive"].ToString()) == true)
                    {
                        checkActivateJob.Checked = true;
                    }
                    else
                    {
                        checkActivateJob.Checked = false;
                    }
                }
                reader.Close();
                conDB.Close();
            }
        }
        protected void PostJob_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(JobTitle.Text) || string.IsNullOrEmpty(IndName.Text) || jobtype.Value.Equals("") || course.Value.Equals("") || string.IsNullOrEmpty(jobLoc.Text) || string.IsNullOrEmpty(jobDescript.Text) || string.IsNullOrEmpty(jobQuali.Text))
            {
                Response.Write("<script>alert('Please fill up the required field.')</script>");
            }
            else if (Request.QueryString["jobid"] != null)
            {
                int jobId = int.Parse(Request.QueryString["jobid"].ToString());
                string jobTitle = JobTitle.Text;
                string industryName = IndName.Text;
                string jobType = "";

                foreach (ListItem item in jobtype.Items)
                {
                    if (item.Selected)
                    {
                        jobType += item.Value + ",";
                    }
                }
                jobType = jobType.Remove(jobType.Length - 1, 1);
                string jobCourse = "";
                foreach (ListItem item in course.Items)
                {
                    if (item.Selected)
                    {
                        jobCourse += item.Value + ",";
                    }
                }
                jobCourse = jobCourse.Remove(jobCourse.Length - 1, 1);
                string jobLocation = jobLoc.Text;
                string jobDescription = HttpUtility.HtmlEncode(jobDescript.Text);
                string jobQualification = HttpUtility.HtmlEncode(jobQuali.Text);
                string jobInstruction = jobInstruct.Text;
                string salaryRange = salary.Text;
                bool isActiveJob = checkActivateJob.Checked;
                conDB.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HIRING SET jobTitle=@jobTitle, industryName=@industryName, " +
                    "jobType=@jobType, jobCourse=@jobCourse, jobLocation=@jobLocation, jobDescription=@jobDescription, jobQualifications=@jobQualifications, " +
                    "applicationInstruction=@applicationInstruction,salaryRange=@salary,isActive = @isActive WHERE jobID = @jobId", conDB);
                cmd.Parameters.AddWithValue("@jobTitle", jobTitle);
                cmd.Parameters.AddWithValue("@industryName", industryName);
                cmd.Parameters.AddWithValue("@jobType", jobType);
                cmd.Parameters.AddWithValue("@jobCourse", jobCourse);
                cmd.Parameters.AddWithValue("@jobLocation", jobLocation);
                cmd.Parameters.AddWithValue("@jobDescription", jobDescription);
                cmd.Parameters.AddWithValue("@jobQualifications", jobQualification);
                cmd.Parameters.AddWithValue("@applicationInstruction", jobInstruction);
                cmd.Parameters.AddWithValue("@salary", salaryRange);
                cmd.Parameters.AddWithValue("@isActive", isActiveJob);
                cmd.Parameters.AddWithValue("@jobId", jobId);
               
                var ctr = cmd.ExecuteNonQuery();

                if (ctr > 0)
                {

                    Response.Write("<script>alert('The job has been updated successfully.');document.location='IndustryJobPosted.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Cannot update a job now! Please try again later.')</script>");
                }
            }
            else
            {
                int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
                string jobTitle = JobTitle.Text;
                string industryName = IndName.Text;
                string jobType = "";

                foreach (ListItem item in jobtype.Items)
                {
                    if (item.Selected)
                    {
                        jobType += item.Value + ",";
                    }
                }
                jobType = jobType.Remove(jobType.Length - 1, 1);
                string jobCourse = "";
                foreach (ListItem item in course.Items)
                {
                    if (item.Selected)
                    {
                        jobCourse += item.Value + ",";
                    }
                }
                jobCourse = jobCourse.Remove(jobCourse.Length - 1, 1);
                string jobLocation = jobLoc.Text;
                string jobDescription = HttpUtility.HtmlEncode(jobDescript.Text);
                string jobQualification = HttpUtility.HtmlEncode(jobQuali.Text);
                string jobInstruction = jobInstruct.Text;
                string salaryRange = salary.Text;
                bool isActiveJob = checkActivateJob.Checked;
                conDB.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO HIRING( industry_accID, jobTitle, industryName, " +
                    "jobType, jobCourse, jobLocation, jobDescription, jobQualifications, applicationInstruction,salaryRange,isActive,jobPostedDate)" +
                    "VALUES(@industry_accID, @jobTitle, @industryName,@jobType,@jobCourse,@jobLocation,@jobDescription," +
                    "@jobQualifications,@applicationInstruction, @salary,@isActive,@jobPostedDate)", conDB);
                cmd.Parameters.AddWithValue("@industry_accID", industryAccID);
                cmd.Parameters.AddWithValue("@jobTitle", jobTitle);
                cmd.Parameters.AddWithValue("@industryName", industryName);
                cmd.Parameters.AddWithValue("@jobType", jobType);
                cmd.Parameters.AddWithValue("@jobCourse", jobCourse);
                cmd.Parameters.AddWithValue("@jobLocation", jobLocation);
                cmd.Parameters.AddWithValue("@jobDescription", jobDescription);
                cmd.Parameters.AddWithValue("@jobQualifications", jobQualification);
                cmd.Parameters.AddWithValue("@applicationInstruction", jobInstruction);
                cmd.Parameters.AddWithValue("@salary", salaryRange);
                cmd.Parameters.AddWithValue("@isActive", isActiveJob);
                cmd.Parameters.AddWithValue("@jobPostedDate", DateTime.Now);
                var ctr = cmd.ExecuteNonQuery();

                if (ctr > 0)
                {

                   cmd = new SqlCommand("INSERT INTO NOTIFICATION (industry_accID, type, " +
                   "title, description, dateCreated, isRead, isRemove)" +
                   "VALUES(@industry_accID,@type, @title, @description," +
                   "@dateCreated,@isRead,@isRemove)", conDB);
                    cmd.Parameters.AddWithValue("@industry_accID", industryAccID);
                    cmd.Parameters.AddWithValue("@type", jobType);
                    cmd.Parameters.AddWithValue("@title", jobTitle);
                    cmd.Parameters.AddWithValue("@description", jobDescription);
                    cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@isRead", 0);
                    cmd.Parameters.AddWithValue("@isRemove", 0);
                    ctr =  cmd.ExecuteNonQuery();
                    if(ctr > 0)
                    {
                       Response.Write("<script>alert('The job has been posted successfully.');document.location='IndustryJobPosted.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Cannot post a job now! Please try again later.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Cannot post a job now! Please try again later.')</script>");
                }
            }
            conDB.Close();
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }
       /* void jobPostNotify(int industryAccID)
        {
           
        }*/
    /* void Clear()
     {
         JobTitle.Text = string.Empty;
         jobtype.Value = "";
         course.Value = "";
         jobDescript.Text = string.Empty;
         jobQuali.Text = string.Empty;
         jobInstruct.Text = string.Empty;
         salary.Text = string.Empty;

     }*/
    }
}