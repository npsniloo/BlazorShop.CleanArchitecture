using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class GetMenuByIdUseCase : IGetMenuByIdUseCase
    {
        private readonly IRepository<Menu, int> repository;

        public GetMenuByIdUseCase(IRepository<Menu, int> menuRepo)
        {
            this.repository = menuRepo;
        }
        public async Task<Menu?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
