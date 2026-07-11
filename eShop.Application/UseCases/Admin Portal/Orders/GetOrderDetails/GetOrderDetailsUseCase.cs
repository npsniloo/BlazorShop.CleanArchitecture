using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class GetOrderDetailsUseCase : IGetOrderDetailsUseCase
    {
        private readonly IRepository<OrderDetail, int> repository;

        public GetOrderDetailsUseCase(IRepository<OrderDetail, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<OrderDetail>> ExecuteAsync(int orderId)
        {
            return await repository.GetByFilterAsync((od => od.OrderId == orderId));
        }
    }
}
