using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class GetOrderDetailsUseCase : IGetOrderDetailsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetOrderDetailsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<List<OrderDetail>> ExecuteAsync(int orderId)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.OrderDetails.GetByFilterAsync((od => od.OrderId == orderId));
        }
    }
}
