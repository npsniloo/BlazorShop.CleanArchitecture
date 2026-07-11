using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public interface IAddOrderDetailUseCase
    {
        Task ExecuteAsync(List<OrderDetail> orderDetails);
    }
}
