using eShop.Domain.Entities;
using System.Linq.Expressions;

namespace eShop.Application.Interfaces.Repository
{
    public interface IRepository<T, Tkey> where T : class, IEntity<Tkey>
    {
        Task<List<T>> GetAsync();
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetByIdAsync(Tkey id);
        Task<List<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task<List<T>> GetPagedAsync(Expression<Func<T, bool>> filter, int pageNumber, int pageSize);
         Task<bool> ExistsByIdAsyn(Tkey id);
        Task AddAsync(T entity);
        void Remove(T entity);
    }
}
