using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;



namespace OnlineRecipeSharing
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private string connectionString;
        string category, searchtxt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["dbconnection"]?.ConnectionString))
                {
                    connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                    //BindDropdownlistCategory();
                    BindDataLv_Recipes();
                }
                else
                {
                    // Handle the case where the connection string is not found or empty
                    DisplayErrorMessage("Database connection string is not configured. Please contact the administrator.");
                }
            }
        }

        private void BindDataLv_Recipes()
        {
            try
            {

                using (SqlConnection dbconnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT recipe_id, RecipeTitle, CookingTime, image FROM Recipes";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, dbconnection);
                    DataTable recipeTable = new DataTable();
                    adapter.Fill(recipeTable);

                    Lv_Recipies.DataSource = recipeTable;
                    Lv_Recipies.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void DisplayErrorMessage(string message)
        {
            ErrorMessageLabel.Text = message;

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //category = ChooseCategory.SelectedItem.ToString();
            searchtxt = SearchTextBox.Text;
            int statusbit = 0;
            connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            try
            {

                using (SqlConnection dbconnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT recipe_id, RecipeTitle, CookingTime, image FROM Recipes ";
                    if (!string.IsNullOrEmpty(category) || !string.IsNullOrEmpty(searchtxt))
                    {
                        query += "where ";
                        if (!string.IsNullOrEmpty(category))
                        {
                            query += "[category] = '" + category + "'";
                            statusbit = 1;
                        }

                        if (!string.IsNullOrEmpty(searchtxt))
                        {
                            if (statusbit == 1)
                            {
                                query += " or [RecipeTitle] like '%" + searchtxt + "%' or [keywords] like '%" + searchtxt + "%'";
                            }
                            else
                            {
                                query += "[RecipeTitle] like '%" + searchtxt + "%' or [keywords] like '%" + searchtxt + "%'";
                            }


                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(query, dbconnection);
                    DataTable recipeTable = new DataTable();
                    adapter.Fill(recipeTable);

                    Lv_Recipies.DataSource = recipeTable;
                    Lv_Recipies.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, such as logging it or displaying an error message
                throw ex;
            }
        }
    }
}









