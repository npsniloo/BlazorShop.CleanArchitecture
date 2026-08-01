using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public interface IGetCustomerOrdersUseCase
    {
        Task<List<Order>> ExecuteAsync(int userId);
    }
}
