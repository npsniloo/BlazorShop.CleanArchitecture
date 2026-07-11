using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public interface IGetMainSettingUseCase
    {
        Task<Setting?> ExecuteAsync();
    }
}
