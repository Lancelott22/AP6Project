using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class MyAccount1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            disp_name.Text = Session["FNAME"].ToString() + " " + Session["INITIAL"].ToString()+ ". " + Session["LNAME"].ToString();
            


            
        }
    }
}