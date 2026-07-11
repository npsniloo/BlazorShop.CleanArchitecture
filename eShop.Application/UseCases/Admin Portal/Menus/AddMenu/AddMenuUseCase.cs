using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class AddMenuUseCase : IAddMenuUseCase
    {
        private readonly IRepository<Menu, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public AddMenuUseCase(IRepository<Menu, int> menuRepo, IUnitOfWork unitOfWork)
        {
            this.repository = menuRepo;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(AddMenuCommand command)
        {
            await repository.AddAsync(command.Menu);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
