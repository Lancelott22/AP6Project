using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = iTextSharp.text.Image;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace ctuconnect
{
    public partial class Resume : System.Web.UI.Page
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

        private DataTable dtEducation = new DataTable();
        private DataTable dtSkills = new DataTable();
        private DataTable dtCertificates = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int studentaccID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                if (studentaccID > 0)
                {
                    DisplayResume(studentaccID);

                }



            }

        }

        private void DisplayResume(int studentaccID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT picture, lname, fname, contactNumber, email, birthdate, gender, address, jobLevel FROM Resume WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentaccID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblName.Text = reader["fname"].ToString() + " " + reader["lname"].ToString();
                    lblContact.Text = reader["contactNumber"].ToString();
                    LoadProfilePicture(reader["picture"].ToString());
                    lblEmail.Text = reader["email"].ToString();
                    DateTime bdate = Convert.ToDateTime(reader["birthdate"].ToString());
                    lblGender.Text = reader["gender"].ToString();
                    lblAddress.Text = reader["address"].ToString();
                    lblJobLevel.Text = reader["jobLevel"].ToString();

                    string formattedBdate = bdate.ToString("yyyy-MM-dd");
                    lblBirthdate.Text = formattedBdate;
                }
                reader.Close();

                // Clear the DataTable before filling it with fresh data (optional)
                dtEducation.Clear();
                dtSkills.Clear();
                dtCertificates.Clear();

                LoadEducation(studentaccID);
                LoadSkills(studentaccID);
                LoadCertificates(studentaccID);
            }
        }

        private void LoadProfilePicture(string profilePicturePath)
        {
            if (!string.IsNullOrEmpty(profilePicturePath))
            {
                imgProfilePicture.ImageUrl = profilePicturePath;
            }
            else
            {
                imgProfilePicture.ImageUrl = "ResumeProfile/defaultprofile.jpg";
            }
        }

        private void LoadSkills(int studentaccID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM Resume WHERE skills IS NOT NULL AND student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentaccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSkills);
            }

            rptSkills.DataSource = dtSkills;
            rptSkills.DataBind();
        }

        private void LoadEducation(int studentaccID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM Resume WHERE edDegree IS NOT NULL AND edNameOfSchool IS NOT NULL AND edGraduationDate IS NOT NULL AND student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentaccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtEducation);
            }

            rptEducation.DataSource = dtEducation;
            rptEducation.DataBind();
        }

        private void LoadCertificates(int studentaccID)
        {
            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM Resume WHERE certificate IS NOT NULL AND student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentaccID);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCertificates);
            }

            rptCertificates.DataSource = dtCertificates;
            rptCertificates.DataBind();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            int studentaccID = Convert.ToInt32(Session["STUDENT_ACC_ID"].ToString());

            // Generate the resume content as a PDF.
            byte[] resumePDF = GenerateResumePDF(studentaccID);

            // Set the response headers to make the document downloadable.
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + lblName.Text + "_resume.pdf");
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(resumePDF);
            Response.Flush();
            Response.End();

        }

        private byte[] GenerateResumePDF(int studentaccID)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                // Initialize a StringBuilder to store the HTML content
                StringBuilder htmlContent = new StringBuilder();

                htmlContent.Append(@"
                <html>
                <head>
                    <style>                      
                        .personal-info{ padding-left:7em; display: flex;
                                flex-wrap: wrap; }
                        .resume-section {
                                padding-left:7em;
                                display: flex;
                                flex-wrap: wrap;
                            }
                            .personal-three {
                                width: 40%; 
                                padding-left:110px;
                                font-weight: normal;
                            }
                            .personal-nine {
                                width: 60%; 
                                padding-left:7em;
                                font-weight: normal;
                               
                            }

                            .education-three {
                                width: 20%; 
                                padding-left:110px;
                                font-weight: normal;
                            }
                            .education-nine {
                                width: 80%; 
                                padding-left:35px;
                                font-weight: normal;
                               
                            }
                    </style>  
                    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet' />
                </head>
                
                <body>");

                string profilePicturePath = imgProfilePicture.ImageUrl; // Get the profile picture URL from the ASP.NET Image control
                if (!string.IsNullOrEmpty(profilePicturePath))
                {
                    Image profileImage = Image.GetInstance(Server.MapPath(profilePicturePath)); // Map the image path
                    profileImage.ScaleAbsolute(90, 90); // Set image size
                    document.Add(profileImage); // Add the image to the PDF
                }

                htmlContent.Append(@"<hr />");

                htmlContent.Append(@"
                    
                            <b>PERSONAL INFORMATION</b>
                            <br />
                            <table class='personal-info'>
                                <tr>
                                    <th class='personal-three'>
                                        Name:
                                    </th>
                                    <th class='personal-nine'>"
                                        + lblName.Text +
                                    @"</th>
                                </tr>
                                <tr>
                                    <th class='personal-three'>
                                        Contact Number:
                                    </th>
                                    <th class='personal-nine'>"
                                        + lblContact.Text +
                                    @"</th>
                                </tr>
                                <tr>
                                    <th class='personal-three'>
                                        Email:
                                    </th>
                                    <th class='personal-nine'>"
                                        + lblEmail.Text +
                                    @"</th>
                                </tr>
                                <tr>
                                    <th class='personal-three'>
                                        Birthdate:
                                    </th>
                                    <th class='personal-nine'>"
                                        + lblBirthdate.Text +
                                    @"</th>
                                </tr>
                                <tr>
                                    <th class='personal-three'>
                                        Gender:
                                    </th>
                                    <th class='personal-nine'>"
                                        + lblGender.Text +
                                    @"</th>
                                </tr>
                                <tr>
                                    <th class='personal-three'>
                                        Address:
                                    </th>
                                    <th class='personal-nine'>"
                                        + lblAddress.Text +
                                    @"</th>
                                </tr>
                                <tr>
                                    <th class='personal-three'>
                                        Job Level:
                                    </th>
                                    <th class='personal-nine'>"
                                        + lblJobLevel.Text +
                                    @"</th>
                                </tr>
                            </table>
                                    
                    ");

                htmlContent.Append(@"<br />");
                htmlContent.Append(@"<hr />");

                htmlContent.Append(@"<b>SKILLS</b><br />");
                foreach (RepeaterItem item in rptSkills.Items)
                {
                    Label lblSkill = (Label)item.FindControl("lblSkills");
                    htmlContent.Append(@"
                    <div class='row'>
                        <div class='col-12 d-flex flex-column'>
                            <asp:Repeater ID='rptSkills' runat='server'>
                                <ItemTemplate>
                                    <div class='row resume-section'>                                        
                                            <div class='col-3 d-flex flex-column'>"
                                               + lblSkill.Text +
                                            @"</div>      
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    
                    ");
                }

                htmlContent.Append(@"<br />");
                htmlContent.Append(@"<hr />");

                htmlContent.Append(@"<b>EDUCATION</b><br /><br />");
                foreach (RepeaterItem item in rptEducation.Items)
                {
                    Label lblEdDegree = (Label)item.FindControl("lblDegree");
                    Label lblEdNameOfSchool = (Label)item.FindControl("lblSchool");
                    Label lblEdGraduationDate = (Label)item.FindControl("lblGrad");

                    htmlContent.Append(@"
                    < div class='row'>
                        <div class='col-12'>
                            <asp:Repeater ID='rptEducation' runat='server'>
                                <ItemTemplate>
                                    <table>
                                        <tr class='row resume-section'>                                             
                                            <th class='education-three'>
                                                <b>" + lblEdDegree.Text + @"</b>
                                            </th>
                                            <th class='education-nine'>
                                                <b>" + lblEdNameOfSchool.Text + @"</b>
                                            </th>
                                        </tr>
                                        <tr class='row resume-section'> 
                                            <th class='education-three'>
                                                        
                                            </th>
                                            <th class='education-nine'>"
                                                + lblEdGraduationDate.Text +
                                                @"<br />
                                            </th>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    
                    ");

                }
                htmlContent.Append(@"<br />");
                htmlContent.Append(@"<hr />");

                htmlContent.Append(@"<b>CERTIFICATES OR AWARDS</b><br />");
                foreach (RepeaterItem item in rptCertificates.Items)
                {
                    Label lblCertificate = (Label)item.FindControl("lblCertificates");
                    htmlContent.Append(@"
                    <div class='row'>
                        <div class='col-12 d-flex flex-column'>
                            <asp:Repeater ID='rptCertificates' runat='server'>
                                <ItemTemplate>
                                    <div class='row resume-section'>
                                        <div class='col-12 d-flex flex-column'>"
                                            + lblCertificate.Text +
                                        @"</div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    ");
                }
                htmlContent.Append(@"<br />");
                // Close the HTML and body tags
                htmlContent.Append(@"
                </body>
                </html>");

                // Use XMLWorker to parse and add the HTML content to the PDF
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(htmlContent.ToString()));

                document.Close();
                return ms.ToArray();
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditResume");
        }
    }
}