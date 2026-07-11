using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IRepository<User, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateUserUseCase(IRepository<User, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(UpdateUserCommand command)
        {
            var user = await repository.GetByIdAsync(command.User.Id);
            if (user == null)
                return;

            // TODO: map User-specific fields here
            await unitOfWork.SaveChangesAsync();
        }
    }
}
