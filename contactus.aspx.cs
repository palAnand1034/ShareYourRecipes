using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRecipeSharing
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string email = ConfigurationManager.AppSettings["Email"];
                string password = ConfigurationManager.AppSettings["Password"];
                string name = NameTextBox.Text.Trim();
                string userEmail = EmailTextBox.Text.Trim();
                string message = MessageTextBox.Text.Trim();

                // Create mail message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(email);
                mailMessage.To.Add("a77112035@gmail.com"); // recipient's email address
                mailMessage.Subject = "Contact Form Submission";
                mailMessage.Body = $"Name: {name}\nEmail: {userEmail}\nMessage: {message}";

                // Configure SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); //  SMTP server address
                smtpClient.Port = 587; // Replace with your SMTP port number
                smtpClient.Credentials = new NetworkCredential(email, password); // Use email and password from configuration
                smtpClient.EnableSsl = true;

                // Send mail
                smtpClient.Send(mailMessage);

                // Clear form and show success message
                NameTextBox.Text = "";
                EmailTextBox.Text = "";
                MessageTextBox.Text = "";
                ResultPanel.Controls.Add(new LiteralControl("<div class='success'>Your message has been sent successfully.</div>"));
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = "An error occurred while sending your message. Please try again later.";
            }
        }
    }
}
