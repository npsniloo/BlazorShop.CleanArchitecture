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
        private readonly ICartRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public RemoveProductFromCartUseCase(ICartRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(int userId, int productId)
        {
            var carts = await repository.GetByFilterAsync(c => c.UserId == userId && c.ProductId == productId);
            if (!carts.Any())
                throw new Exception("Cart Item not found");

            if (carts.Count() != 1)
                throw new Exception("Multi Cart Item found");
           
            var cart = carts.Single();
            
            repository.Remove(cart);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
