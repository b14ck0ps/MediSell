using System;
using System.Net;
using System.Net.Mail;

namespace BLL.Services
{
    public static class EmailService
    {
        public static bool SendEmail(string fromAddress, string toAddress, string subject, string htmlBody)
        {
            try
            {
                var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("4c58ece63856e5", "37a2b74d1f8220"),
                    EnableSsl = true
                };

                // Create an alternate view for the HTML body
                var htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");

                // Create the email message
                var mailMessage = new MailMessage();
                mailMessage.AlternateViews.Add(htmlView);
                mailMessage.From = new MailAddress(fromAddress);
                mailMessage.To.Add(new MailAddress(toAddress));
                mailMessage.Subject = subject;

                // Send the email
                client.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}