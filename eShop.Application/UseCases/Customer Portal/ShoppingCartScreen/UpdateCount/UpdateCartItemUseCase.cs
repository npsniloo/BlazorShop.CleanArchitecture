using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal.ShoppingCartScreen.UpdateCount
{
    public class UpdateCartItemUseCase : IUpdateCartItemUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateCartItemUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(Cart cart)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var cartexists = await unitOfWork.Carts.ExistsByIdAsyn(cart.Id);
            if (cartexists)
                return;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
