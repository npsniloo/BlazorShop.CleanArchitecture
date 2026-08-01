using eShop.Application.Dtos;
using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        private readonly OnlineShopContext dbContext;
        public ProductRepository(OnlineShopContext context) : base(context)
        {
            dbContext = context;
        }
        public async Task<Product?> GetProductByIdWithGalleries(int id)
        {
            return await dbContext.Products
                .Include(p => p.Galleries)
                .FirstOrDefaultAsync(x => x.Id == id);
                
        }
        public async Task<List<Product>> GetNewProducts(int count)
        {
            return await dbContext.Products
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }
        public async Task<List<BestSellingProduct>> GetBestSellingProductsAsync(int count)
        {
            var bestSellingProducts = await(from odetail in dbContext.OrderDetails
                                            join prod in dbContext.Products
                                            on odetail.ProductId equals prod.Id
                                            join order in dbContext.Orders
                                            on odetail.OrderId equals order.Id
                                            where order.TransactionStatus == "approved"
                                            group odetail by new
                                            {
                                                odetail.ProductId,
                                                prod.Title,
                                                prod.Price,
                                                prod.Discount,
                                                prod.ImageName,
                                                prod.Qty,
                                                order.TransactionStatus
                                            } into g
                                            select new BestSellingProduct
                                            {
                                                ProductId = g.Key.ProductId,
                                                TotalSum = g.Sum(x => x.Count),
                                                Title = g.Key.Title,
                                                Price = g.Key.Price,
                                                Discount = g.Key.Discount,
                                                ImageName = g.Key.ImageName,
                                                Qty = g.Key.Qty
                                            }).OrderByDescending(x => x.TotalSum).Take(count).ToListAsync();
            return bestSellingProducts;
        }

        public async Task AddProductWithProductGalleriesAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.ProductGalleries.AddRangeAsync(product.Galleries);
        }

        
        public void RemoveProductWithProductGalleries(Product product)
        {
            var galleries = dbContext.ProductGalleries.Where(d => d.ProductId == product.Id);
            dbContext.ProductGalleries.RemoveRange(galleries);
            dbContext.Products.Remove(product);
        }

      
    }
}
