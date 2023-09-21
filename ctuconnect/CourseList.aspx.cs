using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface
{
    public partial class CourseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create an empty DataTable
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("No.", typeof(int));
                dataTable.Columns.Add("Department", typeof(string));
                dataTable.Columns.Add("Course", typeof(string));
                dataTable.Columns.Add("CourseName", typeof(string));
                dataTable.Columns.Add("Major", typeof(string));
                dataTable.Columns.Add("hours", typeof(string));

                // Add some sample data rows

                dataTable.Rows.Add(1, "COED", "BSED","Bachelor of Secondary Education", "Mathematics", "230 hours");
                dataTable.Rows.Add(2, "CCICT", "BSIT", "Bachelor of Science in Information Technology","--", "170 hours");

                // Bind the empty DataTable to the GridView
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }
    }
}