using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ctuconnect
{
    public partial class TraceAlumni : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl traceAlumniLink = (HtmlControl)Master.FindControl("traceAlumni");
            traceAlumniLink.Attributes.Add("class", "active");
            BindAlumniList();
        }
        void BindAlumniList()
        {
            SqlCommand cmd = new SqlCommand("select * from ALUMNI_ACCOUNT JOIN HIRED_LIST ON ALUMNI_ACCOUNT.alumni_accID = HIRED_LIST.alumni_accID JOIN PROGRAM ON ALUMNI_ACCOUNT.course_ID = PROGRAM.course_ID", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            AlumniListView.DataSource = ds;
            AlumniListView.DataBind();
            if (AlumniListView.Items.Count == 0)
            {
                /*  ListViewPager.Visible = false;*/
            }
        }
    }
}