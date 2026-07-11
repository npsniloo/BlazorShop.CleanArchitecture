using eShop.Application.Dtos;
using eShop.Application.Interfaces.Services.Shared;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.EmailService
{
    public class SmtpEmailService :IEmailService
    {
        private readonly IOptions<EmailConfig> options;

        public SmtpEmailService(IOptions<EmailConfig> options)
        {
            this.options = options;
        }

        public async Task SendEmailAsync(string toEmail, string message, string subject)
        {
            using (var mail = new MailMessage())
            using (var smtpServer = new SmtpClient("niloofarpahlevan.com"))
            {
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.From = new MailAddress(options.Value.FromEmail, options.Value.DisplayName);
                mail.Body = message;
                smtpServer.Port = options.Value.Port;
                smtpServer.Credentials = new System.Net.NetworkCredential(options.Value.UserName, options.Value.Password);
                smtpServer.EnableSsl = options.Value.EnableSsl;
                await smtpServer.SendMailAsync(mail);
            }
        }
    }
}
