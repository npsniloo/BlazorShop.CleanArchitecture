using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public interface IGetProductsUseCase
    {
        Task<IEnumerable<Product>> ExecuteAsync();
    }
}
