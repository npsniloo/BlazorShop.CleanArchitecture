using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ShowSliderUseCase : IShowSliderUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ShowSliderUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Banner>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var sliders = (await unitOfWork.Banners.GetByFilterAsync(b => b.Position == "Slider"))
                .OrderBy(s => s.Priority)
                .ToList();
            return sliders;
        }
    }
}
