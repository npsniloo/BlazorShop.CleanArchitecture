using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetProductDetailsUseCase : IGetProductDetailsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;


        public GetProductDetailsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Product?> ExecuteAsync(int id)
        {
            var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Products.GetByIdAsync(id);
        }
    }
}
