using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear session variables
            Session.Clear();
            Session.Abandon(); // Optional, to end the session immediately

            // Clear authentication cookies
            if (Request.Cookies["YourAuthenticationCookieName"] != null)
            {
                HttpCookie myCookie = new HttpCookie("YourAuthenticationCookieName");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }

            // Redirect to the login page
            Response.Redirect("Login.aspx");
        }
    }
}