using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class LoginIndustry : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] != null)
            {
                Response.Redirect("IndustryDashboard.aspx");
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
                    LoginErrorMessage.Visible = false;
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
                        string query = "SELECT COUNT(1) FROM INDUSTRY_ACCOUNT WHERE Email=@Email AND Password=@Password AND isDeactivated=@isDeactivated";
                        using (SqlCommand command = new SqlCommand(query, conDB2))
                        {
                            command.Parameters.AddWithValue("@Email", loginEmail);
                            command.Parameters.AddWithValue("@Password", loginPassword);
                            command.Parameters.AddWithValue("@isDeactivated", false);
                            int count = Convert.ToInt32(command.ExecuteScalar());
                            if (count == 1)
                            {
                                // User is authenticated, retrieve industry information
                                getIndustryInfo();
                                Session["IndustryEmail"] = txtemail.Text;
                                Response.Redirect("IndustryDashboard.aspx");
                            }
                            else
                            {
                                // Check if the account is deactivated
                                command.Parameters.Clear();
                                command.CommandText = "SELECT COUNT(1) FROM INDUSTRY_ACCOUNT WHERE Email=@Email AND isDeactivated=@isDeactivated";
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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                txtpwd.TextMode = TextBoxMode.SingleLine;
                CheckBox1.Text = "Hide Password";
            }
        }

        void getIndustryInfo()
        {
            try
            {
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT * FROM INDUSTRY_ACCOUNT WHERE EMAIL = '" + getEmail + "' ";
                    using (SqlCommand command = new SqlCommand(query, conDB))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve industry information and store in session
                                Session["INDUSTRY_ACC_ID"] = reader["industry_accID"];
                                Session["INDUSTRYNAME"] = reader["industryName"];
                                Session["LOCATION"] = reader["location"];
                                Session["IndustryEmail"] = reader["email"];
                                Session["PASSWORD"] = reader["password"];
                                Session["MOU"] = reader["mou"];
                                Session["INDUSTRYPIC"] = reader["industryPicture"];
                                Session["DATEREG"] = reader["dateRegistered"];
                                Session["ISVerified"] = reader["isVerified"];
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

        // Helper method to show error messages
        private void ShowErrorMessage(string message)
        {
            LoginErrorMessage.Visible = true;
            LoginErrorMessage.Text = message;
        }
    }
}
