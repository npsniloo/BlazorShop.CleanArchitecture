namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public interface IUpdateSettingsUseCase
    {
        Task ExecuteAsync(UpdateSettingsCommand command);
    }
}
