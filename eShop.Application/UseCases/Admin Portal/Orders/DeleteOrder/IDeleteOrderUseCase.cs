using eShop.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public interface IDeleteOrderUseCase
    {
        public Task ExecuteAsync(int id);
    }
}
