using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IRepository<User, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteUserUseCase(IRepository<User, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            if (user == null)
                return;

            repository.Remove(user);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
