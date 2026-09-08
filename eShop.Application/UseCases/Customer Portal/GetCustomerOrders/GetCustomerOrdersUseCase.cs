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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetCustomerOrdersUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Order>> ExecuteAsync(int userId)
        {
            var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var orders = (await unitOfWork.Orders.GetByFilterAsync(c => c.UserId == userId))
                .ToList();
            return orders;
        }
    }
}
