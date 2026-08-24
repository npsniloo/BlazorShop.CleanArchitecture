using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{ 
    public class GetTopMenusUseCase : IGetTopMenusUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetTopMenusUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Menu>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var menus = await unitOfWork.Menus.GetByFilterAsync(m => m.Type == "Top");
            if (menus == null)
                throw new Exception("menus doesnt exist");
            return menus;
        }
    }
}
