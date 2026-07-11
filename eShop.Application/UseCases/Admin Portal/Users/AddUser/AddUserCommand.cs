using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class AddUserCommand
    {
      
        public AddUserCommand(string email, string password, string fullName, bool isAdmin)
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
