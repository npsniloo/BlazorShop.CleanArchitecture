using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class GetOrderByIdUseCase : IGetOrderByIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetOrderByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<Order?> ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Orders.GetByIdAsync(id);
        }
    }
}
