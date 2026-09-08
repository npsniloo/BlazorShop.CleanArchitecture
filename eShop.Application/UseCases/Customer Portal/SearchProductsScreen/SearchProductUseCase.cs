

using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System.Linq.Expressions;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class SearchProductUseCase : ISearchProductUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public SearchProductUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Product>> Execute(int pageSize, int pageNumber, string? nameFilter)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();

            if (string.IsNullOrWhiteSpace(nameFilter))
            {
                return await unitOfWork.Products.GetPagedAsync(pageNumber, pageSize);
            }
            Expression<Func<Product, bool>> filter = p => string.IsNullOrEmpty(nameFilter) || 
            (p.Title!=null && p.Title.Contains(nameFilter));
            return await unitOfWork.Products.GetPagedAsync(filter, pageNumber, pageSize);
        }
    }
}
