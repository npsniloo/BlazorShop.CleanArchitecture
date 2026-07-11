using eShop.Domain.Enums;

namespace eShop.Application.UseCases.Common.RegisterUser
{
    public interface IRegisterUserHandler
    {
        public Task ExecuteAsync(RegisterUserCommand command);
    }
}
