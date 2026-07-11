using eShop.Application.Dtos;
using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ViewBestSellingProducts : IViewBestSellingProducts
    {
        private readonly IProductRepository productRepository;

        public ViewBestSellingProducts(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<BestSellingProduct>> ExecuteAsync(int count)
        {
            var products = await productRepository.GetBestSellingProductsAsync(count);
            return products;

        }
    }
}
