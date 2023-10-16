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
    public partial class LoginIndustry : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Email"] != null)
            {
                Response.Redirect("IndustryHome.aspx");
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
            SqlConnection conDB2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            try
            {

                string loginEmail = txtemail.Text;
                string loginPassword = txtpwd.Text;

                using (conDB2)
                {
                    conDB2.Open();

                    string query = "SELECT * FROM INDUSTRY_ACCOUNT WHERE email = @email AND password = @password";
                    SqlCommand command = new SqlCommand(query, conDB2);
                    command.Parameters.AddWithValue("@email", loginEmail);
                    command.Parameters.AddWithValue("@password", loginPassword);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            getIndustryInfo();
                        }
                        reader.Close();
                    }

                    Session["Email"] = txtemail.Text;
                    Response.Redirect("IndustryHome.aspx");
                    conDB2.Close();
                    
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginIndustry.aspx'</script>");
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
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["ACC_ID"] = reader["industry_accID"];
                        Session["INDUSTRYNAME"] = reader["industryName"];
                        Session["LOCATION"] = reader["location"];
                        Session["EMAIL"] = reader["email"];
                        Session["PASSWORD"] = reader["password"];
                        Session["MOU"] = reader["mou"];
                        Session["INDUSTRYPIC"] = reader["industryPicture"];
                        Session["DATEREG"] = reader["dateRegistered"];
                    }
                    conDB.Close();
                    reader.Close();
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginIndustry.aspx'</script>");
            }
        }

       
    }
}