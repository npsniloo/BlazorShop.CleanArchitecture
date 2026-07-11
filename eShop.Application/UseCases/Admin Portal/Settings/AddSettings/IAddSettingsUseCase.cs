namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public interface IAddSettingsUseCase
    {
        Task ExecuteAsync(AddSettingsCommand command);
    }
}
