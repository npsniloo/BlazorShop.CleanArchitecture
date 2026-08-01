using eShop.Application.Interfaces.Repository;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ClearCartItemsUseCase : IClearCartItemsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ClearCartItemsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int userId)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var items = await unitOfWork.Carts.GetByFilterAsync(x => x.UserId == userId);
            foreach (var item in items)
            {
                unitOfWork.Carts.Remove(item);
            }
            await unitOfWork.SaveChangesAsync();
        }
    }
}
