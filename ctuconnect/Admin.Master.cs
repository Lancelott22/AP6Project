﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace ctuconnect
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtNotif = new DataTable();
        private DataTable dtRegistered = new DataTable();
        private DataTable dtSuggestion = new DataTable();
        private DataTable dtJobReport = new DataTable();
        private DataTable dtDispute = new DataTable();
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["AdminUsername"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {

                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();

                this.LoadNotification();
                rptjobposted.DataSource = dtNotif;
                rptjobposted.DataBind();

                this.LoadNewRegistered();
                rptnewregistered.DataSource = dtRegistered;
                rptnewregistered.DataBind();

                this.LoadSuggestion();
                rptsuggestions.DataSource = dtSuggestion;
                rptsuggestions.DataBind();

                this.LoadJobReport();
                rptjobreported.DataSource = dtJobReport;
                rptjobreported.DataBind();

                this.LoadDispute();
                rptdispute.DataSource = dtDispute;
                rptdispute.DataBind();


                refreshCounting();
                disableHeader();
                disableHeader2();
                disableHeader3();
                disableHeader4();
                disableHeader5();

            }

            
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
            if (rptjobposted.Items.Count == 0)
            {
                // Find the headerTemplateContainer and set its Visible property to false
                Control headerTemplateContainer = rptjobposted.Controls[0].Controls[0].FindControl("headerTemplateContainer");

                if (headerTemplateContainer != null)
                {
                    headerTemplateContainer.Visible = false;
                }
            }    
        }

        void disableHeader2()
        {
            if (rptnewregistered.Items.Count == 0)
            {
                // Find the headerTemplateContainer and set its Visible property to false
                Control headerTemplateContainer2 = rptnewregistered.Controls[0].Controls[0].FindControl("headerTemplateContainer2");

                if (headerTemplateContainer2 != null)
                {
                    headerTemplateContainer2.Visible = false;
                }
            }     
        }

        void disableHeader3()
        {
            if (rptsuggestions.Items.Count == 0)
            {
                // Find the headerTemplateContainer and set its Visible property to false
                Control headerTemplateContainer3 = rptsuggestions.Controls[0].Controls[0].FindControl("headerTemplateContainer3");

                if (headerTemplateContainer3 != null)
                {
                    headerTemplateContainer3.Visible = false;
                }
            }
        }

        void disableHeader4()
        {
            if (rptjobreported.Items.Count == 0)
            {
                // Find the headerTemplateContainer and set its Visible property to false
                Control headerTemplateContainer4 = rptjobreported.Controls[0].Controls[0].FindControl("headerTemplateContainer4");

                if (headerTemplateContainer4 != null)
                {
                    headerTemplateContainer4.Visible = false;
                }
            }
        }

        void disableHeader5()
        {

            if (rptdispute.Items.Count == 0)
            {
                // Find the headerTemplateContainer and set its Visible property to false
                Control headerTemplateContainer5 = rptdispute.Controls[0].Controls[0].FindControl("headerTemplateContainer5");

                if (headerTemplateContainer5 != null)
                {
                    headerTemplateContainer5.Visible = false;
                }
            }


        }

        private void LoadNotification()
        {

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM HIRING JOIN INDUSTRY_ACCOUNT ON HIRING.INDUSTRY_ACCID = INDUSTRY_ACCOUNT.INDUSTRY_ACCID WHERE HIRING.isRemove = 0 ORDER BY jobPostedDate DESC";
                SqlCommand cmd = new SqlCommand(query, db);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtNotif);

                
            }

            rptjobposted.DataSource = dtNotif;
            rptjobposted.DataBind();
            disableHeader();
        }

        private void LoadNewRegistered()
        {

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM INDUSTRY_ACCOUNT WHERE isRemove = 0 ORDER BY dateRegistered DESC";
                SqlCommand cmd = new SqlCommand(query, db);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtRegistered);

                
            }
            rptnewregistered.DataSource = dtRegistered;
            rptnewregistered.DataBind();
            disableHeader2();
        }

        private void LoadSuggestion()
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM SUGGESTIONS WHERE isRemove = 0 ORDER BY dateCreated DESC";
                SqlCommand cmd = new SqlCommand(query, db);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSuggestion);


            }
            rptsuggestions.DataSource = dtSuggestion;
            rptsuggestions.DataBind();
            disableHeader3();
        }

        private void LoadJobReport()
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM REPORT_JOB JOIN HIRING ON REPORT_JOB.jobID = HIRING.jobID WHERE REPORT_JOB.isRemove = 0 ORDER BY reportDate DESC";
                SqlCommand cmd = new SqlCommand(query, db);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtJobReport);


            }
            rptjobreported.DataSource = dtJobReport;
            rptjobreported.DataBind();
            disableHeader4();
        }

        private void LoadDispute()
        {
            
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM DISPUTE JOIN INDUSTRY_ACCOUNT ON DISPUTE.industry_accID = INDUSTRY_ACCOUNT.industry_accID WHERE DISPUTE.isRemove = 0 ORDER BY dateAdded DESC";
                SqlCommand cmd = new SqlCommand(query, db);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtDispute);
            }


            rptdispute.DataSource = dtDispute;
            rptdispute.DataBind();
            disableHeader5();


        }

        protected int UnreadNotificationCount()
        {
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM HIRING WHERE isRead = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
            
        }

        protected int UnreadRegisteredCount()
        {
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM INDUSTRY_ACCOUNT WHERE isRead = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        protected int UnreadSuggestionCount()
        {
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM SUGGESTIONS WHERE isRead = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        protected int UnreadReportCount()
        {
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM REPORT_JOB WHERE isRead = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        protected int UnreadDisputeCount()
        {
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM DISPUTE WHERE isRead = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }


        protected void readNotification_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRead")
            {
                int notificationID = Convert.ToInt32(e.CommandArgument);

                MarkNotificationAsRead(notificationID);
      
            }
            this.LoadNotification();
            this.UnreadNotificationCount();
            
            
        }

        
        private void MarkNotificationAsRead(int jobID)
        {
            
            using (var db = new SqlConnection(conDB))
            {
                
                string query = "UPDATE HIRING SET isRead = 1 WHERE jobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@JobID", jobID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader();
            RedirectToJobPosted(jobID);
        }

        
        private void RedirectToJobPosted(int jobID)
        {
            Response.Redirect("Admin_JobPosted.aspx?jobID=" + jobID);
        }
        

        private void NotificationRead(int jobID)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE HIRING SET isRead = 1 WHERE jobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@JobID", jobID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader();
        }

        protected void removeNotification_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRemove")
            {
                int jobID = Convert.ToInt32(e.CommandArgument);

                MarkNotificationAsRemoved(jobID);
                NotificationRead(jobID);
                
                
            }
            
            // Refresh the notifications
            this.LoadNotification();
            this.UnreadNotificationCount();
        }
        private void MarkNotificationAsRemoved(int jobID)
        {
            // Update the isRemove property in the database
            using (var db = new SqlConnection(conDB))
            {
                
                string query = "UPDATE HIRING SET isRemove = 1 WHERE jobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@JobID", jobID);
                db.Open();
                cmd.ExecuteNonQuery();

                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //disableHeader();

            if (rptjobposted.Items.Count == 1)
            {
                disableHeader();
            }
        }


        protected void readRegistered_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRegisteredRead")
            {
                int industryID = Convert.ToInt32(e.CommandArgument);

                MarkRegisteredAsRead(industryID);

            }
            // Refresh
            this.LoadNewRegistered();
            this.UnreadRegisteredCount();

        }


        private void MarkRegisteredAsRead(int industryID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE INDUSTRY_ACCOUNT SET isRead = 1 WHERE industry_accID = @IndustryID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@IndustryID", industryID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader2();
            RedirectToListOfIndustries(industryID);

        }

        
        void RedirectToListOfIndustries(int industryID)
        {
            Response.Redirect("ListOfIndustries_Alumni.aspx?industryID=" + industryID);
        }
        

        private void RegisteredRead(int industryID)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE INDUSTRY_ACCOUNT SET isRead = 1 WHERE industry_accID = @IndustryID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@IndustryID", industryID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader2();
        }

        protected void removeRegistered_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRegisteredRemove")
            {
                int industryID = Convert.ToInt32(e.CommandArgument);

                MarkRegisteredAsRemoved(industryID);
                RegisteredRead(industryID);

            }
            // Refresh the notifications
            this.LoadNewRegistered();
            this.UnreadRegisteredCount();

        }


        private void MarkRegisteredAsRemoved(int industryID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE INDUSTRY_ACCOUNT SET isRemove = 1 WHERE industry_accID = @IndustryID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@IndustryID", industryID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //disableHeader2();

            if (rptnewregistered.Items.Count == 1)
            {
                disableHeader2();
            }

        }

        protected void readSuggestion_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsSuggestionRead")
            {
                int suggestionID = Convert.ToInt32(e.CommandArgument);

                MarkSuggestionAsRead(suggestionID);

            }
            // Refresh
            this.LoadSuggestion();
            this.UnreadSuggestionCount();

        }

        private void MarkSuggestionAsRead(int suggestionID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE SUGGESTIONS SET isRead = 1 WHERE suggestionID = @SuggestionID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@SuggestionID", suggestionID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader3();
            RedirectToSuggestion(suggestionID);

        }

        
        void RedirectToSuggestion(int suggestionID)
        {
            Response.Redirect("SuggestionsAdmin.aspx?suggestionID=" + suggestionID);
        }
        

        private void SuggestionRead(int suggestionID)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE SUGGESTIONS SET isRead = 1 WHERE suggestionID = @SuggestionID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@SuggestionID", suggestionID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader3();
        }

        protected void removeSuggestion_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsSuggestionRemove")
            {
                int suggestionID = Convert.ToInt32(e.CommandArgument);

                MarkSuggestionAsRemoved(suggestionID);
                SuggestionRead(suggestionID);

            }
            // Refresh the notifications
            this.LoadSuggestion();
            this.UnreadSuggestionCount();

        }

        private void MarkSuggestionAsRemoved(int suggestionID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE SUGGESTIONS SET isRemove = 1 WHERE suggestionID = @SuggestionID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@SuggestionID", suggestionID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //disableHeader3();

            if (rptsuggestions.Items.Count == 1)
            {
                disableHeader3();
            }

        }

        protected void readReport_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsReportRead")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                MarkReportAsRead(id);

            }
            // Refresh
            this.LoadJobReport();
            this.UnreadReportCount();

        }

        private void MarkReportAsRead(int id)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REPORT_JOB SET isRead = 1 WHERE id = @ID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ID", id);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader4();
            RedirectToReport(id);

        }

        void RedirectToReport(int id)
        {
            Response.Redirect("Admin_JobPosted.aspx?suggestionID=" + id);
        }

        private void ReportRead(int id)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REPORT_JOB SET isRead = 1 WHERE id = @ID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ID", id);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader4();
        }

        protected void removeReport_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsReportRemove")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                MarkReportAsRemoved(id);
                ReportRead(id);

            }
            // Refresh the notifications
            this.LoadJobReport();
            this.UnreadReportCount();

        }

        private void MarkReportAsRemoved(int id)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REPORT_JOB SET isRemove = 1 WHERE id = @ID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ID", id);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //disableHeader3();

            if (rptjobreported.Items.Count == 1)
            {
                disableHeader4();
            }

        }

        protected void readDispute_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRead")
            {
                int disputeID = Convert.ToInt32(e.CommandArgument);

                MarkDisputeAsRead(disputeID);


            }
            // Refresh the notifications
            this.LoadDispute();
            this.UnreadDisputeCount();

        }

        private void MarkDisputeAsRead(int disputeID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE DISPUTE SET isRead = 1 WHERE disputeID = @DisputeID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@DisputeID", disputeID);
                db.Open();
                cmd.ExecuteNonQuery();



                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader5();
            RedirectToDispute(disputeID);


        }

        private void RedirectToDispute(int disputeID)
        {
            Response.Redirect("Dispute.aspx?disputeID=" + disputeID);
        }

        private void DisputeRead(int disputeID)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE DISPUTE SET isRead = 1 WHERE disputeID = @DisputeID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@DisputeID", disputeID);
                db.Open();
                cmd.ExecuteNonQuery();



                // Update the unread count
                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader5();
        }

        protected void removeDispute_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRemove")
            {
                int disputeID = Convert.ToInt32(e.CommandArgument);

                MarkDisputeAsRemoved(disputeID);
                DisputeRead(disputeID);


            }

            // Refresh the notifications
            this.LoadDispute();
            this.UnreadDisputeCount();
        }

        private void MarkDisputeAsRemoved(int disputeID)
        {
            // Update the isRemove property in the database
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE DISPUTE SET isRemove = 1 WHERE disputeID = @DisputeID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@DisputeID", disputeID);
                db.Open();
                cmd.ExecuteNonQuery();

                int totalCounts = UnreadNotificationCount() + UnreadRegisteredCount() + UnreadSuggestionCount() + UnreadReportCount() + UnreadDisputeCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //this.disableHeader();

            if (rptdispute.Items.Count == 1)
            {
                disableHeader5();
            }
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");

        }
    }
}