using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal.ShoppingCartScreen.UpdateCount
{
    public class UpdateCartItemUseCase : IUpdateCartItemUseCase
    {
        private readonly ICartRepository cartRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateCartItemUseCase(ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(Cart cart)
        {
            var cartexists = await cartRepository.ExistsByIdAsyn(cart.Id);
            if (cartexists)
                return;
            await unitOfWork.SaveChangesAsync();

        }
    }
}
