using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductUseCase(IProductRepository repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(int id)
        {
            var product = await repository.GetByIdAsync(id);
           
            if (product == null)
                return;

            repository.RemoveProductWithProductGalleries(product);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
