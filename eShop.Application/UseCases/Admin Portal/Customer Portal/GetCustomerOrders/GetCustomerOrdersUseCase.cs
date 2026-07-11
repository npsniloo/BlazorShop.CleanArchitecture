using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetCustomerOrdersUseCase : IGetCustomerOrdersUseCase
    {
        private readonly IOrderRepository repository;

        public GetCustomerOrdersUseCase(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Order>> ExecuteAsync(int userId)
        {
            var orders = (await repository
                .GetByFilterAsync(c => c.UserId == userId))
                .ToList();
            return orders;
        }
    }
}
