using eShop.Domain.Entities;
using System.Linq.Expressions;

namespace eShop.Application.Interfaces.Repository
{
    public interface IRepository<T, Tkey> where T : class, IEntity<Tkey>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetByIdAsync(Tkey id);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task<IEnumerable<T>> GetPagedAsync(Expression<Func<T, bool>> filter, int pageNumber, int pageSize);
         Task<bool> ExistsByIdAsyn(Tkey id);
        Task AddAsync(T entity);
        void Remove(T entity);
    }
}
