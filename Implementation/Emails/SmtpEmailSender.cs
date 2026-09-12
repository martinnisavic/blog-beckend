using Application.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Implementation.Emails
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly string _fromEmail;
        private readonly string _appPassword;

        public SmtpEmailSender(string fromEmail, string appPassword)
        {
            _fromEmail = fromEmail;
            _appPassword = appPassword;
        }
        public async Task SendEmailAsync(string recipient, string subject, string content)
        {
            using var message = new MailMessage
            {
                From = new MailAddress(_fromEmail, "BlogApi"),
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };
            message.To.Add(recipient);

            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromEmail, _appPassword)
            };

            await client.SendMailAsync(message);
        }
    }
}
