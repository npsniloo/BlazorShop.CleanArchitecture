using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class GetUsersUseCase : IGetUsersUseCase
    {
        private readonly IRepository<User, int> repository;

        public GetUsersUseCase(IRepository<User, int> repo)
        {
            this.repository = repo;
        }

        public async Task<IEnumerable<User>> ExecuteAsync()
        {
            return await repository.GetAsync();
        }
    }
}
