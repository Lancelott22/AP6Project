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
using System.Text;
using iText.Html2pdf;

namespace ctuconnect
{
    public partial class ViewEvaluation : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack && Request.QueryString["hired_id"] != null && Request.QueryString["student_accID"] != null)
                {
                    string student_accID = Request.QueryString["student_accID"];
                    getEvalInfo();
                    GetProductivity();
                    GetCooperation();
                    GetAbilityToFollow();
                    GetAbilityToGetAlong();
                    GetInitiative();
                    GetAttendance();
                    GetQualityOfWork();
                    GetAppearance();
                    GetDependability();
                    GetOverAll();
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


        void GetProductivity()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 1;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Prod1.Text = reader["categoryDetail12"].ToString();
                    disp_Prod2.Text = reader["categoryDetail34"].ToString();
                    disp_Prod3.Text = reader["categoryDetail56"].ToString();
                    disp_Prod4.Text = reader["categoryDetail78"].ToString();
                    disp_Prod5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetCooperation()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 2;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Coop1.Text = reader["categoryDetail12"].ToString();
                    disp_Coop2.Text = reader["categoryDetail34"].ToString();
                    disp_Coop3.Text = reader["categoryDetail56"].ToString();
                    disp_Coop4.Text = reader["categoryDetail78"].ToString();
                    disp_Coop5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetAbilityToFollow()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 3;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_AbilityF1.Text = reader["categoryDetail12"].ToString();
                    disp_AbilityF2.Text = reader["categoryDetail34"].ToString();
                    disp_AbilityF3.Text = reader["categoryDetail56"].ToString();
                    disp_AbilityF4.Text = reader["categoryDetail78"].ToString();
                    disp_AbilityF5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetAbilityToGetAlong()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 4;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_AbilityG1.Text = reader["categoryDetail12"].ToString();
                    disp_AbilityG2.Text = reader["categoryDetail34"].ToString();
                    disp_AbilityG3.Text = reader["categoryDetail56"].ToString();
                    disp_AbilityG4.Text = reader["categoryDetail78"].ToString();
                    disp_AbilityG5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetInitiative()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 5;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Init1.Text = reader["categoryDetail12"].ToString();
                    disp_Init2.Text = reader["categoryDetail34"].ToString();
                    disp_Init3.Text = reader["categoryDetail56"].ToString();
                    disp_Init4.Text = reader["categoryDetail78"].ToString();
                    disp_Init5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetAttendance()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 6;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Attend1.Text = reader["categoryDetail12"].ToString();
                    disp_Attend2.Text = reader["categoryDetail34"].ToString();
                    disp_Attend3.Text = reader["categoryDetail56"].ToString();
                    disp_Attend4.Text = reader["categoryDetail78"].ToString();
                    disp_Attend5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetQualityOfWork()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 7;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Qual1.Text = reader["categoryDetail12"].ToString();
                    disp_Qual2.Text = reader["categoryDetail34"].ToString();
                    disp_Qual3.Text = reader["categoryDetail56"].ToString();
                    disp_Qual4.Text = reader["categoryDetail78"].ToString();
                    disp_Qual5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetAppearance()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 8;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Appear1.Text = reader["categoryDetail12"].ToString();
                    disp_Appear2.Text = reader["categoryDetail34"].ToString();
                    disp_Appear3.Text = reader["categoryDetail56"].ToString();
                    disp_Appear4.Text = reader["categoryDetail78"].ToString();
                    disp_Appear5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetDependability()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 9;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Depend1.Text = reader["categoryDetail12"].ToString();
                    disp_Depend2.Text = reader["categoryDetail34"].ToString();
                    disp_Depend3.Text = reader["categoryDetail56"].ToString();
                    disp_Depend4.Text = reader["categoryDetail78"].ToString();
                    disp_Depend5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetOverAll()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 10;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    disp_Overall1.Text = reader["categoryDetail12"].ToString();
                    disp_Overall2.Text = reader["categoryDetail34"].ToString();
                    disp_Overall3.Text = reader["categoryDetail56"].ToString();
                    disp_Overall4.Text = reader["categoryDetail78"].ToString();
                    disp_Overall5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void getEvalInfo()
        {
            string student_accID = Request.QueryString["student_accID"];
            string hired_ID = Request.QueryString["hired_id"];
            using (conDB)
            {
                conDB.Open();
                string query = "SELECT *, STUDENT_ACCOUNT.firstName, STUDENT_ACCOUNT.lastName, EVALUATION.major, Evaluation.trainingPeriod, EVALUATION.totalScore, EVALUATION.gradeEquivalent, EVALUATION.describeStrength, EVALUATION.describeImprovement,EVALUATION.cooperatingAgency,EVALUATION.address, EVALUATION.dateEvaluated " +
               "FROM STUDENT_ACCOUNT " +
               "JOIN EVALUATION ON STUDENT_ACCOUNT.student_accID = EVALUATION.student_accID " +
               "WHERE STUDENT_ACCOUNT.student_accID = @student_accID and hired_id = @hired_id";


                SqlCommand command = new SqlCommand(query, conDB);
                command.Parameters.AddWithValue("@student_accID", student_accID);
                command.Parameters.AddWithValue("@hired_id", hired_ID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    firstName.Text = reader["firstName"].ToString();
                    lastName.Text = reader["lastName"].ToString();
                    course.Text = reader["major"].ToString();
                    forCourse.Text = reader["major"].ToString();
                    trainingPeriod.Text = reader["trainingPeriod"].ToString();
                    score.Text = reader["totalScore"].ToString();
                    grade.Text = reader["gradeEquivalent"].ToString();
                    txtStrengths.Text = reader["describeStrength"].ToString();
                    txtImprovement.Text = reader["describeImprovement"].ToString();
                    disp_industryName.Text = reader["cooperatingAgency"].ToString();
                    disp_Indlocation.Text = reader["address"].ToString();
                    disp_dateEval.Text = reader["dateEvaluated"].ToString();
                    Session["Productivity"] = reader["productivity"].ToString();
                    Session["Cooperation"] = reader["cooperation"].ToString();
                    Session["AbilityToFollow"] = reader["abilityTofollow"].ToString();
                    Session["AbilityToGet"] = reader["abilityToget"].ToString();
                    Session["Category5"] = reader["initiative"].ToString();
                    Session["Category6"] = reader["attendance"].ToString();
                    Session["Category7"] = reader["qualityOfwork"].ToString();
                    Session["Category8"] = reader["appearance"].ToString();
                    Session["Category9"] = reader["dependability"].ToString();
                    Session["Category10"] = reader["overAllperformance"].ToString();
                }
                conDB.Close();
                reader.Close();
            }
        }
        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            // Get the HTML content from the ASPX page
            string htmlContent = GetHtmlFromControl(evaluationForm);

            // Create a MemoryStream to hold the PDF bytes
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Set up iTextSharp HTML to PDF conversion
                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(htmlContent, memoryStream, converterProperties);

                /*  // Save the PDF file to the database
                  SavePdfToDatabase(memoryStream.ToArray());*/

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



        private string GetHtmlFromControl(Control control)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            control.RenderControl(writer);
            return sw.ToString();
        }


        // Helper method to save the PDF to the database
        /*private void SavePdfToDatabase(byte[] pdfBytes)
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
        }*/

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        
    }
}
