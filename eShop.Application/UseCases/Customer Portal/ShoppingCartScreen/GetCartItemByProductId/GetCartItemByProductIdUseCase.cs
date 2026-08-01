using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetCartItemByProductIdUseCase : IGetCartItemByProductIdUseCase
    {

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetCartItemByProductIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Cart?> ExecuteAsync(int userId, int productId)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var cartItem = await unitOfWork.Carts.GetByFilterAsync(c => c.UserId == userId &&
            c.ProductId == productId);
            return cartItem.FirstOrDefault();
        }
    }
}
