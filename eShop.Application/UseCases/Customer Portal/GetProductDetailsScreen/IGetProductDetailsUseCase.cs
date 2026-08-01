using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public interface IGetProductDetailsUseCase
    {
        Task<Product?> ExecuteAsync(int id);
    }
}
