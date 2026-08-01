using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public interface IRemoveProductFromCartUseCase
    {
        Task ExecuteAsync(int userId, int productId);
    }
}
