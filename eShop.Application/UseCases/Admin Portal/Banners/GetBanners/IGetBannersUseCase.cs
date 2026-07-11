using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public interface IGetBannersUseCase
    {
        Task<IEnumerable<Banner>> ExecuteAsync();
    }
}
