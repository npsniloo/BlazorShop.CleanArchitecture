using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class AddOrderCommand
    {
        public AddOrderCommand(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
