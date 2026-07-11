using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public class GetMainSettingUseCase : IGetMainSettingUseCase
    {
        private readonly IRepository<Setting, int> repository;

        public GetMainSettingUseCase(IRepository<Setting, int> repo)
        {
            this.repository = repo;
        }

        public async Task<Setting?> ExecuteAsync()
        {
            return (await repository.GetAsync()).FirstOrDefault();
        }
    }
}
