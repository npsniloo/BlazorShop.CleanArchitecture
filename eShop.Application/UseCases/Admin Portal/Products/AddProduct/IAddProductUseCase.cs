namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(AddProductCommand command);
    }
}
