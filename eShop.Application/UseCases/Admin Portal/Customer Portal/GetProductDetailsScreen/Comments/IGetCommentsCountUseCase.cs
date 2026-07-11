using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public interface IGetCommentsCountUseCase
    {
        Task<int> ExecuteAsync(int prodId);
    }
}
