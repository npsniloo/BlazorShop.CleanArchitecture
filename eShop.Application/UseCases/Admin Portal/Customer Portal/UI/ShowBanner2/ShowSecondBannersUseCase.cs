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
        private readonly IRepository<Banner, int> _bannerRepository;

        public ShowSecondBannersUseCase(IRepository<Banner, int> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<List<Banner>> ExecuteAsync()
        {
            var banners = (await _bannerRepository
                .GetByFilterAsync(c => c.Position == "Banner2"))
                .OrderBy(d => d.Priority)
                .ToList();
            return banners;
        }
    }
}
