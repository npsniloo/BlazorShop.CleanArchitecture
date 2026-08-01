using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class DeleteMenuUseCase : IDeleteMenuUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DeleteMenuUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var menu = await unitOfWork.Menus.GetByIdAsync(id);
            if (menu == null)
                return;
            unitOfWork.Menus.Remove(menu);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
