using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public interface IGetUserByIdUseCase
    {
        Task<User?> ExecuteAsync(int id);
    }
}
