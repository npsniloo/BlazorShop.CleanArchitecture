using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IRepository<Product, int> repository;

        public GetProductsUseCase(IRepository<Product, int> repo)
        {
            this.repository = repo;
        }

        public async Task<IEnumerable<Product>> ExecuteAsync()
        {
            return await repository.GetAsync();
        }
    }
}
