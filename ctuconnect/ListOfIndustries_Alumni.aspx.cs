﻿using System;
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

            string query = "SELECT INDUSTRY_ACCOUNT.industryName, INDUSTRY_ACCOUNT.location, CONTACT_PERSON.fName + ' ' + CONTACT_PERSON.LNAme AS contactPerson, CONTACT_PERSON.contactNumber, CONTACT_PERSON.contactEmail, INDUSTRY_ACCOUNT.mou " +
            "FROM INDUSTRY_ACCOUNT  JOIN CONTACT_PERSON ON INDUSTRY_ACCOUNT.industry_accID = CONTACT_PERSON.industry_accID ORDER BY INDUSTRY_ACCOUNT.industry_accID DESC ";
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
    }
}