using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Application.UseCases.Common.ResetPassword;

namespace eShop.Application.UseCases.Common
{
    public class ResetPasswordHandler : IResetPasswordHandler
    {

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPasswordHashService passwordService;

        public ResetPasswordHandler(IUnitOfWorkFactory unitOfWorkFactory, IPasswordHashService passwordService)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            this.passwordService = passwordService;
        }

        public async Task ExecuteAsync(ResetPasswordCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();

            var usr = await unitOfWork.Users.GetByEmailAsync(command.Email);
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
