using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace ctuconnect
{
    public partial class Coordinator_UploadCSV : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }

        protected void UploadInternCSV_Click(object sender, EventArgs e)
        {

            try
            {


                HttpPostedFile studentCSVFile = studentCSV.PostedFile;
                string studentCSVFileName = Path.GetFileName(studentCSVFile.FileName);
                string studentCSVFileEx = Path.GetExtension(studentCSVFileName).ToLower();

                if (studentCSVFileEx == ".csv")
                {
                    //Upload and save the file.
                    string studentCSVFilePath = Server.MapPath("~/STUDENT CSV FILE/") + Path.GetFileName(studentCSVFileName);
                    studentCSV.SaveAs(studentCSVFilePath);

                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[11] {
                new DataColumn("studentID", typeof(int)),
                new DataColumn("firstName", typeof(string)),
                new DataColumn("midInitials", typeof(string)),
                new DataColumn("lastName", typeof(string)),
                new DataColumn("studentStatus",typeof(string)),
                new DataColumn("email",typeof(string)),
                new DataColumn("password",typeof(string)),
                new DataColumn("dateRegistered", typeof(DateTime)),
                new DataColumn("department_ID", typeof(int)),
                new DataColumn("course_ID", typeof(int)),
                new DataColumn("personalEmail", typeof(string))
                });


                    string csvData = File.ReadAllText(studentCSVFilePath);
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (string cell in row.Split(','))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell;
                                i++;
                            }
                        }
                    }


                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conDB))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.STUDENT_ACCOUNT";
                        //Mapping Table column    
                        sqlBulkCopy.ColumnMappings.Add("studentID", "studentId");
                        sqlBulkCopy.ColumnMappings.Add("firstName", "firstName");
                        sqlBulkCopy.ColumnMappings.Add("midInitials", "midInitials");
                        sqlBulkCopy.ColumnMappings.Add("lastName", "lastName");
                        sqlBulkCopy.ColumnMappings.Add("studentStatus", "studentStatus");
                        sqlBulkCopy.ColumnMappings.Add("email", "email");
                        sqlBulkCopy.ColumnMappings.Add("password", "password");
                        sqlBulkCopy.ColumnMappings.Add("dateRegistered", "dateRegistered");
                        sqlBulkCopy.ColumnMappings.Add("department_ID", "department_ID");
                        sqlBulkCopy.ColumnMappings.Add("course_ID", "course_ID");
                        sqlBulkCopy.ColumnMappings.Add("personalEmail", "personalEmail");
                        conDB.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        conDB.Close();
                        Response.Write("<script>alert('The file has been uploaded successfully.')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable! Must be .csv file.')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('The csv is not in correct format. The number of columns is not consistent or the column names are missing or invalid. Or the StudentID is already in the list or duplicated.')</script>");
            }
        }

        protected void UploadGraduate_Click(object sender, EventArgs e)
        {
            try
            {


                HttpPostedFile graduateCSVFile = graduateCSV.PostedFile;
                string graduateCSVFileName = Path.GetFileName(graduateCSVFile.FileName);
                string graduateCSVFileEx = Path.GetExtension(graduateCSVFileName).ToLower();

                if (graduateCSVFileEx == ".csv")
                {
                    //Upload and save the file.
                    string graduateCSVFilePath = Server.MapPath("~/STUDENT CSV FILE/") + Path.GetFileName(graduateCSVFileName);
                    studentCSV.SaveAs(graduateCSVFilePath);

                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[7] {
                new DataColumn("studentID", typeof(int)),
                new DataColumn("firstName", typeof(string)),
                new DataColumn("midInitials", typeof(string)),
                new DataColumn("lastName", typeof(string)),
                new DataColumn("department",typeof(string)),
                new DataColumn("course",typeof(string)),
                new DataColumn("yearGraduated",typeof(string)),
               
                });


                    string csvData = File.ReadAllText(graduateCSVFilePath);
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (string cell in row.Split(','))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell;
                                i++;
                            }
                        }
                    }


                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conDB))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.GRADUATES_TABLE";
                        //Mapping Table column    
                        sqlBulkCopy.ColumnMappings.Add("studentID", "studentId");
                        sqlBulkCopy.ColumnMappings.Add("firstName", "firstName");
                        sqlBulkCopy.ColumnMappings.Add("midInitials", "midInitials");
                        sqlBulkCopy.ColumnMappings.Add("lastName", "lastName");
                        sqlBulkCopy.ColumnMappings.Add("department", "department");
                        sqlBulkCopy.ColumnMappings.Add("course", "course");
                        sqlBulkCopy.ColumnMappings.Add("yearGraduated", "yearGraduated");
                        conDB.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        conDB.Close();
                        Response.Write("<script>alert('The file has been uploaded successfully.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable! Must be .csv file.')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('The csv is not in correct format. The number of columns is not consistent or the column names are missing or invalid. Or the StudentID is already in the list or duplicated.')</script>");
            }
        }
    }
}