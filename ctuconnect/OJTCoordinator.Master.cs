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
    public partial class OJTCoordinator : System.Web.UI.MasterPage
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtRegisteredIntern = new DataTable();
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Coor_ACC_ID"] != null)
                {
                    getDepartmentID();
                    int totalCounts = UnreadNotificationCount();
                    lblUnreadCount.Text = totalCounts.ToString();

                    this.LoadStudentAccount();
                    rptregisteredstudent.DataSource = dtRegisteredIntern;
                    rptregisteredstudent.DataBind();

                    refreshCounting();
                    disableHeader();
                    coordinatorInfo();
     
                }
                else
                {
                    Response.Redirect("LoginOJTCoordinator.aspx");
                }
            }               
            
        }

        
        void getDepartmentID()
        {
            string coordinatorID = Session["Coor_ACC_ID"].ToString();

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM COORDINATOR_ACCOUNT JOIN DEPARTMENT ON COORDINATOR_ACCOUNT.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID WHERE coordinator_accID = '" + coordinatorID + "' ";
                //string query = "SELECT * FROM COORDINATOR_ACCOUNT WHERE coordinator_accID = '" + coordinatorID + "' ";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Session["DEPT"] = reader["department_ID"];
                    Session["COORDINATORPIC"] = reader["coordinatorPicture"];
                    lbldepartmentName.Text = reader["departmentName"].ToString();
                    lblname.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();

                }
                
            }
        }
        

        void coordinatorInfo()
        {
            if (!string.IsNullOrEmpty(Session["COORDINATORPIC"].ToString()))
            {
                imageProfile.ImageUrl = "~/images/OJTCoordinatorProfile/" + Session["COORDINATORPIC"].ToString();
                profileimg.Src = "~/images/OJTCoordinatorProfile/" + Session["COORDINATORPIC"].ToString();
            }
            else
            {
                imageProfile.ImageUrl = "~/images/OJTCoordinatorProfile/defaultprofile.jpg";
                profileimg.Src = "~/images/OJTCoordinatorProfile/defaultprofile.jpg";
            }

            
        }

        void refreshCounting()
        {
            if (lblUnreadCount.Text == "0")
            {
                lblUnreadCount.Visible = false;
            }
            else
            {
                lblUnreadCount.Visible = true;
            }
        }

        void disableHeader()
        {
            
            if (rptregisteredstudent.Items.Count == 0)
            {
                // Find the headerTemplateContainer and set its Visible property to false
                Control headerTemplateContainer = rptregisteredstudent.Controls[0].Controls[0].FindControl("headerTemplateContainer");

                if (headerTemplateContainer != null)
                {
                    headerTemplateContainer.Visible = false;
                }
            }

            

        }

        void LoadStudentAccount()
        {
            
                string departmentID = Session["DEPT"].ToString();

                using (var db = new SqlConnection(conDB))
                {
                    //and department_ID = '" + departmentID + "'
                    string query = "SELECT * FROM STUDENT_ACCOUNT WHERE isRemove = 0 and department_ID = '" + departmentID + "' ORDER BY dateRegistered DESC";
                    SqlCommand cmd = new SqlCommand(query, db);

                    db.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtRegisteredIntern);
                }

                rptregisteredstudent.DataSource = dtRegisteredIntern;
                rptregisteredstudent.DataBind();
                disableHeader();
            
            
        }

        protected int UnreadNotificationCount()
        {
            string departID = Session["DEPT"] as string;
            //int departmentIDDDD = Convert.ToInt32(departID);
            //string departmentIDD = "400000";
            int count = 0;

            // Replace with your connection string
            //string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
            //using (SqlConnection connection = new SqlConnection(conDB))
            using (var db = new SqlConnection(conDB))
            {
                //connection.Open();
                db.Open();

                string query = "SELECT COUNT(*) FROM STUDENT_ACCOUNT WHERE isRead = 0 and department_ID = '" + departID + "'";

                using (SqlCommand command = new SqlCommand(query, db))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        protected void readRegistered_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRegisteredRead")
            {
                int studentAccID = Convert.ToInt32(e.CommandArgument);

                MarkRegisteredStudentAsRead(studentAccID);


            }
            this.LoadStudentAccount();
            this.UnreadNotificationCount();

        }


        private void MarkRegisteredStudentAsRead(int studentAccID)
        {
            string departID = Session["DEPARTMENT"] as string;
            int departmentID = Convert.ToInt32(departID);
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE STUDENT_ACCOUNT SET isRead = 1 WHERE student_accID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@StudentID", studentAccID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader();
            RedirectToListOfInterns(studentAccID);

        }

        void RedirectToListOfInterns(int studentAccID)
        {
            Response.Redirect("CoordinatorProfile.aspx?student_accID=" + studentAccID);
        }

        private void RegisteredRead(int studentAccID)
        {
            string departID = Session["DEPARTMENT"] as string;
            int departmentID = Convert.ToInt32(departID);
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE STUDENT_ACCOUNT SET isRead = 1 WHERE student_accID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@StudentID", studentAccID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader();
        }

        protected void removeRegistered_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRegisteredRemove")
            {
                int studentAccID = Convert.ToInt32(e.CommandArgument);

                MarkRegisteredStudentAsRemoved(studentAccID);
                RegisteredRead(studentAccID);

            }
            this.LoadStudentAccount();
            this.UnreadNotificationCount();

        }


        private void MarkRegisteredStudentAsRemoved(int studentID)
        {
            string departID = Session["DEPARTMENT"] as string;
            int departmentID = Convert.ToInt32(departID);
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE STUDENT_ACCOUNT SET isRemove = 1 WHERE student_accID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                db.Open();
                cmd.ExecuteNonQuery();


                // Update the unread count
                int totalCounts = UnreadNotificationCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();

            if (rptregisteredstudent.Items.Count == 1)
            {
                disableHeader();
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