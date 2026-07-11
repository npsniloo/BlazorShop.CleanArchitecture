using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class DeleteOrderUseCase : IDeleteOrderUseCase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteOrderUseCase(IOrderRepository repo, IUnitOfWork unitOfWork)
        {
            this.orderRepository = repo;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(int id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null)
                return;
            orderRepository.RemoveOrderWithDetailsByOrderId(order);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
