using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Student_AccountSetting : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && Session["StudentEmail"] == null)
            {
                Response.Redirect("LoginStudent.aspx");

            }
            else
            {
                PasswordErrorMessage.Visible = false;
                NewpassErrorMessage.Visible = false;
            }
            hidden.Enabled = false;
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginStudent.aspx");
        }

        protected void BtnUpdatePass_Click(object sender, EventArgs e)
        {
            var newPass = Newpass.Text;
            var email = Session["StudentEmail"].ToString();

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
                    using (SqlCommand command = new SqlCommand("UPDATE STUDENT_ACCOUNT SET password= @password WHERE email = @email;", con))
                    {
                        if (newPass != null)
                        {
                            command.Parameters.AddWithValue("password", newPass);
                            command.Parameters.AddWithValue("email", email);
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
            var email = Session["StudentEmail"].ToString();

            using (conDB)
            {
                conDB.Open();
                var command = conDB.CreateCommand();
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM STUDENT_ACCOUNT WHERE email = '" + email + "' AND Password = '" + oldPass + "'";

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



        bool checkIsDeactivated(int studentID)
        {
            int selectedStudentID = studentID;
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select isDeactivated from STUDENT_ACCOUNT Where student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", selectedStudentID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (bool.Parse(reader["isDeactivated"].ToString()) == true)
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }

            }
            conDB.Close();
            return false;

        }

        protected void Deactivate_Command(object sender, CommandEventArgs e)
        {
            string deactivate = e.CommandName.ToString();
            int num = -1;
            int student_accID = int.Parse(e.CommandArgument.ToString());

            if (deactivate == "Activate")
            {
                num = 0;
            }
            else if (deactivate == "Deactivate")
            {
                num = 1;
            }
            conDB.Open();
            SqlCommand cmd = new SqlCommand("UPDATE STUDENT_ACCOUNT SET isDeactivated = '" + num + "' where student_accID = '" + student_accID + "'", conDB);
            var ctr = cmd.ExecuteNonQuery();

            if (ctr > 0)
            {
                Response.Write("<script>confirm('Confirm deactivate.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Cannot deactivate the account now! Please try again later.')</script>");
            }
            conDB.Close();
        }

        protected void DeactivateButton_Click(object sender, EventArgs e)
        {
            // Your deactivation logic here
            // You can use the hidden field or other means to confirm the deactivation

            // For example, you can set a flag in the database or perform any other necessary steps.
            // Once the deactivation is successful, you can redirect the user to the login page or any other page.

            // After deactivation, you might want to clear the session or log the user out.

            // Example:
            Session.Clear(); // Clear all session variables
            Session.Abandon(); // Abandon the session
            Response.Redirect("Login.aspx"); // Redirect to the login page
        }
    }
}