using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal.NewProductsScreen
{
    public class NewProductsUseCase : INewProductsUseCase
    {
        private IProductRepository repository;

        public NewProductsUseCase(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Product>> ExecuteAsync(int count)
        {
            var products = await repository.GetNewProducts(count);
            return products;
        }
    }
}
