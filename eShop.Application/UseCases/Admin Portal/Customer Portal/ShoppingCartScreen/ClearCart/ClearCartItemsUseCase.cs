using eShop.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ClearCartItemsUseCase : IClearCartItemsUseCase
    {
        private readonly ICartRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public ClearCartItemsUseCase(ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            repository = cartRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(int userId)
        {
            var items = await repository.GetByFilterAsync(x => x.UserId == userId);
            foreach (var item in items)
            {
                repository.Remove(item);
            }
            await unitOfWork.SaveChangesAsync();
        }
    }
}
