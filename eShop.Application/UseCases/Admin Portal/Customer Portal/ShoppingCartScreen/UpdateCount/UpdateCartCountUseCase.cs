using eShop.Application.Interfaces.Repository;
using System;


namespace eShop.Application.UseCases.Customer_Portal
{
    public class UpdateCartCountUseCase : IUpdateCartCountUseCase
    {
        private ICartRepository repository;
        private IUnitOfWork unitOfWork;
        public UpdateCartCountUseCase(ICartRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(int userId, int productId, int count)
        {
            var cartItem = (await repository.GetByFilterAsync(x => x.UserId == userId && x.ProductId == productId)).FirstOrDefault();
           
            if (cartItem == null)
                throw new NullReferenceException();

            cartItem.Count = count;
            await unitOfWork.SaveChangesAsync();

        }
    }
}
