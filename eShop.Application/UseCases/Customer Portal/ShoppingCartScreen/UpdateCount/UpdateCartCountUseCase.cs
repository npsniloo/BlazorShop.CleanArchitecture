using eShop.Application.Interfaces.Repository;
using System;


namespace eShop.Application.UseCases.Customer_Portal
{
    public class UpdateCartCountUseCase : IUpdateCartCountUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateCartCountUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int userId, int productId, int count)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var cartItem = (await unitOfWork.Carts.GetByFilterAsync(x => x.UserId == userId && x.ProductId == productId)).FirstOrDefault();

            if (cartItem == null)
                throw new NullReferenceException();

            cartItem.Count = count;
            await unitOfWork.SaveChangesAsync();

        }
    }
}
