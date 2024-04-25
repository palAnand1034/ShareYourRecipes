using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("Registration.aspx");
            }
            else
            {
                string userId = Session["user_id"].ToString();
                BindWishlist(userId);
            }
        }

        private void BindWishlist(string userId)
        {
            DataTable wishlistData = GetWishlistData(userId);

            if (wishlistData.Rows.Count > 0)
            {
                WishlistListView.DataSource = wishlistData;
                WishlistListView.DataBind();
            }
            else
            {
                WishlistListView.Visible = false;
                // Optionally, display a message indicating that the wishlist is empty.
                // Example: lblMessage.Text = "Your wishlist is empty.";
            }
        }

        private DataTable GetWishlistData(string userId)
        {
            DataTable dt = new DataTable();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT RecipeID, RecipeTitle, image, category FROM Wishlist WHERE UserID = @UserID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during data retrieval
                // Log the exception details if needed
                // LogException(ex);
            }

            return dt;
        }
       


        protected void WishlistListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveItem")
            {
                string userId = Session["user_id"].ToString();
                int recipeId = Convert.ToInt32(e.CommandArgument);
                RemoveItemFromWishlist(userId, recipeId);
                BindWishlist(userId); // Rebind the ListView after removing the item
            }
        }

        private void RemoveItemFromWishlist(string userId, int recipeId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Wishlist WHERE UserID = @UserID AND RecipeID = @RecipeID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@RecipeID", recipeId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the remove operation
                // Log the exception details if needed
                // LogException(ex);
            }
        }
        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string userId = Session["user_id"].ToString();
            int recipeId = Convert.ToInt32(btn.CommandArgument);
            RemoveItemFromWishlist(userId, recipeId);
            BindWishlist(userId); // Rebind the ListView after removing the item
        }


    }
}

