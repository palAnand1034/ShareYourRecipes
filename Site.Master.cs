using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            if (Session["User_id"] == null)
            {
                ShowGuestLinks();
                // Hide the user icon for guest users
                After_log.Visible = false;
            }
            else
            {
                ShowUserLinks();
                // Show the user icon for logged-in users
                After_log.Visible = true;
                // Set the user's name as the text for the user icon
                After_log.Text = "<i class='fas fa-user'></i> Hello " + Session["Username"].ToString();
            }
        }


        private void ShowGuestLinks()
        {
            User_login.Visible = true;
            User_Profile.Visible = false;
            Logout.Visible = false;
            After_log.Visible = false;
            WishlistLink.Visible = false;
        }

        private void ShowUserLinks()
        {
            User_login.Visible = false;
            User_Profile.Visible = true;
            Logout.Visible = true;
            After_log.Visible = true;
            After_log.Text = "Hello " + Session["Username"].ToString();
            WishlistLink.Visible = true;
        }

        protected void User_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void User_Profile_click(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["User_id"] != null)
            {
                // Redirect to SubmitRecipe.aspx page
                Response.Redirect("userprofile.aspx");
            }
            else
            {
                // If the user is not logged in, redirect them to the login page
                Response.Redirect("Registration.aspx");
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            // Clear user-related session variables
            Session["User_id"] = null;

            // Redirect to the default page
            Response.Redirect("Default.aspx");
        }

        protected void After_log_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
