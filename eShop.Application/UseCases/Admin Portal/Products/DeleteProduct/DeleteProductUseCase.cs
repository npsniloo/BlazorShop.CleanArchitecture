using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DeleteProductUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var product = await unitOfWork.Products.GetByIdAsync(id);
           
            if (product == null)
                return;

            unitOfWork.Products.RemoveProductWithProductGalleries(product);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
