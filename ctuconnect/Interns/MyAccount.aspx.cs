using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ctuconnect
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Session["Acc_ID"] as string;
            string first = Session["FNAME"] as string;
            string mid = Session["INITIAL"] as string;
            string last = Session["LNAME"] as string;
            string status = Session["STATUS"] as string;
            string picture = Session["PROFILE"] as string;
            string accId = id;
            string fname = first.ToUpper();
            string mname = mid.ToUpper();
            string lname = last.ToUpper();
            string studstatus = status.ToUpper();
            string studpicture = picture;


            disp_name.Text = lname + ", " + fname + " " + mname;

        }
    }
}