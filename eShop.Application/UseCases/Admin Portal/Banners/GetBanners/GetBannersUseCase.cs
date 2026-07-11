using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class GetBannersUseCase : IGetBannersUseCase
    {
        private readonly IRepository<Banner, int> repository;

        public GetBannersUseCase(IRepository<Banner, int> bannerRepository)
        {
            this.repository = bannerRepository;
        }
        public async Task<IEnumerable<Banner>> ExecuteAsync()
        {
            return await repository.GetAsync();
        }
    }
}
