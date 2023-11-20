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

namespace ctuconnect
{
    public partial class RegisterStudent : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if there's saved data and populate the fields
                if (Session["savedFname"] != null)
                {
                    txtfname.Text = Session["savedFname"].ToString();
                }

                if (Session["savedInitial"] != null)
                {
                    txtinitial.Text = Session["savedInitial"].ToString();
                }

                if (Session["savedLname"] != null)
                {
                    txtlname.Text = Session["savedLname"].ToString();
                }

                if (Session["savedStudentID"] != null)
                {
                    txtid.Text = Session["savedStudentID"].ToString();
                }

                if (Session["savedCourse"] != null)
                {
                    drpcourse.SelectedValue = Session["savedCourse"].ToString();
                }

                if (Session["savedEmail"] != null)
                {
                    txtemail.Text = Session["savedEmail"].ToString();
                }

            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
                // Save input data to session before encountering an error

                Session["savedFname"] = txtfname.Text;
                Session["savedInitial"] = txtinitial.Text;
                Session["savedLname"] = txtlname.Text;
                Session["savedStudentID"] = txtid.Text;
                Session["savedCourse"] = drpcourse.SelectedValue;
                Session["savedEmail"] = txtemail.Text;

            int dep_ID = 290001;

                HttpPostedFile postedFile = corUpload.PostedFile; /// upload file
                string filename = Path.GetFileName(postedFile.FileName); ///to check the filename
                string fileExtension = Path.GetExtension(filename).ToLower(); //to get the extension filename
                int filezise = postedFile.ContentLength; //to get the filesize

                string logpath = Server.MapPath("~/images/COR/"); //creating a drive to upload or save the image

                string filepath = Path.Combine(logpath, filename);
                string fname = txtfname.Text;
                string midinitial = txtinitial.Text;
                string lname = txtlname.Text;
                string status = "Intern";
                string email = txtemail.Text;
                int stuID = Convert.ToInt32(txtid.Text);  
                int course = Convert.ToInt32(drpcourse.SelectedValue.ToString());
                string password = txtcpwd.Text;
                HttpPostedFile postedFile2 = profileUpload.PostedFile;
                string filename2 = Path.GetFileName(postedFile2.FileName);
                string fileExtension2 = Path.GetExtension(filename2).ToLower();
                int filezise2 = postedFile2.ContentLength;

                string logpath2 = Server.MapPath("~/images/StudentProfiles/");
    
                string filepath2 = Path.Combine(logpath2, filename2);

            // Check if the email already exists in the database
            if (IsEmailAlreadyRegistered(email))
            {
                lblErrorMessage.Text = "Error: This email address is already registered.";
                lblErrorMessage.Visible = true;
                return; // Exit the event handler
            }
            
            // Check if the account ID already exists in the database
            if (IsAccountIdAlreadyRegistered(stuID))
            {
                lblErrorMessage2.Text = "Error: This account ID is already registered.";
                lblErrorMessage2.Visible = true;
                return; // Exit the event handler
            }


            if (fileExtension == ".bmp" || fileExtension.Equals(".jpg") || fileExtension.Equals(".png") || fileExtension.Equals(".jpeg") || fileExtension.Equals(".pdf") &&
                    fileExtension2 == ".bmp" || fileExtension2.Equals(".jpg") || fileExtension2.Equals(".png") || fileExtension2.Equals(".jpeg") ) //check the filename extension
                    {
                        if (File.Exists(filepath) || File.Exists(filepath2))
                        {
                            Response.Write("<script>alert('A file with the same name already exists. Please choose a different name.');document.location='RegisterStudent.aspx'</script>");
                            return; // Return to stop further execution
                        }
                                postedFile.SaveAs(filepath); //save the file in the folder or drive
                                postedFile2.SaveAs(filepath2);
                                using (conDB)
                                {
                                    //SQL Connection
                                    conDB.Open();
                                    using (var cmd = conDB.CreateCommand())
                                    {
                                        //SQL Statement
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandText = "INSERT INTO STUDENT_ACCOUNT (STUDENTID, FIRSTNAME, MIDINITIALS, LASTNAME, STUDENTSTATUS, DEPARTMENT_ID, COURSE_ID, STUDENTPICTURE, COR, EMAIL, PASSWORD, DATEREGISTERED )"
                                            + "VALUES (@studentid, @fname, @midinitial, @lname, @studentstatus,@department_Id, @courseid, @studentpic, @cor, @email, @password, @date)";

                                        cmd.Parameters.AddWithValue("@studentid", stuID);
                                        cmd.Parameters.AddWithValue("@fname", fname);
                                        cmd.Parameters.AddWithValue("@midinitial", midinitial);
                                        cmd.Parameters.AddWithValue("@lname", lname);
                                        cmd.Parameters.AddWithValue("@studentstatus", status);
                                        cmd.Parameters.AddWithValue("@department_Id", dep_ID);
                                        cmd.Parameters.AddWithValue("@courseid", course);
                                        cmd.Parameters.AddWithValue("@studentpic", filename2);
                                        cmd.Parameters.AddWithValue("@cor", filename);
                                        cmd.Parameters.AddWithValue("@email", email);
                                        cmd.Parameters.AddWithValue("@password", password);
                                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy/MM/dd"));
                                        cmd.ExecuteNonQuery();
                            

                                        conDB.Close();

                                    }
                                    Response.Write("<script>alert('Created Successfully');document.location='LoginStudent.aspx'</script>");
                                    Session.RemoveAll();
                                }
                    }
                    else
                    {
                        Response.Write("<script>alert('The file extension of the uploaded file is not acceptable')</script>"); //error message after checking the file extensions
                    }

            
        }

        private bool IsEmailAlreadyRegistered(string email)
        {
            SqlConnection conDB2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            using (conDB2)
            {
                conDB2.Open();

                string query = "SELECT COUNT(1) FROM STUDENT_ACCOUNT WHERE email = @email";
                SqlCommand command = new SqlCommand(query, conDB2);
                command.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

        private bool IsAccountIdAlreadyRegistered(int stuID)
        {
            SqlConnection conDB2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            using (conDB2)
            {
                conDB2.Open();

                string query = "SELECT COUNT(1) FROM STUDENT_ACCOUNT WHERE studentId = @studentId";
                SqlCommand command = new SqlCommand(query, conDB2);
                command.Parameters.AddWithValue("@studentId", stuID);
                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }


    }
}