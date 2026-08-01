using eShop.Application.Interfaces.Repository;
using eShop.Application.UseCases.Customer_Portal;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        private readonly OnlineShopContext dbContext;
        public OrderRepository(OnlineShopContext context) : base(context)
        {
            dbContext = context;
        }


        public void RemoveOrderWithDetailsByOrderId(Order order)
        {
            var details = dbContext.OrderDetails.Where(d => d.OrderId == order.Id);
            dbContext.OrderDetails.RemoveRange(details);
            dbContext.Orders.Remove(order);

        }
    }
}
