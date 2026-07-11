using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eShop.Infrastructure.Repository
{
    public class Repository<T, Tkey> : IRepository<T, Tkey> where T : class, IEntity<Tkey>
    {
        private readonly IDbContextFactory<OnlineShopContext> _dbFactory;

        public Repository(IDbContextFactory<OnlineShopContext> dbFactory)
    {
            _dbFactory = dbFactory;
            
        }
        public async Task<IEnumerable<T>> GetAsync()
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            var dbSet = dbContext.Set<T>();
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            var dbSet = dbContext.Set<T>();
            return dbSet.Where(filter);
        }
        public async Task<T?> GetByIdAsync(Tkey id)
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            var dbSet = dbContext.Set<T>();
            return await dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize)
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            var dbSet = dbContext.Set<T>();
            return await dbSet.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<IEnumerable<T>> GetPagedAsync(Expression<Func<T, bool>> filter, int pageNumber, int pageSize)
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            var dbSet = dbContext.Set<T>();
            return await dbSet.Where(filter)
                .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }
        public async Task<bool> ExistsByIdAsyn(Tkey id)
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            var dbSet = dbContext.Set<T>();
            return await dbSet.AnyAsync(e => EqualityComparer<Tkey>.Default.Equals(e.Id, id));
        }
        public async Task AddAsync(T entity)
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            var dbSet = dbContext.Set<T>();
            await dbSet.AddAsync(entity);
        }
        public void Remove(T entity)
        {
            using var dbContext =  _dbFactory.CreateDbContext();
            var dbSet = dbContext.Set<T>();
            dbSet.Remove(entity);
        }


    }
}
