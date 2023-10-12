using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class HiredList : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //// Create an empty DataTable
                //DataTable dataTable = new DataTable();
                //dataTable.Columns.Add("ID", typeof(int));
                //dataTable.Columns.Add("LastName", typeof(string));
                //dataTable.Columns.Add("FirstName", typeof(string));
                //dataTable.Columns.Add("DateStarted", typeof(string));
                //dataTable.Columns.Add("Position", typeof(string));
                //dataTable.Columns.Add("Resume", typeof(string));


                //dataTable.Rows.Add(1, "Paderna", "John Ryan", "07/13/2023", "Software Developer", "--");
                //dataTable.Rows.Add(2, "Paderna", "John Ryan", "07/13/2023", "Software Developer", "--");
                //dataTable.Rows.Add(3, "Paderna", "John Ryan", "07/13/2023", "Software Developer", "--");
                //dataTable.Rows.Add(4, "Paderna", "John Ryan", "07/13/2023", "Software Developer", "--");

                //DataTable dataTable2 = new DataTable();
                //dataTable2.Columns.Add("ID", typeof(int));
                //dataTable2.Columns.Add("LastName", typeof(string));
                //dataTable2.Columns.Add("FirstName", typeof(string));
                //dataTable2.Columns.Add("DateStarted", typeof(string));
                //dataTable2.Columns.Add("InternshipStatus", typeof(string));
                //dataTable2.Columns.Add("RenderedHours", typeof(string));
                //dataTable2.Columns.Add("EvaluationRequest", typeof(string));

                //dataTable2.Rows.Add(1, "Guardiario", "Kenth Davis", "07/13/2023", "on internship", "--", "--");
                //dataTable2.Rows.Add(2, "Cruz", "Tiffany", "07/13/2023", "done", "120 hrs", "requested");


                //GridView2.DataSource = dataTable2;
                //GridView2.DataBind();

                //GridView1.DataSource = dataTable;
                //GridView1.DataBind();
                BindGridView1();
                BindGridView2();
            }
        }
        void BindGridView1()
        {
                    string query = "SELECT lastName, firstName, dateStarted, position, resumeFile FROM HIRED_LIST WHERE jobType = 'job'";
                SqlCommand cmd = new SqlCommand(query, conDB);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        // Bind the DataTable to the GridView
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    


                }
           
        
        void BindGridView2()
        {
             
            
                string query = "SELECT lastName, firstName, dateStarted, internshipStatus, renderedHours, evaluationRequest FROM HIRED_LIST WHERE jobType = 'internship'";
            SqlCommand cmd = new SqlCommand(query, conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the DataTable to the GridView
                GridView2.DataSource = ds;
                    GridView2.DataBind();
                
        }
            
        

        protected void btnSwitchGrid_Click1(object sender, EventArgs e)
        {
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton1.CssClass += " active";

            GridView1.Visible = true;
            GridView2.Visible = false;

            UpdatePanel1.Update();
        }
        protected void btnSwitchGrid_Click2(object sender, EventArgs e)
        {
            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("ID", typeof(int));
            //dataTable.Columns.Add("Name", typeof(string));
            //dataTable.Rows.Add(01783, "Robert");
            //dataTable.Rows.Add(0178903, "RYan");

            //GridView2.DataSource = dataTable;
            //GridView2.DataBind();
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton2.CssClass += " active";
            GridView1.Visible = false;
            GridView2.Visible = true;

            UpdatePanel1.Update();
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string InternshipStatus = DataBinder.Eval(e.Row.DataItem, "InternshipStatus").ToString();
                string EvaluationRequest = DataBinder.Eval(e.Row.DataItem, "EvaluationRequest").ToString();
                TableCell cell = e.Row.Cells[4];
                TableCell cell2 = e.Row.Cells[6];

                if (InternshipStatus == "on internship")
                {
                    cell.ForeColor = System.Drawing.Color.Green;
                }
                else if (InternshipStatus == "done")
                {
                    cell.ForeColor = System.Drawing.Color.Red;
                }
                if (EvaluationRequest == "requested")
                {
                    cell2.ForeColor = System.Drawing.Color.Red;
                }
                else if (EvaluationRequest == "--")
                {
                    cell2.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
    }
}