using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class RegisterIndustry : System.Web.UI.Page
    {
        
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                HttpPostedFile postedFile = mouUpload.PostedFile; /// upload file
                string filename = Path.GetFileName(postedFile.FileName); ///to check the filename
                string fileExtension = Path.GetExtension(filename).ToLower(); //to get the extension filename
                int filezise = postedFile.ContentLength; //to get the filesize
                string logpath = "C:\\Users\\jelbe\\source\\repos\\Kenthdavis\\ctuconnect\\ctuconnect\\images\\Uploads\\"; //creating a drive to upload or save the image
                string filepath = Path.Combine(logpath, filename);
                string industryName = txtindustry.Text;
                string location = txtlocation.Text; 
                string email = txtemail.Text;
                string password = txtcpwd.Text;
                HttpPostedFile postedFile2 = profileUpload.PostedFile;
                string filename2 = Path.GetFileName(postedFile2.FileName);
                string fileExtension2 = Path.GetExtension(filename2).ToLower();
                int filezise2 = postedFile2.ContentLength;
                string logpath2 = "C:\\Users\\jelbe\\source\\repos\\Kenthdavis\\ctuconnect\\ctuconnect\\images\\Uploads\\";
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
                            cmd.CommandText = "INSERT INTO INDUSTRY_ACCOUNT (industry_accID, industryName, location, email, password, mou, IndustryLogo )"
                                + "VALUES (@industryID, @industryName, @location, @email, @password, @mou, @IndustryLogo )";
                            cmd.Parameters.AddWithValue("@industryID", 66666);
                            cmd.Parameters.AddWithValue("@industryName", industryName);
                            cmd.Parameters.AddWithValue("@location", location);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.Parameters.AddWithValue("@mou", filename);
                            cmd.Parameters.AddWithValue("@IndustryLogo", filename2);
                            cmd.ExecuteNonQuery();
                            conDB.Close();

                        }
                        Response.Write("<script>alert('Created Successfully');document.location='Login.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable')</script>"); //error message after checking the file extensions
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong!')</script");
            }
        }
        
    }
}