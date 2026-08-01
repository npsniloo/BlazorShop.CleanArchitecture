using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetProductByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Product?> ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Products.GetByIdAsync(id);
        }
    }
}
