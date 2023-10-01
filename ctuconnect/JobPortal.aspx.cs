using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
namespace ctuconnect
{
    
    public partial class JobPortal : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                JobBind();
            }
        }
        void JobBind()
        {
            string studentCourse = "IT";
            /*SqlCommand cmd = new SqlCommand("select * from HIRING WHERE jobCourse = @studCourse", conDB);
            cmd.Parameters.AddWithValue("@studCourse", studentCourse);*/
            SqlCommand cmd = new SqlCommand("select * from HIRING", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            JobHiring.DataSource = ds;
            JobHiring.DataBind();
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }

        protected void ApplyJob_Click(object sender, EventArgs e)
        {

            string script = "$('#myModal').modal('show')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }
    }
}