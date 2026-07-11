using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class UpdateMenuUseCase : IUpdateMenuUseCase
    {
        private readonly IRepository<Menu, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateMenuUseCase(IRepository<Menu, int> menuRepo, IUnitOfWork unitOfWork)
        {
            this.repository = menuRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(UpdateMenuCommand command)
        {
            var menu = await repository.GetByIdAsync(command.Menu.Id);
            if (menu == null)
                return;
            

            menu.Title = command.Menu.Title;
            menu.Link = command.Menu.Link;
            menu.Type = command.Menu.Type;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
