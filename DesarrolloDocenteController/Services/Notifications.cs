using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace DesarrolloDocenteController.Services
{
    public class Notifications
    {
        public Boolean SendEmail(string subject, string content, string toName, string toEmail)
        {
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            string emailFrom = System.Configuration.ConfigurationSettings.AppSettings["EmailFromSendGrid"];
            string nameFrom = System.Configuration.ConfigurationSettings.AppSettings["NameFromSendGrid"];
            var from = new EmailAddress(emailFrom, nameFrom);
            
            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = content;
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            return true;
        }

        public Boolean SendSMS(string content, string to, string from)
        {
            // twillio service
            return true;
        }
    }
}
