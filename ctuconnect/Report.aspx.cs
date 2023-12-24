using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ctuconnect
{
    public partial class Report : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);

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
                BindIndustry();
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginStudent.aspx");

        }
        void BindIndustry()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM INDUSTRY_ACCOUNT", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            industry.DataSource = ds;
            industry.DataValueField = "industry_accID";
            industry.DataTextField = "industryName";
            industry.DataBind();
            industry.Items.Insert(0, new ListItem("Select Industry", "0"));
        }
        protected void SubmitReport_Click(object sender, EventArgs e)
        {
            if (industry.SelectedIndex == 0 || string.IsNullOrEmpty(reasonTxt.Value))
            {
                Response.Write("<script>alert('Please fill up the required field.')</script>");
            }
            else { 
              
                int industry_accID = int.Parse(industry.SelectedValue);
                int student_accID = int.Parse(Session["Student_ACC_ID"].ToString());
                string reason = reasonTxt.Value;
                string status = "Open";
                conDB.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DISPUTE (industry_accID, student_accID, reason,dateAdded, status) " +
                        "Values(@industry_accID, @student_accID, @reason, @dateAdded, @status)", conDB);
                cmd.Parameters.AddWithValue("@industry_accID", industry_accID);
                cmd.Parameters.AddWithValue("@student_accID", student_accID);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@status", status);

                var ctr = cmd.ExecuteNonQuery();
                if (ctr > 0)
                {
                    Response.Write("<script>alert('The report has been submitted successfully');document.location='Report.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Cannot submit a report right now! Please try again later.')</script>");
                }
                conDB.Close();
            }
        }
    }
}