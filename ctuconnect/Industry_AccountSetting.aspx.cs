using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Industry_AccountSetting : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");

            }
            else
            {
                PasswordErrorMessage.Visible = false;
                NewpassErrorMessage.Visible = false;
            }
            if (!IsPostBack && Session["IndustryEmail"] != null)
            {
                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;
            }
            if (checkVerified())
            {
                verifiedIcon.Attributes.Add("title", "Verified");
                verifiedIcon.Attributes.Add("class", "fa fa-check-circle m-1 text-info");
            }
            else
            {
                verifiedIcon.Attributes.Add("title", "Unverified");
                verifiedIcon.Attributes.Add("class", "fa fa-check-circle m-1 text-danger");
            }
        }
        bool checkVerified()
        {
            int industry_accId = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select isVerified from INDUSTRY_ACCOUNT where industry_accID = @industry_accID", con);
            cmd.Parameters.AddWithValue("@industry_accID", industry_accId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["isVerified"] == DBNull.Value || bool.Parse(reader["isVerified"].ToString()) == false)
                {
                    reader.Close();
                    con.Close();
                    return false;

                }
                else
                {
                    reader.Close();
                    con.Close();
                    return true;
                }

            }
            reader.Close();
            con.Close();
            return false;
        }
        protected void BtnUpdatePass_Click(object sender, EventArgs e)
        {
            var newPass = Newpass.Text;
            var email = Session["IndustryEmail"].ToString();

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
                    using (SqlCommand command = new SqlCommand("UPDATE INDUSTRY_ACCOUNT SET password= @password WHERE email = @email;", con))
                    {
                        if (newPass != null)
                        {
                            command.Parameters.AddWithValue("password", newPass);
                            command.Parameters.AddWithValue("email", email);
                            command.ExecuteNonQuery();
                            Response.Write("<script>alert('Change password was successful!');document.location='Industry_AccountSetting.aspx'</script>");
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
            var email = Session["IndustryEmail"].ToString();

            using (conDB)
            {
                conDB.Open();
                var command = conDB.CreateCommand();
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM INDUSTRY_ACCOUNT WHERE email = '" + email + "' AND Password = '" + oldPass + "'";

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
        protected void Deactivate_Command(object sender, CommandEventArgs e)
        {
            string industry_accID = Session["INDUSTRY_ACC_ID"].ToString();

            conDB.Open();
            SqlCommand cmd = new SqlCommand("UPDATE INDUSTRY_ACCOUNT SET isDeactivated = 'true' where industry_accID = '" + industry_accID + "'", conDB);
            var ctr = cmd.ExecuteNonQuery();

            if (ctr > 0)
            {
                Response.Write("<script>alert('You successfully deactivated your account. Thank you for using our website.');document.location='LoginIndustry.aspx'</script>");
                Session.Clear(); // Clear all session variables
                Session.Abandon(); // Abandon the session
                Session.RemoveAll();
            }
            else
            {
                Response.Write("<script>alert('Cannot deactivate the account now! Please try again later.')</script>");
            }
            conDB.Close();

        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");
        }
    }
}