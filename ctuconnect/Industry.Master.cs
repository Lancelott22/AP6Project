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
    public partial class Industry : System.Web.UI.MasterPage
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtApplicants = new DataTable();
        private DataTable dtReferred = new DataTable();
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["INDUSTRY_ACC_ID"] != null)
                {
                    string industryID = Session["INDUSTRY_ACC_ID"].ToString();
                    // Do something with the departmentID
                }
                int totalCounts = UnreadApplicantsCount() + UnreadReferredCount();
                lblUnreadCount.Text = totalCounts.ToString();

                this.LoadApplicants();
                rptapplicants.DataSource = dtApplicants;
                rptapplicants.DataBind();

                this.LoadReferred();
                rptreferred.DataSource = dtReferred;
                rptreferred.DataBind();

                refreshCounting();
                industryInfo();

                disableHeader();
                disableHeader2();
            }
        }

        void industryInfo()
        {
            if (!string.IsNullOrEmpty(Session["INDUSTRYPIC"].ToString()))
            {
                imageProfile.ImageUrl = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                profileimg.Src = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
            }
            else
            {
                imageProfile.ImageUrl = "~/images/IndustryProfile/defaultprofile.jpg";
                profileimg.Src = "~/images/IndustryProfile/defaultprofile.jpg";
            }

            lblname.Text = Session["INDUSTRYNAME"].ToString();
        }

        void refreshCounting()
        {
            if (lblUnreadCount.Text == "0")
            {
                lblUnreadCount.Visible = false;
            }
            else
            {
                lblUnreadCount.Visible = true;
            }
        }

        void disableHeader()
        {
            
                if (rptapplicants.Items.Count == 0)
                {
                    // Find the headerTemplateContainer and set its Visible property to false
                    Control headerTemplateContainer = rptapplicants.Controls[0].Controls[0].FindControl("headerTemplateContainer");

                    if (headerTemplateContainer != null)
                    {
                        headerTemplateContainer.Visible = false;
                    }
                }       

        }

        void disableHeader2()
        {
            
                if (rptreferred.Items.Count == 0)
                {
                    // Find the headerTemplateContainer and set its Visible property to false
                    Control headerTemplateContainer2 = rptreferred.Controls[0].Controls[0].FindControl("headerTemplateContainer2");

                    if (headerTemplateContainer2 != null)
                    {
                        headerTemplateContainer2.Visible = false;
                    }
                }
         
            
        }

        private void LoadApplicants()
        {
            if (Session["INDUSTRY_ACC_ID"] != null)
            {
                string industryID = Session["INDUSTRY_ACC_ID"].ToString();


                using (var db = new SqlConnection(conDB))
                {
                    string query = "SELECT * FROM APPLICANT WHERE isRemove = 0 and industry_accID = '"+ industryID +"' ORDER BY dateApplied DESC";
                    SqlCommand cmd = new SqlCommand(query, db);

                    db.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtApplicants);
                }


                rptapplicants.DataSource = dtApplicants;
                rptapplicants.DataBind();
                disableHeader();
            }
            
        }

        private void LoadReferred()
        {
            if (Session["INDUSTRY_ACC_ID"] != null)
            {
                string industryID = Session["INDUSTRY_ACC_ID"].ToString();

                using (var db = new SqlConnection(conDB))
                {
                    string query = "SELECT * FROM REFERRAL WHERE isRemove = 0 and industry_accID = '" + industryID + "' ORDER BY dateReferred DESC";
                    SqlCommand cmd = new SqlCommand(query, db);

                    db.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtReferred);
                }

                rptreferred.DataSource = dtReferred;
                rptreferred.DataBind();
                disableHeader2();
            }
        }

        protected int UnreadApplicantsCount()
        {
            string industryID = Session["INDUSTRY_ACC_ID"].ToString();
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM APPLICANT WHERE isRead = 0 and industry_accID = '"+ industryID +"'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        protected int UnreadReferredCount()
        {
            string industryID = Session["INDUSTRY_ACC_ID"].ToString();

            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM REFERRAL WHERE isRead = 0 and industry_accID = '" + industryID + "'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }


        protected void readApplicants_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRead")
            {
                int applicantID = Convert.ToInt32(e.CommandArgument);

                MarkApplicantAsRead(applicantID);


            }
            // Refresh the notifications
            this.LoadApplicants();
            this.UnreadApplicantsCount();

        }


        private void MarkApplicantAsRead(int applicantID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE APPLICANT SET isRead = 1 WHERE applicantID = @ApplicantID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ApplicantID", applicantID);
                db.Open();
                cmd.ExecuteNonQuery();



                // Update the unread count
                int totalCounts = UnreadApplicantsCount() + UnreadReferredCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader();
            RedirectToApplicants(applicantID);


        }

        private void RedirectToApplicants(int applicantID)
        {
            Response.Redirect("Applicants.aspx?applicantID=" + applicantID);
        }

        private void ApplicantRead(int applicantID )
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE APPLICANT SET isRead = 1 WHERE applicantID = @ApplicantID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ApplicantID", applicantID);
                db.Open();
                cmd.ExecuteNonQuery();



                // Update the unread count
                int totalCounts = UnreadApplicantsCount() + UnreadReferredCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader();
        }

        protected void removeApplicants_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRemove")
            {
                int applicantID = Convert.ToInt32(e.CommandArgument);

                MarkApplicantAsRemoved(applicantID);
                ApplicantRead(applicantID);


            }

            // Refresh the notifications
            this.LoadApplicants();
            this.UnreadApplicantsCount();
        }
        private void MarkApplicantAsRemoved(int applicantID)
        {
            // Update the isRemove property in the database
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE APPLICANT SET isRemove = 1 WHERE applicantID = @ApplicantID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ApplicantID", applicantID);
                db.Open();
                cmd.ExecuteNonQuery();

                int totalCounts = UnreadApplicantsCount() + UnreadReferredCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //this.disableHeader();

            if (rptapplicants.Items.Count == 1)
            {
                disableHeader();
            }
        }


        protected void readReferred_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsReferredRead")
            {
                int referralID = Convert.ToInt32(e.CommandArgument);

                MarkReferredAsRead(referralID);

            }
            // Refresh
            this.LoadReferred();
            this.UnreadReferredCount();

        }


        private void MarkReferredAsRead(int referralID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REFERRAL SET isRead = 1 WHERE referralID = @ReferralID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ReferralID", referralID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadApplicantsCount() + UnreadReferredCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader2();
            RedirectToReferralList(referralID);


        }
        void RedirectToReferralList(int referralID)
        {
            Response.Redirect("ReferralList.aspx?referralID=" + referralID);
        }

        private void ReferredRead(int referralID)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REFERRAL SET isRead = 1 WHERE referralID = @ReferralID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ReferralID", referralID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadApplicantsCount() + UnreadReferredCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader2();
        }

        protected void removeReferred_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsReferredRemove")
            {
                int referralID = Convert.ToInt32(e.CommandArgument);

                MarkReferredAsRemoved(referralID);
                ReferredRead(referralID);

            }
            // Refresh the notifications
            this.LoadReferred();
            this.UnreadReferredCount();

        }


        private void MarkReferredAsRemoved(int referralID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REFERRAL SET isRemove = 1 WHERE referralID = @ReferralID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ReferralID", referralID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadApplicantsCount() + UnreadReferredCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //this.disableHeader2();

            if (rptreferred.Items.Count == 1)
            {
                disableHeader2();
            }

        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }
    }
}