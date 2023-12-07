using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Coord_AccountSetting : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
            else
            {
                PasswordErrorMessage.Visible = false;
                NewpassErrorMessage.Visible = false;
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }




        protected void BtnUpdatePass_Click(object sender, EventArgs e)
        {

            var newPass = Newpass.Text;
            var username = Session["USERNAME"].ToString();

            if (!checkPassword())
            {
                PasswordErrorMessage.Visible = true;
            }
            else if (checkNewPassword())
            {
                NewpassErrorMessage.Visible = true;
            }
            else
            {
                using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE COORDINATOR_ACCOUNT SET password= @password WHERE username = @username;", con))
                    {
                        if (newPass != null)
                        {
                            command.Parameters.AddWithValue("password", newPass);
                            command.Parameters.AddWithValue("username", username);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            Response.Write("<script>alert('Change password was unsuccessful! Try again!')</script>");
                        }
                    }
                    con.Close();
                }

            }
        }
        bool checkPassword()
        {
            var oldPass = Oldpass.Text;
            var username = Session["Username"].ToString();

            using (conDB)
            {
                conDB.Open();
                var command = conDB.CreateCommand();
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM COORDINATOR_ACCOUNT WHERE Username = '" + username + "' AND Password = '" + oldPass + "'";

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Session["CurrentPass"] = reader["password"].ToString();
                        conDB.Close();
                        return true;
                    }
                    else
                    {
                        conDB.Close();
                        return false;
                    }
                }

            }
        }
        bool checkNewPassword()
        {
            var newPass = Newpass.Text;

            if (Session["CURRENTPASS"].ToString() == newPass)
            {
                return true;
            }
            return false;
        }

      /*  protected void Deactivate_Command(object sender, CommandEventArgs e)
        {
            string coordinator_accID = Session["Coor_ACC_ID"].ToString();

            conDB.Open();
            SqlCommand cmd = new SqlCommand("UPDATE COORDINATOR_ACCOUNT SET isDeactivated = 'true' where coordinator_accID = '" + coordinator_accID + "'", conDB);
            var ctr = cmd.ExecuteNonQuery();

            if (ctr > 0)
            {
                Response.Write("<script>alert('You successfully deactivated your account. Thank you for using our website.');document.location='LoginIndustry.aspx'</script>");
                Session.Clear(); // Clear all session variables
                Session.Abandon(); // Abandon the session
                Session.RemoveAll();
            }
            else
            {
                Response.Write("<script>alert('Cannot deactivate the account now! Please try again later.')</script>");
            }
            conDB.Close();

        }*/

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
                    dt.Columns.AddRange(new DataColumn[23] {
                new DataColumn("studentId", typeof(int)),
                new DataColumn("firstName", typeof(string)),
                new DataColumn("midInitials", typeof (string)),
                new DataColumn("lastName", typeof(string)),
                new DataColumn("studentStatus",typeof(string)),
                new DataColumn("department_ID", typeof (int)),
                new DataColumn("course_ID", typeof (int)),
                new DataColumn("studentPicture", typeof (string)),
                new DataColumn("cor", typeof (string)),
                new DataColumn("email",typeof(string)),
                new DataColumn("password",typeof(string)),
                new DataColumn("dateRegistered", typeof(DateTime)),
                new DataColumn("isVerified", typeof (bool)),
                new DataColumn("isDeactivated", typeof (bool)),
                new DataColumn("resumeFile", typeof (string)),
                new DataColumn("isHired", typeof (bool)),
                new DataColumn("contactNumber", typeof (string)),
                new DataColumn("address", typeof(string)),
                new DataColumn("yearGraduated", typeof (string)),
                new DataColumn("isGraduated", typeof (bool)),
                new DataColumn("isRead", typeof (bool)),
                new DataColumn("IsRemove", typeof (bool)),
                new DataColumn("isAnswered", typeof (bool))});


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
                        sqlBulkCopy.ColumnMappings.Add("studentId", "studentId");
                        sqlBulkCopy.ColumnMappings.Add("firstName", "firstName");
                        sqlBulkCopy.ColumnMappings.Add("midInitials", "midInitials");
                        sqlBulkCopy.ColumnMappings.Add("lastName", "lastName");
                        sqlBulkCopy.ColumnMappings.Add("department_ID", "department_ID");
                        sqlBulkCopy.ColumnMappings.Add("course_ID", "course_ID");
                        sqlBulkCopy.ColumnMappings.Add("studentPicture", "studentPicture");
                        sqlBulkCopy.ColumnMappings.Add("cor", "cor");
                        sqlBulkCopy.ColumnMappings.Add("email", "email");
                        sqlBulkCopy.ColumnMappings.Add("password", "password");
                        sqlBulkCopy.ColumnMappings.Add("dateRegistered", "dateRegistered");
                        sqlBulkCopy.ColumnMappings.Add("isVerified", "isVerified");
                        sqlBulkCopy.ColumnMappings.Add("isDeactivated", "isDeactivate");
                        sqlBulkCopy.ColumnMappings.Add("resumeFile", "isResume");
                        sqlBulkCopy.ColumnMappings.Add("isHired", "isHired");
                        sqlBulkCopy.ColumnMappings.Add("contactNumber", "contactNumber");
                        sqlBulkCopy.ColumnMappings.Add("personalEmail", "personalEmail");
                        sqlBulkCopy.ColumnMappings.Add("address", "address");
                        sqlBulkCopy.ColumnMappings.Add("yearGraduated", "yearGraduated");
                        sqlBulkCopy.ColumnMappings.Add("isGraduated", "isGraduated");
                        sqlBulkCopy.ColumnMappings.Add("isRead", "isRead");
                        sqlBulkCopy.ColumnMappings.Add("isRemove", "isRemove");
                        sqlBulkCopy.ColumnMappings.Add("isAnswered", "isAnswered");

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
                Response.Write("<script>alert('The csv is not in correct format. The number of columns is not consistent or the column names are missing or invalid.')</script>");
            }

        }








    }
}