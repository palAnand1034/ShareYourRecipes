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
                lblMessage.Text = "Your wishlist is empty.";
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
            catch (Exception)
            {

            }

            return dt;
        }

    }
}

