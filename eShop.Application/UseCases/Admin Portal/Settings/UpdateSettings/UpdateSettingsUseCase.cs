using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public class UpdateSettingsUseCase : IUpdateSettingsUseCase
    {
        private readonly IRepository<Setting, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateSettingsUseCase(IRepository<Setting, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(UpdateSettingsCommand command)
        {
            var settings = await repository.GetByIdAsync(command.Settings.Id);
            if (settings == null)
                return;

            // TODO: map Settings-specific fields here
            await unitOfWork.SaveChangesAsync();
        }
    }
}
