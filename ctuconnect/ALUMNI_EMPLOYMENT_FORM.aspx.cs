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

namespace ctuconnect
{
    public partial class ALUMNI_EMPLOYMENT_FORM : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["StudentEmail"] == null)
            {  
                 Response.Redirect("LoginStudent.aspx");               
            }else if(!IsPostBack && Session["StudentEmail"] != null && Session["STATUSorTYPE"].ToString() != "Alumni")
            {
                Response.Redirect("JobPortal.aspx");
            }
            if (!IsPostBack)
            {
                HtmlGenericControl navBar = (HtmlGenericControl)Master.FindControl("navvbar");
                navBar.Attributes["class"] = "d-none";             
            }
            if(!IsPostBack && checkIfAnswered())
            {
                Save.Text = "Update";
                Save.CssClass = "btn btn-success";
                getDetails();
            }
            else
            {
                Save.Text = "Save";
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
           
                int student_accID = int.Parse(Session["Student_ACC_ID"].ToString());
                string employmentStatus = EmploymentStatus.SelectedValue;
                string companyName = txtCompanyOrBusinessName.Text;
                string department = txtDepartment.Text;
                string position = txtPosition.Text;
                string typeOfEmployment = TypeOfEmployment.SelectedValue;
                string salary = SalaryRange.SelectedValue;
                string dateHired = txtDateHired.Text;
                string isConnectedtoCourse = ConnectedToCourse.SelectedValue;
                string isAlignedToSkills = AlignedToSkills.SelectedValue;
                
                if (string.IsNullOrEmpty(employmentStatus) || string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(department) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(typeOfEmployment) || string.IsNullOrEmpty(salary) || string.IsNullOrEmpty(dateHired) || string.IsNullOrEmpty(isConnectedtoCourse) || string.IsNullOrEmpty(isAlignedToSkills))
                {
                    Response.Write("<script>alert('Please fill up all the field.')</script>");
                }
                else
                {
                    if (Save.Text == "Save")
                    {
                        conDB.Open();

                        SqlCommand cmd = new SqlCommand("INSERT INTO ALUMNI_EMPLOYMENTFORM( student_accID, employmentStatus, CompanyOrBusinessName, Department, Position, " +
                            "TypeOfEmployement, SalaryRange, DateHired, isConnectedToCourse,isAlignedToSkill) " +
                            "VALUES(@student_accID, @employmentStatus, @CompanyOrBusinessName,@Department,@Position,@TypeOfEmployement,@SalaryRange, @DateHired,@isConnectedToCourse, @isAlignedToSkill)", conDB);
                        cmd.Parameters.AddWithValue("@student_accID", student_accID);
                        cmd.Parameters.AddWithValue("@employmentStatus", employmentStatus);
                        cmd.Parameters.AddWithValue("@CompanyOrBusinessName", companyName);
                        cmd.Parameters.AddWithValue("@Department", department);
                        cmd.Parameters.AddWithValue("@Position", position);
                        cmd.Parameters.AddWithValue("@TypeOfEmployement", typeOfEmployment);
                        cmd.Parameters.AddWithValue("@SalaryRange", salary);
                        cmd.Parameters.AddWithValue("@DateHired", dateHired);
                        cmd.Parameters.AddWithValue("@isConnectedToCourse", isConnectedtoCourse);
                        cmd.Parameters.AddWithValue("@isAlignedToSkill", isAlignedToSkills);
                        var ctr = cmd.ExecuteNonQuery();

                        if (ctr > 0)
                        {
                            cmd = new SqlCommand("UPDATE STUDENT_ACCOUNT SET isAnsweredAlumniForm = 1 WHERE student_accID = '" + student_accID + "'", conDB);
                            cmd.ExecuteNonQuery();
                            Response.Write("<script>alert('The form has been submitted successfully.');document.location='JobPortal.aspx';</script>");

                        }
                        else
                        {
                            Response.Write("<script>alert('Cannot submit a form now! Please try again later.')</script>");
                        }
                        conDB.Close();
                    }
                }
            
          
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            if(!checkIfAnswered())
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("LoginStudent.aspx");
            }else
            {
                Response.Redirect("JobPortal.aspx");
            }
                 
        }
        bool checkIfAnswered()
        {
                
                int student_accID = int.Parse(Session["Student_ACC_ID"].ToString());
                string query = "SELECT isAnsweredAlumniForm FROM STUDENT_ACCOUNT WHERE student_accID = '" + student_accID + "' ";
                SqlCommand command = new SqlCommand(query, conDB);
                conDB.Open();
                SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (bool.Parse(reader["isAnsweredAlumniForm"].ToString()) == true)
                {
                    reader.Close();
                    conDB.Close();
                    return true;

                }
            }
            conDB.Close();
            reader.Close();
            return false;
        }
        protected void EmploymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EmploymentStatus.SelectedValue == "Employed")
            {
               
                txtCompanyOrBusinessName.ReadOnly = false;              
                txtDepartment.ReadOnly = false;   
                txtPosition.ReadOnly = false;      
                TypeOfEmployment.Enabled = true;   
                SalaryRange.Enabled = true;     
                txtDateHired.ReadOnly = false;
                ConnectedToCourse.Enabled = true;
                AlignedToSkills.Enabled = true;
                txtCompanyOrBusinessName.Text = string.Empty;
                txtDepartment.Text = string.Empty;
                txtPosition.Text = string.Empty;
                TypeOfEmployment.SelectedValue = "Fulltime";
                SalaryRange.SelectedValue = "Minimum";
                txtDateHired.Text = string.Empty;
                ConnectedToCourse.SelectedValue = "N/A";
                AlignedToSkills.SelectedValue = "N/A";
            }
            else if (EmploymentStatus.SelectedValue == "Not Employed")
            {
                txtCompanyOrBusinessName.Text = "N/A";
                txtCompanyOrBusinessName.ReadOnly = true;
                txtDepartment.Text = "N/A";
                txtDepartment.ReadOnly = true;
                txtPosition.Text = "N/A";
                txtPosition.ReadOnly = true;
                TypeOfEmployment.SelectedValue = "N/A";
                TypeOfEmployment.Enabled = false;
                SalaryRange.SelectedValue = "N/A";
                SalaryRange.Enabled = false;
                txtDateHired.Text = "N/A";
                txtDateHired.ReadOnly = true;
                ConnectedToCourse.SelectedValue = "N/A";
                ConnectedToCourse.Enabled = false;
                AlignedToSkills.SelectedValue = "N/A";
                AlignedToSkills.Enabled = false;
            }
            else if (EmploymentStatus.SelectedValue == "Self-Employed")
            {
                txtCompanyOrBusinessName.ReadOnly = false;
                txtCompanyOrBusinessName.Text = string.Empty;
                txtPosition.ReadOnly = false;
                txtPosition.Text = string.Empty;
                TypeOfEmployment.Enabled = true;
                TypeOfEmployment.SelectedValue = "Fulltime";
                SalaryRange.Enabled = true;
                SalaryRange.SelectedValue = "Minimum";
                txtDepartment.Text = "N/A";
                txtDepartment.ReadOnly = true;
                txtDateHired.Text = "N/A";
                txtDateHired.ReadOnly = true;
                ConnectedToCourse.SelectedValue = "N/A";
                ConnectedToCourse.Enabled = false;
                AlignedToSkills.SelectedValue = "N/A";
                AlignedToSkills.Enabled = false;

            }
        }
        void getDetails()
        {
            int student_accID = int.Parse(Session["Student_ACC_ID"].ToString());
            string query = "SELECT * FROM ALUMNI_EMPLOYMENTFORM WHERE student_accID = '" + student_accID + "'";
            SqlCommand command = new SqlCommand(query, conDB);
            conDB.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                EmploymentStatus.SelectedValue = reader["employmentStatus"].ToString();
                txtCompanyOrBusinessName.Text = reader["CompanyOrBusinessName"].ToString();
                txtDepartment.Text = reader["Department"].ToString();
                txtPosition.Text = reader["Position"].ToString();
                TypeOfEmployment.SelectedValue = reader["TypeOfEmployement"].ToString();
                SalaryRange.SelectedValue = reader["SalaryRange"].ToString();
                txtDateHired.Text = reader["DateHired"].ToString();
                ConnectedToCourse.SelectedValue = reader["isConnectedToCourse"].ToString();
                AlignedToSkills.SelectedValue = reader["isAlignedToSkill"].ToString();
            }
            reader.Close();
            conDB.Close();
        }
    }
}