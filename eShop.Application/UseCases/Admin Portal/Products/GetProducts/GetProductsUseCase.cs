using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetProductsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Product>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Products.GetAsync();
        }
    }
}
