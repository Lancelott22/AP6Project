using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] != null)
            {
                back.HRef = "CoordinatorProfile.aspx";
            }
            else if(!IsPostBack && Session["AdminUsername"] != null)
            {
                back.HRef = "AdminDashboard.aspx";
            }
        }
    }
}