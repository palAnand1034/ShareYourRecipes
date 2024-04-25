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
    public partial class Recipie_details : System.Web.UI.Page
    {
        private string connectionString;
        private Recipe recipe;
        int recipe_id;
        string id;
        string User_id, RecipeTitle, img, category;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["recipeId"] != null)
            {
                id = Request.QueryString["recipeId"];
                // Ensure id is not empty and is a valid integer
                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int recipeId))
                {
                    BindRecipes(recipeId);
                }
                else
                {
                    // Handle invalid or missing recipe ID
                }
            }


        }
        public void BindRecipes(int recipeId)
        {
            List<Recipe1> recipes = GetRecipesFromDatabase(recipeId);
            RecipesListView.DataSource = recipes;
            RecipesListView.DataBind();
        }

        private List<Recipe1> GetRecipesFromDatabase(int recipeId)
        {
            List<Recipe1> recipes = new List<Recipe1>();

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                            [RecipeTitle],
                            [CookingTime],
                            [image],
                            [author],
                            [ingredients],
                            [directions],
                            [Proportion],
                            [ShortSummary],
                            [calories],
                            [category],
                            [Preparationtime],
                            [carbohydrate],
                            [Protein]
                        FROM [recipe].[dbo].[Recipes]
                        WHERE recipe_id = @RecipeId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RecipeId", recipeId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Recipe1 rec = new Recipe1
                        {
                            RecipeTitle = reader["RecipeTitle"].ToString(),
                            CookingTime = reader["CookingTime"].ToString(),
                            ShortSummary = reader["ShortSummary"].ToString(),
                            Calories = reader["calories"].ToString(),
                            PreparationTime = reader["Preparationtime"].ToString(),
                            Author = reader["author"].ToString(),
                            Ingredients = reader["ingredients"].ToString(),
                            Proportion = reader["Proportion"].ToString(),
                            image = reader["image"].ToString(),
                            directions = reader["directions"].ToString(),
                            Category = reader["category"].ToString(),
                            Carbohydrate = reader["carbohydrate"].ToString(),
                            Protein = reader["Protein"].ToString()
                        };
                        recipes.Add(rec);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, you can log it or throw a custom exception
                // For now, let's just print the exception message
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return recipes;
        }
        protected void BtnAddToWishlist_Click(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                User_id = Session["user_id"].ToString();
                recipe_id = Convert.ToInt32(Request.QueryString["recipeId"]);


                connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                            [RecipeTitle],
                            [image],
                            [category]
                        FROM [recipe].[dbo].[Recipes]
                        WHERE recipe_id = @RecipeId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RecipeId", recipe_id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        RecipeTitle = reader["RecipeTitle"].ToString();
                        img = reader["image"].ToString();
                        category = reader["category"].ToString();
                    };

                }



                //img = imgProduct.image;

                AddToWishlist(recipe_id, User_id, RecipeTitle, img, category);
                Response.Redirect("wishlist.aspx");
                //if (!IsProductInWishlist(recipe_id, User_id)) // Check if product is not already in the wishlist
                //{
                //    AddToWishlist(recipe_id, User_id, RecipeTitle.Text, img);
                //    Response.Redirect("Wishlist.aspx");
                //}
                //else
                //{
                //    // Display alert if the product is already in the wishlist
                //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This product is already in your wishlist.');", true);
                //}


            }
            else
            {
                Response.Redirect("Registration.aspx");
            }
        }
        private void AddToWishlist(int recipe_id, string User_id, string R_title, string img, string cat)
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Wishlist( RecipeId,UserID,  RecipeTitle,  image, category) VALUES (@recipe_id, @User_id, @RecipeTitle, @image, @category)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@recipe_id", recipe_id);
                        command.Parameters.AddWithValue("@User_id", User_id);
                        command.Parameters.AddWithValue("@RecipeTitle", R_title);
                        command.Parameters.AddWithValue("@image", img);
                        command.Parameters.AddWithValue("@category", cat);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
            }
        }
    }
}

public class Recipe1
{
    public string RecipeTitle { get; set; }
    public string CookingTime { get; set; }
    public string ShortSummary { get; set; }
    public string Calories { get; set; }
    public string PreparationTime { get; set; }
    public string Author { get; set; }
    public string Ingredients { get; set; }
    public string Proportion { get; set; }
    public string image { get; set; }
    public string directions { get; set; }
    public string Category { get; set; }
    public string Carbohydrate { get; set; }
    public string Protein { get; set; }
}
