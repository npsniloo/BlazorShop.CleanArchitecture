using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Common.Login
{
    public class LoginResponse
    {
        public LoginResponse(int id, string email, string name, bool isAdmin)
        {
            Id = id;
            Email = email;
            Name = name;
            IsAdmin = isAdmin;
        }

        public int Id { get; }
        public string Email { get; }
        public string Name { get; }
        public bool IsAdmin { get; }
    }
}
