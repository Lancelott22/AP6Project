using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;



namespace ctuconnect
{
    public partial class IndustryVerification : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            bindIndustryAccount();
        }
        void bindIndustryAccount()
        {
            SqlCommand cmd = new SqlCommand("select *, case when isVerified = 1 then 'Verified' else 'Not Verified' end as Verify, case when isDeactivated = 1 then 'Deactivated' else 'Active' end as Deactivate from INDUSTRY_ACCOUNT", conDB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            IndustryListView.DataSource = ds;
            IndustryListView.DataBind();
            if (IndustryListView.Items.Count == 0)
            {
                /*  ListViewPager.Visible = false;*/
            }
        }
        protected void Verify_Command(object sender, CommandEventArgs e)
        {
            int industry_accID = int.Parse(e.CommandArgument.ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("UPDATE INDUSTRY_ACCOUNT SET isVerified = 1 where industry_accID = '" + industry_accID + "'", conDB);
            var ctr = cmd.ExecuteNonQuery();

            if (ctr > 0)
            {
                Response.Write("<script>alert('Industry has been successfully verified.')</script>");
            }
            else
            {
                Response.Write("<script>alert('Cannot verify the account now! Please try again later.')</script>");
            }
            conDB.Close();
        }

        protected void ViewMou_Command(object sender, CommandEventArgs e)
        {

            string mouFile = e.CommandArgument.ToString();

            // Retrieve and display the mou file
            byte[] mouFileData = getMouFileData(mouFile);


            if (mouFileData != null)
            {
                // Provide the file data for download in a new browser tab
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf"; // Set the appropriate content type
                Response.AddHeader("content-disposition", "inline; filename=mou.pdf"); // Open in a new tab
                Response.BinaryWrite(mouFileData);
                Response.End();
            }
        }
        private byte[] getMouFileData(string mouFile)
        {
            using (conDB)
            {
                string query = "SELECT mou FROM INDUSTRY_ACCOUNT WHERE mou = @mouFile";
                SqlCommand cmd = new SqlCommand(query, conDB);
                cmd.Parameters.AddWithValue("@mouFile", mouFile);

                conDB.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Assuming that the result is a file path, read the file content
                    string fileName = result.ToString();
                    string filePath = "~/images/MOU/" + fileName; // Construct the path
                    byte[] fileData = System.IO.File.ReadAllBytes(Server.MapPath(filePath));
                    return fileData;
                }

                return null; // No file found
            }
        }
        protected void IndustryListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HtmlGenericControl industryID = (HtmlGenericControl)e.Item.FindControl("industryID");
            int industry_accID = int.Parse(industryID.InnerText);
            LinkButton verifyBtn = e.Item.FindControl("Verify") as LinkButton;
            LinkButton activateBtn = e.Item.FindControl("Deactivate") as LinkButton;
            if (checkIsVerified(industry_accID) == true)
            {
                verifyBtn.Text = "Verified";
                verifyBtn.Enabled = false;
                verifyBtn.CssClass = "btn btn-success";
                verifyBtn.OnClientClick = "";
            }
            else
            {
                verifyBtn.Text = "Verify";
            }
            if (checkIsDeactivated(industry_accID) == true)
            {
                activateBtn.Text = "Activate";
                activateBtn.CssClass = "btn btn-success";
                activateBtn.CommandName = "Activate";
                activateBtn.CommandArgument = industry_accID.ToString();
            }
            else
            {
                activateBtn.Text = "Deactivate";
                activateBtn.CssClass = "btn btn-danger";
                activateBtn.CommandName = "Deactivate";
                activateBtn.CommandArgument = industry_accID.ToString();
            }
        }
        bool checkIsVerified(int industryID)
        {
            int selectedIndustryID = industryID;
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select isVerified from INDUSTRY_ACCOUNT Where industry_accID = @industry_accID", conDB);
            cmd.Parameters.AddWithValue("@industry_accID", selectedIndustryID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (bool.Parse(reader["isVerified"].ToString()) == true)
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }

            }
            conDB.Close();
            return false;

        }
        bool checkIsDeactivated(int industryID)
        {
            int selectedIndustryID = industryID;
            conDB.Open();
            SqlCommand cmd = new SqlCommand("Select isDeactivated from INDUSTRY_ACCOUNT Where industry_accID = @industry_accID", conDB);
            cmd.Parameters.AddWithValue("@industry_accID", selectedIndustryID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (bool.Parse(reader["isDeactivated"].ToString()) == true)
                {
                    reader.Close();
                    conDB.Close();
                    return true;
                }

            }
            conDB.Close();
            return false;

        }
        protected void Deactivate_Command(object sender, CommandEventArgs e)
        {
            string deactivate = e.CommandName.ToString();
            int num = -1;
            int industry_accID = int.Parse(e.CommandArgument.ToString());

            if (deactivate == "Activate")
            {
                num = 0;
            }
            else if (deactivate == "Deactivate")
            {
                num = 1;
            }
            conDB.Open();
            SqlCommand cmd = new SqlCommand("UPDATE INDUSTRY_ACCOUNT SET isDeactivated = '" + num + "' where industry_accID = '" + industry_accID + "'", conDB);
            var ctr = cmd.ExecuteNonQuery();

            if (ctr > 0)
            {
                Response.Write("<script>alert('Industry has been successfully "+ deactivate + "d.')</script>");
            }
            else
            {
                Response.Write("<script>alert('Cannot deactivate the account now! Please try again later.')</script>");
            }
            conDB.Close();
        }
    }
}