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

        protected void DeactivateButton_Click(object sender, EventArgs e)
        {
          

            if (ConfirmDeactivation())
            {
                Deactivate();
            }
            
            
        }
        private void Deactivate()
        {
            string student_accID = Session["student_accID"].ToString();

            if (string.IsNullOrEmpty(student_accID))
            {
                // Handle the case where student_accID is missing or invalid
                Response.Write("<script>alert('Invalid or missing student_accID')</script>");
                return;
            }

            using (conDB)
            {
                conDB.Open();

                using (SqlCommand command = new SqlCommand("UPDATE STUDENT_ACCOUNT SET isDeactivated=@isDeact WHERE student_accID=@student_accID;", conDB))
                {
                    command.Parameters.AddWithValue("@student_accID", student_accID);
                    command.Parameters.AddWithValue("@isDeactivated", true); // Corrected parameter name
                    int ctr = command.ExecuteNonQuery();

                    // Additional code if needed after the update
                }
            }
            conDB.Close();
        }
        private bool ConfirmDeactivation()
        {
            // You can place any additional server-side confirmation logic here
            return true; // Return true if you want to proceed with deactivation
        }
    }
}