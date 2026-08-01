using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eShop.Infrastructure.Repository
{
    public class UserRepository : Repository<User, int> ,IUserRepository
    {
        private readonly OnlineShopContext dbContext;
        public UserRepository(OnlineShopContext context) : base(context)
        {
            dbContext = context;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return (await dbContext.Users.SingleOrDefaultAsync(u => u.Email == Normalize(email)));
        }
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return (await dbContext.Users.AnyAsync(u => u.Email == Normalize(email)));
        }
        private static string Normalize(string txt)
        {
            return txt.Trim().ToLowerInvariant();
        }




    }
}
