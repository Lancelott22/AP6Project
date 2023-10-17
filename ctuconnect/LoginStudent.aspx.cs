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
    public partial class LoginStudent : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["StudentEmail"] != null)
            {
                Response.Redirect("MyAccount.aspx");
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

            string loginEmail = txtemail.Text;
                string loginPassword = txtpwd.Text;

                using (conDB2)
                {
                    conDB2.Open();

                    string query = "SELECT COUNT(1) FROM INDUSTRY_ACCOUNT WHERE email = @email AND password = @password";
                    SqlCommand command = new SqlCommand(query, conDB2);
                    command.Parameters.AddWithValue("@email", loginEmail);
                    command.Parameters.AddWithValue("@password", loginPassword);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                        getStudentInfo();
                        
                        }
                            Response.Write("<script>alert('Invalid Credentials')</script>");
                            conDB2.Close();
                            reader.Close();
                    }
                    Session["StudentEmail"] = txtemail.Text;
                    Response.Redirect("MyAccount.aspx");
                    
                }
            
                //Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>");
            
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                txtpwd.TextMode = TextBoxMode.SingleLine;
                CheckBox1.Text = "Hide Password";
            }
        }

        void getStudentInfo()
        {
            
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT * FROM STUDENT_ACCOUNT WHERE EMAIL = '" + getEmail + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Session["Student_ACC_ID"] = reader["student_accID"];
                    Session["STUDENT_ID"] = reader["studentId"];
                    Session["FNAME"] = reader["firstName"];
                    Session["INITIAL"] = reader["midInitials"];
                    Session["LNAME"] = reader["lastName"];
                    Session["STATUSorTYPE"] = reader["studentStatus"];
                    Session["Student_COURSE"] = reader["course_ID"];
                    Session["PROFILE"] = reader["studentPicture"];
                    Session["COR"] = reader["cor"];
                    Session["ResumeFile"] = reader["resumeFile"];
                    Session["StudentEmail"] = reader["email"];
                        Session["PASSWORD"] = reader["password"];
                        Session["DATEREG"] = reader["dateRegistered"];
                        Session["RESUMEFILE"] = reader["resumeFile"];
                }
                    conDB.Close();
                    reader.Close();
                }
                //Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>"); 
        }
    }

    
}