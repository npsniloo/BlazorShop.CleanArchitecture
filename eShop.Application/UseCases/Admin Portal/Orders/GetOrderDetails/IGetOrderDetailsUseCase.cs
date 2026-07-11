using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public interface IGetOrderDetailsUseCase
    {
        Task<IEnumerable<OrderDetail>> ExecuteAsync(int orderId);
    }
}
