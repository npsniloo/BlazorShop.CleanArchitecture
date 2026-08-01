using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class RemoveProductFromCartUseCase : IRemoveProductFromCartUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public RemoveProductFromCartUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int userId, int productId)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var carts = await unitOfWork.Carts.GetByFilterAsync(c => c.UserId == userId && c.ProductId == productId);
            if (!carts.Any())
                throw new Exception("Cart Item not found");

            if (carts.Count() != 1)
                throw new Exception("Multi Cart Item found");

            var cart = carts.Single();

            unitOfWork.Carts.Remove(cart);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
