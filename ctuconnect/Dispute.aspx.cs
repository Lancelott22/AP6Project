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

        }
    }
}