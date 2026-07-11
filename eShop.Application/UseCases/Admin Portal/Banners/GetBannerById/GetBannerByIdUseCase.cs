using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class GetBannerByIdUseCase : IGetBannerByIdUseCase
    {
        private readonly IRepository<Banner, int> repository;

        public GetBannerByIdUseCase(IRepository<Banner, int> bannerRepository)
        {
            this.repository = bannerRepository;
        }
        public async Task<Banner?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
