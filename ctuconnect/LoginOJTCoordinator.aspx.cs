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
    public partial class LoginOJTCoordinator : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] != null)
            {
                Response.Redirect("CoordinatorProfile.aspx");
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
            

                string loginUsername = txtusername.Text;
                string loginPassword = txtpwd.Text;

            if (!string.IsNullOrEmpty(loginUsername) && !string.IsNullOrEmpty(loginPassword))
            {
                using (conDB2)
                {
                    conDB2.Open();
                    string query = "SELECT COUNT(1) FROM COORDINATOR_ACCOUNT WHERE username=@Email AND password=@Password AND isDeactivated=@isDeactivated";
                    using (SqlCommand command = new SqlCommand(query, conDB2))
                    {
                        command.Parameters.AddWithValue("@Email", loginUsername);
                        command.Parameters.AddWithValue("@Password", loginPassword);
                        command.Parameters.AddWithValue("@isDeactivated", false);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 1)
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {

                                    getOJTCoordinatorInfo();

                                }
                                Response.Write("<script>alert('Invalid Credentials')</script>");
                                conDB2.Close();
                                reader.Close();
                            }
                            if(checkIsFirstTimeLogin(Session["Coor_ACC_ID"].ToString()))
                            {
                                Session["ChangePass"] = true;
                                var usertype = "coordinator";
                                Response.Redirect("ChangePasswordFirstTimeLogin.aspx?account_ID=" + Session["Coor_ACC_ID"].ToString() + "&Email=" + txtusername.Text + "&UserType=" + usertype);
                            }
                            else
                            {
                                Session["ChangePass"] = null;
                                Session["Username"] = txtusername.Text;
                                Response.Redirect("CoordinatorProfile.aspx");// User is authenticated, you can redirect to another page
                            }
                           
                            
                        }
                        else
                        {
                            // Check if the account is deactivated
                            command.Parameters.Clear();
                            command.CommandText = "SELECT COUNT(1) FROM COORDINATOR_ACCOUNT WHERE username=@Email AND isDeactivated=@isDeactivated";
                            command.Parameters.AddWithValue("@Email", loginUsername);
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

        bool checkIsFirstTimeLogin(string coordinator_accID)
        {

            SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            conDB.Open();
            SqlCommand cmd = new SqlCommand("select isFirstTimeLogin from COORDINATOR_ACCOUNT WHERE coordinator_accID = @coordinator_accID", conDB);
            cmd.Parameters.AddWithValue("@coordinator_accID", coordinator_accID);
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
                    string query = "SELECT * FROM COORDINATOR_ACCOUNT WHERE username = '" + getUsername + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["Coor_ACC_ID"] = reader["coordinator_accID"];
                        Session["Coord_FNAME"] = reader["firstName"];
                        Session["MIDNAME"] = reader["midInitials"];
                        Session["Coord_LNAME"] = reader["lastName"];
                        Session["DEPART"] = reader["department_ID"];
                        Session["USRNAME"] = reader["username"];
                        Session["PWD"] = reader["password"];
                        Session["Coord_Picture"] = reader["coordinatorPicture"];

                    }
                    reader.Close();
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginOJTCoordinator.aspx'</script>");
            }
        }
        private void ShowErrorMessage(string message)
        {
            LoginErrorMessage.Visible = true;
            LoginErrorMessage.Text = message;
        }
    }
}