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
    public partial class EditEvaluation : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
            if (!IsPostBack)
            {
                string imagePath = "~/images/OJTCoordinatorProfile/" + Session["Coord_Picture"].ToString();
                CoordinatorImage.ImageUrl = imagePath;

                GetProductivity();
                GetCooperation();
                GetAbilityToFollow();
                GetAbilityToGetAlong();
                GetInitiative();
                GetAttendance();
                GetQualityOfWork();
                GetAppearance();
                GetDependability();
                GetOverAll();
            }
            
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }
        void GetProductivity()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 1;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Prod1.Text = reader["categoryDetail12"].ToString();
                    disp_Prod2.Text = reader["categoryDetail34"].ToString();
                    disp_Prod3.Text = reader["categoryDetail56"].ToString();
                    disp_Prod4.Text = reader["categoryDetail78"].ToString();
                    disp_Prod5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetCooperation()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 2;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Coop1.Text = reader["categoryDetail12"].ToString();
                    disp_Coop2.Text = reader["categoryDetail34"].ToString();
                    disp_Coop3.Text = reader["categoryDetail56"].ToString();
                    disp_Coop4.Text = reader["categoryDetail78"].ToString();
                    disp_Coop5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetAbilityToFollow()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 3;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_AbilityF1.Text = reader["categoryDetail12"].ToString();
                    disp_AbilityF2.Text = reader["categoryDetail34"].ToString();
                    disp_AbilityF3.Text = reader["categoryDetail56"].ToString();
                    disp_AbilityF4.Text = reader["categoryDetail78"].ToString();
                    disp_AbilityF5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetAbilityToGetAlong()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 4;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_AbilityG1.Text = reader["categoryDetail12"].ToString();
                    disp_AbilityG2.Text = reader["categoryDetail34"].ToString();
                    disp_AbilityG3.Text = reader["categoryDetail56"].ToString();
                    disp_AbilityG4.Text = reader["categoryDetail78"].ToString();
                    disp_AbilityG5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetInitiative()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 5;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Init1.Text = reader["categoryDetail12"].ToString();
                    disp_Init2.Text = reader["categoryDetail34"].ToString();
                    disp_Init3.Text = reader["categoryDetail56"].ToString();
                    disp_Init4.Text = reader["categoryDetail78"].ToString();
                    disp_Init5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetAttendance()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 6;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Attend1.Text = reader["categoryDetail12"].ToString();
                    disp_Attend2.Text = reader["categoryDetail34"].ToString();
                    disp_Attend3.Text = reader["categoryDetail56"].ToString();
                    disp_Attend4.Text = reader["categoryDetail78"].ToString();
                    disp_Attend5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetQualityOfWork()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 7;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Qual1.Text = reader["categoryDetail12"].ToString();
                    disp_Qual2.Text = reader["categoryDetail34"].ToString();
                    disp_Qual3.Text = reader["categoryDetail56"].ToString();
                    disp_Qual4.Text = reader["categoryDetail78"].ToString();
                    disp_Qual5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetAppearance()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 8;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Appear1.Text = reader["categoryDetail12"].ToString();
                    disp_Appear2.Text = reader["categoryDetail34"].ToString();
                    disp_Appear3.Text = reader["categoryDetail56"].ToString();
                    disp_Appear4.Text = reader["categoryDetail78"].ToString();
                    disp_Appear5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetDependability()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 9;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Depend1.Text = reader["categoryDetail12"].ToString();
                    disp_Depend2.Text = reader["categoryDetail34"].ToString();
                    disp_Depend3.Text = reader["categoryDetail56"].ToString();
                    disp_Depend4.Text = reader["categoryDetail78"].ToString();
                    disp_Depend5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetOverAll()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 10;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentAcctID", category_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Overall1.Text = reader["categoryDetail12"].ToString();
                    disp_Overall2.Text = reader["categoryDetail34"].ToString();
                    disp_Overall3.Text = reader["categoryDetail56"].ToString();
                    disp_Overall4.Text = reader["categoryDetail78"].ToString();
                    disp_Overall5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateEvaluation.aspx");
        }
    }
}