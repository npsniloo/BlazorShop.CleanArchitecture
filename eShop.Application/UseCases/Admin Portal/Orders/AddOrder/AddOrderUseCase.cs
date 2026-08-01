using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class AddOrderUseCase : IAddOrderUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AddOrderUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(AddOrderCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            await unitOfWork.Orders.AddAsync(command.Order);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
