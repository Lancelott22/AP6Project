using System;
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
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["StudentEmail"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
            if (!IsPostBack)
            {
                LoadSuggestions();
            }
        }

        private void LoadSuggestions()
        {
            using (conDB)
            {
                conDB.Open();
                using (var cmd = conDB.CreateCommand())
                {
                    // SQL Statement to retrieve suggestions
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT suggestion, dateCreated FROM SUGGESTIONS WHERE isRemove = 0 ORDER BY dateCreated DESC";

                    using (var reader = cmd.ExecuteReader())
                    {
                        rptSuggestions.DataSource = reader;
                        rptSuggestions.DataBind();
                    }
                }
            }
        }
        protected void Submit_Suggestions(object sender, EventArgs e)
        {
            int studentAccID = Convert.ToInt32(Session["Student_ACC_ID"]);
            string suggestions= txtsuggestion.Text;

            using (conDB)
            {
                conDB.Open();
                using (var cmd = conDB.CreateCommand())
                {
                    //SQL Statement
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO SUGGESTIONS (student_accID, suggestion, dateCreated, isRead, isRemove ) " +
                                          "VALUES (@student_accID, @suggestion, @dateCreated, @isRead, @isRemove)";

                    cmd.Parameters.AddWithValue("@student_accID", studentAccID);
                    cmd.Parameters.AddWithValue("@suggestion", suggestions);
                    cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now.ToString("yyyy/MM/dd"));
                    cmd.Parameters.AddWithValue("@isRead", 0);
                    cmd.Parameters.AddWithValue("@isRemove", 0);
                    cmd.ExecuteNonQuery();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('show');", true);
            }

        }
        protected void Close_SuccessPrompt(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#SuccessPrompt').modal('hide');document.location='Home.aspx'", true);
        }
    }
}