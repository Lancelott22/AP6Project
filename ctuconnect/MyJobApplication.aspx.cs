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
using System.Web.UI.HtmlControls;


namespace ctuconnect
{
    public partial class WebForm1 : System.Web.UI.Page
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
                myApplicationBind();
                myCurrentJobBind();
            }
            
        }
        void myApplicationBind()
        {
            int studentAccID = int.Parse(Session["Student_ACC_ID"].ToString());
            SqlCommand cmd = new SqlCommand("select * from APPLICANT JOIN INDUSTRY_ACCOUNT ON APPLICANT.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN HIRING ON APPLICANT.jobID = HIRING.jobID Where student_accID = @Student_accID ORDER BY dateApplied DESC", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            MyApplication.DataSource = ds;
            MyApplication.DataBind();
            if (MyApplication.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
        }
        bool checkResumeStatus(int applicantID, int jobId)
        {
            int studentAccID = int.Parse(Session["Student_ACC_ID"].ToString()); //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select resumeStatus from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string resumeStatus = reader["resumeStatus"].ToString();
                if (resumeStatus == "Reviewed")
                {
                    conDB.Close();
                    return true;
                }
                else if (resumeStatus == "Pending")
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
            int studentAccID = int.Parse(Session["Student_ACC_ID"].ToString()); //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select interviewStatus from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string interviewStatus = reader["interviewStatus"].ToString();
                if (interviewStatus == "Scheduled")
                {
                    conDB.Close();
                    return true;
                }
                else if (interviewStatus == "Pending")
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
            int studentAccID = int.Parse(Session["Student_ACC_ID"].ToString()); //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select applicantStatus from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string applicantStatus = reader["applicantStatus"].ToString();
                if (applicantStatus == "Approved" || applicantStatus == "Rejected")
                {
                    conDB.Close();
                    return true;
                }
                else if (applicantStatus == "Pending")
                {
                    conDB.Close();
                    return false;
                }
            }
            conDB.Close();
            return false;
        }
        protected void ViewApplication_Command(object sender, CommandEventArgs e)
        {
            int jobId = int.Parse(e.CommandName.ToString());
            int applicantID = int.Parse(e.CommandArgument.ToString());
            if (checkResumeStatus(applicantID, jobId) == true)
            {
                resumeStatusCheck.Text = "Your resume has been reviewed.";
                statusResume.Visible = true;
                statusResume.Attributes.Add("class", "statusStyle");
                statusResume.InnerText = "Reviewed";
                InterviewStatus.Visible = true;
                dateReviewed.Visible = true;
                dateReviewed.InnerText = getResumeDate(applicantID, jobId);
                if (checkInterviewStatus(applicantID, jobId) == true)
                {
                    StatusOrDetails.InnerText = "Interview Details: ";
                    statusInterview.InnerText = "Scheduled";
                    interviewStatusCheck.Text = showInterviewDetails(applicantID, jobId);
                    statusInterview.Visible = true;
                    statusInterview.Attributes.Add("class", "statusStyle");
                    dateScheduled.Visible = true;
                    interviewDate.Visible = true;
                }
                else
                {
                    interviewStatusCheck.Text = "Waiting for your interview schedule...";
                    statusInterview.Visible = true;
                    statusInterview.InnerText = "Pending";
                    statusInterview.Attributes.Add("class", "statusStylePending");
                    StatusOrDetails.InnerText = "Status: ";
                    dateScheduled.Visible = false;
                    interviewDate.Visible = false;
                }
            }
            else
            {
                statusResume.Visible = true;
                statusResume.InnerText = "Pending";
                statusResume.Attributes.Add("class", "statusStylePending");
                resumeStatusCheck.Text = "Waiting for your resume review status...";
                InterviewStatus.Visible = false;
                dateReviewed.Visible = false;
            }
            if ((checkInterviewStatus(applicantID, jobId) == true && checkResumeStatus(applicantID, jobId) == true))

            {
                applicantStatus.Visible = true;
                if (checkApplicantStatus(applicantID, jobId) == true)
                {
                    if (getApplicantStatus(applicantID, jobId) == "Approved")
                    {
                        statusApplication.InnerText = "Approved";
                        applicationStatusCheck.Text = "Congratulations! Your application has been approved.";
                        statusApplication.Visible = true;
                        statusApplication.Attributes.Add("class", "statusStyle");
                        requirementDetails.Visible = true;
                        dateStarted.Visible = true;
                        dateApproved.Visible = true;
                    }
                    else if (getApplicantStatus(applicantID, jobId) == "Rejected")
                    {
                        statusApplication.InnerText = "Rejected";
                        applicationStatusCheck.Text = "Sorry! Your application has been rejected.";
                        statusApplication.Visible = true;
                        statusApplication.Attributes.Add("class", "statusStyleReject");
                        dateApproved.Visible = true;
                    }

                }
                else
                {
                    requirementDetails.Visible = false;
                    dateStarted.Visible = false;
                    dateApproved.Visible = false;
                    applicationStatusCheck.Text = "Waiting for your application approval...";
                    statusApplication.Visible = true;
                    statusApplication.InnerText = "Pending";
                    statusApplication.Attributes.Add("class", "statusStylePending");

                }
            }
            else
            {
                applicantStatus.Visible = false;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "View", "viewApplication();", true);

            ListViewItem currentItem = (sender as Button).NamingContainer as ListViewItem;
            foreach (ListViewItem item in MyApplication.Items)
            {
                HtmlGenericControl myApplication = item.FindControl("myApplicationList") as HtmlGenericControl;
                if (currentItem.DataItemIndex == item.DataItemIndex)
                {
                    myApplication.Attributes["class"] = "row d-flex align-items-center jobBoxSelected";
                }
                else
                {
                    myApplication.Attributes["class"] = "row d-flex align-items-center jobAppliedBox";
                }
            }
        }
        string getApplicantStatus(int applicantID, int jobId)
        {
            int studentAccID = int.Parse(Session["Student_ACC_ID"].ToString()); //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select applicantStatus,  CONVERT(nvarchar,applicationApprovalDate, 1) as applicationApprovalDate,CONVERT(nvarchar,dateStart, 1) as dateStart,requirements from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string applicantStatus = reader["applicantStatus"].ToString();
                dateApproved.InnerText = reader["applicationApprovalDate"].ToString();
                requirementDetails.Text = "<br /><b>Details: </b><br />" + HttpUtility.HtmlDecode(reader["requirements"].ToString());
                dateStarted.Text = "<br /><b>Work Start Date: </b>" + reader["dateStart"].ToString();
                conDB.Close();
                return applicantStatus;
            }
            conDB.Close();
            return "";
        }
        string getResumeDate(int applicantID, int jobId)
        {
            int studentAccID = int.Parse(Session["Student_ACC_ID"].ToString()); //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select CONVERT(nvarchar,resumeReviewedDate, 1) as resumeReviewedDate  from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string dateReviewed = reader["resumeReviewedDate"].ToString();
                conDB.Close();
                return dateReviewed;
            }
            conDB.Close();
            return "";
        }
        string showInterviewDetails(int applicantID, int jobId)
        {
            string interviewDetail = "";
            int studentAccID = int.Parse(Session["Student_ACC_ID"].ToString()); //int.Parse(Sessios["student_accID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select interviewDetails,  CONVERT(nvarchar,interviewScheduledDate, 1) as interviewScheduledDate , CONVERT(nvarchar,interviewDate, 1)  as interviewDate from APPLICANT Where student_accID = @Student_accID and applicantID = @applicantId and jobID = @jobId", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            cmd.Parameters.AddWithValue("@applicantId", applicantID);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                interviewDetail = HttpUtility.HtmlDecode(reader["interviewDetails"].ToString());
                dateScheduled.Text = "<br /><b>Interview Date: </b>" + reader["interviewDate"].ToString();
                interviewDate.InnerText = reader["interviewScheduledDate"].ToString();
                conDB.Close();
                return interviewDetail;
            }
            conDB.Close();
            return interviewDetail;
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginStudent.aspx");

        }

        protected void MyApplication_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HtmlGenericControl dateApplied = (HtmlGenericControl)e.Item.FindControl("DateApplied");
            DateTime appliedDate = Convert.ToDateTime(dateApplied.InnerText);
            DateTime currentDate = DateTime.Now;
            TimeSpan timegap = currentDate - appliedDate;

            if (timegap.Days < 1)
            {
                HtmlGenericControl Badge = (HtmlGenericControl)e.Item.FindControl("badge");
                Badge.Visible = true;
                /* HtmlGenericControl myApplicationList = (HtmlGenericControl)e.Item.FindControl("myApplicationList");
                 myApplicationList.Style.Add("background-color", "#f0e789");*/
            }
        }

        protected void MyApplication_PagePropertiesChanged(object sender, EventArgs e)
        {
            myApplicationBind();
        }

        protected void HiredView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HtmlGenericControl dateHired = (HtmlGenericControl)e.Item.FindControl("DateHired");
            DateTime hiredDate = Convert.ToDateTime(dateHired.InnerText);
            DateTime currentDate = DateTime.Now;
            TimeSpan timegap = currentDate - hiredDate;

            if (timegap.Days < 1)
            {
                HtmlGenericControl Badge = (HtmlGenericControl)e.Item.FindControl("HiredBadge");
                Badge.Visible = true;
                /* HtmlGenericControl myApplicationList = (HtmlGenericControl)e.Item.FindControl("myApplicationList");
                 myApplicationList.Style.Add("background-color", "#f0e789");*/
            }
            HtmlGenericControl hiredID = (HtmlGenericControl)e.Item.FindControl("HiredID");
            int hired_Id = int.Parse(hiredID.InnerText);
            Button reqEval = (Button)e.Item.FindControl("RequestEval");
            Button viewEval = (Button)e.Item.FindControl("ViewEvaluation");
            if (checkStatusOngoing(hired_Id))
            {
                reqEval.Text = "Request Evaluation";
            }
            if (checkRequestedEval(hired_Id))
            {
                reqEval.Text = "Requested";
                reqEval.Enabled = false;
                reqEval.CssClass = "buttonStyle my-2";               
            }
            if(checkEvaluated(hired_Id))
            {
                reqEval.Text = "Evaluated";
                reqEval.Enabled = false;
                reqEval.CssClass = "buttonStyle my-2";
                viewEval.Enabled = true;
                viewEval.CssClass = "buttonStyle my-2";
            }
            else
            {
                viewEval.Enabled = false;
                viewEval.CssClass = "buttonStyle my-2";
            }

            if(checkIfAlumni(hired_Id))
            {
                viewEval.Visible = false;
                reqEval.Visible = false;
            }
        }
        bool checkIfAlumni(int hiredID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select * from HIRED_LIST WHERE id = @hiredID", conDB);
            cmd.Parameters.AddWithValue("@hiredID", hiredID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["studentType"].ToString() == "Alumni")
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }
            }
            reader.Close();
            conDB.Close();
            return false;
        }
        bool checkStatusOngoing(int hiredID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select * from HIRED_LIST WHERE id = @hiredID", conDB);
            cmd.Parameters.AddWithValue("@hiredID", hiredID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["internshipStatus"].ToString() == "Ongoing")
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }
            }
            reader.Close();
            conDB.Close();
            return false;
        }
        bool checkRequestedEval(int hiredID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select * from HIRED_LIST WHERE id = @hiredID", conDB);
            cmd.Parameters.AddWithValue("@hiredID", hiredID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["evaluationRequest"].ToString() == "Requested")
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }
            }
            reader.Close();
            conDB.Close();
            return false;
        }
        bool checkEvaluated(int hiredID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select * from HIRED_LIST WHERE id = @hiredID", conDB);
            cmd.Parameters.AddWithValue("@hiredID", hiredID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["evaluationRequest"].ToString() == "Evaluated")
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }
            }
            reader.Close();
            conDB.Close();
            return false;
        }
        void myCurrentJobBind()
        {
            int studentAccID = int.Parse(Session["Student_ACC_ID"].ToString());

            SqlCommand cmd = new SqlCommand("select * from HIRED_LIST JOIN INDUSTRY_ACCOUNT ON HIRED_LIST.industry_accID = INDUSTRY_ACCOUNT.industry_accID Where student_accID = @Student_accID ORDER BY dateHired DESC", conDB);
            cmd.Parameters.AddWithValue("@Student_accID", studentAccID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            MyJobView.DataSource = ds;
            MyJobView.DataBind();
            if (MyJobView.Items.Count == 0)
            {
                /* ListViewPager.Visible = false;*/
            }
        }
        protected void RequestEval_Command(object sender, CommandEventArgs e)
        {
            int hiredID = int.Parse(e.CommandArgument.ToString());
            if (checkStatusOngoing(hiredID))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('You cannot request now because your job is currently ongoing.');", true);

            }
            else
            {

                conDB.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HIRED_LIST SET evaluationRequest = 'Requested' WHERE id = @hiredID", conDB);
                cmd.Parameters.AddWithValue("@hiredID", hiredID);
                var ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('Your evaluation request has been sent successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Cannot request an evaluation right now! Please try again later.')", true);
                }
            }
        }

        protected void SwitchView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SwitchView.SelectedValue == "1")
            {
                MyJobApplicationView.Visible = true;
                MyJobHiredView.Visible = false;
            }
            else if (SwitchView.SelectedValue == "2")
            {
                MyJobApplicationView.Visible = false;
                MyJobHiredView.Visible = true;
            }
        }

        protected void ViewEvaluation_Command(object sender, CommandEventArgs e)
        {
            int student_accID = int.Parse(e.CommandArgument.ToString());
            int hiredID = int.Parse(e.CommandName.ToString());
            Response.Redirect("ViewEvaluation.aspx?student_accID=" + student_accID + "&hired_id=" + hiredID);
        }
    }
}