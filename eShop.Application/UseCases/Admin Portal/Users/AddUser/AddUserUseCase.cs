using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class AddUserUseCase : IAddUserUseCase
    {
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHashService passwordHashService;

        public AddUserUseCase(IUserRepository repo, IUnitOfWork unitOfWork, IPasswordHashService hashService)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
            this.passwordHashService = hashService;
        }

        public async Task ExecuteAsync(AddUserCommand command)
        {
            var email = command.Email.Trim().ToLowerInvariant();
           
            var exists = await repository.ExistsByEmailAsync(email);
            
            if (exists)
                throw new InvalidOperationException("A user with this email already exists.");

            var passwordHash = passwordHashService.GetPasswordHash(command.Password);
           
            var user = User.Create(email,command.FullName,passwordHash.Hash,passwordHash.Salt,command.IsAdmin);
            
            await repository.AddAsync(user);
            
            await unitOfWork.SaveChangesAsync();
        }
    }
}
