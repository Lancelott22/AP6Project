using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface
{
    public partial class Coordinator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create an empty DataTable
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("studentID", typeof(int));
                dataTable.Columns.Add("lastName", typeof(string));
                dataTable.Columns.Add("firstName", typeof(string));
                dataTable.Columns.Add("course", typeof(string));
                dataTable.Columns.Add("workedAt", typeof(string));
                dataTable.Columns.Add("dateStarted", typeof(string));
                dataTable.Columns.Add("internshipStatus", typeof(string));

                // Add some sample data rows

                dataTable.Rows.Add(1202200, "Paderna", "John Ryan", "BSIT","Accenture.Inc", "07/13/2023", "on internship");

                // Bind the empty DataTable to the GridView
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }
       
    }
}