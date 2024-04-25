using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class recipes_category : System.Web.UI.Page
    {
        string cat;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Category"] != null)
            {
                cat = Request.QueryString["Category"];
                // Ensure id is not empty and is a valid integer
                if (!string.IsNullOrEmpty(cat))
                {
                    BindDataLv_Recipes(cat);
                }
                else
                {
                    // Handle invalid or missing recipe ID
                }
            }


        }
        private void BindDataLv_Recipes(string category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "SELECT recipe_id, RecipeTitle, CookingTime, image, Category FROM Recipes  WHERE category = '" + category + "'";
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
}