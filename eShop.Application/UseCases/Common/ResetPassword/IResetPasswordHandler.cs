using eShop.Domain.Enums;

namespace eShop.Application.UseCases.Common.ResetPassword
{
    public interface IResetPasswordHandler
    {
        public Task ExecuteAsync(ResetPasswordCommand command);
    }
}
