using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class CSV_UPLOAD_FOR_STUDENT_ACCOUNT : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Upload(object sender, EventArgs e)
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
                    dt.Columns.AddRange(new DataColumn[7] {
                new DataColumn("studentID", typeof(int)),
                new DataColumn("firstName", typeof(string)),
                new DataColumn("lastName", typeof(string)),
                new DataColumn("studentStatus",typeof(string)),
                new DataColumn("email",typeof(string)),
                new DataColumn("password",typeof(string)),
                new DataColumn("dateRegistered", typeof(DateTime))});


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
                        sqlBulkCopy.ColumnMappings.Add("lastName", "lastName");
                        sqlBulkCopy.ColumnMappings.Add("studentStatus", "studentStatus");
                        sqlBulkCopy.ColumnMappings.Add("email", "email");
                        sqlBulkCopy.ColumnMappings.Add("password", "password");
                        sqlBulkCopy.ColumnMappings.Add("dateRegistered", "dateRegistered");

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
            catch {
                Response.Write("<script>alert('The csv is not in correct format. The number of columns is not consistent or the column names are missing or invalid.')</script>");
            }
            
        }
    }
}