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
    public partial class SuggestionsAdmin : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}