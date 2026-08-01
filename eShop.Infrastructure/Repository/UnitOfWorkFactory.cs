using eShop.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repository
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContextFactory<OnlineShopContext> dbContextFactory;
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWorkFactory(IDbContextFactory<OnlineShopContext> contextFactory, IServiceProvider serviceProvider)
        {
            dbContextFactory = contextFactory;
            this._serviceProvider = serviceProvider;
        }

        public IUnitOfWork Create(CancellationToken cancellationToken = default)
        {
            var dbContext =  dbContextFactory.CreateDbContext();
            return new UnitOfWork(dbContext, _serviceProvider);
        }

        public async Task<IUnitOfWork> CreateAsync(CancellationToken cancellationToken = default)
        {
            var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
            return new UnitOfWork(dbContext,_serviceProvider);
        }
    }
}
