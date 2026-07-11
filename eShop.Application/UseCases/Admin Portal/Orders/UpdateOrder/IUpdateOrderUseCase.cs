
namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public interface IUpdateOrderUseCase
    {
        public Task ExecuteAsync(UpdateOrderCommand command);
    }
}
