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
using static iTextSharp.tool.xml.html.HTML;

namespace ctuconnect
{
    public partial class UpdateEvaluation : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //database connection

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProductivity();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
                string prod1 = txtProd1.Text;
                string prod2 = txtProd2.Text;
                string prod3 = txtProd3.Text;
                string prod4 = txtProd4.Text;
                string prod5 = txtProd5.Text;

                string coop1 = txtCoop1.Text;
                string coop2 = txtCoop2.Text;
                string coop3 = txtCoop3.Text;
                string coop4 = txtCoop4.Text;
                string coop5 = txtCoop5.Text;

                string abilityF1 = txtAbilityF1.Text;
                string abilityF2 = txtAbilityF2.Text;
                string abilityF3 = txtAbilityF3.Text;
                string abilityF4 = txtAbilityF4.Text;
                string abilityF5 = txtAbilityF5.Text;

                string abilityG1 = txtAbilityG1.Text;
                string abilityG2 = txtAbilityG2.Text;
                string abilityG3 = txtAbilityG3.Text;
                string abilityG4 = txtAbilityG4.Text;
                string abilityG5 = txtAbilityG5.Text;

                string init1 = txtInit1.Text;
                string init2 = txtInit2.Text;
                string init3 = txtInit3.Text;
                string init4 = txtInit4.Text;
                string init5 = txtInit5.Text;

                string attend1 = txtAttend1.Text;
                string attend2 = txtAttend2.Text;
                string attend3 = txtAttend3.Text;
                string attend4 = txtAttend4.Text;
                string attend5 = txtAttend5.Text;

                string qual1 = txtQual1.Text;
                string qual2 = txtQual2.Text;
                string qual3 = txtQual3.Text;
                string qual4 = txtQual4.Text;
                string qual5 = txtQual5.Text;

                string appear1 = txtAppear1.Text;
                string appear2 = txtAppear2.Text;
                string appear3 = txtAppear3.Text;
                string appear4 = txtAppear4.Text;
                string appear5 = txtAppear5.Text;

                string depend1 = txtDepend1.Text;
                string depend2 = txtDepend2.Text;
                string depend3 = txtDepend3.Text;
                string depend4 = txtDepend4.Text;
                string depend5 = txtDepend5.Text;

                string overall1 = txtOverall1.Text;
                string overall2 = txtOverall2.Text;
                string overall3 = txtOverall3.Text;
                string overall4 = txtOverall4.Text;
                string overall5 = txtOverall5.Text;

                int categoryID1 = 1;
                int categoryID2 = 2;
                int categoryID3 = 3;
                int categoryID4 = 4;
                int categoryID5 = 5;
                int categoryID6 = 6;
                int categoryID7 = 7;
                int categoryID8 = 8;
                int categoryID9 = 9;
                int categoryID10 = 10;
                // Call the UpdateProductivity method when the "Save" button is clicked
                UpdateCategoryDetails(prod1, prod2, prod3, prod4, prod5, categoryID1, coop1, coop2, coop3, coop4, coop5,
                categoryID2, abilityF1, abilityF2, abilityF3, abilityF4, abilityF5, categoryID3, abilityG1, abilityG2,
                abilityG3, abilityG4, abilityG5, categoryID4, init1, init2, init3, init4, init5, categoryID5, attend1,
                attend2, attend3, attend4, attend5, categoryID6, qual1, qual2, qual3, qual4, qual5, categoryID7, appear1,
                appear2, appear3, appear4, appear5, categoryID8, depend1, depend2, depend3, depend4, depend5, categoryID9,
                overall1, overall2, overall3, overall4, overall5, categoryID10);
            
            
        }
        private void UpdateCategoryDetails(string prod1, string prod2, string prod3, string prod4, string prod5, int categoryID1,
        string coop1, string coop2, string coop3, string coop4, string coop5, int categoryID2,
        string abilityF1, string abilityF2, string abilityF3, string abilityF4, string abilityF5, int categoryID3,
        string abilityG1, string abilityG2, string abilityG3, string abilityG4, string abilityG5, int categoryID4,
        string init1, string init2, string init3, string init4, string init5, int categoryID5,
        string attend1, string attend2, string attend3, string attend4, string attend5, int categoryID6,
        string qual1, string qual2, string qual3, string qual4, string qual5, int categoryID7,
        string appear1, string appear2, string appear3, string appear4, string appear5, int categoryID8,
        string depend1, string depend2, string depend3, string depend4, string depend5, int categoryID9,
        string overall1, string overall2, string overall3, string overall4, string overall5, int categoryID10)
        {
            try
            {
                using (conDB)
                {
                    conDB.Open();
                    using (var cmd = conDB.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"
                                        UPDATE Category_Details 
                                        SET 
                                            categoryDetail12 = CASE category_ID 
                                                WHEN @CategoryID1 THEN @Prod1 
                                                WHEN @CategoryID2 THEN @Coop1 
                                                WHEN @CategoryID3 THEN @AbilityF1 
                                                WHEN @CategoryID4 THEN @AbilityG1 
                                                WHEN @CategoryID5 THEN @Init1 
                                                WHEN @CategoryID6 THEN @Attend1 
                                                WHEN @CategoryID7 THEN @Qual1 
                                                WHEN @CategoryID8 THEN @Appear1 
                                                WHEN @CategoryID9 THEN @Depend1 
                                                WHEN @CategoryID10 THEN @Overall1 
                                            END,
                                            categoryDetail34 = CASE category_ID 
                                                WHEN @CategoryID1 THEN @Prod2 
                                                WHEN @CategoryID2 THEN @Coop2 
                                                WHEN @CategoryID3 THEN @AbilityF2 
                                                WHEN @CategoryID4 THEN @AbilityG2 
                                                WHEN @CategoryID5 THEN @Init2 
                                                WHEN @CategoryID6 THEN @Attend2 
                                                WHEN @CategoryID7 THEN @Qual2 
                                                WHEN @CategoryID8 THEN @Appear2 
                                                WHEN @CategoryID9 THEN @Depend2 
                                                WHEN @CategoryID10 THEN @Overall2 
                                            END,
                                          categoryDetail56 = CASE category_ID 
                                              WHEN @CategoryID1 THEN @Prod3 
                                              WHEN @CategoryID2 THEN @Coop3 
                                              WHEN @CategoryID3 THEN @AbilityF3 
                                              WHEN @CategoryID4 THEN @AbilityG3
                                              WHEN @CategoryID5 THEN @Init3 
                                              WHEN @CategoryID6 THEN @Attend3 
                                              WHEN @CategoryID7 THEN @Qual3
                                              WHEN @CategoryID8 THEN @Appear3 
                                              WHEN @CategoryID9 THEN @Depend3 
                                              WHEN @CategoryID10 THEN @Overall3 
                                          END, 
                                          categoryDetail78 = CASE category_ID 
                                              WHEN @CategoryID1 THEN @Prod4 
                                              WHEN @CategoryID2 THEN @Coop4 
                                              WHEN @CategoryID3 THEN @AbilityF4 
                                              WHEN @CategoryID4 THEN @AbilityG4 
                                              WHEN @CategoryID5 THEN @Init4 
                                              WHEN @CategoryID6 THEN @Attend4 
                                              WHEN @CategoryID7 THEN @Qual4 
                                              WHEN @CategoryID8 THEN @Appear4 
                                              WHEN @CategoryID9 THEN @Depend4 
                                              WHEN @CategoryID10 THEN @Overall4 
                                          END, 
                                          categoryDetail910 = CASE category_ID 
                                              WHEN @CategoryID1 THEN @Prod5 
                                              WHEN @CategoryID2 THEN @Coop5 
                                              WHEN @CategoryID3 THEN @AbilityF5
                                              WHEN @CategoryID4 THEN @AbilityG5 
                                              WHEN @CategoryID5 THEN @Init5 
                                              WHEN @CategoryID6 THEN @Attend5 
                                              WHEN @CategoryID7 THEN @Qual5 
                                              WHEN @CategoryID8 THEN @Appear5 
                                              WHEN @CategoryID9 THEN @Depend5 
                                              WHEN @CategoryID10 THEN @Overall5 
                                          END 
                                          WHERE category_ID IN (@CategoryID1, @CategoryID2, @CategoryID3, @CategoryID4, @CategoryID5, @CategoryID6, @CategoryID7, @CategoryID8, @CategoryID9, @CategoryID10)";

                        // Use parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Prod1", prod1);
                        cmd.Parameters.AddWithValue("@Prod2", prod2);
                        cmd.Parameters.AddWithValue("@Prod3", prod3);
                        cmd.Parameters.AddWithValue("@Prod4", prod4);
                        cmd.Parameters.AddWithValue("@Prod5", prod5);
                        cmd.Parameters.AddWithValue("@CategoryID1", categoryID1);

                        cmd.Parameters.AddWithValue("@Coop1", coop1);
                        cmd.Parameters.AddWithValue("@Coop2", coop2);
                        cmd.Parameters.AddWithValue("@Coop3", coop3);
                        cmd.Parameters.AddWithValue("@Coop4", coop4);
                        cmd.Parameters.AddWithValue("@Coop5", coop5);
                        cmd.Parameters.AddWithValue("@CategoryID2", categoryID2);

                        cmd.Parameters.AddWithValue("@AbilityF1", abilityF1);
                        cmd.Parameters.AddWithValue("@AbilityF2", abilityF2);
                        cmd.Parameters.AddWithValue("@AbilityF3", abilityF3);
                        cmd.Parameters.AddWithValue("@AbilityF4", abilityF4);
                        cmd.Parameters.AddWithValue("@AbilityF5", abilityF5);
                        cmd.Parameters.AddWithValue("@CategoryID3", categoryID3);

                        cmd.Parameters.AddWithValue("@AbilityG1", abilityG1);
                        cmd.Parameters.AddWithValue("@AbilityG2", abilityG2);
                        cmd.Parameters.AddWithValue("@AbilityG3", abilityG3);
                        cmd.Parameters.AddWithValue("@AbilityG4", abilityG4);
                        cmd.Parameters.AddWithValue("@AbilityG5", abilityG5);
                        cmd.Parameters.AddWithValue("@CategoryID4", categoryID4);

                        cmd.Parameters.AddWithValue("@Init1", init1);
                        cmd.Parameters.AddWithValue("@Init2", init2);
                        cmd.Parameters.AddWithValue("@Init3", init3);
                        cmd.Parameters.AddWithValue("@Init4", init4);
                        cmd.Parameters.AddWithValue("@Init5", init5);
                        cmd.Parameters.AddWithValue("@CategoryID5", categoryID5);

                        cmd.Parameters.AddWithValue("@Attend1", attend1);
                        cmd.Parameters.AddWithValue("@Attend2", attend2);
                        cmd.Parameters.AddWithValue("@Attend3", attend3);
                        cmd.Parameters.AddWithValue("@Attend4", attend4);
                        cmd.Parameters.AddWithValue("@Attend5", attend5);
                        cmd.Parameters.AddWithValue("@CategoryID6", categoryID6);

                        cmd.Parameters.AddWithValue("@Qual1", qual1);
                        cmd.Parameters.AddWithValue("@Qual2", qual2);
                        cmd.Parameters.AddWithValue("@Qual3", qual3);
                        cmd.Parameters.AddWithValue("@Qual4", qual4);
                        cmd.Parameters.AddWithValue("@Qual5", qual5);
                        cmd.Parameters.AddWithValue("@CategoryID7", categoryID7);

                        cmd.Parameters.AddWithValue("@Appear1", appear1);
                        cmd.Parameters.AddWithValue("@Appear2", appear2);
                        cmd.Parameters.AddWithValue("@Appear3", appear3);
                        cmd.Parameters.AddWithValue("@Appear4", appear4);
                        cmd.Parameters.AddWithValue("@Appear5", appear5);
                        cmd.Parameters.AddWithValue("@CategoryID8", categoryID8);

                        cmd.Parameters.AddWithValue("@Depend1", depend1);
                        cmd.Parameters.AddWithValue("@Depend2", depend2);
                        cmd.Parameters.AddWithValue("@Depend3", depend3);
                        cmd.Parameters.AddWithValue("@Depend4", depend4);
                        cmd.Parameters.AddWithValue("@Depend5", depend5);
                        cmd.Parameters.AddWithValue("@CategoryID9", categoryID9);

                        cmd.Parameters.AddWithValue("@Overall1", overall1);
                        cmd.Parameters.AddWithValue("@Overall2", overall2);
                        cmd.Parameters.AddWithValue("@Overall3", overall3);
                        cmd.Parameters.AddWithValue("@Overall4", overall4);
                        cmd.Parameters.AddWithValue("@Overall5", overall5);
                        cmd.Parameters.AddWithValue("@CategoryID10", categoryID10);

                        var ctr = cmd.ExecuteNonQuery();

                        // Check if the update was successful
                        if (ctr > 0)
                        {
                            Response.Write("<script>alert('Evaluation Updated!');document.location='EditEvaluation.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('There's something wrong while updating the Evaluation!');document.location='UpdateEvaluation.aspx'</script>");
                        }
                    }
                }
            }
            catch
            {
               
                throw; // Re-throw the exception to the calling method
            }
        }
        void GetProductivity()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 1;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtProd1.Text = reader["categoryDetail12"].ToString();
                    txtProd2.Text = reader["categoryDetail34"].ToString();
                    txtProd3.Text = reader["categoryDetail56"].ToString();
                    txtProd4.Text = reader["categoryDetail78"].ToString();
                    txtProd5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }
        void GetCooperation()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString); //databse connection
            int category_ID = 2;
            using (con)
            {
                con.Open();
                string query = "SELECT categoryDetail12, categoryDetail34, categoryDetail56, categoryDetail78, categoryDetail910 FROM CATEGORY_DETAILS WHERE category_ID = '" + category_ID + "'";

                SqlCommand command = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtCoop1.Text = reader["categoryDetail12"].ToString();
                    txtCoop2.Text = reader["categoryDetail34"].ToString();
                    txtCoop3.Text = reader["categoryDetail56"].ToString();
                    txtCoop4.Text = reader["categoryDetail78"].ToString();
                    txtCoop5.Text = reader["categoryDetail910"].ToString();
                }
                con.Close();
                reader.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Handle cancel button click if needed
            Response.Redirect("EditEvaluation");
        }


    }
}
