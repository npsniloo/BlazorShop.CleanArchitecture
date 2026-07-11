using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public class AddSettingsUseCase : IAddSettingsUseCase
    {
        private readonly IRepository<Setting, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public AddSettingsUseCase(IRepository<Setting, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(AddSettingsCommand command)
        {
            await repository.AddAsync(command.Settings);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
