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
        private readonly IOrderRepository orderRepository;
        private readonly IRepository<OrderDetail,int> orderDetailRepository;

        public GetCustomerOrderByIdUseCase(IOrderRepository orderRepository, IRepository<OrderDetail, int> orderDetailRepository)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> ExecuteAsync(int orderId, int userId)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order == null || order.UserId != userId)
                throw new Exception("Order not found");
            var orderDetails = (await orderDetailRepository
                 .GetByFilterAsync(o => o.OrderId == orderId))
                 .ToList();
            return orderDetails;
        }
    }
}
