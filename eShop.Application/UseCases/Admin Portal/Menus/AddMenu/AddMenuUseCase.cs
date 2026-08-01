using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class AddMenuUseCase : IAddMenuUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AddMenuUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(AddMenuCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            await unitOfWork.Menus.AddAsync(command.Menu);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
