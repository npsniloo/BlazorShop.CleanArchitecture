using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Common.RegisterUser
{
    public class RegisterUserCommand
    {
        public RegisterUserCommand(string email, string password, string fullName, bool isAdmin)
        {
            Email = email;
            Password = password;
            FullName = fullName;
            IsAdmin = isAdmin;
        }

        public string Email { get; }
        public string Password { get; }
        public string FullName { get; }
        public bool IsAdmin { get; }
    }
}
