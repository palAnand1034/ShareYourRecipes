using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_id"] == null)
                {
                    // If the user is not logged in, redirect them to the sign-in page
                    Response.Redirect("Registration.aspx");
                }
                else
                {
                    // If the user is logged in, proceed with loading the user profile
                    LoadUserProfile();
                    LoadSharedRecipes();
                }
            }
        }

        private void LoadUserProfile()
        {
            if (Session["User_id"] != null)
            {
                string userId = Session["User_id"].ToString();
                string query = "SELECT Username, email, Contact_number, ProfileImage FROM Users WHERE User_id = @UserId";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        lblName.Text = reader["Username"].ToString();
                        lblEmail.Text = reader["email"].ToString();
                        lblContactNo.Text = reader["Contact_number"].ToString();

                        // Set the profile image URL
                        string profileImage = reader["ProfileImage"].ToString();
                        if (!string.IsNullOrEmpty(profileImage))
                        {
                            imgProfile.ImageUrl = profileImage;
                        }
                        else
                        {
                            // If no profile image is available, set a default image
                            imgProfile.ImageUrl = "default_profile_image.jpg";
                        }
                    }
                    reader.Close();
                }
            }
        }

        private void LoadSharedRecipes()
        {
            if (Session["User_id"] != null)
            {
                string userId = Session["User_id"].ToString();
                string query = "SELECT recipe_id, RecipeTitle, CookingTime, image FROM Recipes WHERE User_id = @UserId";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    lvSharedRecipes.DataSource = dt;
                    lvSharedRecipes.DataBind();
                }
            }
        }

        protected void EditRecipe_Click(object sender, EventArgs e)
        {
            // Retrieve the recipe ID from the button's command argument
            Button btnEdit = (Button)sender;
            string recipe_id = btnEdit.CommandArgument;

            // Redirect to the edit recipe page with the recipe ID
            Response.Redirect("submitrecipe.aspx?recipe_id=" + recipe_id);
        }
    }
}
