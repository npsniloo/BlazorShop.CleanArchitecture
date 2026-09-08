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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public NewProductsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Product>> ExecuteAsync(int count)
        {
            var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var products = await unitOfWork.Products.GetNewProductsAsync(count);
            return products;
        }
    }
}
