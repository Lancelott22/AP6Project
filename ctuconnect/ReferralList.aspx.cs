using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class ReferralList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create an empty DataTable
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ReferralID", typeof(int));
                dataTable.Columns.Add("LastName", typeof(string));
                dataTable.Columns.Add("FirstName", typeof(string));
                dataTable.Columns.Add("ReferredBy", typeof(string));
                dataTable.Columns.Add("DateReferred", typeof(string));
                dataTable.Columns.Add("Resume", typeof(string));


                dataTable.Rows.Add(089457896, "Paderna", "John Ryan", "Bell Campanilla", "07/13/2023", "view resume");

                GridView1.DataSource = dataTable;
                GridView1.DataBind();

            }
        }
    }
}