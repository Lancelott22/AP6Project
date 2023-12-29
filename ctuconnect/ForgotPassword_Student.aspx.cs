using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class ForgotPassword_Student : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        private bool IsStudentIDValid(string studentID)
        {

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM STUDENT_ACCOUNT WHERE studentId = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    int count = (int)command.ExecuteScalar();

                    // If the count is greater than 0, the student ID exists
                    return count > 0;
                }
            }
        }

        protected void txtstudentID_TextChanged(object sender, EventArgs e)
        {

            string studentID = txtstudentID.Text.Trim();
            if (IsNumeric(studentID))
            {
                bool isValidStudentID = IsStudentIDValid(studentID);

                lblErrorMessage.Text = isValidStudentID ? "" : "Student ID is invalid or doesn't exist";
            }
            else
            {
                lblErrorMessage.Text = "Please enter a numeric Student ID.";
            }

        }

        private bool IsNumeric(string value)
        {
            int result;
            return int.TryParse(value, out result);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtstudentID.Text.Trim();
                bool isValidStudentID = IsStudentIDValid(studentID);

                if (!isValidStudentID)
                {
                    Response.Write("<script>alert('Student ID is invalid or doesn't exist');</script>");
                    return;
                }
                else
                {
                    int studID = Convert.ToInt32(txtstudentID.Text);
                    using (SqlConnection connection = new SqlConnection(conDB))
                    {
                        connection.Open();
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = "SELECT * FROM STUDENT_ACCOUNT WHERE studentId = @StudentID";
                            command.Parameters.AddWithValue("@StudentID", studID);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {

                                    string personalEmail = reader["personalEmail"].ToString();
                                    string email = reader["email"].ToString();
                                    string password = reader["password"].ToString();
                                    string name = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                                    reader.Close();

                                    string sendToEmail = personalEmail;
                                    string sendFrom = "ctuconnect00@gmail.com";
                                    string sendMessage = $"Hello {name}, <br/><br/>" +
                                        $"Your email is: {email} <br/>" +
                                        $"Your password is: {password}<br/>" +
                                        $"<br/><br/><h4>Note: This is a confidential information. Please do not share this message to anyone.</h4>";
                                    string subject = "Forgot password";
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

                                        Response.Write("<script>alert('Submitted successfully. Check your email for your account details.');document.location='LoginStudent.aspx'</script>");
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('Student ID is invalid or doesn't exist');</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginStudent.aspx");
        }
    }
}