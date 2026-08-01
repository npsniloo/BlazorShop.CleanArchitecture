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
            await unitOfWork.SaveChangesAsync();
        }
    }
}
