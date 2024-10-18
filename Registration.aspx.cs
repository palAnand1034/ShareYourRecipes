using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class RegistrationAndSignIn : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FL_img.PostedFile != null && FL_img.PostedFile.ContentLength > 0)
                {
                    string filename = Path.GetFileName(FL_img.PostedFile.FileName);
                    string serverPath = Server.MapPath("upload") + "\\" + filename;
                    string fileUrl = "Upload\\" + filename;

                    FL_img.PostedFile.SaveAs(serverPath);

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = @"INSERT INTO Users (First_name, Last_name, email, Contact_number, Username, Password, ProfileImage) 
                                         VALUES (@FirstName, @LastName, @Email, @ContactNumber, @Username, @Password, @ProfileImage)";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@FirstName", firstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", lastName.Text);
                        cmd.Parameters.AddWithValue("@Email", email.Text);
                        cmd.Parameters.AddWithValue("@ContactNumber", contactNumber.Text);
                        cmd.Parameters.AddWithValue("@Username", username.Text);
                        cmd.Parameters.AddWithValue("@Password", password.Text);
                        cmd.Parameters.AddWithValue("@ProfileImage", fileUrl);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            registrationResult.InnerText = "Registration successful";
                        }
                    }
                }
                else
                {
                    registrationResult.InnerText = "Please upload a profile image";
                }
            }
            catch (Exception ex)
            {
                registrationResult.InnerText = "Error: " + ex.Message;
            }
        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*), User_id FROM Users WHERE Username = @Username AND Password = @Password GROUP BY User_id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", signInUsername.Text);
                    command.Parameters.AddWithValue("@Password", signInPassword.Text);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int userCount = Convert.ToInt32(reader[0]);
                        int userId = Convert.ToInt32(reader[1]);

                        if (userCount > 0)
                        {
                            Session["User_id"] = userId;
                            Session["Username"] = signInUsername.Text;
                            Response.Redirect("Default.aspx"); // Redirect to a welcome page upon successful sign-in
                        }
                        else
                        {
                            SignInResult.InnerHtml = "Invalid username or password. Please try again.";
                        }
                    }
                    else
                    {
                        SignInResult.InnerHtml = "Invalid username or password. Please try again.";
                    }

                    reader.Close();
                }
            }
            catch (Exception )
            {
                SignInResult.InnerHtml = "An error occurred while signing in. Please try again later.";
            }
        }
    }
}
