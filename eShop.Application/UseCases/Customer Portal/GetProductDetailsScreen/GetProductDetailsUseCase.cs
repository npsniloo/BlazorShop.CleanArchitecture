using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetProductDetailsUseCase : IGetProductDetailsUseCase
    {
        private readonly IRepository<Product, int> repository;

        public GetProductDetailsUseCase(IRepository<Product, int> repo)
        {
            this.repository = repo;
        }

        public async Task<Product?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
