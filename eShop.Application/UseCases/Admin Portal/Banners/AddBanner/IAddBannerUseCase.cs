
namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public interface IAddBannerUseCase
    {
        public Task ExecuteAsync(AddBannerCommand command);
    }
}
