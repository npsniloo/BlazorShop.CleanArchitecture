using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IRepository<User, int> repository;

        public GetUserByIdUseCase(IRepository<User, int> repo)
        {
            this.repository = repo;
        }

        public async Task<User?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
