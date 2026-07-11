using eShop.Domain.Enums;

namespace eShop.Application.UseCases.Common.RecoveryCode
{
    public interface ISendRecoveryCodeHandler
    {
        public Task ExecuteAsync(string email);
    }
}
