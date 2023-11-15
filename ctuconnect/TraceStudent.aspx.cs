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
    public partial class TraceStudent : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl traceStudentLink = (HtmlControl)Master.FindControl("traceStudent");
            traceStudentLink.Attributes.Add("class", "active");
            BindInternList();
        }
        void BindInternList()
        {
            SqlCommand cmd = new SqlCommand("select * from STUDENT_ACCOUNT JOIN HIRED_LIST ON STUDENT_ACCOUNT.student_accID = HIRED_LIST.student_accID JOIN PROGRAM ON STUDENT_ACCOUNT.course_ID = PROGRAM.course_ID", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            InternListView.DataSource = ds;
            InternListView.DataBind();
            if (InternListView.Items.Count == 0)
            {
              /*  ListViewPager.Visible = false;*/
            }
        }
    }
}