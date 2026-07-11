using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    internal class AddCartItemUseCase : IAddCartItemUseCase
    {
        private readonly ICartRepository cartRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddCartItemUseCase(ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(Cart cart)
        {
            await cartRepository.AddAsync(cart);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
