using eShop.Application.Interfaces.Repository;
using eShop.Application.UseCases.Customer_Portal;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        private readonly IDbContextFactory<OnlineShopContext> _dbFactory;
        public OrderRepository(IDbContextFactory<OnlineShopContext> dbFactory) : base(dbFactory)
        {
            _dbFactory = dbFactory;
        }


        public void RemoveOrderWithDetailsByOrderId(Order order)
        {
            using var dbContext =  _dbFactory.CreateDbContext();
            var details = dbContext.OrderDetails.Where(d => d.OrderId == order.Id);
            dbContext.OrderDetails.RemoveRange(details);
            dbContext.Orders.Remove(order);

        }
    }
}
