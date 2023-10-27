using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Xml.Linq;
using System.Drawing;

namespace ctuconnect
{

    public partial class Refer : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*if (Session["Coor_ACC_ID"] != null)
                {
                    // Retrieve the coordinator_accID from the session
                    *//*BindGridView1();*//*
                }
                else
                {
                    // Handle the case where the user is not logged in or doesn't have a coordinator_accID.
                }*/
             
                BindGridView1();
                using (conDB)
                {
                    conDB.Open();
                    string query = "SELECT industry_accID, industryName FROM INDUSTRY_ACCOUNT";

                    using (SqlCommand cmd = new SqlCommand(query, conDB))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dropdownIndustries.DataSource = reader;
                            dropdownIndustries.DataTextField = "industryName"; 
                            dropdownIndustries.DataValueField = "industry_accID";   
                            dropdownIndustries.DataBind();
                        }
                    }
                }
            }
        }

        void BindGridView1()
        {
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);

            string query = "SELECT STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.midInitials,  INDUSTRY_ACCOUNT.industryName,   COORDINATOR_ACCOUNT.firstName + ' ' + COORDINATOR_ACCOUNT.lastName AS referredBy , REFERRAL.endorsementLetter, REFERRAL.dateReferred " +
            "FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
            "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
            "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
            "WHERE REFERRAL.coordinator_accID = @CoordinatorID";
            SqlCommand cmd = new SqlCommand(query, conDB);
            cmd.Parameters.AddWithValue("@CoordinatorID", coordinatorID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void addRefer_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#AddReferralModal').modal('show');", true);
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);
            conDB.Open();
            string query = "SELECT firstName, midInitials, lastName FROM COORDINATOR_ACCOUNT where coordinator_accID = @coordinator_accID";
            SqlCommand command = new SqlCommand(query, conDB);
            command.Parameters.AddWithValue("@coordinator_accID", coordinatorID);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Populate the first name and last name textboxes
                    txtFirstName_coordinator.Text = reader["firstName"].ToString();
                    txtMiddleInitial_coordinator.Text = reader["midInitials"].ToString();
                    txtLastName_coordinator.Text = reader["lastName"].ToString();
                    txtID_coordinator.Text = coordinatorID.ToString();
                }
                else
                {
                    txtFirstName_coordinator.Text = "Not found";
                    txtMiddleInitial_coordinator.Text = "Not found";
                    txtLastName_coordinator.Text = "Not found";
                    txtID_coordinator.Text = "Not found";
                }
            }
        }
        
            protected void findByID_Student(object sender, EventArgs e)
        {
            string enteredID = txtID_student.Text.Trim();

            using (conDB)
            {
                conDB.Open();
                string query = "SELECT firstName, midInitials, lastName, resumeFile FROM STUDENT_ACCOUNT WHERE student_accID = @student_accID";
                SqlCommand command = new SqlCommand(query, conDB);
                command.Parameters.AddWithValue("@student_accID", enteredID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the first name and last name textboxes
                        txtFirstName_student.Text = reader["firstName"].ToString();
                        txtMiddleInitial_student.Text = reader["midInitials"].ToString();
                        txtLastName_student.Text = reader["lastName"].ToString();
                        txtResumeFileName.Text = reader["resumeFile"].ToString();
                    }
                    else
                    {
                        // Handle the case when no matching record is found
                        txtFirstName_student.Text = "Not found";
                        txtMiddleInitial_student.Text = "Not found";
                        txtLastName_student.Text = "Not found";
                        txtResumeFileName.Text = "No resume found";
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#AddReferralModal').modal('show');", true);
        }
        protected void Close_SuccessPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('hide');document.location='Refer.aspx'", true);
        }
        protected void Submit_ButtonClick(object sender, EventArgs e)
        {
            string studentID = txtID_student.Text;
            string industryID = dropdownIndustries.SelectedValue;
            
            int coordinatorID = Convert.ToInt32(Session["Coor_ACC_ID"]);

            // Add the data to the Referral table in the database
            using (conDB)
            {
                conDB.Open();
                using (var cmd = conDB.CreateCommand())
                {
                    // SQL Statement to insert data into the Referral table
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO REFERRAL (student_accID, industry_accID, coordinator_accID, dateReferred) " +
                                      "VALUES (@studentID, @industryID, @coordinatorID, @dateReferred)";

                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@industryID", industryID);
                    cmd.Parameters.AddWithValue("@coordinatorID", coordinatorID);
                    cmd.Parameters.AddWithValue("@dateReferred", DateTime.Now.ToString("yyyy/MM/dd"));
                    cmd.ExecuteNonQuery();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('show');", true);
                
            }
           /* Response.Redirect("Refer.aspx");*/
            /*
            this.BindGridView1();*/
        }

        

    }
}
    
