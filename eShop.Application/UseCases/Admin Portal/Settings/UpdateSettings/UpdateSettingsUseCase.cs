using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public class UpdateSettingsUseCase : IUpdateSettingsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateSettingsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(UpdateSettingsCommand command)
        {
           await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var settings = await unitOfWork.Settings.GetByIdAsync(command.Settings.Id);
            if (settings == null)
                return;

            // TODO: map Settings-specific fields here
            settings.Email = command.Settings.Email;
            settings.Shipping = command.Settings.Shipping;
            settings.Phone = command.Settings.Phone;
            settings.Logo = command.Settings.Logo;
            settings.FaceBook = command.Settings.FaceBook;
            settings.GooglePlus = command.Settings.GooglePlus;
            settings.Twitter = command.Settings.Twitter;
            settings.Instagram = command.Settings.Instagram;
            settings.Youtube = command.Settings.Youtube;
            settings.Address = command.Settings.Address;
            settings.CopyRight = command.Settings.CopyRight;
            settings.Title = command.Settings.Title;

            await unitOfWork.SaveChangesAsync();
        }
    }
}
