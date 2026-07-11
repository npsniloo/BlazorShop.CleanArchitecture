using eShop.Application.Interfaces.Repository;
using eShop.Application.UseCases.Customer_Portal;
using eShop.Application.UseCases.Customer_Portal.ShoppingCartScreen.GetCartItems;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repository
{
    internal class CartRepository : Repository<Cart, int>, ICartRepository
    {
        private readonly IDbContextFactory<OnlineShopContext> _dbFactory;

        public CartRepository(IDbContextFactory<OnlineShopContext> dbFactory) :base(dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<CartItemReadModel>> GetCartWithProductByUserIdAsync(int userId)
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            var items = await (from item in dbContext.Carts
                               join p in dbContext.Products
                               on item.ProductId equals p.Id
                               select new CartItemReadModel
                               {
                                   Id = item.Id,
                                   ProductId = p.Id,
                                   ProductTitle = p.Title,
                                   ProductImage = p.ImageName,
                                   ProductDiscount = p.Discount,
                                   ProductPrice = p.Price,
                                   Count = item.Count,
                                   UserId = item.UserId
                               }).ToListAsync();
            return items;
        }
    }
}
