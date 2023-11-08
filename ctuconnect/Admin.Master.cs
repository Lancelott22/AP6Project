using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtNotif = new DataTable();
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUnreadCount.Text = UnreadNotificationCount().ToString();
                this.LoadNotification();
            }

        }

        private void LoadNotification()
        {

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM NOTIFICATION JOIN INDUSTRY_ACCOUNT ON NOTIFICATION.INDUSTRY_ACCID = INDUSTRY_ACCOUNT.INDUSTRY_ACCID";
                SqlCommand cmd = new SqlCommand(query, db);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtNotif);
            }

           
            r2.DataSource = dtNotif;
            r2.DataBind();
        }

        protected int UnreadNotificationCount()
        {
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM NOTIFICATION WHERE isRead = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        

    }
}