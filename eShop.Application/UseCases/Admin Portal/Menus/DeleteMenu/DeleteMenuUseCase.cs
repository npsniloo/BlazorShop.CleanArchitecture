using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class DeleteMenuUseCase : IDeleteMenuUseCase
    {
        private readonly IRepository<Menu, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteMenuUseCase(IRepository<Menu, int> menuRepo, IUnitOfWork unitOfWork)
        {
            this.repository = menuRepo;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(int id)
        {
            var menu = await repository.GetByIdAsync(id);
            if (menu == null)
                return;            
            repository.Remove(menu);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
