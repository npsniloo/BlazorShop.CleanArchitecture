using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class UpdateUserCommand
    {
        public UpdateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}
