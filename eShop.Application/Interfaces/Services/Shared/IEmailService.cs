using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Interfaces.Services.Shared
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string toEmail, string message, string subject);
    }
}
