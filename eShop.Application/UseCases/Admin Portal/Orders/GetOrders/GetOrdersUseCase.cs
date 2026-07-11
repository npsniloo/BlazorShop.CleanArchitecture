using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class GetOrdersUseCase : IGetOrdersUseCase
    {
        private readonly IRepository<Order, int> repository;

        public GetOrdersUseCase(IRepository<Order, int> repo)
        {
            this.repository = repo;
        }
        public async Task<IEnumerable<Order>> ExecuteAsync()
        {
            return await repository.GetAsync();
        }
    }
}
