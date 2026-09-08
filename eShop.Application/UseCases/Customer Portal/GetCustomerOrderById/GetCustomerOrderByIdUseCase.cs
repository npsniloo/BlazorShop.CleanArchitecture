using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetCustomerOrderByIdUseCase : IGetCustomerOrderByIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetCustomerOrderByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<OrderDetail>> ExecuteAsync(int orderId, int userId)
        {
            var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var order = await unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null || order.UserId != userId)
                throw new Exception("Order not found");

            var orderDetails = (await unitOfWork.OrderDetails
                 .GetByFilterAsync(o => o.OrderId == orderId))
                 .ToList();
            return orderDetails;
        }
    }
}
