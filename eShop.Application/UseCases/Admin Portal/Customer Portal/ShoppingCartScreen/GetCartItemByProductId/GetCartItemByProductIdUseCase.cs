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
        private readonly ICartRepository cartRepository;

        public GetCartItemByProductIdUseCase(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<Cart?> ExecuteAsync(int userId, int productId)
        {
            var cartItem = await cartRepository.GetByFilterAsync(c => c.UserId == userId &&
            c.ProductId == productId);
            return cartItem.FirstOrDefault();
        }
    }
}
