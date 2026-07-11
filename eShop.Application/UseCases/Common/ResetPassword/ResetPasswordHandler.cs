using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Application.UseCases.Common.ResetPassword;

namespace eShop.Application.UseCases.Common
{
    public class ResetPasswordHandler : IResetPasswordHandler
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHashService passwordService;

        public ResetPasswordHandler(IUserRepository userRepository, IPasswordHashService passwordService, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.passwordService = passwordService;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(ResetPasswordCommand command)
        {       
            var usr = await userRepository.GetByEmailAsync(command.Email);
            if (usr == null || usr.RecoveryCode != command.RecoveryCode)
                throw new Exception("UserName or code is wrong ");

            var password = passwordService.GetPasswordHash(command.NewPassword);
            usr.RecoveryCode = null;
            usr.PasswordSalt = password.Hash;
            usr.PasswordHash = password.Salt;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
