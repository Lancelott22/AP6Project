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
            SqlCommand cmd = new SqlCommand("SELECT *, Convert(nvarchar, dateAdded, 1) as date_Added from DISPUTE JOIN INDUSTRY_ACCOUNT ON DISPUTE.industry_accID = INDUSTRY_ACCOUNT.industry_accID JOIN STUDENT_ACCOUNT ON DISPUTE.student_accID = STUDENT_ACCOUNT.student_accID ORDER BY disputeID DESC", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            disputeListView.DataSource = ds;
            disputeListView.DataBind();
            if (disputeListView.Items.Count == 0)
            {
                /*ListViewPager.Visible = false;*/
            }
        }
        protected void statusBtn_Command(object sender, CommandEventArgs e)
        {

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
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertSuccess", "alert('You have successfully added the industry to blacklist.');document.location='Blacklist_Admin.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alertError", "alert('Sorry! There is something wrong in adding the industry to blacklist.. Please try again later..');document.location='Dispute.aspx';", true);
                }
                conDB.Close();
            }
        }
    }
}