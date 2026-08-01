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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetCartItemsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<List<CartItemDto>> ExecuteAsync(int userId)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var items = await unitOfWork.Carts.GetCartWithProductByUserIdAsync(userId);
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
