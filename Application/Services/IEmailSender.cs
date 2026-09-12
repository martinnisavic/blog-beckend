using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string recipient, string subject, string content);
    }
}
