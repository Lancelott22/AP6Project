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
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace ctuconnect
{
    public partial class EditResume : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                rptEducation.DataSource = GetEmptyEducationTable();
                rptEducation.DataBind();
                rptSkills.DataSource = GetEmptySkillsTable();
                rptSkills.DataBind();
                rptCertificate.DataSource = GetEmptyCertificateTable();
                rptCertificate.DataBind();
                int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                if (studentAcctID > 0)
                {
                    LoadResumeForEdit(studentAcctID);
                    LoadEducation(studentAcctID);
                    LoadProfilePicture(studentAcctID);
                    LoadSkills(studentAcctID);
                    LoadCertificate(studentAcctID);

                }
                else
                {
                    rptEducation.DataSource = GetEmptyEducationTable();
                    rptEducation.DataBind();
                    rptSkills.DataSource = GetEmptySkillsTable();
                    rptSkills.DataBind();
                    rptCertificate.DataSource = GetEmptyCertificateTable();
                    rptCertificate.DataBind();
                }

                // Populate day dropdown list with values from 1 to 31
                for (int day = 1; day <= 31; day++)
                {
                    ddlDay.Items.Add(new ListItem(day.ToString(), day.ToString()));
                }

                // Populate month dropdown list with month names
                string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                for (int month = 1; month <= 12; month++)
                {
                    ddlMonth.Items.Add(new ListItem(monthNames[month - 1], month.ToString()));
                }

                // Populate year dropdown list with a range of years, e.g., from 1900 to the current year
                int currentYear = DateTime.Now.Year;
                for (int year = 1900; year <= currentYear; year++)
                {
                    ddlYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                }

            }

        }

        protected void btnUploadPicture_Click(object sender, EventArgs e)
        {
            if (fileUploadProfilePicture.HasFile)
            {
                int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
                string fileName = Path.GetFileName(fileUploadProfilePicture.FileName);
                string filePath = Server.MapPath("~/ResumeProfile/") + studentAcctID + "_" + fileName;

                fileUploadProfilePicture.SaveAs(filePath);

                // Save the profile picture file path to the database (you need to implement this part)
                SaveProfilePicturePath(studentAcctID.ToString(), "~/ResumeProfile/" + studentAcctID + "_" + fileName);

                LoadProfilePicture(studentAcctID); // Reload the profile picture after uploading
            }
        }

        private void SaveProfilePicturePath(string studentAcctID, string profilePicture)
        {
            using (var db = new SqlConnection(connDB))
            {
                string query = "UPDATE Resume SET Picture = @ProfilePicture WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ProfilePicture", profilePicture);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private string GetProfilePicturePath(int studentAcctID)
        {
            string profilePicture = string.Empty;
            using (var db = new SqlConnection(connDB))
            {
                string query = "SELECT Picture FROM Resume WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    profilePicture = reader["Picture"].ToString();
                }
                reader.Close();
            }
            return profilePicture;
        }

        private void LoadProfilePicture(int studentAcctID)
        {
            // Retrieve the profile picture path from the database (you need to implement this part)
            string profilePicture = GetProfilePicturePath(studentAcctID);

            if (!string.IsNullOrEmpty(profilePicture))
            {
                imgProfilePicture.ImageUrl = profilePicture;
            }
            else
            {
                // If no profile picture is found, display a default image (you can set a default image in the ImageUrl)
                imgProfilePicture.ImageUrl = "~/ResumeProfile/defaultprofile.jpg";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string fname = txtfname.Text;
            string lname = txtlname.Text;
            string contactNumber = txtContact.Text;
            string email = txtEmail.Text;

            string gender = drpgender.Text;
            string address = txtAddress.Text;
            string jobLevel = drpjoblevel.Text;

            string day = ddlDay.SelectedValue;
            string month = ddlMonth.SelectedValue;
            string year = ddlYear.SelectedValue;

            int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());

            try
            {
                // Parsing successful
                int parsedDay = int.Parse(day);
                int parsedMonth = int.Parse(month);
                int parsedYear = int.Parse(year);

                // Check if the parsed values are valid
                if (parsedMonth >= 1 && parsedMonth <= 12 && parsedDay >= 1 && parsedDay <= DateTime.DaysInMonth(parsedYear, parsedMonth))
                {
                    DateTime birthdate = new DateTime(parsedYear, parsedMonth, parsedDay);
                    string bdate = birthdate.ToString("yyyy-MM-dd");

                    UpdateResume(studentAcctID, lname, fname, contactNumber, email, bdate, gender, address, jobLevel);

                    // Update resume information in the database
                    SaveEducation(studentAcctID, GetEducationTableFromRepeater());
                    SaveSkills(studentAcctID, GetSkillsTableFromRepeater());
                    SaveCertificate(studentAcctID, GetCertificateTableFromRepeater());
                }
            }
            catch
            {

            }



        }

        protected void btnAddEducation_Click(object sender, EventArgs e)
        {

            AddNewRowToEducationRepeater();

        }

        protected void btnAddSkills_Click(object sender, EventArgs e)
        {

            AddNewRowToSkillsRepeater();

        }

        protected void btnAddCertificates_Click(object sender, EventArgs e)
        {

            AddNewRowToCertificateRepeater();

        }

        private void AddNewRowToEducationRepeater()
        {

            DataTable dtEducation = GetEducationTableFromRepeater();

            DataRow drNewRow = dtEducation.NewRow();
            dtEducation.Rows.Add(drNewRow);

            rptEducation.DataSource = dtEducation;
            rptEducation.DataBind();

        }

        private void AddNewRowToSkillsRepeater()
        {

            DataTable dtSkills = GetSkillsTableFromRepeater();

            DataRow drNewRow = dtSkills.NewRow();
            dtSkills.Rows.Add(drNewRow);

            rptSkills.DataSource = dtSkills;
            rptSkills.DataBind();

        }

        private void AddNewRowToCertificateRepeater()
        {

            DataTable dtCertificate = GetCertificateTableFromRepeater();

            DataRow drNewRow = dtCertificate.NewRow();
            dtCertificate.Rows.Add(drNewRow);

            rptCertificate.DataSource = dtCertificate;
            rptCertificate.DataBind();

        }

        private DataTable GetEducationTableFromRepeater()
        {
            DataTable dtEducation = new DataTable();
            dtEducation.Columns.Add("edDegree", typeof(string));
            dtEducation.Columns.Add("edNameOfSchool", typeof(string));
            dtEducation.Columns.Add("edGraduationDate", typeof(int));

            foreach (RepeaterItem item in rptEducation.Items)
            {
                TextBox txtDegree = (TextBox)item.FindControl("txtDegree");
                TextBox txtSchool = (TextBox)item.FindControl("txtSchool");
                TextBox txtGradDate = (TextBox)item.FindControl("txtGradDate");

                int graduationDate;
                if (int.TryParse(txtGradDate.Text, out graduationDate))
                {
                    dtEducation.Rows.Add(txtDegree.Text, txtSchool.Text, graduationDate);
                }
            }

            return dtEducation;
        }

        private DataTable GetSkillsTableFromRepeater()
        {
            DataTable dtSkills = new DataTable();
            dtSkills.Columns.Add("skills", typeof(string));

            foreach (RepeaterItem item in rptSkills.Items)
            {
                TextBox txtSkills = (TextBox)item.FindControl("txtSkills");



                dtSkills.Rows.Add(txtSkills.Text);

            }

            return dtSkills;
        }

        private DataTable GetCertificateTableFromRepeater()
        {
            DataTable dtCertificate = new DataTable();
            dtCertificate.Columns.Add("certificate", typeof(string));

            foreach (RepeaterItem item in rptCertificate.Items)
            {
                TextBox txtCertificates = (TextBox)item.FindControl("txtCertificates");



                dtCertificate.Rows.Add(txtCertificates.Text);

            }

            return dtCertificate;
        }

        private void UpdateResume(int studentAcctID, string lname, string fname, string contactNumber, string email, string birthdate, string gender, string address, string jobLevel)
        {

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Resume SET "
                        + "lname = '" + lname + "',"
                        + "fname = '" + fname + "',"
                        + "contactNumber = '" + contactNumber + "',"
                        + "email = '" + email + "',"
                        + "birthdate = '" + birthdate + "',"
                        + "gender = '" + gender + "',"
                        + "address = '" + address + "',"
                        + "jobLevel = '" + jobLevel + "'"
                        + "WHERE student_accID = '" + studentAcctID + "'";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                        Response.Write("<script>alert('Resume Updated!')</script>");


                }
            }
        }

        private DataTable GetEmptyEducationTable()
        {
            DataTable dtEducationBackground = new DataTable();
            dtEducationBackground.Columns.Add("edDegree", typeof(string));
            dtEducationBackground.Columns.Add("edNameOfSchool", typeof(string));
            dtEducationBackground.Columns.Add("Year", typeof(int));
            return dtEducationBackground;
        }

        private DataTable GetEmptySkillsTable()
        {
            DataTable dtSkills = new DataTable();
            dtSkills.Columns.Add("skills", typeof(string));
            return dtSkills;
        }

        private DataTable GetEmptyCertificateTable()
        {
            DataTable dtCertificate = new DataTable();
            dtCertificate.Columns.Add("certificate", typeof(string));
            return dtCertificate;
        }


        private void LoadResumeForEdit(int studentAcctID)
        {


            using (var db = new SqlConnection(connDB))
            {
                string query = "SELECT lname, fname, contactNumber, email, birthdate, gender, address, jobLevel FROM Resume WHERE student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", @studentAcctID);

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtlname.Text = reader["lname"].ToString();
                    txtfname.Text = reader["fname"].ToString();
                    txtContact.Text = reader["contactNumber"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    DateTime bdate = Convert.ToDateTime(reader["birthdate"].ToString());
                    drpgender.Text = reader["gender"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    drpjoblevel.Text = reader["jobLevel"].ToString();

                    ddlDay.Text = bdate.Day.ToString();
                    ddlMonth.Text = bdate.Month.ToString();
                    ddlYear.Text = bdate.Year.ToString();
                }

                reader.Close();
            }


        }

        private void LoadEducation(int studentAcctID)
        {

            using (var db = new SqlConnection(connDB))
            {

                string query = "SELECT * FROM Resume WHERE edDegree IS NOT NULL AND edNameOfSchool IS NOT NULL AND edGraduationDate IS NOT NULL AND student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtEducation = new DataTable();
                da.Fill(dtEducation);

                rptEducation.DataSource = dtEducation;
                rptEducation.DataBind();


            }

        }

        private void LoadSkills(int studentAcctID)
        {

            using (var db = new SqlConnection(connDB))
            {

                string query = "SELECT * FROM Resume WHERE skills IS NOT NULL AND student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtSkills = new DataTable();
                da.Fill(dtSkills);

                rptSkills.DataSource = dtSkills;
                rptSkills.DataBind();


            }

        }

        private void LoadCertificate(int studentAcctID)
        {

            using (var db = new SqlConnection(connDB))
            {

                string query = "SELECT * FROM Resume WHERE certificate IS NOT NULL AND student_accID = @studentAcctID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);

                db.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtCertificate = new DataTable();
                da.Fill(dtCertificate);

                rptCertificate.DataSource = dtCertificate;
                rptCertificate.DataBind();


            }

        }


        private void SaveEducation(int studentAcctID, DataTable dtEducation)
        {

            using (var db = new SqlConnection(connDB))
            {

                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    //Clear existing education records for the student                   
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Resume SET edDegree = NULL, edNameOfSchool = NULL, edGraduationDate = NULL WHERE student_accID = '" + studentAcctID + "' ";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                        Response.Write("<script>alert('Resume Updated!')</script>");

                    // Insert updated education records
                    foreach (DataRow row in dtEducation.Rows)
                    {
                        string insertQuery = "INSERT INTO Resume (student_accID, edDegree, edNameOfSchool, edGraduationDate)" +
                                             "VALUES (@studentAcctID, @Degree, @School, @GradDate)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, db);
                        insertCmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);
                        insertCmd.Parameters.AddWithValue("@Degree", row["edDegree"].ToString());
                        insertCmd.Parameters.AddWithValue("@School", row["edNameOfSchool"].ToString());
                        insertCmd.Parameters.AddWithValue("@GradDate", Convert.ToInt32(row["edGraduationDate"]));
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }

        }

        private void SaveSkills(int studentAcctID, DataTable dtSkills)
        {

            using (var db = new SqlConnection(connDB))
            {

                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    // Clear existing skills records for the student                   
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Resume SET skills = NULL WHERE student_accID = '" + studentAcctID + "' ";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                        Response.Write("<script>alert('Resume Updated!')</script>");

                    // Insert updated skills records
                    foreach (DataRow row in dtSkills.Rows)
                    {
                        string insertQuery = "INSERT INTO Resume (student_accID, skills)" +
                                             "VALUES (@studentAcctID, @Skills)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, db);
                        insertCmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);
                        insertCmd.Parameters.AddWithValue("@Skills", row["skills"].ToString());
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }

        }

        private void SaveCertificate(int studentAcctID, DataTable dtCertificate)
        {

            using (var db = new SqlConnection(connDB))
            {

                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    // Clear existing certificate records for the student                   
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Resume SET certificate = NULL WHERE student_accID = '" + studentAcctID + "' ";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                        Response.Write("<script>alert('Resume Updated!')</script>");

                    // Insert updated certificate records
                    foreach (DataRow row in dtCertificate.Rows)
                    {
                        string insertQuery = "INSERT INTO Resume (student_accID, certificate)" +
                                             "VALUES (@studentAcctID, @Certificate)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, db);
                        insertCmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);
                        insertCmd.Parameters.AddWithValue("@Certificate", row["certificate"].ToString());
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }

        }


        protected void rptEducation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RemoveEducation")
            {

                int itemIndex = Convert.ToInt32(e.CommandArgument);

                DataTable dtEducation = GetEducationTableFromRepeater();
                if (dtEducation.Rows.Count > itemIndex)
                {
                    // Remove the row from the DataTable
                    dtEducation.Rows.RemoveAt(itemIndex);

                    // Re-bind the Repeater with the updated DataTable
                    rptEducation.DataSource = dtEducation;
                    rptEducation.DataBind();
                }

            }
        }

        protected void rptSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RemoveSkills")
            {

                int itemIndex = Convert.ToInt32(e.CommandArgument);

                DataTable dtSkills = GetSkillsTableFromRepeater();
                if (dtSkills.Rows.Count > itemIndex)
                {
                    // Remove the row from the DataTable
                    dtSkills.Rows.RemoveAt(itemIndex);

                    // Re-bind the Repeater with the updated DataTable
                    rptSkills.DataSource = dtSkills;
                    rptSkills.DataBind();
                }

            }
        }

        protected void rptCertificate_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RemoveCertificates")
            {

                int itemIndex = Convert.ToInt32(e.CommandArgument);

                DataTable dtCertificate = GetCertificateTableFromRepeater();
                if (dtCertificate.Rows.Count > itemIndex)
                {
                    // Remove the row from the DataTable
                    dtCertificate.Rows.RemoveAt(itemIndex);

                    // Re-bind the Repeater with the updated DataTable
                    rptCertificate.DataSource = dtCertificate;
                    rptCertificate.DataBind();
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Resume.aspx");
        }
    }
}