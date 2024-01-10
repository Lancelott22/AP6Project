using System;
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
    public partial class ApplyJob : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["ChangePass"] == null)
            {
                ChangePasswordBox.Visible = false;
            }
            NewpassErrorMessage.Visible = false;

        }

        protected void BtnUpdatePass_Click(object sender, EventArgs e)
        {
            var newPass = Newpass.Text;
            var email = Request.QueryString["Email"].ToString();
            var usertype = Request.QueryString["UserType"].ToString();
            var accountID = Request.QueryString["account_ID"].ToString();

            if (checkNewPassword())
            {
                NewpassErrorMessage.Visible = true;
            }
            else
            {
                conDB.Open();
                SqlCommand cmd = new SqlCommand();
                if (usertype == "coordinator")
                {
                    cmd = new SqlCommand("UPDATE COORDINATOR_ACCOUNT SET password = @password, isFirstTimeLogin = 0 WHERE coordinator_accID = @account_ID", conDB);
                }
                else if (usertype == "student")
                {
                    cmd = new SqlCommand("UPDATE STUDENT_ACCOUNT SET password = @password, isFirstTimeLogin = 0 WHERE student_accID = @account_ID;", conDB);
                }               
                cmd.Parameters.AddWithValue("password", newPass);
                cmd.Parameters.AddWithValue("@account_ID", accountID);
                int ctr = cmd.ExecuteNonQuery();
                if(ctr > 0)
                {   
                    if (usertype == "coordinator")
                    {
                        Session["ChangePass"] = null;
                        Session["Username"] = email;
                        Response.Write("<script>alert('Your password has been updated successfully');document.location='CoordinatorProfile.aspx';</script>");                       
                    }
                    else if (usertype == "student")
                    {
                        Session["ChangePass"] = null;
                        Session["StudentEmail"] = email;
                        Response.Write("<script>alert('Your password has been updated successfully');document.location='JobPortal.aspx';</script>");                      
                    }
                 }
                else
                {
                    Response.Write("<script>alert('Something went wrong! Please try again later');</script>");
                }
                conDB.Close();
            }
        }
        bool checkNewPassword()
        {
            var newPass = Newpass.Text;
            var usertype = Request.QueryString["UserType"].ToString();
            var accountID = Request.QueryString["account_ID"].ToString();
            var currentPassword = "";

            conDB.Open();
            SqlCommand cmd = new SqlCommand();
            if (usertype == "coordinator")
            {
               cmd = new SqlCommand("select password from COORDINATOR_ACCOUNT where coordinator_accID = @account_ID", conDB);
            }
            else if (usertype == "student")
            {
               cmd = new SqlCommand("select password from STUDENT_ACCOUNT where student_accID = @account_ID", conDB);
            }
            
            cmd.Parameters.AddWithValue("@account_ID", accountID);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                currentPassword = reader["password"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Something went wrong! Please try again later');</script>");
            }
            reader.Close();
            conDB.Close();

            if (currentPassword == newPass)
            {
                return true;
            }
            return false;
        }
    }
}