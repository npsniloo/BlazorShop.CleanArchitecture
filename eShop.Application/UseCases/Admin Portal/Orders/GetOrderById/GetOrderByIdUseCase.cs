using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class GetOrderByIdUseCase : IGetOrderByIdUseCase
    {
        private readonly IRepository<Order, int> repository;

        public GetOrderByIdUseCase(IRepository<Order, int> repo)
        {
            this.repository = repo;
        }
        public async Task<Order?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
