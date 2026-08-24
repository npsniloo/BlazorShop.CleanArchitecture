using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{ 
    public class GetBottomMenusUseCase : IGetBottomMenusUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetBottomMenusUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Menu>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var menus = await unitOfWork.Menus.GetByFilterAsync(m => m.Type == "Bottom");
            if (menus == null)
                throw new Exception("menus doesnt exist");
            return menus;
        }
    }
}
