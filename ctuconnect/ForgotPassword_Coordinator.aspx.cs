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
    public partial class ForgotPassword_Coordinator : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool IsEmailValid(string coordemail)
        {

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM COORDINATOR_ACCOUNT WHERE username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", coordemail);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {
            string coordemail = txtemail.Text.Trim();
            bool isValidEmail = IsEmailValid(coordemail);

            lblErrorMessage.Text = isValidEmail ? "" : "Email/Username is invalid or doesn't exist";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string coordEmail = txtemail.Text.Trim();
            bool isValidEmail = IsEmailValid(coordEmail);

            if (!isValidEmail)
            {
                Response.Write("<script>alert('Email/Username is invalid or doesn't exist');</script>");
                return;
            }
            else
            {
                string emailCoord = txtemail.Text;
                using (SqlConnection connection = new SqlConnection(conDB))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM COORDINATOR_ACCOUNT WHERE username = @Email";
                        command.Parameters.AddWithValue("@Email", emailCoord);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string email = reader["username"].ToString();
                                string password = reader["password"].ToString();
                                string name = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                                reader.Close();

                                string sendToEmail = email;
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

                                    Response.Write("<script>alert('Submitted successfully. Check your email for your account details.');document.location='LoginOJTCoordinator.aspx'</script>");
                                }

                            }
                        }
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginOJTCoordinator.aspx");
        }
    }
}