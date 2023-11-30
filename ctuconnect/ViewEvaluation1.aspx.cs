using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.tool.xml.html;
using System.Text;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using PdfWriter = iTextSharp.text.pdf.PdfWriter;
using iText.Html2pdf;

namespace ctuconnect
{
    public partial class ViewEvaluation1 : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack && Request.QueryString["student_accID"] != null)
                {
                    string student_accID = Request.QueryString["student_accID"];
                    getEvalInfo();
                }

                SetSelectedRadioButtons();
            }
        }


        private void SetSelectedRadioButtons()
        {
            Dictionary<string, string> radioButtons = new Dictionary<string, string>
    {
        { "productivity", Session["Productivity"] as string },
        { "cooperation", Session["Cooperation"] as string },
        { "abilityToFollow", Session["AbilityToFollow"] as string },
        { "abilityToGet", Session["AbilityToGet"] as string },
        { "category5", Session["Category5"] as string },
        { "category6", Session["Category6"] as string },
        { "category7", Session["Category7"] as string },
        { "category8", Session["Category8"] as string },
        { "category9", Session["Category9"] as string },
        { "category10", Session["Category10"] as string },
    };

            foreach (Control control in evaluationForm.Controls)
            {
                if (control is HtmlTableRow tableRow)
                {
                    foreach (Control rowControl in tableRow.Cells[0].Controls)
                    {
                        if (rowControl is HtmlInputRadioButton radioButton && radioButtons.ContainsKey(radioButton.Name))
                        {
                            if (radioButton.Value == radioButtons[radioButton.Name])
                            {
                                radioButton.Checked = true;
                            }
                        }
                    }
                }
            }
        }



        void getEvalInfo()
        {
            string student_accID = Request.QueryString["student_accID"];
            using (conDB)
            {
                conDB.Open();
                string query = "SELECT STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.lastName, EVALUATION.major, Evaluation.trainingPeriod, EVALUATION.totalScore, EVALUATION.gradeEquivalent, EVALUATION.describeStrength, EVALUATION.describeImprovement " +
               "FROM STUDENT_ACCOUNT " +
               "JOIN EVALUATION ON STUDENT_ACCOUNT.student_accID = EVALUATION.student_accID " +
               "WHERE STUDENT_ACCOUNT.student_accID = @student_accID";


                SqlCommand command = new SqlCommand(query, conDB);
                command.Parameters.AddWithValue("@student_accID", student_accID);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    firstName.Text = reader["firstName"].ToString();
                    lastName.Text = reader["lastName"].ToString();
                    course.Text = reader["major"].ToString();
                    trainingPeriod.Text = reader["trainingPeriod"].ToString();
                    score.Text = reader["totalScore"].ToString();
                    grade.Text = reader["gradeEquivalent"].ToString();
                    txtStrengths.Text = reader["describeStrength"].ToString();
                    txtImprovement.Text = reader["describeImprovement"].ToString();

                }

                conDB.Close();
                reader.Close();
            }
        }



        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            // Get the HTML content from the ASPX page
            string htmlContent = RenderControlToHtml(evaluationForm);

            // Create a MemoryStream to hold the PDF bytes
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Set up iTextSharp HTML to PDF conversion
                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(htmlContent, memoryStream, converterProperties);

                // Save the PDF file to the database
                //SavePdfToDatabase(memoryStream.ToArray());

                // Save the PDF file to disk or respond to the client
                byte[] pdfBytes = memoryStream.ToArray();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + lastName.Text + "_" + firstName.Text + "EvaluationForm.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(pdfBytes);
                Response.End();
            }
        }

        // Helper method to render the ASPX control to HTML
        private string RenderControlToHtml(Control control)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter writer = new HtmlTextWriter(sw))
                {
                    control.RenderControl(writer);
                }
            }
            return sb.ToString();
        }


        /* private string GetHtmlFromControl(Control control)
         {
             StringWriter sw = new StringWriter();
             HtmlTextWriter writer = new HtmlTextWriter(sw);
             control.RenderControl(writer);
             return sw.ToString();
         }*/

        /*
        // Helper method to save the PDF to the database
        private void SavePdfToDatabase(byte[] pdfBytes)
        {

            string student_accID = Request.QueryString["student_accID"];


            if (string.IsNullOrEmpty(student_accID))
            {
                // Handle the case where student_accID is missing or invalid
                Response.Write("<script>alert('Invalid or missing student_accID')</script>");
                return;
            }

            using (conDB)
            {
                conDB.Open();

                using (SqlCommand command = new SqlCommand("UPDATE EVALUATION SET evaluationForm = @evaluationFile WHERE student_accID = @student_accID;", conDB))
                {

                    if (pdfBytes != null && pdfBytes.Length > 0)
                    {
                        command.Parameters.AddWithValue("@student_accID", student_accID);
                        command.Parameters.AddWithValue("@evaluationFile", pdfBytes);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        Response.Write("<script>alert('No evaluationform has been saved in database')</script>");
                    }
                }
            }
        }
        */


        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("HiredList.aspx");
        }
    }
}
