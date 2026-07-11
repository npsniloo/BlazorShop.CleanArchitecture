using eShop.Domain.Entities;


namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public interface IGetOrdersUseCase
    {
        Task<IEnumerable<Order>> ExecuteAsync();
    }
}
