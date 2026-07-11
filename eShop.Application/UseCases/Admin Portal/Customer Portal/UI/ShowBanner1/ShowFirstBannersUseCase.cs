using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ShowFirstBannersUseCase : IShowFirstBannersUseCase
    {
        private readonly IRepository<Banner,int> _bannerRepository;

        public ShowFirstBannersUseCase(IRepository<Banner, int> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<List<Banner>> ExecuteAsync()
        {
            var banners = (await _bannerRepository
                .GetByFilterAsync(c => c.Position == "Banner1"))
                .OrderBy(d => d.Priority)
                .ToList();
            return banners;
        }
    }
}
