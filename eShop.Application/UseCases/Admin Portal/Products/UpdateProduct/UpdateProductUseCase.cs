using eShop.Application.Interfaces.Repository;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateProductUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(UpdateProductCommand command)
        {
            using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var product = await unitOfWork.Products.GetProductByIdWithGalleries(command.Product.Id);
            if (product == null)
                return;
            product.FullDesc = command.Product.FullDesc;
            product.Description = command.Product.Description;
            product.Price = command.Product.Price;
            product.Qty = command.Product.Qty;
            product.ImageName = command.Product.ImageName;
            product.Discount = command.Product.Discount;
            product.Tags = command.Product.Tags;
            product.Title = command.Product.Title;
            product.VideoUrl = command.Product.VideoUrl;

            product.AddGalleries(command.NewImages);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
