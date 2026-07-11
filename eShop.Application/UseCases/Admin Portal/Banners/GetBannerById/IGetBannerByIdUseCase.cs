using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public interface IGetBannerByIdUseCase
    {
        public Task<Banner?> ExecuteAsync(int id);
    }
}
