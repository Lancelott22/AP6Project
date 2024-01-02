using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Antlr.Runtime.Tree;
using System.Drawing;
using System.Net.Mail;
using System.Net;

namespace ctuconnect
{
    public partial class Dispute : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDispute();
            }
        }
        void BindDispute()
        {
            SqlCommand cmd = new SqlCommand("SELECT *, Convert(nvarchar, dateAdded, 1) as date_Added, Convert(nvarchar, decisionDate, 1) as decision_Date, case when isResolved = 1 then 'Resolved' when isResolved = 0 then 'Unresolved' else 'On process' end as disputeResolveStatus from DISPUTE JOIN INDUSTRY_ACCOUNT ON DISPUTE.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN STUDENT_ACCOUNT ON DISPUTE.student_accID = STUDENT_ACCOUNT.student_accID ORDER BY disputeID DESC", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            disputeListView.DataSource = ds;
            disputeListView.DataBind();
            if (disputeListView.Items.Count == 0)
            {
                ListViewPager.Visible = false;
            }
        }
        protected void statusBtn_Command(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showChangeStatus();", true);
            disputeID.Text = e.CommandArgument.ToString();
            changeError.Visible = false;
        }

        protected void blacklistBtn_Command(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showBlackList();", true);
            blacklist_ID.Text = e.CommandArgument.ToString();
            BlackList_IndustryName.InnerText = e.CommandName.ToString();
            errorText.Visible = false;
            BlacklistReason.Value = string.Empty;
        }

        protected void ConfirmBlacklist_Command(object sender, CommandEventArgs e)
        {
            int industryID = int.Parse(blacklist_ID.Text);
            string industryName = BlackList_IndustryName.InnerText;
            string reason = BlacklistReason.Value;

            if (string.IsNullOrEmpty(BlacklistReason.Value))
            {
                errorText.Visible = true;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showBlackList();", true);
            }
            else
            {
                conDB.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO BLOCKLIST (industry_accID, industryName, reason, dateAdded) " +
                    "VALUES(@industry_accID, @industryName, @reason,@dateAdded)", conDB);
                cmd.Parameters.AddWithValue("@industry_accID", industryID);
                cmd.Parameters.AddWithValue("@industryName", industryName);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                int ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    string email = getIndustryEmail(industryID);
                    SendEmail(industryName, email, reason);
                    DeactivateAccount(industryID);
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully added the industry to blacklist.');document.location='Blacklist_Admin.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in adding the industry to blacklist.. Please try again later..');document.location='Dispute.aspx';", true);
                }
                conDB.Close();
            }
        }
        void DeactivateAccount(int industryID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE INDUSTRY_ACCOUNT SET isDeactivated = 'True' where industry_accID = '" + industryID + "'", conDB);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Dispute.aspx'</script>");
            }

        }
        string getIndustryEmail(int industryID)
        {
            SqlCommand cmd = new SqlCommand("Select email from INDUSTRY_ACCOUNT Where industry_accID = @industry_accID", conDB);
            cmd.Parameters.AddWithValue("@industry_accID", industryID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string industryEmail = reader["email"].ToString();
                reader.Close();
                return industryEmail;

            }
            reader.Close();
            return "";
        }
        private void SendEmail(string industryName, string email, string reason)
        {
            try
            { 
                string sendToEmail = email;
                string sendFrom = "ctuconnect00@gmail.com";
                string sendMessage = $"Dear <b>{industryName}</b>, <br/><br/>" +
                    $"Unfortunately, we regret to inform you that your account with CTU Connect has been blacklisted due to specific reasons.<br/>" +
                    $"Your account will be deactivated and you can no longer use it to sign in.<br/><br/>" +
                    $"Reason: {reason}<br/>" +
                    $"Date: {DateTime.Now}<br/><br/>" +
                    $"We appreciate your understanding in this matter and thank you for your cooperation.<br/><br/>" +
                    $"Best regards,<br/><br/>" +
                    $"<b>CTU Connect</b>";
                string subject = "Notification of Account Blacklisting";
                using (MailMessage mm = new MailMessage())
                {
                    mm.From = new MailAddress(sendFrom, "CTU Connect");
                    mm.To.Add(sendToEmail);
                    mm.Subject = subject;
                    mm.Body = sendMessage;
                    mm.IsBodyHtml = true;
                    mm.ReplyToList.Add(new MailAddress(sendFrom));
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = "ctuconnect00@gmail.com";
                        NetworkCred.Password = "diwvlfhaanwwfsid";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Dispute.aspx'</script>");
            }
        }
        protected void Save_Command(object sender, CommandEventArgs e)
        {
            
            int DisputeID = int.Parse(disputeID.Text);
            string status = StatusDDL.SelectedValue;
            string IsResolved = IsResolvedDLL.SelectedValue;
            
            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(IsResolved) || !DateTime.TryParse(DateDecided.Text, out _) || StatusDDL.SelectedValue == "Open" || IsResolvedDLL.SelectedValue == "-1")
            {
                changeError.Visible = true;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showChangeStatus();", true);
            }
            else
            {
                DateTime dateDecided = Convert.ToDateTime(DateDecided.Text);
                conDB.Open();
                SqlCommand cmd = new SqlCommand("UPDATE DISPUTE SET status = @status, isResolved = @isResolved, decisionDate = @decisionDate WHERE disputeID = '" + DisputeID + "'", conDB);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@isResolved", IsResolved);
                cmd.Parameters.AddWithValue("@decisionDate", dateDecided);
                int ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully save the changes.');document.location='Dispute.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong. Please try again later..');document.location='Dispute.aspx';", true);
                }
                conDB.Close();
            }
        }

        protected void disputeListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            LinkButton statusBTN = (LinkButton)e.Item.FindControl("statusBtn");
            LinkButton blacklistBTN = (LinkButton)e.Item.FindControl("blacklistBtn");
            Label DisputeID = e.Item.FindControl("disputeID") as Label;
            int dispute_ID = int.Parse(DisputeID.Text);
            if (checkStatusClose(dispute_ID))
            {
                statusBTN.Enabled = false;
            }
            if (checkStatusResolved(dispute_ID))
            {
                blacklistBTN.Enabled = false;
            }
        }
        bool checkStatusClose(int dispute_ID)
        {

            conDB.Open();
            SqlCommand cmd = new SqlCommand("SELECT status FROM DISPUTE WHERE disputeID = '"+ dispute_ID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["status"].ToString() == "Close")
                {
                    conDB.Close();
                    reader.Close();
                    return true;
                }
            }
            conDB.Close();
            reader.Close();
            return false;
        }
        bool checkStatusResolved(int dispute_ID)
        {

            conDB.Open();
            SqlCommand cmd = new SqlCommand("SELECT isResolved FROM DISPUTE WHERE disputeID = '" + dispute_ID + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["isResolved"] == DBNull.Value)
                {
                    conDB.Close();
                    reader.Close();
                    return true;
                }
                else if (bool.Parse(reader["isResolved"].ToString()) == false)
                {
                    conDB.Close();
                    reader.Close();
                    return false;
                }
            }
            conDB.Close();
            reader.Close();
            return true;
        }

        void SearchByIndustryName(string industry)
        {
            SqlCommand cmd = new SqlCommand("select *, Convert(nvarchar, dateAdded, 1) as date_Added, Convert(nvarchar, decisionDate, 1) as decision_Date, case when isResolved = 1 then 'Resolved' when isResolved = 0 then 'Unresolved' else 'On process' end as disputeResolveStatus from DISPUTE JOIN INDUSTRY_ACCOUNT ON DISPUTE.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN STUDENT_ACCOUNT ON DISPUTE.student_accID = STUDENT_ACCOUNT.student_accID WHERE (INDUSTRY_ACCOUNT.industryName LIKE '%" + industry + "%') ", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            disputeListView.DataSource = ds;
            disputeListView.DataBind();
        }
        protected void SearchIndustry_Click(object sender, EventArgs e)
        {
            string industry = IndustryName.Text;
            SearchByIndustryName(industry);
        }

        protected void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (Status.SelectedValue == "0")
            {
                Response.Redirect("Dispute.aspx");
            }
            else
            {
                cmd = new SqlCommand("select *, Convert(nvarchar, dateAdded, 1) as date_Added, Convert(nvarchar, decisionDate, 1) as decision_Date, case when isResolved = 1 then 'Resolved' when isResolved = 0 then 'Unresolved' else 'On process' end as disputeResolveStatus from DISPUTE JOIN INDUSTRY_ACCOUNT ON DISPUTE.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN STUDENT_ACCOUNT ON DISPUTE.student_accID = STUDENT_ACCOUNT.student_accID WHERE DISPUTE.status = '" + Status.SelectedValue + "' ", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            disputeListView.DataSource = ds;
            disputeListView.DataBind();
        }

        protected void Resolve_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (Status.SelectedValue == "-1")
            {
                Response.Redirect("Dispute.aspx");
            }
            else
            {
                cmd = new SqlCommand("select *, Convert(nvarchar, dateAdded, 1) as date_Added, Convert(nvarchar, decisionDate, 1) as decision_Date, case when isResolved = 1 then 'Resolved' when isResolved = 0 then 'Unresolved' else 'On process' end as disputeResolveStatus from DISPUTE JOIN INDUSTRY_ACCOUNT ON DISPUTE.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN STUDENT_ACCOUNT ON DISPUTE.student_accID = STUDENT_ACCOUNT.student_accID WHERE DISPUTE.isResolved = '" + Resolve.SelectedValue + "' ", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            disputeListView.DataSource = ds;
            disputeListView.DataBind();
        }

        protected void SearchByDate_Click(object sender, EventArgs e)
        {
            string dateAdded = txtdate.Text;
            SearchByDateAdded(dateAdded);
        }

        void SearchByDateAdded(string dateAdded)
        {
            SqlCommand cmd = new SqlCommand();

            if (string.IsNullOrEmpty(dateAdded))
            {
                Response.Redirect("Dispute.aspx");
            }
            else
            {
                cmd = new SqlCommand("select *, Convert(nvarchar, dateAdded, 1) as date_Added, Convert(nvarchar, decisionDate, 1) as decision_Date, case when isResolved = 1 then 'Resolved' when isResolved = 0 then 'Unresolved' else 'On process' end as disputeResolveStatus from DISPUTE JOIN INDUSTRY_ACCOUNT ON DISPUTE.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN STUDENT_ACCOUNT ON DISPUTE.student_accID = STUDENT_ACCOUNT.student_accID WHERE dateAdded = '" + dateAdded + "' ", conDB);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            disputeListView.DataSource = ds;
            disputeListView.DataBind();
        }

        protected void disputeListView_PagePropertiesChanged(object sender, EventArgs e)
        {
            BindDispute();
        }
    }
}