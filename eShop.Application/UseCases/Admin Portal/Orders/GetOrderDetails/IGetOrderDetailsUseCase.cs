using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public interface IGetOrderDetailsUseCase
    {
        Task<List<OrderDetail>> ExecuteAsync(int orderId);
    }
}
