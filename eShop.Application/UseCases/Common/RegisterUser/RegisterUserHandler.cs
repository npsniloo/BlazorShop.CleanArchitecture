using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Application.UseCases.Common.RegisterUser;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Common
{
    public class RegisterUserHandler : IRegisterUserHandler
    {
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHashService passwordService;

        public RegisterUserHandler(IUserRepository userRepository,IUnitOfWork unitOfWork, IPasswordHashService hashService)
        {
            this.repository = userRepository;
            this.unitOfWork = unitOfWork;
            this.passwordService = hashService;
        }

        public async Task ExecuteAsync(RegisterUserCommand command)
        {
            var email = command.Email.Trim().ToLowerInvariant();

            var exists = await repository.ExistsByEmailAsync(command.Email);
            
            if (exists)
               throw new Exception("email or password is not acceptable");

            var passwordHash = passwordService.GetPasswordHash(command.Password);

            var user = User.Create(email, command.FullName, passwordHash.Hash, passwordHash.Salt, command.IsAdmin);

            await repository.AddAsync(user);

            await unitOfWork.SaveChangesAsync();


        }

        
    }
}
