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
using System.Net.Mail;
using System.Net;
using System.Web.Services.Description;

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
            if (!IsPostBack)
            {
                string imagePath = "~/images/OJTCoordinatorProfile/" + Session["Coord_Picture"].ToString();
                CoordinatorImage.ImageUrl = imagePath;
                BindDepartment();
                BindSemCode();
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
                new DataColumn("personalEmail", typeof(string)),
                new DataColumn("semCode", typeof(int)),
                new DataColumn("department_ID", typeof(int)),
                new DataColumn("course_ID", typeof(int))               
                });

                    /*string csvData = File.ReadAllText(studentCSVFilePath);
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

                    string csvData = File.ReadAllText(studentCSVFilePath);
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
                        sqlBulkCopy.ColumnMappings.Add("personalEmail", "personalEmail");
                        sqlBulkCopy.ColumnMappings.Add("semCode", "semCode");
                        sqlBulkCopy.ColumnMappings.Add("department_ID", "department_ID");
                        sqlBulkCopy.ColumnMappings.Add("course_ID", "course_ID");
                        
                        conDB.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        sqlBulkCopy.Close();
                        conDB.Close();
                        Response.Write("<script>alert('The file has been uploaded successfully.');document.location='CoordinatorProfile.aspx';</script>");
                                               
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        string studentEmail = row["personalEmail"].ToString();
                        string studentPassword = row["password"].ToString();
                        string Name = row["firstName"].ToString() + " " + row["lastName"].ToString();
                        string username = row["email"].ToString();
                        // Send email to each student
                        SendEmail(studentEmail, studentPassword, username, Name);
                    }

                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable! Must be .csv file.');document.location='Coordinator_UploadCSV.aspx';</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('The csv is not in correct format. The number of columns is not consistent or the column names are missing or invalid. Or the StudentID is already in the list or duplicated.');document.location='Coordinator_UploadCSV.aspx';</script>");
            }
        }

        private void SendEmail(string studentEmail, string password,string username, string studentName)
        {
            try
            {
                string sendToEmail = studentEmail;
                string sendFrom = "ctuconnect00@gmail.com";
                string sendMessage = $"Hello {studentName}, <br/><br/>" +
                    $"Your account has been created by your department OJT Coordinator. You can now use it to sign in on CTU Connect as Student/Intern. Please change your default password to make your account secure.<br/><br/>" +
                    $"Your email is: {username} <br/>" +
                    $"Your password is: {password}<br/>" +
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
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Coordinator_UploadCSV.aspx'</script>");
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
                    graduateCSV.SaveAs(graduateCSVFilePath);

                    DataTable dt1 = new DataTable();
                    dt1.Columns.AddRange(new DataColumn[7] {
                new DataColumn("studentID", typeof(int)),
                new DataColumn("firstName", typeof(string)),
                new DataColumn("midInitials", typeof(string)),
                new DataColumn("lastName", typeof(string)),
                new DataColumn("department",typeof(string)),
                new DataColumn("course",typeof(string)),
                new DataColumn("yearGraduated",typeof(string))
                });


                    /*string csvData = File.ReadAllText(graduateCSVFilePath);
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            dt1.Rows.Add();
                            int i = 0;
                            foreach (string cell in row.Split(','))
                            {
                                dt1.Rows[dt1.Rows.Count - 1][i] = cell;
                                i++;
                            }
                        }
                    }*/

                string csvData = File.ReadAllText(graduateCSVFilePath);
                string[] rows = csvData.Split('\n');

                for (int rowIndex = 1; rowIndex < rows.Length; rowIndex++)
                {
                    string row = rows[rowIndex];

                    if (!string.IsNullOrEmpty(row))
                    {
                        dt1.Rows.Add();
                        int i = 0;

                        foreach (string cell in row.Split(','))
                        {
                            dt1.Rows[dt1.Rows.Count - 1][i] = cell;
                            i++;
                        }
                    }
                }

                using (SqlBulkCopy sqlBulkCopy1 = new SqlBulkCopy(conDB))
                    {
                        //Set the database table name.
                        sqlBulkCopy1.DestinationTableName = "dbo.GRADUATES_TABLE";
                        //Mapping Table column    
                        sqlBulkCopy1.ColumnMappings.Add("studentID", "studentID");
                        sqlBulkCopy1.ColumnMappings.Add("firstName", "firstName");
                        sqlBulkCopy1.ColumnMappings.Add("midInitials", "midInitials");
                        sqlBulkCopy1.ColumnMappings.Add("lastName", "lastName");
                        sqlBulkCopy1.ColumnMappings.Add("department", "department");
                        sqlBulkCopy1.ColumnMappings.Add("course", "course");
                        sqlBulkCopy1.ColumnMappings.Add("yearGraduated", "yearGraduated");
                        conDB.Open();
                        sqlBulkCopy1.WriteToServer(dt1);
                        sqlBulkCopy1.Close();
                        conDB.Close();
                        Response.Write("<script>alert('The file has been uploaded successfully.');document.location='Coordinator_UploadCSV.aspx';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable! Must be .csv file.');document.location='Coordinator_UploadCSV.aspx';</script>");
                }
           }
            catch 
            {
                Response.Write("<script>alert('The csv is not in correct format. The number of columns is not consistent or the column names are missing or invalid. Or the StudentID is already in the list or duplicated.');document.location='Coordinator_UploadCSV.aspx';</script>");
            }
        }

        protected void AddIntern_Click(object sender, EventArgs e)
        {
            try
            {


                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showAddIntern();", true);
                addError.Visible = false;
                studentIdError.Visible = false;
                StudentID.Value = string.Empty;
                FirstName.Value = string.Empty;
                MidInitial.Value = string.Empty;
                LastName.Value = string.Empty;
                StudEmail.Value = string.Empty;
                StudPassword.Value = string.Empty;
                StudPersonalEmail.Value = string.Empty;
                Sem_Code.SelectedValue = "0";
                DepartmentID.SelectedValue = Session["DEPART"].ToString();
                BindCourse();
                CourseID.SelectedValue = "0";
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Coordinator_UploadCSV.aspx'</script>");
            }
        }

        protected void Save_Command(object sender, CommandEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(StudentID.Value) || string.IsNullOrEmpty(FirstName.Value) || string.IsNullOrEmpty(MidInitial.Value) || string.IsNullOrEmpty(LastName.Value)
                    || string.IsNullOrEmpty(StudEmail.Value) || string.IsNullOrEmpty(StudPassword.Value) || string.IsNullOrEmpty(StudPersonalEmail.Value) || Sem_Code.SelectedValue.Equals("0")
                    || DepartmentID.SelectedValue.Equals("0") || CourseID.SelectedValue.Equals("0"))
                {
                    addError.Visible = true;
                    studentIdError.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showAddIntern();", true);
                    return;
                }
                else if(checkStudentID(int.Parse(StudentID.Value)))
                {
                    studentIdError.Visible = true;
                    addError.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showAddIntern();", true);
                    return;
                }
                else
                {
                    int studentID = int.Parse(StudentID.Value);
                    string firstName = FirstName.Value;
                    string midInit = MidInitial.Value;
                    string lastName = LastName.Value;
                    string studentStats = StudentStatus.Value;
                    string username = StudEmail.Value;
                    string password = StudPassword.Value;
                    string personalEmail = StudPersonalEmail.Value;
                    string semCode = Sem_Code.SelectedValue;
                    string departmentID = DepartmentID.SelectedValue;
                    string courseID = CourseID.SelectedValue;

                    conDB.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT_ACCOUNT (studentId, firstName, midInitials, lastName, studentStatus, email, password, personalEmail, semCode, department_ID, course_ID) " +
                      "Values(@studentId, @firstName, @midInitials, @lastName, @studentStatus,  @email, @password, @personalEmail,@semCode, @department_ID, @course_ID)", conDB);

                    cmd.Parameters.AddWithValue("@studentId", studentID);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@midInitials", midInit);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@studentStatus", studentStats);
                    cmd.Parameters.AddWithValue("@email", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@personalEmail", personalEmail);
                    cmd.Parameters.AddWithValue("@semCode", semCode);
                    cmd.Parameters.AddWithValue("@department_ID", departmentID);
                    cmd.Parameters.AddWithValue("@course_ID", courseID);
                    int ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        string studentEmail = personalEmail;
                        string studentPassword = password;
                        string Name = firstName + " " + lastName;
                        string usernameEmail = username;
                        // Send email to each student
                        SendEmail(studentEmail, studentPassword, usernameEmail, Name);
                        Response.Write("<script>alert('Student account has been saved successfully.');document.location='CoordinatorProfile.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Student account has not been saved. Please try again later!');document.location='Coordinator_UploadCSV.aspx';</script>");
                    }
                    conDB.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Coordinator_UploadCSV.aspx'</script>");
            }
        }
        bool checkStudentID(int studentID)
        {
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select studentId from STUDENT_ACCOUNT Where studentId = @studentId", conDB);
            cmd.Parameters.AddWithValue("@studentId", studentID);
            
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
        void BindSemCode()
        {
            SqlCommand cmd = new SqlCommand("SELECT *, CONCAT(semDescription,' (',semCode,')') as sem_Description FROM ACADEMIC_YEAR", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Sem_Code.DataSource = ds;
            Sem_Code.DataValueField = "semCode";
            Sem_Code.DataTextField = "sem_Description";
            Sem_Code.DataBind();
            Sem_Code.Items.Insert(0, new ListItem("Select Semester Code", "0"));
        }
        protected void DepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCourse();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Popup1", "$('.modal-backdrop').removeClass('modal-backdrop');", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "showAddIntern();", true);
        }

        void BindCourse()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PROGRAM WHERE department_ID = '" + DepartmentID.SelectedValue + "'", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            CourseID.DataSource = ds;
            CourseID.DataValueField = "course_ID";
            CourseID.DataTextField = "course";
            CourseID.DataBind();
            CourseID.Items.Insert(0, new ListItem("Select Course", "0"));
        }
    }
}