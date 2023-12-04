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
using System.Globalization;

namespace ctuconnect
{
    public partial class EditResume : System.Web.UI.Page
    {
        string connDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["StudentEmail"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
            else if (!IsPostBack && Session["StudentEmail"] != null && Session["STATUSorTYPE"].ToString() == "Alumni" && bool.Parse(Session["IsAnswered"].ToString()) == false)
            {
                Response.Redirect("Alumni_Employment_Form.aspx");
            }
            if (!IsPostBack)
            {

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

                // Save the profile picture file path to the database 
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
            int studentAcctID = Convert.ToInt32(Session["Student_ACC_ID"].ToString());
            string fname = txtfname.Text;
            string lname = txtlname.Text;
            string contactNumber = txtContact.Text;
            string email = txtEmail.Text;

            string gender = drpgender.Text;
            string address = txtAddress.Text;
            string jobLevel = drpjoblevel.Text;

            string birthdate = txtbdate.Text;

            if (Convert.ToDateTime(txtbdate.Text) >= DateTime.Now.Date)
            {
                Response.Write("<script>alert('Resume Updated!'); history.back();</script>");
                return;
            }

            UpdateResume(studentAcctID, lname, fname, contactNumber, email, birthdate, gender, address, jobLevel);

            // Update resume information in the database
            SaveEducation(studentAcctID, GetEducationTableFromRepeater());
            SaveSkills(studentAcctID, GetSkillsTableFromRepeater());
            SaveCertificate(studentAcctID, GetCertificateTableFromRepeater());
                 

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
            dtEducation.Columns.Add("edGraduationDate", typeof(string));

            foreach (RepeaterItem item in rptEducation.Items)
            {
                TextBox txtDegree = (TextBox)item.FindControl("txtDegree");
                TextBox txtSchool = (TextBox)item.FindControl("txtSchool");
                TextBox txtGradDate = (TextBox)item.FindControl("txtGradDate");

                dtEducation.Rows.Add(txtDegree.Text, txtSchool.Text, txtGradDate.Text);

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
                        Response.Write("<script>alert('Resume Updated!');document.location='Resume.aspx'</script>");


                }
            }
        }

        private DataTable GetEmptyEducationTable()
        {
            DataTable dtEducationBackground = new DataTable();
            dtEducationBackground.Columns.Add("edDegree", typeof(string));
            dtEducationBackground.Columns.Add("edNameOfSchool", typeof(string));
            dtEducationBackground.Columns.Add("Year", typeof(string));
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

                    object birthdateValue = reader["birthdate"];
                    if (birthdateValue != DBNull.Value)
                    {
                        DateTime birthdate = Convert.ToDateTime(birthdateValue);
                        txtbdate.Text = birthdate.ToString("yyyy-MM-dd");

                    }

                    drpgender.Text = reader["gender"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    drpjoblevel.Text = reader["jobLevel"].ToString();


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


                        // Insert updated education records
                        foreach (DataRow row in dtEducation.Rows)
                        {
                            string insertQuery = "INSERT INTO Resume (student_accID, edDegree, edNameOfSchool, edGraduationDate)" +
                                                 "VALUES (@studentAcctID, @Degree, @School, @GradDate)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, db);
                            insertCmd.Parameters.AddWithValue("@studentAcctID", studentAcctID);
                            insertCmd.Parameters.AddWithValue("@Degree", row["edDegree"].ToString());
                            insertCmd.Parameters.AddWithValue("@School", row["edNameOfSchool"].ToString());
                            insertCmd.Parameters.AddWithValue("@GradDate", row["edGraduationDate"].ToString());
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

        protected void clndrbdate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void txtbdate_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(txtbdate.Text) >= DateTime.Now.Date)
            {
                labelbdate.Visible = true;
                labelbdate.Text = "The selected birth date must be a past date.";
            }

            else
            {
                labelbdate.Visible = false;
            }
            
            
        }
    }
}