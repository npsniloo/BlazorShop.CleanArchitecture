using eShop.Application.Interfaces.Repository;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AddProductUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(AddProductCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            command.Product.AddGalleries(command.Images);
            await unitOfWork.Products.AddProductWithProductGalleriesAsync(command.Product);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
