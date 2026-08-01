using eShop.Application.Dtos;
using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Application.Interfaces.Services.Shared;
using System.Security.Cryptography;

namespace eShop.Application.UseCases.Common.Login
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IPasswordHashService passwordService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public LoginHandler(IUnitOfWorkFactory unitOfWorkFactory, IPasswordHashService passwordService)
        {
            this.passwordService = passwordService;
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<LoginResponse> ExecuteAsync(string email, string password)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var usr = await unitOfWork.Users.GetByEmailAsync(email);
            if (usr == null || passwordService.VerifyPassword(password, usr.PasswordHash, usr.PasswordSalt) == false)
                throw new Exception("userName or password is wrong ");
            return new LoginResponse(usr.Id, usr.Email, usr.FullName, usr.IsAdmin);
        }

        
    }
}
