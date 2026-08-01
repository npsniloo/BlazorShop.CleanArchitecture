using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class GetOrdersUseCase : IGetOrdersUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetOrdersUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<List<Order>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Orders.GetAsync();
        }
    }
}
