using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ctuconnect
{
    public partial class PartneredIndustries : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
            if (!IsPostBack)
            {
                string imagePath = "~/images/OJTCoordinatorProfile/" + Session["Coord_Picture"].ToString();
                CoordinatorImage.ImageUrl = imagePath;
                /*if (Session["Coor_ACC_ID"] != null)
                {
                    // Retrieve the coordinator_accID from the session
                    *//*BindGridView1();*//*
                }
                else
                {
                    // Handle the case where the user is not logged in or doesn't have a coordinator_accID.
                }*/


                BindTable();
            }

            }
        void BindTable()
        {

            string query = "SELECT INDUSTRY_ACCOUNT.industryName, INDUSTRY_ACCOUNT.location, CONTACT_PERSON.fName + ' ' + CONTACT_PERSON.LNAme AS contactPerson, CONTACT_PERSON.contactNumber, CONTACT_PERSON.contactEmail " +
            "FROM INDUSTRY_ACCOUNT  JOIN CONTACT_PERSON ON INDUSTRY_ACCOUNT.industry_accID = CONTACT_PERSON.industry_accID ORDER BY INDUSTRY_ACCOUNT.industry_accID DESC ";
            SqlCommand cmd = new SqlCommand(query, conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the DataTable to the GridView
            dataRepeater.DataSource = ds;
            dataRepeater.DataBind();

        }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }
    }
}