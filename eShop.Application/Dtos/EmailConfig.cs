using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Dtos
{
    public class EmailConfig
    {
        public EmailConfig(string fromEmail, int port, string userName, string password, string displayName, bool enableSsl)
        {
            FromEmail = fromEmail;
            Port = port;
            UserName = userName;
            Password = password;
            DisplayName = displayName;
            EnableSsl = enableSsl;
        }

        public string FromEmail { get; }
        public string DisplayName { get; }
        public int Port { get;  }
        public string UserName { get; }
        public string Password { get; }
        public bool EnableSsl { get; }

    }
}
