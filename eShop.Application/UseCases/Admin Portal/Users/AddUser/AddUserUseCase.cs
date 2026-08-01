using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class AddUserUseCase : IAddUserUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPasswordHashService passwordHashService;

        public AddUserUseCase(IUnitOfWorkFactory unitOfWorkFactory, IPasswordHashService hashService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this.passwordHashService = hashService;
        }

        public async Task ExecuteAsync(AddUserCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var email = command.Email.Trim().ToLowerInvariant();
           
            var exists = await unitOfWork.Users.ExistsByEmailAsync(email);
            
            if (exists)
                throw new InvalidOperationException("A user with this email already exists.");

            var passwordHash = passwordHashService.GetPasswordHash(command.Password);
           
            var user = User.Create(email,command.FullName,passwordHash.Hash,passwordHash.Salt,command.IsAdmin);
            
            await unitOfWork.Users.AddAsync(user);
            
            await unitOfWork.SaveChangesAsync();
        }
    }
}
