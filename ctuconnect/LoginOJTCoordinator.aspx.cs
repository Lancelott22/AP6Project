﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class LoginOJTCoordinator : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            LoginErrorMessage.Visible = false;

            string passWord = txtpwd.Text;
            txtpwd.Attributes.Add("value", passWord);
            CheckBox1.Text = "Show Password";
            txtpwd.TextMode = TextBoxMode.Password;

            if (!IsPostBack)
            {
                if (Request.Cookies["Username"] != null && Request.Cookies["Password"] != null)
                {
                    txtusername.Text = Request.Cookies["Username"].Value;
                    txtpwd.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            SqlConnection conDB2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            try
            {

                string loginUsername = txtusername.Text;
                string loginPassword = txtpwd.Text;

                using (conDB2)
                {
                    conDB2.Open();

                    string query = "SELECT COUNT(1) FROM INDUSTRY_ACCOUNT WHERE username = @username AND password = @password";
                    SqlCommand command = new SqlCommand(query, conDB2);
                    command.Parameters.AddWithValue("@email", loginUsername);
                    command.Parameters.AddWithValue("@password", loginPassword);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        getOJTCoordinatorInfo();
                    }

                    Session["Username"] = txtusername.Text;
                    Response.Redirect("Home.aspx");
                    conDB2.Close();
                    reader.Close();
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginOJTCoordinator.aspx'</script>");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                txtpwd.TextMode = TextBoxMode.SingleLine;
                CheckBox1.Text = "Hide Password";
            }
        }

        void getOJTCoordinatorInfo()
        {
            try
            {
                string getUsername = txtusername.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT * FROM COORDINATOR_ACCOUNT WHERE USERNAME = '" + getUsername + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["ACC_ID"] = reader["coordinator_accID"];
                        Session["FNAME"] = reader["firstNanme"];
                        Session["MIDNAME"] = reader["midInitials"];
                        Session["LNAME"] = reader["lastName"];
                        Session["DEPART"] = reader["department"];
                        Session["USRNAME"] = reader["username"];
                        Session["PWD"] = reader["password"];
                        
                    }
                    reader.Close();
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginOJTCoordinator.aspx'</script>");
            }
        }
    }
}