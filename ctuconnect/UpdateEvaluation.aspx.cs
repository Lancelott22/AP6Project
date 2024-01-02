using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class UpdateEvaluation : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //database connection

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Call the UpdateProductivity method when the "Save" button is clicked
                UpdateProductivity();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                // For example, you can log it using ILogger
                // logger.LogError(ex, "An error occurred while updating productivity.");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Handle cancel button click if needed
        }

        private void UpdateProductivity()
        {
            try
            {
                string prod1 = txtProd1.Text;
                string prod2 = txtProd2.Text;
                string prod3 = txtProd3.Text;
                string prod4 = txtProd4.Text;
                string prod5 = txtProd5.Text;
                int categoryID = 1;

                using (conDB)
                {
                    conDB.Open();
                    using (var cmd = conDB.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE CATEGORYDETAILS SET "
                            + "categoryDetail12 = @Prod1,"
                            + "categoryDetail34 = @Prod2,"
                            + "categoryDetail56 = @Prod3,"
                            + "categoryDetail78 = @Prod4,"
                            + "categoryDetail910 = @Prod5 "
                            + "WHERE category_ID = @CategoryID";

                        // Use parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Prod1", prod1);
                        cmd.Parameters.AddWithValue("@Prod2", prod2);
                        cmd.Parameters.AddWithValue("@Prod3", prod3);
                        cmd.Parameters.AddWithValue("@Prod4", prod4);
                        cmd.Parameters.AddWithValue("@Prod5", prod5);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                        var ctr = cmd.ExecuteNonQuery();

                        // Check if the update was successful
                        if (ctr > 0)
                        {
                            Response.Write("<script>alert('Evaluation Updated!');document.location='EditEvaluation.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Evaluation Updated!');document.location='UpdateEvaluation.aspx'</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                // For example, you can log it using ILogger
                //logger.LogError(ex, "An error occurred while updating productivity.");
                throw; // Re-throw the exception to the calling method
            }
        }
    }
}
