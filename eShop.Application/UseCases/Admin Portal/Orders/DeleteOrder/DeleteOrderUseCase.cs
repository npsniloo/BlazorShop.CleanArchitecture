using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class DeleteOrderUseCase : IDeleteOrderUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DeleteOrderUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var order = await unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
                return;
            unitOfWork.Orders.RemoveOrderWithDetailsByOrderId(order);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
