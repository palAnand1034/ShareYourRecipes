using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the username is stored in the session
                if (Session["Username"] != null)
                {
                    lblUsername.Text = Session["Username"].ToString();
                }
                else
                {
                    // Redirect to the sign-in page if the username is not found in the session
                    Response.Redirect("signin.aspx");
                }
            }
        }
        protected void btnSubmitRecipe_Click(object sender, EventArgs e)
        {
            // Redirect to SubmitRecipe.aspx
            Response.Redirect("~/submitrecipe.aspx");
        }
    }
}

        