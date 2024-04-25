using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services.Description;

namespace OnlineRecipeSharing
{
    public partial class contactusNEW : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // No specific action needed on page load for this scenario
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string email = this.email.Text;
            string message = TextBox2.Text;

            // Retrieve connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            // Check if the connection string is not null or empty
            if (!string.IsNullOrEmpty(connectionString))
            {
                // Use the connection string to connect to the database
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string insertQuery = "INSERT INTO contactform (Name, Email, Message) VALUES (@Name, @Email, @Message)";

                    try
                    {
                        con.Open();

                        // Initialize the SqlCommand object with the insert query and connection
                        using (SqlCommand command = new SqlCommand(insertQuery, con))
                        {
                            // Add parameters to the command
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Message", message);

                            // Execute the command
                            command.ExecuteNonQuery();

                            // Display success message or redirect to a thank you page
                            // For simplicity, let's just set a message here
                            ResultPanel.Visible = true;
                            ResultPanel.Controls.Add(new LiteralControl("Message sent successfully."));
                        }
                    }
                    catch (Exception ex)
                    {
                        // Display error message
                        ErrorMessageLabel.Text = "An error occurred while sending the message: " + ex.Message;
                    }
                }
            }
            else
            {
                // Handle the case where the connection string is null or empty
                ErrorMessageLabel.Text = "The connection string is null or empty. Please check your Web.config file.";
            }
        }

    }
}


