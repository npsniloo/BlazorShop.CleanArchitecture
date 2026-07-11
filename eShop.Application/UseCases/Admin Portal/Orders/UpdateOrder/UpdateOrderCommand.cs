using eShop.Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class UpdateOrderCommand
    {
        public UpdateOrderCommand(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
