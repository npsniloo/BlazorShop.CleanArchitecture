using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public class UpdateSettingsCommand
    {
        public UpdateSettingsCommand(Setting settings)
        {
            Settings = settings;
        }

        public Setting Settings { get; }
    }
}
