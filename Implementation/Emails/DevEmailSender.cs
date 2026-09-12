using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Emails
{
    public class DevEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string recipient, string subject, string content)
        {
            Console.WriteLine("========== EMAIL (DEV) ==========");
            Console.WriteLine($"Za:      {recipient}");
            Console.WriteLine($"Naslov:  {subject}");
            Console.WriteLine($"Sadržaj: {content}");
            Console.WriteLine("=================================");
        }
    }
}
