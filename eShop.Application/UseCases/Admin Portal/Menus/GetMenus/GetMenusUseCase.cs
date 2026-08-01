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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetMenusUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<List<Menu>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Menus.GetAsync();
        }
    }
}
