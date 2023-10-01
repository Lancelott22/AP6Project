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
            if (!IsPostBack && Session["Email"] != null)
            {
                Response.Redirect("homepage.aspx");
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

        protected void LogIn_Click(object sender, EventArgs e)
        {
            try
            {

                string loginEmail = txtemail.Text;
                string loginPassword = txtpwd.Text;

                using (SqlConnection dataBase = new SqlConnection())
                {
                    dataBase.Open();

                    string query = "SELECT COUNT(1) FROM INDUSTRY_ACCOUNT WHERE email = @email AND password = @password";
                    SqlCommand command = new SqlCommand(query, dataBase);
                    command.Parameters.AddWithValue("@email", loginEmail);
                    command.Parameters.AddWithValue("@password", loginPassword);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    Session["Email"] = txtemail.Text;
                    Response.Redirect("Home.aspx");
                    dataBase.Close();
                }
            }
            catch
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