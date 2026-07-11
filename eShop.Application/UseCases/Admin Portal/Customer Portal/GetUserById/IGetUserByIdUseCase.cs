using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public interface IGetUserByIdUseCase
    {
        Task<User?> ExecuteAsync(int id);
    }
}
