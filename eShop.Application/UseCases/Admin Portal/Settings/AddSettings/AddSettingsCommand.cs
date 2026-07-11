using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public class AddSettingsCommand
    {
        public AddSettingsCommand(Setting settings)
        {
            Settings = settings;
        }

        public Setting Settings { get; }
    }
}
