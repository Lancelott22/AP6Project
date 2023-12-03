using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
	public partial class EvaluationForm : System.Web.UI.Page
	{
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (!IsPostBack && Request.QueryString["student_accID"] != null && Request.QueryString["hired_id"] != null)
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

        private void isEvaluated()
        {
            string student_accID = Request.QueryString["STUDENT_ID"];
            string evaluated = "Evaluated";

            if (string.IsNullOrEmpty(student_accID))
            {
                // Handle the case where student_accID is missing or invalid
                Response.Write("<script>alert('Invalid or missing student_accID')</script>");
                return;
            }

            using (conDB)
            {
                conDB.Open();

                using (SqlCommand command = new SqlCommand("UPDATE HIRED_LIST SET evaluationRequest = @evaluationRequest WHERE student_accID = @student_accID;", conDB))
                {
                    command.Parameters.AddWithValue("@student_accID", student_accID);
                    command.Parameters.AddWithValue("@evaluationRequest", evaluated); // Corrected parameter name
                    int ctr = command.ExecuteNonQuery();

                    // Additional code if needed after the update
                }
            }
            conDB.Close();
        }
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
        private int GetSelectedRadioButtonValue(string groupName)
        {
            // Use Request.Form to get the selected value of the radio button group
            string selectedValue = Request.Form[groupName];
            // Convert the selected value to an integer
            if (int.TryParse(selectedValue, out int result))
            {
                return result;
            }
            return 0; // Default value if parsing fails
        }

        protected void btnsubmit_Command(object sender, CommandEventArgs e)
        {

            int Productivity = int.Parse(Session["Productivity"].ToString());
            int Cooperation = int.Parse(Session["Cooperation"].ToString());
            int AbilityToFollow = int.Parse(Session["AbilityToFollow"].ToString());
            int AbilityToGet = int.Parse(Session["AbilityToGet"].ToString());
            int Category5 = int.Parse(Session["Category5"].ToString());
            int Category6 = int.Parse(Session["Category6"].ToString());
            int Category7 = int.Parse(Session["Category7"].ToString());
            int Category8 = int.Parse(Session["Category8"].ToString());
            int Category9 = int.Parse(Session["Category9"].ToString());
            int Category10 = int.Parse(Session["Category10"].ToString());


            // Get data from form controls

            string major = course.Text;
            string strengths = txtStrengths.Text;
            string improvement = txtImprovement.Text;
            string industryName = disp_industryName.Text;
            string indLocation = disp_Indlocation.Text;
            int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
            int trainingPeriod = int.Parse(disp_trainingPeriod.Text);
            string student_accID = Request.QueryString["student_accID"];
            string hired_ID = Request.QueryString["hired_id"];
            // Retrieve values from hidden fields using Request.Form
            string totalScore = Request.Form[hidden_score.UniqueID];
            string equivalentGrade = Request.Form[hidden_grade.UniqueID];

            // Insert data into the database
            using (conDB)
            {
                conDB.Open();

                // Replace 'YourTable' with your actual table name and column names
                string insertQuery = "INSERT INTO EVALUATION (student_accID, major, trainingPeriod, totalScore, gradeEquivalent, describeStrength, describeImprovement, industry_accID, cooperatingAgency, address, dateEvaluated," +
                    " productivity, cooperation, abilityTofollow, abilityToget, initiative, attendance, qualityOfwork, appearance, dependability, overAllperformance, hired_id) " +
                           "VALUES (@student_accID, @Course, @TrainingPeriod, @Score, @Grade, @Strengths, @Improvement,  @industry_accID, @IndustryName, @IndLocation, @dateEval, " +
                           "@productivity, @cooperation, @abilityTofollow, @abilityToget,@initiative,@attendance,@qualityOfwork,@appearance, @dependability, @overAllperformance, @hired_id)";

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
                            cmd.Parameters.AddWithValue("@productivity", Productivity);
                            cmd.Parameters.AddWithValue("@cooperation", Cooperation);
                            cmd.Parameters.AddWithValue("@abilityTofollow", AbilityToFollow);
                            cmd.Parameters.AddWithValue("@abilityToget", AbilityToGet);
                            cmd.Parameters.AddWithValue("@initiative", Category5);
                            cmd.Parameters.AddWithValue("@attendance", Category6);
                            cmd.Parameters.AddWithValue("@qualityOfwork", Category7);
                            cmd.Parameters.AddWithValue("@appearance", Category8);
                            cmd.Parameters.AddWithValue("@dependability", Category9);
                            cmd.Parameters.AddWithValue("@overAllperformance", Category10);
                            cmd.Parameters.AddWithValue("@hired_id", hired_ID);
                            isEvaluated();
                            int ctr = cmd.ExecuteNonQuery();
                            if(ctr> 0)
                            {
                                Response.Write("<script>alert('You have successfully evaluated the student.');document.location='HiredList.aspx'</script>");
                                SqlCommand cmd1 = new SqlCommand("UPDATE HIRED_LIST SET evaluationRequest = 'Evaluated' WHERE id = '" + hired_ID +"'", conDB);
                                cmd1.ExecuteNonQuery();
                            }
                            else
                            {
                                Response.Write("<script>alert('There is something wrong while submitting your evaluation form.Please try again!');</script>");
                            }
                        }
                        else
                        {
                            // Conversion failed, handle the error
                            Response.Write("<script>alert('The input string is not a valid integer.');</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('No score and grade Read');</script>");
                    }
                }
                conDB.Close();
            }
        }

        protected void btnnext1_Click(object sender, EventArgs e)
        {
            // Store values in session
            Session["Productivity"] = GetSelectedRadioButtonValue("productivity");
            Session["Cooperation"] = GetSelectedRadioButtonValue("cooperation");
            Session["AbilityToFollow"] = GetSelectedRadioButtonValue("abilityToFollow");
            Session["AbilityToGet"] = GetSelectedRadioButtonValue("abilityToGet");
            Session["Category5"] = GetSelectedRadioButtonValue("category5");
            Session["Category6"]  = GetSelectedRadioButtonValue("category6");
            Session["Category7"] = GetSelectedRadioButtonValue("category7");
            Session["Category8"] = GetSelectedRadioButtonValue("category8");
            Session["Category9"]  = GetSelectedRadioButtonValue("category9");
            Session["Category10"] = GetSelectedRadioButtonValue("category10");

            btnsubmit.Visible = true;
        }
    }
}