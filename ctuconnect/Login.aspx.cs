using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] != null)
            {
                Response.Redirect("AdminDashboard.aspx");
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

        protected void LogIn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

            try
            {
                string loginUser = txtusername.Text;
                string loginPassword = txtpwd.Text;

                if (!string.IsNullOrEmpty(loginUser) && !string.IsNullOrEmpty(loginPassword))
                {
                    using (con)
                    {
                        con.Open();

                        string query = "SELECT COUNT(1) FROM ADMIN_ACCOUNT WHERE username = @username AND password = @password";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@username", loginUser);
                            command.Parameters.AddWithValue("@password", loginPassword);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count > 0)
                            {
                                // Valid credentials
                                Session["Username"] = txtusername.Text;
                                Response.Redirect("AdminDashboard.aspx");
                            }
                            else
                            {
                                // Invalid credentials
                                LoginErrorMessage.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Login.aspx'</script>");
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
    }
}