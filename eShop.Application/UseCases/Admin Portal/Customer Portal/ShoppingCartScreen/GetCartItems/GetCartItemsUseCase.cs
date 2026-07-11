using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetCartItemsUseCase : IGetCartItemsUseCase
    {
        private ICartRepository repository;
        public GetCartItemsUseCase(ICartRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<CartItemDto>> ExecuteAsync(int userId)
        {
            var items = await repository.GetCartWithProductByUserIdAsync(userId);
            return items.Select(item => new CartItemDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductTitle = item.ProductTitle,
                Count = item.Count,
                ProductPrice = item.ProductPrice,
                ProductDiscount = item.ProductDiscount,
                RowSum = (item.ProductPrice.GetValueOrDefault(0) - item.ProductDiscount.GetValueOrDefault(0)) * item.Count
            }).ToList();
        }
    }
}
