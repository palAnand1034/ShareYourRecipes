using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class Registeration : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        // sign up button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {

                Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
            }
            else
            {
                signUpNewMember();
            }
        }

        // user defined method
        bool checkMemberExists()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(strcon);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from  Users where User_id='" + userid.Text.Trim() + "';", dbconnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewMember()
        {
            try
            {
                SqlConnection dbconnection = new SqlConnection(strcon);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO Users(User_id, Username, email, [password]) VALUES (@User_id, @Username, @email, @password)");
                cmd.Parameters.AddWithValue("@User_id", userid.Text.Trim());
                cmd.Parameters.AddWithValue("@Username", username.Text.Trim());
                cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                cmd.Connection = dbconnection;
                cmd.ExecuteNonQuery(); // This line is essential to execute the SQL command
                dbconnection.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}