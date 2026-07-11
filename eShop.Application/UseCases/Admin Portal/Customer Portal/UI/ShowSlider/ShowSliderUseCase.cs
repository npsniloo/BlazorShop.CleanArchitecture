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
        private readonly IRepository<Banner, int> repository;

        public ShowSliderUseCase(IRepository<Banner, int> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Banner>> ExecuteAsync()
        {
            var sliders = (await repository.GetByFilterAsync(b => b.Position == "Slider"))
                .OrderBy(s => s.Priority)
                .ToList();
            return sliders;
        }
    }
}
