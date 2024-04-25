using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind data to ListView
                BindDataLv_Recipes();
            }
        }

        private void BindDataLv_Recipes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "SELECT TOP 20 recipe_id, RecipeTitle, CookingTime, image, Category FROM Recipes ORDER BY recipe_id DESC";
            List<Recipe> recipeList = new List<Recipe>();

            using (SqlConnection dbconnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, dbconnection))
                {
                    dbconnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Recipe recipe = new Recipe();
                        recipe.Id = Convert.ToInt32(reader["recipe_id"]);
                        recipe.Name = reader["RecipeTitle"].ToString();
                        recipe.CookingTime1 = reader["CookingTime"].ToString();
                        recipe.Image = reader["image"].ToString();
                        recipe.Category = reader["Category"].ToString();
                        recipeList.Add(recipe);
                    }
                }
            }

            // Set DataSource and DataBind on the ListView control
            Lv_Recipies.DataSource = recipeList;
            Lv_Recipies.DataBind();
        }



    }

    public class Recipe
    {
        public string Name { get; set; }
        public string CookingTime1 { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public int Id { get; internal set; }
        public string DDL_Meal { get; internal set; }
    }
}
