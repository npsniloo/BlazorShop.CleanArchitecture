

using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System.Linq.Expressions;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class SearchProductUseCase : ISearchProductUseCase
    {
        private readonly IRepository<Product, int> repository;
        public SearchProductUseCase(IRepository<Product, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Product>> Execute(int pageSize, int pageNumber, string? nameFilter)
        {
            if (string.IsNullOrWhiteSpace(nameFilter))
            {
                return await repository.GetPagedAsync(pageNumber, pageSize);
            }
            Expression<Func<Product, bool>> filter = p => string.IsNullOrEmpty(nameFilter) || 
            (p.Title!=null && p.Title.Contains(nameFilter));
            return await repository.GetPagedAsync(filter, pageNumber, pageSize);
        }
    }
}
