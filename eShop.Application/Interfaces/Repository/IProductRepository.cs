using eShop.Application.Dtos;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task<Product?> GetProductByIdWithGalleries(int id);
        Task<List<Product>> GetNewProducts(int count);
        Task<List<BestSellingProduct>> GetBestSellingProductsAsync(int count);
        Task AddProductWithProductGalleriesAsync(Product product);
        void RemoveProductWithProductGalleries(Product product);
    }
}
