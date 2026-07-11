using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class AddOrderUseCase : IAddOrderUseCase
    {
        private readonly IRepository<Order, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public AddOrderUseCase(IRepository<Order, int> menuRepo, IUnitOfWork unitOfWork)
        {
            this.repository = menuRepo;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(AddOrderCommand command)
        {
            await repository.AddAsync(command.Order);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
