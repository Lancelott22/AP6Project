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
    public partial class ListOfIndustries_Alumni : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTable();
            }
        }
        void BindTable()
        {

            string query = "SELECT INDUSTRY_ACCOUNT.industry_accID, INDUSTRY_ACCOUNT.industryName, INDUSTRY_ACCOUNT.location, CONTACT_PERSON.fName + ' ' + CONTACT_PERSON.LNAme AS contactPerson, CONTACT_PERSON.contactNumber, CONTACT_PERSON.contactEmail, INDUSTRY_ACCOUNT.mou " +
            "FROM INDUSTRY_ACCOUNT  LEFT JOIN CONTACT_PERSON ON INDUSTRY_ACCOUNT.industry_accID = CONTACT_PERSON.industry_accID ORDER BY INDUSTRY_ACCOUNT.industry_accID DESC ";
            SqlCommand cmd = new SqlCommand(query, conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater.DataSource = ds;
            dataRepeater.DataBind();

        }
        protected void ViewMOU_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                /* Button btn = (Button)sender;
                 int studentID = Convert.ToInt32(btn.Attributes["data-studentid"]);
 */
                string MOUFileName = e.CommandArgument.ToString();
                /*string endorsementLetterPath = Server.MapPath("~/images/EndorsementLetter" + endorsementLetterFileName);*/
                // Change the button text to "Reviewed"
                //Button button = (Button)sender;
                //button.Text = "Reviewed";


                // Retrieve and display the resume file
                byte[] MOUFileData = GetEndorsementFileData(MOUFileName);


                if (MOUFileData != null)
                {
                    // Provide the file data for download in a new browser tab
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf"; // Set the appropriate content type
                    Response.AddHeader("content-disposition", "inline; filename=memorandumofunderstanding.pdf"); // Open in a new tab
                    Response.BinaryWrite(MOUFileData);
                    Response.End();
                }
            }
        }
        private byte[] GetEndorsementFileData(string MOUFileName)
        {
            using (conDB)
            {
                string query = "SELECT mou FROM INDUSTRY_ACCOUNT WHERE mou = @MOUFileName";
                SqlCommand cmd = new SqlCommand(query, conDB);
                cmd.Parameters.AddWithValue("@MOUFileName", MOUFileName);

                conDB.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Assuming that the result is a file path, read the file content
                    string fileName = result.ToString();
                    string filePath = "~/images/MOU/" + fileName; // Construct the path
                    byte[] fileData = System.IO.File.ReadAllBytes(Server.MapPath(filePath));
                    return fileData;
                }

                return null; // No file found
            }
        }

        protected void BtnAddIndustry_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#AddIndustryModal').modal('show');", true);
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) 
            { 
                string industryName = txtIndustryName.Text;
                string industryEmail = txtemail.Text;
                //string industryPwd = txtpwd.Text;
               // string industryLoc = txtLocation.Text;
                HttpPostedFile postedFile = mouUpload.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName); ///to check the filename
                string fileExtension = Path.GetExtension(filename).ToLower(); //to get the extension filename
                int filezise = postedFile.ContentLength; //to get the filesize
                string logpath = Server.MapPath("~/images/MOU/"); //creating a drive to upload or save the image
                string filepath = Path.Combine(logpath, filename);

                if (fileExtension == ".bmp" || fileExtension.Equals(".jpg") || fileExtension.Equals(".png") || fileExtension.Equals(".jpeg") || fileExtension.Equals(".pdf"))
                {
                    if (File.Exists(filepath))
                    {
                        Response.Write("<script>alert('A file with the same name already exists. Please choose a different name.');document.location='ListOfIndustries_Alumni.aspx'</script>");
                        return; // Return to stop further execution
                    }
                    postedFile.SaveAs(filepath);
                    using (conDB)
                    {
                        //SQL Connection
                        conDB.Open();
                        using (var cmd = conDB.CreateCommand())
                        {
                            //SQL Statement
                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = "INSERT INTO INDUSTRY_ACCOUNT (INDUSTRYNAME, LOCATION, EMAIL, PASSWORD, MOU, DATEREGISTERED,ISVERIFIED, )"
                                + "VALUES (@industryName, @location, @email, @password, @mou, @datereg, @verified )";




                            cmd.Parameters.AddWithValue("@industryName", industryName);
                            //cmd.Parameters.AddWithValue("@location", industryLoc);
                            cmd.Parameters.AddWithValue("@email", industryEmail);
                            //cmd.Parameters.AddWithValue("@password", industryPwd);
                            cmd.Parameters.AddWithValue("@mou", filename);
                            cmd.Parameters.AddWithValue("@datereg", DateTime.Now.ToString("yyyy/MM/dd"));
                            cmd.Parameters.AddWithValue("@verified", true);
                            cmd.ExecuteNonQuery();
                            conDB.Close();

                        }
                        Response.Write("<script>alert('Created Successfully');document.location='ListOfIndustries_Alumni.aspx'</script>");
                        //Response.Redirect("ListOfIndustries_Alumni.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('The file extension of the uploaded file is not acceptable')</script>");//error message after checking the file extensions
                }
            }
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
        protected void CloseIndustryModal(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#AddIndustryModal').modal('hide');document.location='ListOfIndustry_Alumni.aspx'", true);
        }
        protected void close_Modal(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('hide');document.location='ListOfIndustry_Alumni.aspx'", true);
        }
    }
}