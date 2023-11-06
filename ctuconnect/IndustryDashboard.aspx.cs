using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class IndustryDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");

            }
            else
            {
                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;

            }

            IndName.Text = Session["INDUSTRYNAME"].ToString();
            IndName.Enabled = false;
            jobLoc.Text = Session["LOCATION"].ToString();
            jobLoc.Enabled = false;
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");

        }
    }
}