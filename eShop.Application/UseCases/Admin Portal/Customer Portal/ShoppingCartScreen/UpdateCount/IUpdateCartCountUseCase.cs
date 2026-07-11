
namespace eShop.Application.UseCases.Customer_Portal
{
    public interface IUpdateCartCountUseCase
    {
        Task ExecuteAsync(int userId,int productId, int count);
    }
}
