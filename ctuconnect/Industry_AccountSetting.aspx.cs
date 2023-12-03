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
    public partial class Industry_AccountSetting : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
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
                BtnDelete.CausesValidation = false;
            }
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

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            var email = Session["IndustryEmail"].ToString();
            string confirmDelete = Request.Form["confirmValue"];
            if (confirmDelete == "yes")
            {
                using (conDB)
                {
                    conDB.Open();
                    var command = conDB.CreateCommand();
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "DELETE FROM COORDINATOR_ACCOUNT WHERE email = '" + email + "'";
                        var ctr = command.ExecuteNonQuery();
                        if (ctr > 0)
                        {

                            Session.RemoveAll();
                            Session.Clear();
                            Session.Abandon();
                            Response.Write("<script>alert('Account was deleted successfully!');document.location='LoginIndustry.aspx'</script>");
                        }
                    }
                    conDB.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Account deletion has been cancelled!');document.location='Industry_AccountSetting.aspx'</script>");

            }
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