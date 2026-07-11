using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class GetMenusUseCase : IGetMenusUseCase
    {
        private readonly IRepository<Menu, int> repository;

        public GetMenusUseCase(IRepository<Menu, int> bannerRepository)
        {
            this.repository = bannerRepository;
        }
        public async Task<IEnumerable<Menu>> ExecuteAsync()
        {
            return await repository.GetAsync();
        }
    }
}
