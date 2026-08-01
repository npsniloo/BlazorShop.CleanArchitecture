using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ShowSecondBannersUseCase : IShowSecondBannersUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ShowSecondBannersUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Banner>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var banners = (await unitOfWork.Banners
                .GetByFilterAsync(c => c.Position == "Banner2"))
                .OrderBy(d => d.Priority)
                .ToList();
            return banners;
        }
    }
}
