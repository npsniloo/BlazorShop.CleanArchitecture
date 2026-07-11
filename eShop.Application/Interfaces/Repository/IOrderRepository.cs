using eShop.Application.UseCases.Customer_Portal;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        void RemoveOrderWithDetailsByOrderId(Order order);
    }
}
