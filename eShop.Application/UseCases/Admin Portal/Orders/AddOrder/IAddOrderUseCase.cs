

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public interface IAddOrderUseCase
    {
        public Task ExecuteAsync(AddOrderCommand command);
    }
}
