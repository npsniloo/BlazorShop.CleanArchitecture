using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Application.UseCases.Common.RecoveryCode;

namespace eShop.Application.UseCases.Common
{
    public class SendRecoveryCodeHandler : ISendRecoveryCodeHandler
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IEmailService emailService;
        public SendRecoveryCodeHandler(IUnitOfWorkFactory unitOfWorkFactory, IEmailService emailService)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            this.emailService = emailService;
        }
        public async Task ExecuteAsync(string email)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var usr = await unitOfWork.Users.GetByEmailAsync(email);
            if (usr == null)
                throw new Exception("UserName or Password is wrong ");

            usr.RecoveryCode = new Random().Next(1000, 10000);

            try
            {
                await emailService.SendEmailAsync(usr.Email, $"کد بازیابی شما: {usr.RecoveryCode} ", "ایمیل بازیابی");
            }
            catch (Exception ex)
            {
                throw new Exception("Send Code Error");
            }

        }

        
    }
}
