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
    public partial class ReferralList_Admin : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTable();
        }
        void BindTable()
        {

            string query = "SELECT STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.midInitials,  INDUSTRY_ACCOUNT.industryName,   COORDINATOR_ACCOUNT.firstName + ' ' + COORDINATOR_ACCOUNT.lastName AS referredBy , REFERRAL.referralLetter, CONVERT(VARCHAR(10), REFERRAL.dateReferred, 120) AS dateReferred " +
            "FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
            "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
            "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID ORDER BY referralID DESC";
            SqlCommand cmd = new SqlCommand(query, conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater.DataSource = ds;
            dataRepeater.DataBind();

        }
        protected void ReviewLetter_Command(object sender, CommandEventArgs e)
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
                byte[] referralLetterFileData = GetEndorsementFileData(referralLetterFileName);


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
        private byte[] GetEndorsementFileData(string referralLetterFileName)
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
    }
}