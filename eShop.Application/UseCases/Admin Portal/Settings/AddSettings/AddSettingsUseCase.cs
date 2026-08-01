using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public class AddSettingsUseCase : IAddSettingsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AddSettingsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(AddSettingsCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            await unitOfWork.Settings.AddAsync(command.Settings);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
