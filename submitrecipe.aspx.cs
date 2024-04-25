using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        bool isEditMode = false;
        int recipeID=0 ;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_id"] == null)
                {
                    Response.Redirect("Registration.aspx");
                }
                else
                {
                    BindDropdownlistCategory();
                    BindListViewMealType();
                }

                if (!string.IsNullOrEmpty(Request.QueryString["RecipeID"]))
                {
                    recipeID = Convert.ToInt32(Request.QueryString["RecipeID"]);
                    PopulateRecipeDetails(recipeID);
                    LitPageTitle.Text = "Edit Recipe";
                    SubmitRecipe.Text = "Update";
                    isEditMode = true; // Set edit mode to true
                }
                else
                {
                    LitPageTitle.Text = "Submit Recipe";
                    isEditMode = false; // Set edit mode to false
                }
            }
        }


        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                UpdateRecipe(recipeID);
            }
            else
            {
                InsertRecipe();
            }
        }

        // Method to populate the form fields with recipe details for editing
        private void PopulateRecipeDetails(int recipeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT RecipeTitle, CookingTime, Proportion, ingredients, author, directions, ShortSummary, Calories, category, DDL_Meal, Preparationtime, carbohydrate, Protein, keywords, tags, image FROM Recipes WHERE RecipeID = @RecipeID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@RecipeID", recipeID);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        RecipeTitle.Text = reader["RecipeTitle"].ToString();
                        CookingTime.Text = reader["CookingTime"].ToString();
                        Proportion.Text = reader["Proportion"].ToString();
                        ingredients.Text = reader["ingredients"].ToString();
                        author.Text = reader["author"].ToString();
                        directions.Text = reader["directions"].ToString();
                        ShortSummary.Text = reader["ShortSummary"].ToString();
                        Calories.Text = reader["Calories"].ToString();
                        ChooseCategory.SelectedItem.Text = reader["category"].ToString(); // Assuming 'category' is a DropDownList
                        DDL_Meal.SelectedItem.Text = reader["DDL_Meal"].ToString(); // Assuming 'DDL_Meal' is a DropDownList
                        PreparationTime.Text = reader["PreparationTime"].ToString();
                        TotalCarbohydrate.Text = reader["carbohydrate"].ToString();
                        Protein.Text = reader["Protein"].ToString();
                        keywords.Text = reader["keywords"].ToString();
                        tags.Text = reader["tags"].ToString();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw ex;
            }
        }

        // Method to update the recipe in the database
        private void UpdateRecipe(int recipeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Recipes 
                                     SET RecipeTitle = @RecipeTitle, 
                                         CookingTime = @CookingTime, 
                                         Proportion = @Proportion, 
                                         ingredients = @ingredients, 
                                         author = @author, 
                                         directions = @directions, 
                                         ShortSummary = @ShortSummary, 
                                         Calories = @Calories, 
                                         category = @category, 
                                         DDL_Meal = @DDL_Meal, 
                                         Preparationtime = @Preparation_time, 
                                         carbohydrate = @carbohydrate, 
                                         Protein = @Protein, 
                                         keywords = @keywords, 
                                         tags = @tags, 
                                         image = @image 
                                     WHERE RecipeID = @RecipeID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@RecipeTitle", RecipeTitle.Text);
                    cmd.Parameters.AddWithValue("@CookingTime", CookingTime.Text);
                    cmd.Parameters.AddWithValue("@Proportion", Proportion.Text);
                    cmd.Parameters.AddWithValue("@ingredients", ingredients.Text);
                    cmd.Parameters.AddWithValue("@author", author.Text);
                    cmd.Parameters.AddWithValue("@directions", directions.Text);
                    cmd.Parameters.AddWithValue("@ShortSummary", ShortSummary.Text);
                    cmd.Parameters.AddWithValue("@calories", Calories.Text);
                    cmd.Parameters.AddWithValue("@category", ChooseCategory.SelectedItem.Text); // Access Value property
                    cmd.Parameters.AddWithValue("@DDL_Meal", DDL_Meal.SelectedItem.Text); // Access Value property
                    cmd.Parameters.AddWithValue("@Preparation_time", PreparationTime.Text); // Correct parameter name
                    cmd.Parameters.AddWithValue("@carbohydrate", TotalCarbohydrate.Text);
                    cmd.Parameters.AddWithValue("@Protein", Protein.Text);
                    cmd.Parameters.AddWithValue("@keywords", keywords.Text);
                    cmd.Parameters.AddWithValue("@RecipeID", recipeID);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        // Display success message or redirect to a success page
                        Response.Write("<script>alert('Recipe updated successfully')</script>");
                    }
                    else
                    {
                        // Handle the case where the update operation failed
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw ex;
            }
        }

        // Method to insert a new recipe
        private void InsertRecipe()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Recipes (RecipeTitle, CookingTime, Proportion, ingredients, author, directions, ShortSummary, Calories, category, DDL_Meal, Preparationtime, carbohydrate, Protein , keywords,tags,image) 
                                    VALUES (@RecipeTitle, @CookingTime, @Proportion, @ingredients, @author, @directions, @ShortSummary, @calories, @category, @DDL_Meal, @Preparation_time, @carbohydrate, @Protein ,@keywords,@tags,@image)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@RecipeTitle", RecipeTitle.Text);
                    cmd.Parameters.AddWithValue("@CookingTime", CookingTime.Text);
                    cmd.Parameters.AddWithValue("@Proportion", Proportion.Text);
                    cmd.Parameters.AddWithValue("@ingredients", ingredients.Text);
                    cmd.Parameters.AddWithValue("@author", author.Text);
                    cmd.Parameters.AddWithValue("@directions", directions.Text);
                    cmd.Parameters.AddWithValue("@ShortSummary", ShortSummary.Text);
                    cmd.Parameters.AddWithValue("@calories", Calories.Text);
                    cmd.Parameters.AddWithValue("@category", ChooseCategory.SelectedItem.Text); // Access Value property
                    cmd.Parameters.AddWithValue("@DDL_Meal", DDL_Meal.SelectedItem.Text); // Access Value property
                    cmd.Parameters.AddWithValue("@Preparation_time", PreparationTime.Text); // Correct parameter name
                    cmd.Parameters.AddWithValue("@carbohydrate", TotalCarbohydrate.Text);
                    cmd.Parameters.AddWithValue("@Protein", Protein.Text);
                    cmd.Parameters.AddWithValue("@keywords", keywords.Text);
                    cmd.Parameters.AddWithValue("@tags", tags.Text);

                    if ((FL_img.PostedFile != null) && (FL_img.PostedFile.ContentLength > 0))
                    {
                        string filename = System.IO.Path.GetFileName(FL_img.PostedFile.FileName);
                        string Serverpath = Server.MapPath("upload") + "\\" + filename;
                        string fileurl = "Upload\\" + filename;
                        try
                        {
                            FL_img.PostedFile.SaveAs(Serverpath);
                            cmd.Parameters.AddWithValue("@image", fileurl);
                            // FileUploadStatus.Text = "The file has been uploaded.";
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image", "");
                    }

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        // Display success message or redirect to a success page
                        Response.Write(@"<script language='javascript'>alert('Details saved successfully')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw ex;
            }
        }

        // Method to bind category dropdownlist
        private void BindDropdownlistCategory()
        {
            try
            {
                using (SqlConnection dbconnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT CategoryID, CategoryName FROM Categories"; // Assuming 'CategoryID' and 'CategoryName' are columns in your 'Categories' table

                    dbconnection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, dbconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ChooseCategory.DataSource = dt;
                        ChooseCategory.DataTextField = "CategoryName"; // Column name to display
                        ChooseCategory.DataValueField = "CategoryID"; // Column name to use as value
                        ChooseCategory.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw ex;
            }
        }

        // Method to bind data to ListView for meal types
        private void BindListViewMealType()
        {
            try
            {
                using (SqlConnection dbconnection = new SqlConnection(connectionString))
                {
                    string query = "SELECT MealTypeID, MealTypeName FROM MealTypes"; // Assuming 'MealTypeID' and 'MealTypeName' are columns in your 'MealTypes' table

                    dbconnection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, dbconnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DDL_Meal.DataSource = dt;
                        DDL_Meal.DataTextField = "MealTypeName"; // Column name to display
                        DDL_Meal.DataValueField = "MealTypeID"; // Column name to use as value
                        DDL_Meal.DataBind();
                    }
                    else
                    {
                        // If no meal types available, show a message
                        // You can customize this message as needed
                        // Example: lblNoMealTypes.Text = "No meal types available.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw ex;
            }
        }
    }
}
