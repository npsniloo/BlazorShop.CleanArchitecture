
namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public interface IUpdateBannerUseCase 
    {
        public Task ExecuteAsync(UpdateBannerCommand command);
    }
}
