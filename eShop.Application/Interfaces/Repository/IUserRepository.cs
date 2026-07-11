using eShop.Domain.Entities;

namespace eShop.Application.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User,int>
    {

        Task<User?> GetByEmailAsync(string email);
        Task<bool>  ExistsByEmailAsync(string email);
    }
}
