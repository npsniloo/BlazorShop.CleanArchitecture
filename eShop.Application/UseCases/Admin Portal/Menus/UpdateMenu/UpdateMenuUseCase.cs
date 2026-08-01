using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class UpdateMenuUseCase : IUpdateMenuUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateMenuUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(UpdateMenuCommand command)
        {
           await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var menu = await unitOfWork.Menus.GetByIdAsync(command.Menu.Id);
            if (menu == null)
                return;
            

            menu.Title = command.Menu.Title;
            menu.Link = command.Menu.Link;
            menu.Type = command.Menu.Type;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
