using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public interface IGetProductByIdUseCase
    {
        Task<Product?> ExecuteAsync(int id);
    }
}
