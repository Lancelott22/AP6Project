using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class ReferralList : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");


            }
            else if (!IsPostBack)
            {
                BindGridView2();
                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;

            }

        }
        /*void BindGridView1()
        {
            string query = "SELECT REFERRAL.referralID, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, COORDINATOR_ACCOUNT.firstName + ' ' + COORDINATOR_ACCOUNT.lastName AS referredBy, REFERRAL.endorsementLetter, REFERRAL.dateReferred, STUDENT_ACCOUNT.resumeFile " +
                "FROM REFERRAL JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
                "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID";
            SqlCommand cmd = new SqlCommand(query, conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }*/
        void BindGridView2()
        {
            int industryID = Convert.ToInt32(Session["INDUSTRY_ACC_ID"]);
            string query = "SELECT REFERRAL.referralID, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.firstName, COORDINATOR_ACCOUNT.firstName + ' ' + COORDINATOR_ACCOUNT.lastName AS referredBy, REFERRAL.referralLetter, REFERRAL.dateReferred, STUDENT_ACCOUNT.resumeFile, REFERRAL.ReferralStatus, REFERRAL.student_accID " +
                "FROM REFERRAL JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
                "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
                "WHERE INDUSTRY_ACCOUNT.industry_accID = @industryID";
            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@industryID", industryID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater.DataSource = ds;
            dataRepeater.DataBind();

        }
        /*protected void ReviewLetter_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Review")
            {
                *//* Button btn = (Button)sender;
                 int studentID = Convert.ToInt32(btn.Attributes["data-studentid"]);
 *//*
                string referralLetterFileName = e.CommandArgument.ToString();
                *//*string endorsementLetterPath = Server.MapPath("~/images/EndorsementLetter" + endorsementLetterFileName);*//*
                // Change the button text to "Reviewed"
                //Button button = (Button)sender;
                //button.Text = "Reviewed";


                // Retrieve and display the resume file
                byte[] referralLetterFileData = GetReferralFileData(referralLetterFileName);


                if (referralLetterFileData != null)
                {
                    // Provide the file data for download in a new browser tab
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf"; // Set the appropriate content type
                    Response.AddHeader("content-disposition", "inline; filename=referralLetter.pdf"); // Open in a new tab
                    Response.BinaryWrite(referralLetterFileData);
                    Response.End();
                }
            }
        }*/
        private byte[] GetReferralFileData(string referralLetterFileName)
        {
            using (conDB)
            {
                string query = "SELECT referralLetter FROM REFERRAL WHERE referralLetter = @referralLetterFileName";
                SqlCommand cmd = new SqlCommand(query, conDB);
                cmd.Parameters.AddWithValue("@referralLetterFileName", referralLetterFileName);

                conDB.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Assuming that the result is a file path, read the file content
                    string fileName = result.ToString();
                    string filePath = "~/images/ReferralLetter/" + fileName; // Construct the path
                    byte[] fileData = System.IO.File.ReadAllBytes(Server.MapPath(filePath));
                    return fileData;
                }

                return null; // No file found
            }
        }
        protected string GetStatusCssClass(string status)
        {
            string cssClass = "default-status"; // Define a default CSS class

            if (status == "Pending")
            {
                cssClass = "status-pending";
            }
            else if (status == "Approved")
            {
                cssClass = "status-approved";
            }
            // Add more conditions for other status values.

            return cssClass;
        }
        protected void ViewApplicant_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Applicants.aspx?student_accID=" + e.CommandArgument.ToString());
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }

        protected void btnreferralLetterButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Review")
            {
                /* Button btn = (Button)sender;
                 int studentID = Convert.ToInt32(btn.Attributes["data-studentid"]);
 */
                string referralLetterFileName = e.CommandArgument.ToString();
                /*string endorsementLetterPath = Server.MapPath("~/images/EndorsementLetter" + endorsementLetterFileName);*/
                // Change the button text to "Reviewed"
                //Button button = (Button)sender;
                //button.Text = "Reviewed";


                // Retrieve and display the resume file
                byte[] referralLetterFileData = GetReferralFileData(referralLetterFileName);


                if (referralLetterFileData != null)
                {
                    // Provide the file data for download in a new browser tab
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf"; // Set the appropriate content type
                    Response.AddHeader("content-disposition", "inline; filename=referralLetter.pdf"); // Open in a new tab
                    Response.BinaryWrite(referralLetterFileData);
                    Response.End();
                }
            }
        }
    }
}