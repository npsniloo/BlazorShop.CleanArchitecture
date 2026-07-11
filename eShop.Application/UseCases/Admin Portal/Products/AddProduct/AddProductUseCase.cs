using eShop.Application.Interfaces.Repository;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public AddProductUseCase(IProductRepository repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(AddProductCommand command)
        {
            command.Product.AddGalleries(command.Images);
            await repository.AddProductWithProductGalleriesAsync(command.Product);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
