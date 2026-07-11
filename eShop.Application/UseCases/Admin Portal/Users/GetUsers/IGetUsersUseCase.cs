using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public interface IGetUsersUseCase
    {
        Task<IEnumerable<User>> ExecuteAsync();
    }
}
