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
using System.Xml.Linq;

namespace ctuconnect
{
    public partial class RegisterIndustry : System.Web.UI.Page
    {
        
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                // Check if there's saved data and populate the fields
                if (Session["savedName"] != null)
                {
                    txtindustry.Text = Session["savedName"].ToString();
                }

                if (Session["savedLocation"] != null)
                {
                    txtlocation.Text = Session["savedLocation"].ToString();
                }

                if (Session["savedEmail"] != null)
                {
                    txtemail.Text = Session["savedEmail"].ToString();
                }

                if (Session["savedPassword"] != null)
                {
                    txtpwd.Text = Session["savedPassword"].ToString();
                }

                if (Session["savedConfirmPwd"] != null)
                {
                    txtcpwd.Text = Session["savedConfirmPwd"].ToString();
                }



            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            // Save input data to session before encountering an error
            Session["savedName"] = txtindustry.Text;
            Session["savedLocation"] = txtlocation.Text;
            Session["savedEmail"] = txtemail.Text;


                HttpPostedFile postedFile = mouUpload.PostedFile; /// upload file
                string filename = Path.GetFileName(postedFile.FileName); ///to check the filename
                string fileExtension = Path.GetExtension(filename).ToLower(); //to get the extension filename
                int filezise = postedFile.ContentLength; //to get the filesize


                string logpath = Server.MapPath("~/images/MOU/"); //creating a drive to upload or save the image




                string filepath = Path.Combine(logpath, filename);
                string industryName = txtindustry.Text;
                string location = txtlocation.Text; 
                string email = txtemail.Text;
                string password = txtcpwd.Text;
                HttpPostedFile postedFile2 = profileUpload.PostedFile;
                string filename2 = Path.GetFileName(postedFile2.FileName);
                string fileExtension2 = Path.GetExtension(filename2).ToLower();
                int filezise2 = postedFile2.ContentLength;


                string logpath2 = Server.MapPath("~/images/IndustryProfile/");


                string filepath2 = Path.Combine(logpath2, filename2);
                if (fileExtension == ".bmp" || fileExtension.Equals(".jpg") || fileExtension.Equals(".png") || fileExtension.Equals(".jpeg") || fileExtension.Equals(".pdf") && 
                    fileExtension2 == ".bmp" || fileExtension2.Equals(".jpg") || fileExtension2.Equals(".png") || fileExtension2.Equals(".jpeg") || fileExtension2.Equals(".pdf")) //check the filename extension
                {
                    if (File.Exists(filepath) || File.Exists(filepath2))
                    {
                        Response.Write("<script>alert('A file with the same name already exists. Please choose a different name.');document.location='RegisterIndustry.aspx'</script>");
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

                            cmd.CommandText = "INSERT INTO INDUSTRY_ACCOUNT (INDUSTRYNAME, LOCATION, EMAIL, PASSWORD, MOU, INDUSTRYPICTURE, DATEREGISTERED )"
                                + "VALUES (@industryName, @location, @email, @password, @mou, @industryPicture, @datereg )";
                            

                            

                            cmd.Parameters.AddWithValue("@industryName", industryName);
                            cmd.Parameters.AddWithValue("@location", location);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.Parameters.AddWithValue("@mou", filename);

                            cmd.Parameters.AddWithValue("@industryPicture", filename2);
                            cmd.Parameters.AddWithValue("@datereg", DateTime.Now.ToString("yyyy/MM/dd"));

                            cmd.ExecuteNonQuery();
                            conDB.Close();

                        }
                        Response.Write("<script>alert('Created Successfully');document.location='LoginIndustry.aspx'</script>");
                    Session.RemoveAll();
                    }
                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable')</script>"); //error message after checking the file extensions
                }
            
        }


        
    }
}