﻿using System;
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
            string student_accID = Session["student_accID"].ToString();

            if (ConfirmDeactivation())
            {
                if (!string.IsNullOrEmpty(student_accID))
                {
                    using (conDB)
                    {
                        conDB.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE STUDENT_ACCOUNT SET isDeactivated=@isDeact WHERE student_accID=@student_accID;", conDB))
                        {
                            if (int.TryParse(Session["student_accID"].ToString(), out int Student_accID))
                            {
                                cmd.Parameters.AddWithValue("@student_accID", Student_accID);
                                cmd.Parameters.AddWithValue("@isDeactivated", true);
                                var ctr = cmd.ExecuteNonQuery();

                                if (ctr > 0)
                                {
                                    Response.Write("<script>confirm('Confirm deactivate.');</script>");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Cannot deactivate the account now! Please try again later.')</script>");
                                }

                            }
                            conDB.Close();
                        }
                           
                    }
                    Session.Clear(); // Clear all session variables
                    Session.Abandon(); // Abandon the session
                    Response.Redirect("Login.aspx"); // Redirect to the login page
                }
                else
                {
                    Response.Write("<script>alert('No student acc detected')</script>");
                }
            }
            
            
        }
        private bool ConfirmDeactivation()
        {
            // You can place any additional server-side confirmation logic here
            return true; // Return true if you want to proceed with deactivation
        }
    }
}