using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class GetMenuByIdUseCase : IGetMenuByIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetMenuByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<Menu?> ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Menus.GetByIdAsync(id);
        }
    }
}
