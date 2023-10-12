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

namespace ctuconnect
{

    public partial class Refer : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        private bool findButtonClicked = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //// Create an empty DataTable
                //DataTable dataTable = new DataTable();
                //dataTable.Columns.Add("referralID", typeof(int));
                //dataTable.Columns.Add("lastName", typeof(string));
                //dataTable.Columns.Add("firstName", typeof(string));
                //dataTable.Columns.Add("midInitials", typeof(string));
                //dataTable.Columns.Add("industryName", typeof(string));
                //dataTable.Columns.Add("fullName", typeof(string));
                //dataTable.Columns.Add("dateReferred", typeof(string));
                //dataTable.Columns.Add("status", typeof(string));

                //// Add some sample data rows

                //dataTable.Rows.Add(017845903, "Guardiario", "Kenth Davis", "L", "Accenture", "Matthew B Arcena",  "07/13/2023", "--");
                //dataTable.Rows.Add(017845903, "Guardiario", "Kenth Davis", "L", "Accenture", "Matthew B Arcena", "07/13/2023", "--");

                //// Bind the empty DataTable to the GridView
                //GridView1.DataSource = dataTable;
                //GridView1.DataBind();
                if (Session["ACC_ID"] != null)
                {
                    // Retrieve the coordinator_accID from the session
                    int coordinatorID = Convert.ToInt32(Session["ACC_ID"]);

                    BindGridView1(coordinatorID);
                }
                else
                {
                    // Handle the case where the user is not logged in or doesn't have a coordinator_accID.
                }
               
            }
        }
        void BindGridView1(int coordinatorID)
        {
            
                string query = "SELECT STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.lastName, STUDENT_ACCOUNT.midInitials,  INDUSTRY_ACCOUNT.industryName,   COORDINATOR_ACCOUNT.firstName + ' ' + COORDINATOR_ACCOUNT.lastName AS referredBy " +
                "FROM REFERRAL  JOIN STUDENT_ACCOUNT ON REFERRAL.student_accID = STUDENT_ACCOUNT.student_accID " +
                "JOIN INDUSTRY_ACCOUNT  ON REFERRAL.industry_accID = INDUSTRY_ACCOUNT.industry_accID " +
                "JOIN COORDINATOR_ACCOUNT ON REFERRAL.coordinator_accID = COORDINATOR_ACCOUNT.coordinator_accID " +
                "WHERE REFERRAL.coordinator_accID = @CoordinatorID";
                SqlCommand cmd = new SqlCommand(query, conDB);
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



        }
        //protected void SubmitApply_Command(object sender, CommandEventArgs e) //submitApplication
        //{
        //    using (conDB)
        //    {
        //        conDB.Open();

        //    }
        //}
        protected void findByID_Student(object sender, EventArgs e)
        {
            string enteredID = txtID_student.Text.Trim();

            using (conDB)
            {
                conDB.Open();
                string query = "SELECT firstName, midInitials, lastName FROM STUDENT_ACCOUNT WHERE student_accID = @student_accID";
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
                        //if (reader["ResumeFilePath"] != DBNull.Value)
                        //{
                        //    string resumeFilePath = reader["ResumeFilePath"].ToString();
                        //    // Display or link to the resume file based on your UI design
                        //    // You can use an ASP.NET control like HyperLink or an HTML <a> tag.
                        //    // For example:
                        //    // resumeLink.NavigateUrl = resumeFilePath;
                        //    // resumeLink.Text = "Download Resume";
                        //}
                    }
                    else
                    {
                        // Handle the case when no matching record is found
                        txtFirstName_student.Text = "Not found";
                        txtMiddleInitial_student.Text = "Not found";
                        txtLastName_student.Text = "Not found";
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#AddReferralModal').modal('show');", true);
        }


        //protected void findByID_Coordinator(object sender, EventArgs e)
        //{
        //    string enteredID = txtID_coordinator.Text.Trim();

        //    using (conDB)
        //    {
        //        conDB.Open();
        //        string query = "SELECT firstName, midInitials, lastName FROM COORDINATOR_ACCOUNT WHERE coordinator_accID = @coordinator_accID";
        //            SqlCommand command = new SqlCommand(query, conDB);
        //            command.Parameters.AddWithValue("@coordinator_accID", enteredID);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                // Populate the first name and last name textboxes
        //                txtFirstName_coordinator.Text = reader["firstName"].ToString();
        //                 txtMiddleInitial_coordinator.Text = reader["midInitials"].ToString();
        //                    txtLastName_coordinator.Text = reader["lastName"].ToString();
        //                }
        //                else
        //                {
        //                // Handle the case when no matching record is found
        //                txtFirstName_coordinator.Text = "Not found";
        //                txtMiddleInitial_coordinator.Text = "Not found";
        //                txtLastName_coordinator.Text = "Not found";
        //                }
        //            }
        //        }
        //    }



        //    protected void Submit_ButtonClick(object sender, EventArgs e)
        //    {
        //        HttpPostedFile postedFile = resumeUpload.PostedFile; /// upload file
        //        string filename = Path.GetFileName(postedFile.FileName); ///to check the filename
        //        string fileExtension = Path.GetExtension(filename).ToLower(); //to get the extension filename
        //        int filezise = postedFile.ContentLength; //to get the filesize
        //        string logpath = "C:\\Users\\irish\\source\\repos\\ctuconnect\\ctuconnect\\images\\Resume"; //creating a drive to upload or save the image
        //        string filepath = Path.Combine(logpath, filename);
        //        if (fileExtension == ".bmp" || fileExtension.Equals(".jpg") || fileExtension.Equals(".png") || fileExtension.Equals(".jpeg") || fileExtension.Equals(".pdf") &&
        //                fileExtension2 == ".bmp" || fileExtension2.Equals(".jpg") || fileExtension2.Equals(".png") || fileExtension2.Equals(".jpeg") || fileExtension2.Equals(".pdf")) //check the filename extension
        //        {
        //            postedFile.SaveAs(filepath); //save the file in the folder or drive
        //            conDB.Open();
        //            using (var cmd = conDB.CreateCommand())
        //            {
        //            //SQL Statement
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = "INSERT INTO STUDENT_ACCOUNT (STUDENTID, FIRSTNAME, MIDINITIALS, LASTNAME, STUDENTSTATUS, COURSE_ID, STUDENTPICTURE, COR, EMAIL, PASSWORD, DATEREGISTERED )"
        //                + "VALUES (@studentid, @fname, @midinitial, @lname, @studentstatus, @courseid, @studentpic, @cor, @email, @password, @date)";

        //            cmd.Parameters.AddWithValue("@studentid", stuID);
        //            cmd.Parameters.AddWithValue("@fname", fname);
        //            cmd.Parameters.AddWithValue("@midinitial", midinitial);
        //            cmd.Parameters.AddWithValue("@lname", lname);
        //            cmd.Parameters.AddWithValue("@studentstatus", status);
        //            cmd.Parameters.AddWithValue("@courseid", course);
        //            cmd.Parameters.AddWithValue("@studentpic", filename2);
        //            cmd.Parameters.AddWithValue("@cor", filename);
        //            cmd.Parameters.AddWithValue("@email", email);
        //            cmd.Parameters.AddWithValue("@password", password);
        //            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy/MM/dd"));
        //            cmd.ExecuteNonQuery();


        //            conDB.Close();
        //        }
        //     }



        //}
    }
}
    
