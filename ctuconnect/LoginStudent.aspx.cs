﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class LoginStudent : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["StudentEmail"] != null)
            {
                Response.Redirect("JobPortal.aspx");
            }
            LoginErrorMessage.Visible = false;

            string passWord = txtpwd.Text;
            txtpwd.Attributes.Add("value", passWord);
            CheckBox1.Text = "Show Password";
            txtpwd.TextMode = TextBoxMode.Password;

            if (!IsPostBack)
            {
                if (Request.Cookies["Email"] != null && Request.Cookies["Password"] != null)
                {
                    txtemail.Text = Request.Cookies["Email"].Value;
                    txtpwd.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            

            try
            {
                string loginEmail = txtemail.Text;
                string loginPassword = txtpwd.Text;

                if (!string.IsNullOrEmpty(loginEmail) && !string.IsNullOrEmpty(loginPassword))
                {
                    using (SqlConnection conDB2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString))
                    {
                        conDB2.Open();
                        string query = "SELECT COUNT(1) FROM STUDENT_ACCOUNT WHERE Email=@Email AND Password=@Password AND isDeactivated=@isDeactivated";
                        using (SqlCommand command = new SqlCommand(query, conDB2))
                        {
                            command.Parameters.AddWithValue("@Email", loginEmail);
                            command.Parameters.AddWithValue("@Password", loginPassword);
                            command.Parameters.AddWithValue("@isDeactivated", false);
                            int count = Convert.ToInt32(command.ExecuteScalar());
                            if (count == 1)
                            {
                                // User is authenticated, retrieve student information
                                getStudentInfo();

                                if (checkStatusAndIsAnsweredAlumniForm(Session["STUDENT_ID"].ToString()))
                                {
                                    Session["StudentEmail"] = txtemail.Text;
                                    Response.Redirect("Alumni_Employment_Form.aspx");
                                }
                                else if(checkIsFirstTimeLogin(Session["Student_ACC_ID"].ToString()))
                                {
                                    Session["ChangePass"] = true;
                                    var usertype = "student";
                                    Response.Redirect("ChangePasswordFirstTimeLogin.aspx?account_ID=" + Session["Student_ACC_ID"].ToString() + "&Email=" + txtemail.Text + "&UserType=" + usertype);
                                }
                                else
                                {
                                    Session["ChangePass"] = null;
                                    Session["StudentEmail"] = txtemail.Text;
                                    Response.Redirect("JobPortal.aspx");
                                }
                            }
                            else
                            {
                                // Check if the account is deactivated
                                command.Parameters.Clear();
                                command.CommandText = "SELECT COUNT(1) FROM STUDENT_ACCOUNT WHERE Email=@Email AND isDeactivated=@isDeactivated";
                                command.Parameters.AddWithValue("@Email", loginEmail);
                                command.Parameters.AddWithValue("@isDeactivated", true);
                                int deactivatedCount = Convert.ToInt32(command.ExecuteScalar());

                                if (deactivatedCount == 1)
                                {
                                    // Account is deactivated
                                    ShowErrorMessage("Account deactivated. Contact support for assistance.");
                                }
                                else
                                {
                                    // Incorrect credentials
                                    ShowErrorMessage("The password or email is incorrect!");
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                ShowErrorMessage("Something went wrong! Please try again.");
            }

        }
        bool checkIsFirstTimeLogin(string student_accID)
        {

            SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select isFirstTimeLogin from STUDENT_ACCOUNT WHERE student_accID = @student_accID", conDB);
            cmd.Parameters.AddWithValue("@student_accID", student_accID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (bool.Parse(reader["isFirstTimeLogin"].ToString()) == true)
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }
            }
            reader.Close();
            conDB.Close();
            return false;
        }
        bool checkStatusAndIsAnsweredAlumniForm(string studentID)
        {
            SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            conDB.Open();
                SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT WHERE studentID = @studentID", conDB);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["studentStatus"].ToString() == "Alumni" && bool.Parse(reader["isAnsweredAlumniForm"].ToString()) == false)
                    {
                        reader.Close();
                        conDB.Close();
                        return true;
                    }
                }
                reader.Close();
                conDB.Close();
                return false;
         
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                txtpwd.TextMode = TextBoxMode.SingleLine;
                CheckBox1.Text = "Hide Password";
            }
        }

        void getStudentInfo()
        {
            
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT * FROM STUDENT_ACCOUNT JOIN PROGRAM ON STUDENT_ACCOUNT.COURSE_ID = PROGRAM.COURSE_ID WHERE EMAIL = '" + getEmail + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Session["Student_ACC_ID"] = reader["student_accID"];
                    Session["STUDENT_ID"] = reader["studentId"];
                    Session["FNAME"] = reader["firstName"];
                    Session["INITIAL"] = reader["midInitials"];
                    Session["LNAME"] = reader["lastName"];
                    Session["STATUSorTYPE"] = reader["studentStatus"];
                    Session["Student_COURSE"] = reader["course"];
                    Session["PROFILE"] = reader["studentPicture"];
                    Session["ResumeFile"] = reader["resumeFile"];
                        Session["PASSWORD"] = reader["password"];
                        Session["DATEREG"] = reader["dateRegistered"];
                    Session["IsAnswered"] = reader["isAnsweredAlumniForm"];
                }
                    conDB.Close();
                    reader.Close();
                }
                //Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>"); 
        }
        // Helper method to show error messages
        private void ShowErrorMessage(string message)
        {
            LoginErrorMessage.Visible = true;
            LoginErrorMessage.Text = message;
        }
    }

    
}