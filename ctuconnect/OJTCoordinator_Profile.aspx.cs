﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class OJTCoordinatorProfile : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            displayCoordinatorInfo();
            
            
        }

        void displayCoordinatorInfo()
        {
            string coordID = "400000";
            using (var db = new SqlConnection(conDB))
            {

                string query = "SELECT * FROM COORDINATOR_ACCOUNT JOIN DEPARTMENT ON COORDINATOR_ACCOUNT.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID WHERE coordinator_accID = '" + coordID + "' ";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LoadProfilePicture(reader["coordinatorPicture"].ToString());
                    disp_name.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                    coordFname.Text = reader["firstName"].ToString();
                    coordLname.Text = reader["lastName"].ToString();
                    coordInitial.Text = reader["midInitials"].ToString();
                    coordUsername.Text = reader["username"].ToString();
                    coordDepartment.Text = reader["departmentName"].ToString();
                }
                reader.Close();
            }
        }

        private void LoadProfilePicture(string profilePicturePath)
        {
            if (!string.IsNullOrEmpty(profilePicturePath))
            {
                ojtcoordProfile.ImageUrl = "~/images/OJTCoordinatorProfile/" + profilePicturePath;
            }
            else
            {
                ojtcoordProfile.ImageUrl = "~/images/OJTCoordinatorProfile/defaultprofile.jpg";
            }
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }
    }
}