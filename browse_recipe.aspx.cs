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

        //private void BindDropdownlistCategory()
        //{
        //    try
        //    {
        //        using (SqlConnection dbconnection = new SqlConnection(connectionString))
        //        {
        //            string query = "SELECT * FROM Categories UNION SELECT* FROM MealTypes ";


        //            dbconnection.Open();
        //            SqlDataAdapter da = new SqlDataAdapter(query, dbconnection);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            if (dt.Rows.Count > 0)
        //            {
        //                ChooseCategory.DataSource = dt;
        //                ChooseCategory.DataTextField = "CategoryName";
        //                ChooseCategory.DataValueField = "CategoryID";
        //                ChooseCategory.DataBind();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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
                // Handle the exception appropriately, such as logging it or displaying an error message
                throw ex;
            }
        }


        private void DisplayErrorMessage(string message)
        {
            // You can display the error message to the user using a label or some other UI element
            ErrorMessageLabel.Text = message;

            // You can also log the error message for further investigation
            // Example: Logger.LogError(message);
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


       
    





