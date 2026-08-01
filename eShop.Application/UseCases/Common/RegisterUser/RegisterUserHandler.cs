using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Application.UseCases.Common.RegisterUser;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Common
{
    public class RegisterUserHandler : IRegisterUserHandler
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPasswordHashService passwordService;

        public RegisterUserHandler(IUnitOfWorkFactory unitOfWorkFactory, IPasswordHashService hashService)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            this.passwordService = hashService;
        }

        public async Task ExecuteAsync(RegisterUserCommand command)
        {
            var email = command.Email.Trim().ToLowerInvariant();

            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            
            var exists = await unitOfWork.Users.ExistsByEmailAsync(command.Email);
            
            if (exists)
               throw new Exception("email or password is not acceptable");

            var passwordHash = passwordService.GetPasswordHash(command.Password);

            var user = User.Create(email, command.FullName, passwordHash.Hash, passwordHash.Salt, command.IsAdmin);

            await unitOfWork.Users.AddAsync(user);

            await unitOfWork.SaveChangesAsync();


        }

        
    }
}
