using eShop.Application.Dtos;
using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Application.Interfaces.Services.Shared;
using System.Security.Cryptography;

namespace eShop.Application.UseCases.Common.Login
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHashService passwordService;

        public LoginHandler(IUserRepository userRepository, IPasswordHashService passwordHasherService)
        {
            this.userRepository = userRepository;
            this.passwordService = passwordHasherService;
        }

        public async Task<LoginResponse> ExecuteAsync(string email, string password)
        {
            var usr = await userRepository.GetByEmailAsync(email);
            if (usr == null || passwordService.VerifyPassword(password, usr.PasswordHash, usr.PasswordSalt) == false)
                throw new Exception("userName or password is wrong ");
            return new LoginResponse(usr.Id, usr.Email, usr.FullName, usr.IsAdmin);
        }

        
    }
}
