using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private const string ApiKey = "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";
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(ApiKey, subject, htmlMessage, email);
        }

        private Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("orenbusra90@gmail.com", "bilgeadam"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
