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
            if (!IsPostBack && Session["Email"] != null)
            {
                Response.Redirect("Home.aspx");
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
            try
            {

                string loginEmail = txtemail.Text;
                string loginPassword = txtpwd.Text;

                using (conDB)
                {
                    conDB.Open();

                    string query = "SELECT COUNT(1) FROM INDUSTRY_ACCOUNT WHERE email = @email AND password = @password";
                    SqlCommand command = new SqlCommand(query, conDB);
                    command.Parameters.AddWithValue("@email", loginEmail);
                    command.Parameters.AddWithValue("@password", loginPassword);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    Session["Email"] = txtemail.Text;
                    Response.Redirect("Home.aspx");
                    conDB.Close();
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

        void getAcc_ID()
        {
            try
            {
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT STUDENT_ACCID FROM STUDENT_ACCOUNT WHERE EMAIL = '" + getEmail + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["ACC_ID"] = reader["STUDENT_ACCID"];
                    }

                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>");
            }
        }

        void getFname()
        {
            try
            {
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT FIRSTNAME FROM STUDENT_ACCOUNT WHERE EMAIL = '" + getEmail + "' ";
                    SqlCommand command = new SqlCommand (query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["FNAME"] = reader["FIRSTNAME"];
                    }

                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>");
            }
        }
        void getMidInitial()
        {
            try
            {
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT MIDINITIALS FROM STUDENT_ACCOUNT WHERE EMAIL = '" + getEmail + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["INITIAL"] = reader["MIDINITIALS"];
                    }

                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>");
            }
        }

        void getLname()
        {
            try
            {
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT LASTNAME FROM STUDENT_ACCOUNT WHERE EMAIL = '" + getEmail + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["LNAME"] = reader["LASTNAME"];
                    }

                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>");
            }
        }

        void getStatus()
        {
            try
            {
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT STUDENTSTATUS FROM STUDENT_ACCOUNT WHERE EMAIL = '" + getEmail + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["STATUS"] = reader["STUDENTSTATUS"];
                    }

                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>");
            }
        }

        void getStudProfile()
        {
            try
            {
                string getEmail = txtemail.Text;
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT STUDENTPROFILE FROM STUDENT_ACCOUNT WHERE EMAIL = '" + getEmail + "' ";
                    SqlCommand command = new SqlCommand(query, conDB);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["PROFILE"] = reader["STUDENTPROFILE"];
                    }

                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='LoginStudent.aspx'</script>");
            }
        }
    }

    
}