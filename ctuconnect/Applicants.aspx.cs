using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Applicants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create an empty DataTable
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ApplicantID", typeof(int));
                dataTable.Columns.Add("Type", typeof(string));
                dataTable.Columns.Add("FirstName", typeof(string));
                dataTable.Columns.Add("LastName", typeof(string));
                dataTable.Columns.Add("DateApplied", typeof(string));
                dataTable.Columns.Add("Resume", typeof(string));
                dataTable.Columns.Add("RequirementsStatus", typeof(string));
                dataTable.Columns.Add("InterviewStatus", typeof(string));
                dataTable.Columns.Add("ApplicantStatus", typeof(string));

                // Add some sample data rows

                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");
                dataTable.Rows.Add(017845903, "Internship", "John Ryan", "Reynolds", "07/13/2023", "--", "--", "--", "--");

                // Bind the empty DataTable to the GridView
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string id = e.CommandArgument.ToString();
                // Perform edit operation for the item with the specified ID
                // You can access the item data using the ID and perform the desired logic
            }
        }
    }
}