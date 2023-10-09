﻿using System;
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

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            
                HttpPostedFile postedFile = corUpload.PostedFile; /// upload file
                string filename = Path.GetFileName(postedFile.FileName); ///to check the filename
                string fileExtension = Path.GetExtension(filename).ToLower(); //to get the extension filename
                int filezise = postedFile.ContentLength; //to get the filesize
                string logpath = "C:\\Users\\Gebby\\source\\repos\\ctuconnect\\ctuconnect\\images\\COR"; //creating a drive to upload or save the image
                string filepath = Path.Combine(logpath, filename);
                string fname = txtfname.Text;
                string midinitial = txtinitial.Text;
                string lname = txtlname.Text;
                string status = "student";
                string email = txtemail.Text;
                int stuID = Convert.ToInt32(txtid.Text);  
                int course = Convert.ToInt32(drpcourse.SelectedValue.ToString());
                string password = txtcpwd.Text;
                HttpPostedFile postedFile2 = profileUpload.PostedFile;
                string filename2 = Path.GetFileName(postedFile2.FileName);
                string fileExtension2 = Path.GetExtension(filename2).ToLower();
                int filezise2 = postedFile2.ContentLength;
                string logpath2 = "C:\\Users\\Gebby\\source\\repos\\ctuconnect\\ctuconnect\\images\\StudentProfiles";
                string filepath2 = Path.Combine(logpath2, filename2);
                if (fileExtension == ".bmp" || fileExtension.Equals(".jpg") || fileExtension.Equals(".png") || fileExtension.Equals(".jpeg") || fileExtension.Equals(".pdf") &&
                    fileExtension2 == ".bmp" || fileExtension2.Equals(".jpg") || fileExtension2.Equals(".png") || fileExtension2.Equals(".jpeg") || fileExtension2.Equals(".pdf")) //check the filename extension
                {
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
                            cmd.CommandText = "INSERT INTO STUDENT_ACCOUNT (STUDENTID, FIRSTNAME, MIDINITIALS, LASTNAME, STUDENTSTATUS, COURSE_ID, STUDENTPICTURE, COR, EMAIL, PASSWORD, DATEREGISTERED )"
                                + "VALUES (@studentid, @fname, @midinitial, @lname, @studentstatus, @courseid, @studentpic, @cor, @email, @password, @date)";

                            cmd.Parameters.AddWithValue("@studentid", stuID);
                            cmd.Parameters.AddWithValue("@fname", fname);
                            cmd.Parameters.AddWithValue("@midinitial", midinitial);
                            cmd.Parameters.AddWithValue("@lname", lname);
                            cmd.Parameters.AddWithValue("@studentstatus", status);
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
                    }
                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable')</script>"); //error message after checking the file extensions
                }
            
        }
    }
}