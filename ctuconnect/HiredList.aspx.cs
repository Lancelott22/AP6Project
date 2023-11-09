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
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");


            }
            if (!IsPostBack)
            {
                
                BindTable1();
                BindTable2();
                myLinkButton1.CssClass += " active";
                dataRepeater1.Visible = true;
                dataRepeater2.Visible = false;
            }
        }
        void BindTable1()
        {
                    string query = "SELECT lastName, firstName, dateStarted, position, resumeFile FROM HIRED_LIST WHERE jobType = 'job' ORDER BY id DESC";
                SqlCommand cmd = new SqlCommand(query, conDB);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        // Bind the DataTable to the GridView
                        dataRepeater1.DataSource = ds;
                        dataRepeater1.DataBind();
                    


                }
           
        
        void BindTable2()
        {
             
            
                string query = "SELECT lastName, firstName, position, CONVERT(VARCHAR(10), HIRED_LIST.dateHired, 120) AS dateHired, internshipStatus, renderedHours, evaluationRequest FROM HIRED_LIST WHERE jobType = 'internship' ORDER BY id DESC";
            SqlCommand cmd = new SqlCommand(query, conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the DataTable to the GridView
                dataRepeater2.DataSource = ds;
            dataRepeater2.DataBind();
                
        }
            
        

        protected void btnSwitchGrid_Click1(object sender, EventArgs e)
        {
            myLinkButton1.CssClass = "linkbutton";
            myLinkButton2.CssClass = "linkbutton";

            // Apply styles for the clicked button
            myLinkButton1.CssClass += " active";

            dataRepeater1.Visible = true;
            dataRepeater2.Visible = false;

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
            dataRepeater1.Visible = false;
            dataRepeater2.Visible = true;

            UpdatePanel1.Update();

        }
        protected void Evaluate_BtnClick(object sender, EventArgs e)
        {
            // Find the button that triggered the event
            Button EvaluationBtn = (Button)sender;

            // Check if the button's text is "Requested"
            if (EvaluationBtn.Text == "Requested")
            {
                // Redirect to another ASPX page
                Response.Redirect("Home.aspx");
            }
        }
        protected void ViewResume_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                /* Button btn = (Button)sender;
                 int studentID = Convert.ToInt32(btn.Attributes["data-studentid"]);
 */
                string ResumeFileName = e.CommandArgument.ToString();
                /*string endorsementLetterPath = Server.MapPath("~/images/EndorsementLetter" + endorsementLetterFileName);*/
                // Change the button text to "Reviewed"
                //Button button = (Button)sender;
                //button.Text = "Reviewed";


                // Retrieve and display the resume file
                byte[] ResumeFileData = GetResumeFileData(ResumeFileName);


                if (ResumeFileData != null)
                {
                    // Provide the file data for download in a new browser tab
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf"; // Set the appropriate content type
                    Response.AddHeader("content-disposition", "inline; filename=resume.pdf"); // Open in a new tab
                    Response.BinaryWrite(ResumeFileData);
                    Response.End();
                }
            }
        }
        private byte[] GetResumeFileData(string ResumeFileName)
        {
            using (conDB)
            {
                string query = "SELECT resumeFile FROM HIRED_LIST WHERE resumeFile = @ResumeFileName";
                SqlCommand cmd = new SqlCommand(query, conDB);
                cmd.Parameters.AddWithValue("@ResumeFileName", ResumeFileName);

                conDB.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Assuming that the result is a file path, read the file content
                    string fileName = result.ToString();
                    string filePath = "~/images/Resume/" + fileName; // Construct the path
                    byte[] fileData = System.IO.File.ReadAllBytes(Server.MapPath(filePath));
                    return fileData;
                }

                return null; // No file found
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }
        /*protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string InternshipStatus = DataBinder.Eval(e.Row.DataItem, "InternshipStatus").ToString();
                string EvaluationRequest = DataBinder.Eval(e.Row.DataItem, "EvaluationRequest").ToString();
                TableCell cell = e.Row.Cells[4];
                TableCell cell2 = e.Row.Cells[6];

                if (InternshipStatus == "ongoing")
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
        }*/
    }
}