namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public interface IDeleteProductUseCase
    {
        Task ExecuteAsync(int id);
    }
}
