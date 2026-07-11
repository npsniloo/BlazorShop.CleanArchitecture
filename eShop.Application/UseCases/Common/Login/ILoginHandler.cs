using eShop.Application.Dtos;

namespace eShop.Application.UseCases.Common.Login
{
    public interface ILoginHandler
    {
        public Task<LoginResponse> ExecuteAsync(string email, string password);
    }
}
