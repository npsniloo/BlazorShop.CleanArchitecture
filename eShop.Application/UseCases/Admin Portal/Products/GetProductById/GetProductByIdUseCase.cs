using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IRepository<Product, int> repository;

        public GetProductByIdUseCase(IRepository<Product, int> repo)
        {
            this.repository = repo;
        }

        public async Task<Product?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
