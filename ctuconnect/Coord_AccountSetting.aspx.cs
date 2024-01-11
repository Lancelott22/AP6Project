using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Coord_AccountSetting : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
            else
            {
                PasswordErrorMessage.Visible = false;
                NewpassErrorMessage.Visible = false;

                string imagePath = "~/images/OJTCoordinatorProfile/" + Session["Coord_Picture"].ToString();
                CoordinatorImage.ImageUrl = imagePath;
            }
        }


        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }




        protected void BtnUpdatePass_Click(object sender, EventArgs e)
        {

            var newPass = Newpass.Text;
            var username = Session["USERNAME"].ToString();

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
                    using (SqlCommand command = new SqlCommand("UPDATE COORDINATOR_ACCOUNT SET password= @password WHERE username = @username;", con))
                    {
                        if (newPass != null)
                        {
                            command.Parameters.AddWithValue("password", newPass);
                            command.Parameters.AddWithValue("username", username);
                            command.ExecuteNonQuery();
                            Response.Write("<script>alert('Change password was successful!');document.location='Coord_AccountSetting.aspx'</script>");
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
            var username = Session["Username"].ToString();

            using (conDB)
            {
                conDB.Open();
                var command = conDB.CreateCommand();
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM COORDINATOR_ACCOUNT WHERE Username = '" + username + "' AND Password = '" + oldPass + "'";

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

        /*  protected void Deactivate_Command(object sender, CommandEventArgs e)
          {
              string coordinator_accID = Session["Coor_ACC_ID"].ToString();

              conDB.Open();
              SqlCommand cmd = new SqlCommand("UPDATE COORDINATOR_ACCOUNT SET isDeactivated = 'true' where coordinator_accID = '" + coordinator_accID + "'", conDB);
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

          }*/

        protected void Deactivate_Command(object sender, CommandEventArgs e)
        {
            string coor_accID = Session["Coor_ACC_ID"].ToString();

            conDB.Open();
            SqlCommand cmd = new SqlCommand("UPDATE COORDINATOR_ACCOUNT SET isDeactivated = 'true' where coordinator_accID = '" + coor_accID + "'", conDB);
            var ctr = cmd.ExecuteNonQuery();

            if (ctr > 0)
            {
                Response.Write("<script>alert('You successfully deactivated your account. Thank you for using our website.');document.location='LoginOJTCoordinator.aspx'</script>");
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
    }
}