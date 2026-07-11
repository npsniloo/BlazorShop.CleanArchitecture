using eShop.Application.UseCases.Customer_Portal.ShoppingCartScreen.GetCartItems;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Interfaces.Repository
{
    public interface ICartRepository : IRepository<Cart, int>
    {
        Task<List<CartItemReadModel>> GetCartWithProductByUserIdAsync(int userId);
    }
}
