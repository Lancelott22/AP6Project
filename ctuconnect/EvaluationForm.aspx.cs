using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography.X509Certificates;

namespace ctuconnect
{
    public partial class EvaluationForm : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack && Request.QueryString["student_accID"] != null)
                {
                    // Retrieve query parameters
                    string student_accID = Request.QueryString["student_accID"];

                    // Set CommandArgument for the btnsubmit button
                    btnsubmit.CommandArgument = student_accID;

                    // Bind data to the repeater
                    getData();
                }
                // Retrieve values from hidden fields using Request.Form
                string totalScore = Request.Form[hidden_score.UniqueID];
                string equivalentGrade = Request.Form[hidden_grade.UniqueID];


            }
            else
            {
                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_Indlocation.Text = Session["LOCATION"].ToString();
            }

            // RegisterStartupScript to call the JavaScript function
            string script = "<script type=\"text/javascript\"> calculateScore(); </script>";
            string calc = "calculate score";
            ClientScript.RegisterStartupScript(this.GetType(), calc, script);
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {

        }
        /* private DataTable GetStudentData(string student_accID)
         {
             DataTable dataTable = new DataTable();

             // Connection string
             string connectionString = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

             // SQL query
             string query = "SELECT * FROM STUDENT_ACCOUNT JOIN PROGRAM ON STUDENT_ACCOUNT.COURSE_ID = PROGRAM.COURSE_ID WHERE student_accID = @studentAccID";

             using (SqlConnection conDB = new SqlConnection(connectionString))
             {
                 using (SqlCommand cmd = new SqlCommand(query, conDB))
                 {
                     // Add parameters to the query
                     cmd.Parameters.AddWithValue("@studentAccID", student_accID);


                     // Open the database connection
                     conDB.Open();

                     // Execute the query and fill the DataTable
                     using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                     {
                         da.Fill(dataTable);
                     }
                 }
             }

             return dataTable;
         } */

        void getData()
        {
            string student_accID = Request.QueryString["student_accID"];
            using (conDB)
            {
                conDB.Open();
                string query = "SELECT * FROM STUDENT_ACCOUNT JOIN PROGRAM ON STUDENT_ACCOUNT.COURSE_ID = PROGRAM.COURSE_ID WHERE student_accID = '" + student_accID + "' ";

                SqlCommand command = new SqlCommand(query, conDB);
                SqlCommand cmd = new SqlCommand(query, conDB);
                cmd.Parameters.AddWithValue("@studentAcctID", student_accID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {



                    firstName.Text = reader["firstName"].ToString();
                    lastName.Text = reader["lastName"].ToString();
                    course.Text = reader["course"].ToString();
                    disp_trainingPeriod.Text = reader["hoursNeeded"].ToString();



                }
                conDB.Close();
                reader.Close();
            }
        }

        /*
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            // Store values in session
            Session["Productivity"] = Request.Form["productivity"];
            Session["Cooperation"] = Request.Form["cooperation"];
            Session["AbilityToFollow"] = Request.Form["abilityToFollow"];
            Session["AbilityToGet"] = Request.Form["abilityToGet"];
            Session["Category5"] = Request.Form["category5"];
            Session["Category6"] = Request.Form["category6"];
            Session["Category7"] = Request.Form["category7"];
            Session["Category8"] = Request.Form["category8"];
            Session["Category9"] = Request.Form["category9"];
            Session["Category10"] = Request.Form["category10"];
            

            // Get data from form controls

            string major = course.Text;
            string strengths = txtStrengths.Text;
            string improvement = txtImprovement.Text;
            string industryName = disp_industryName.Text;
            string indLocation = disp_Indlocation.Text;
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            int trainingPeriod = int.Parse(disp_trainingPeriod.Text);
            string student_accID = Request.QueryString["student_accID"];

            // Retrieve values from hidden fields using Request.Form
            string totalScore = Request.Form[hidden_score.UniqueID];
            string equivalentGrade = Request.Form[hidden_grade.UniqueID];

            // Insert data into the database
            using (conDB)
            {
                conDB.Open();

                // Replace 'YourTable' with your actual table name and column names
                string insertQuery = "INSERT INTO EVALUATION (student_accID, major, trainingPeriod, totalScore, gradeEquivalent, describeStrength, describeImprovement, industry_accID, cooperatingAgency, address, dateEvaluated) " +
                           "VALUES (@student_accID, @Course, @TrainingPeriod, @Score, @Grade, @Strengths, @Improvement,  @industry_accID, @IndustryName, @IndLocation, @dateEval)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conDB))
                {
                    if (!string.IsNullOrEmpty(totalScore) && !string.IsNullOrEmpty(equivalentGrade))
                    {
                       
                        if (int.TryParse(totalScore, out int score) && int.TryParse(equivalentGrade, out int grade))
                        {
                            // Conversion successful, 'score' now contains the integer value
                            // Do something with the 'score' variable
                            
                            cmd.Parameters.AddWithValue("@student_accID", student_accID);
                            cmd.Parameters.AddWithValue("@Course", major);
                            cmd.Parameters.AddWithValue("@TrainingPeriod", trainingPeriod);
                            cmd.Parameters.AddWithValue("@Score", score);
                            cmd.Parameters.AddWithValue("@Grade", grade);
                            cmd.Parameters.AddWithValue("@Strengths", strengths);
                            cmd.Parameters.AddWithValue("@Improvement", improvement);
                            cmd.Parameters.AddWithValue("@industry_accID", industryAccID);
                            cmd.Parameters.AddWithValue("@IndustryName", industryName);
                            cmd.Parameters.AddWithValue("@IndLocation", indLocation);
                            cmd.Parameters.AddWithValue("@dateEval", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            // Conversion failed, handle the error
                            Console.WriteLine("The input string is not a valid integer.");
                        }
                        
                    }
                    else
                    {
                        Response.Write("<script>alert('No score and grade Read');</script>");
                        Response.Redirect("HiredList.aspx?student_accID=" );
                    }
                }
                conDB.Close();
                Response.Write("<script>alert('Thank you for submitting your evaluation! 🌟 Your feedback is important to us');document.location='ViewEvaluation.aspx?evaluationID='</script>");





            }
            
        }*/

        private string GetSelectedRadioValue(string productivity, string cooperation, string abilityToFollow, string abilitytoGet, string category5, string category6, string category7, string category8, string category9, string category10)
        {
            string selectedValue = string.Empty;
            foreach (var control in Page.Controls)
            {
                if (control is System.Web.UI.HtmlControls.HtmlForm)
                {
                    foreach (var childControl in ((System.Web.UI.HtmlControls.HtmlForm)control).Controls)
                    {
                        if (childControl is System.Web.UI.WebControls.RadioButton)
                        {
                            var radioButton = (System.Web.UI.HtmlControls.HtmlInputRadioButton)childControl;
                            if ((radioButton.Name == productivity ||
                                radioButton.Name == cooperation ||
                                radioButton.Name == abilityToFollow ||
                                radioButton.Name == abilitytoGet ||
                                radioButton.Name == category5 ||
                                radioButton.Name == category6 ||
                                radioButton.Name == category7 ||
                                radioButton.Name == category8 ||
                                radioButton.Name == category9 ||
                                radioButton.Name == category10) && radioButton.Checked)
                            {
                                selectedValue = radioButton.Value;
                                break;
                            }
                        }
                    }
                }
            }
            return selectedValue;
        }

        protected void btnsubmit_Command(object sender, CommandEventArgs e)
        {
            // Store values in session
            Session["Productivity"] = Request.Form["productivity"];
            Session["Cooperation"] = Request.Form["cooperation"];
            Session["AbilityToFollow"] = Request.Form["abilityToFollow"];
            Session["AbilityToGet"] = Request.Form["abilityToGet"];
            Session["Category5"] = Request.Form["category5"];
            Session["Category6"] = Request.Form["category6"];
            Session["Category7"] = Request.Form["category7"];
            Session["Category8"] = Request.Form["category8"];
            Session["Category9"] = Request.Form["category9"];
            Session["Category10"] = Request.Form["category10"];



            // Get data from form controls

            string major = course.Text;
            string strengths = txtStrengths.Text;
            string improvement = txtImprovement.Text;
            string industryName = disp_industryName.Text;
            string indLocation = disp_Indlocation.Text;
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            int trainingPeriod = int.Parse(disp_trainingPeriod.Text);
            string student_accID = Request.QueryString["student_accID"];

            // Retrieve values from hidden fields using Request.Form
            string totalScore = Request.Form[hidden_score.UniqueID];
            string equivalentGrade = Request.Form[hidden_grade.UniqueID];

            // Insert data into the database
            using (conDB)
            {
                conDB.Open();

                // Replace 'YourTable' with your actual table name and column names
                string insertQuery = "INSERT INTO EVALUATION (student_accID, major, trainingPeriod, totalScore, gradeEquivalent, describeStrength, describeImprovement, industry_accID, cooperatingAgency, address, dateEvaluated) " +
                           "VALUES (@student_accID, @Course, @TrainingPeriod, @Score, @Grade, @Strengths, @Improvement,  @industry_accID, @IndustryName, @IndLocation, @dateEval)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conDB))
                {
                    if (!string.IsNullOrEmpty(totalScore) && !string.IsNullOrEmpty(equivalentGrade))
                    {

                        if (int.TryParse(totalScore, out int score) && int.TryParse(equivalentGrade, out int grade))
                        {
                            // Conversion successful, 'score' now contains the integer value
                            // Do something with the 'score' variable

                            cmd.Parameters.AddWithValue("@student_accID", student_accID);
                            cmd.Parameters.AddWithValue("@Course", major);
                            cmd.Parameters.AddWithValue("@TrainingPeriod", trainingPeriod);
                            cmd.Parameters.AddWithValue("@Score", score);
                            cmd.Parameters.AddWithValue("@Grade", grade);
                            cmd.Parameters.AddWithValue("@Strengths", strengths);
                            cmd.Parameters.AddWithValue("@Improvement", improvement);
                            cmd.Parameters.AddWithValue("@industry_accID", industryAccID);
                            cmd.Parameters.AddWithValue("@IndustryName", industryName);
                            cmd.Parameters.AddWithValue("@IndLocation", indLocation);
                            cmd.Parameters.AddWithValue("@dateEval", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            // Conversion failed, handle the error
                            Console.WriteLine("The input string is not a valid integer.");
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('No score and grade Read');document.location='HiredList.aspx'</script>");
                    }
                }
                conDB.Close();
                Response.Write("<script>alert('Thank you for submitting your evaluation! 🌟 Your feedback is important to us');</script>");
                Session["EvaluationPerformed"] = true;
                Response.Redirect("ViewEvaluation.aspx?student_accID=" + e.CommandArgument.ToString());






            }
        }
    }
}