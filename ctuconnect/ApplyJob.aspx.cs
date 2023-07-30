using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class ApplyJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clndrdate.Visible = false;
            }

        }

        protected void clndrbdate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }
        protected void clndrbdate_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = clndrdate.SelectedDate.ToShortDateString();
            clndrdate.Visible = false;

        }

        protected void imgbtncldr_Click(object sender, ImageClickEventArgs e)
        {
            if (clndrdate.Visible)
                clndrdate.Visible = false;
            else
                clndrdate.Visible = true;
        }
    }
}