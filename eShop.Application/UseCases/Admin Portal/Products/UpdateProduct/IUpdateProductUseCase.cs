namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public interface IUpdateProductUseCase
    {
        Task ExecuteAsync(UpdateProductCommand command);
    }
}
