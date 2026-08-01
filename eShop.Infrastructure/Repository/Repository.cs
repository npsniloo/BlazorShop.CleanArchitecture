using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eShop.Infrastructure.Repository
{
    public class Repository<T, Tkey> : IRepository<T, Tkey> where T : class, IEntity<Tkey>
    {
        private readonly OnlineShopContext dbContext;

        public Repository(OnlineShopContext context)
    {
            dbContext = context;
            
        }
        public async Task<List<T>> GetAsync()
        {
            var dbSet = dbContext.Set<T>();
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            var dbSet = dbContext.Set<T>();
            return await dbSet.Where(filter).ToListAsync();
        }
        public async Task<T?> GetByIdAsync(Tkey id)
        {
            var dbSet = dbContext.Set<T>();
            return await dbSet.FindAsync(id);
        }
        public async Task<List<T>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var dbSet = dbContext.Set<T>();
            return await dbSet.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<List<T>> GetPagedAsync(Expression<Func<T, bool>> filter, int pageNumber, int pageSize)
        {
            var dbSet = dbContext.Set<T>();
            return await dbSet.Where(filter)
                .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }
        public async Task<bool> ExistsByIdAsyn(Tkey id)
        {
            var dbSet = dbContext.Set<T>();
            return await dbSet.AnyAsync(e => EqualityComparer<Tkey>.Default.Equals(e.Id, id));
        }
        public async Task AddAsync(T entity)
        {
            var dbSet = dbContext.Set<T>();
            await dbSet.AddAsync(entity);
        }
        public void Remove(T entity)
        {
            var dbSet = dbContext.Set<T>();
            dbSet.Remove(entity);
        }


    }
}
