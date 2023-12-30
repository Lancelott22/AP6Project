using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace ctuconnect
{
    public partial class Coordinator_CreateAccount : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCoordinator();
                BindDepartment();
            }
               
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");

        }
        protected void UploadCoordinatorCSV_Click(object sender, EventArgs e)
        {
            try
            {
                HttpPostedFile coordinatorCSVFile = coordinatorCSV.PostedFile;
                string coordinatorCSVFileName = Path.GetFileName(coordinatorCSVFile.FileName);
                string coordinatorCSVFileEx = Path.GetExtension(coordinatorCSVFileName).ToLower();

                if (coordinatorCSVFileEx == ".csv")
                {
                    //Upload and save the file.
                    string coordinatorCSVFilePath = Server.MapPath("~/STUDENT CSV FILE/") + Path.GetFileName(coordinatorCSVFileName);
                    coordinatorCSV.SaveAs(coordinatorCSVFilePath);

                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[6] {              
                new DataColumn("firstName", typeof(string)),
                new DataColumn("midInitials", typeof(string)),
                new DataColumn("lastName", typeof(string)),                
                new DataColumn("username",typeof(string)),
                new DataColumn("password",typeof(string)),
                new DataColumn("department_ID", typeof(string))
                });

                    /*string csvData = File.ReadAllText(coordinatorCSVFilePath);
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
                    }*/

                    string csvData = File.ReadAllText(coordinatorCSVFilePath);
                    string[] rows = csvData.Split('\n');

                    for (int rowIndex = 1; rowIndex < rows.Length; rowIndex++)
                    {
                        string row = rows[rowIndex];

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

                    using (SqlBulkCopy sqlBulkCopy2 = new SqlBulkCopy(conDB))
                    {
                        //Set the database table name.
                        sqlBulkCopy2.DestinationTableName = "dbo.COORDINATOR_ACCOUNT";
                        //Mapping Table column   
                        sqlBulkCopy2.ColumnMappings.Add("firstName", "firstName");
                        sqlBulkCopy2.ColumnMappings.Add("midInitials", "midInitials");
                        sqlBulkCopy2.ColumnMappings.Add("lastName", "lastName");                       
                        sqlBulkCopy2.ColumnMappings.Add("username", "username");
                        sqlBulkCopy2.ColumnMappings.Add("password", "password");
                        sqlBulkCopy2.ColumnMappings.Add("department_ID", "department_ID");

                        conDB.Open();
                        sqlBulkCopy2.WriteToServer(dt);
                        sqlBulkCopy2.Close();
                        conDB.Close();
                        Response.Write("<script>alert('The file has been uploaded successfully.');document.location='Coordinator_CreateAccount.aspx';</script>");
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        string CoordinatorPassword = row["password"].ToString();
                        string Name = row["firstName"].ToString() + " " + row["lastName"].ToString();
                        string username = row["username"].ToString();
                        // Send email to each student
                        SendEmail(username, CoordinatorPassword, Name);
                    }
                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable! Must be .csv file.');document.location='Coordinator_CreateAccount.aspx';</script>");
                }
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('The csv is not in correct format. The number of columns is not consistent or the column names are missing or invalid. Or the user is already in the list or duplicated.');document.location='Coordinator_CreateAccount.aspx';</script>");
            }
        }

        private void SendEmail(string CoordinatorUsername, string CoordinatorPassword, string CoordinatorName)
        {
            try
            {
                string sendToEmail = CoordinatorUsername;
                string sendFrom = "ctuconnect00@gmail.com";
                string sendMessage = $"Hello {CoordinatorName}, <br/><br/>" +
                    $"Your account has been created by the Admin. You can now use it to sign in on CTU Connect as OJT Coordinator. Please change your default password to make your account secure.<br/><br/>" +
                    $"Your email is: {CoordinatorUsername} <br/>" +
                    $"Your password is: {CoordinatorPassword}<br/>" +
                    $"Date Created: {DateTime.Now}<br/>" +
                    $"<br/><br/><h4>Note: This is a confidential information. Please do not share this message to anyone.</h4>";
                string subject = "New Created Account";
                using (MailMessage mm = new MailMessage())
                {
                    mm.From = new MailAddress(sendFrom, "CTU Connect");
                    mm.To.Add(sendToEmail);
                    mm.Subject = subject;
                    mm.Body = sendMessage;
                    mm.IsBodyHtml = true;
                    mm.ReplyToList.Add(new MailAddress(sendFrom));
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = "ctuconnect00@gmail.com";
                        NetworkCred.Password = "diwvlfhaanwwfsid";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Coordinator_CreateAccount.aspx'</script>");
            }
        }

        void BindCoordinator()
        {           
                SqlCommand cmd = new SqlCommand("select *, CONCAT(firstName, ' ',lastName) as Name, CONVERT(nvarchar, dateRegistered,1) as dateReg FROM COORDINATOR_ACCOUNT JOIN DEPARTMENT ON COORDINATOR_ACCOUNT.department_ID = DEPARTMENT.department_ID", conDB);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                CoordinatorListView.DataSource = ds;
                CoordinatorListView.DataBind();
                if (CoordinatorListView.Items.Count == 0)
                {
                    /*  ListViewPager.Visible = false;*/
                }
        }

        protected void AddCoordinator_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showAddCoordinator();", true);
                addError.Visible = false;
                EmailError.Visible = false;
                CoordFirstName.Value = string.Empty;
                CoordMidInitial.Value = string.Empty;
                CoordLastName.Value = string.Empty;
                CoordEmail.Value = string.Empty;
                CoordPassword.Value = string.Empty;
                DepartmentID.SelectedValue = "0";
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Coordinator_CreateAccount.aspx'</script>");
            }
        }
        void BindDepartment()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DEPARTMENT", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            DepartmentID.DataSource = ds;
            DepartmentID.DataValueField = "department_ID";
            DepartmentID.DataTextField = "departmentName";
            DepartmentID.DataBind();
            DepartmentID.Items.Insert(0, new ListItem("Select Department", "0"));
        }

        protected void Save_Command(object sender, CommandEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(CoordFirstName.Value) || string.IsNullOrEmpty(CoordMidInitial.Value) || string.IsNullOrEmpty(CoordLastName.Value)
                    || string.IsNullOrEmpty(CoordEmail.Value) || string.IsNullOrEmpty(CoordPassword.Value) || DepartmentID.SelectedValue.Equals("0"))
                {
                    addError.Visible = true;
                    EmailError.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showAddCoordinator();", true);
                    return;
                }
                else if (checkCoordEmail(CoordEmail.Value))
                {              
                    EmailError.Visible = true;
                    addError.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showAddCoordinator();", true);
                    return;
                }
                else
                {
                   
                    string firstName = CoordFirstName.Value;
                    string midInit = CoordMidInitial.Value;
                    string lastName = CoordLastName.Value;  
                    string username = CoordEmail.Value;
                    string password = CoordPassword.Value;          
                    string departmentID = DepartmentID.SelectedValue;
                  
                    conDB.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO COORDINATOR_ACCOUNT (firstName, midInitials, lastName, username, password, department_ID) " +
                      "Values(@firstName, @midInitials, @lastName, @username, @password, @department_ID)", conDB);

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@midInitials", midInit);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@department_ID", departmentID);

                    int ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        string coordPassword = password;
                        string Name = firstName + " " + lastName;
                        string usernameEmail = username;
                        // Send email to each student
                        SendEmail(usernameEmail, coordPassword, Name);
                        Response.Write("<script>alert('OJT Coordinator account has been saved successfully.');document.location='Coordinator_CreateAccount.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('OJT Coordinator account has not been saved. Please try again later!');document.location='Coordinator_CreateAccount.aspx';</script>");
                    }
                    conDB.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Coordinator_CreateAccount.aspx'</script>");
            }
        }
        bool checkCoordEmail(string CoordEmail)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select username from COORDINATOR_ACCOUNT Where username = @username", conDB);
            cmd.Parameters.AddWithValue("@username", CoordEmail);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                conDB.Close();
                return true;
            }
            reader.Close();
            conDB.Close();
            return false;
        }
    }
}