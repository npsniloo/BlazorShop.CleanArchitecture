using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eShop.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopContext dbContext;
        private readonly IServiceProvider _serviceProvider;
        private IProductRepository? products;
        private IOrderRepository? orders;
        private ICartRepository? carts;
        private ICommentRepository? comments;
        private IUserRepository? users;
        private IRepository<ProductGallery, int>? productGalleries;
        private IRepository<OrderDetail, int>? orderDetails;
        private IRepository<Banner, int>? banners;
        private IRepository<Coupon, int>? coupons;
        private IRepository<Menu, int>? menus;
        private IRepository<Setting, int>? settings;

        public IProductRepository Products => products ??= ActivatorUtilities.CreateInstance<ProductRepository>(_serviceProvider, dbContext);
        public ICartRepository Carts => carts ??= ActivatorUtilities.CreateInstance<CartRepository>(_serviceProvider, dbContext);
        public IOrderRepository Orders => orders ??= ActivatorUtilities.CreateInstance<OrderRepository>(_serviceProvider, dbContext);
        public ICommentRepository Comments => comments ??= ActivatorUtilities.CreateInstance<CommentRepository>(_serviceProvider, dbContext);
        public IUserRepository Users => users ??= ActivatorUtilities.CreateInstance<UserRepository>(_serviceProvider, dbContext);


        public IRepository<ProductGallery, int> ProductGalleries => productGalleries ??= ActivatorUtilities.CreateInstance<Repository<ProductGallery, int>>(_serviceProvider, dbContext);

        public IRepository<OrderDetail, int> OrderDetails => orderDetails ??= ActivatorUtilities.CreateInstance<Repository<OrderDetail, int>>(_serviceProvider, dbContext);

        public IRepository<Banner, int> Banners => banners ??= ActivatorUtilities.CreateInstance<Repository<Banner, int>>(_serviceProvider, dbContext);

        public IRepository<Coupon, int> Coupons => coupons ??= ActivatorUtilities.CreateInstance<Repository<Coupon, int>>(_serviceProvider, dbContext);

        public IRepository<Menu, int> Menus => menus ??= ActivatorUtilities.CreateInstance<Repository<Menu, int>>(_serviceProvider, dbContext);

        public IRepository<Setting, int> Settings => settings ??= ActivatorUtilities.CreateInstance<Repository<Setting, int>>(_serviceProvider, dbContext);


        public UnitOfWork(OnlineShopContext context, IServiceProvider serviceProvider)
        {
            dbContext = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        private IDbContextTransaction? _currentTransaction;
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            // اگر قبلاً ترانزکشن باز شده، کاری نمی‌کنیم
            if (_currentTransaction is not null) return;

            _currentTransaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction is null)
                throw new InvalidOperationException("Cannot commit transaction. No active transaction found.");

            try
            {
                await dbContext.Database.CommitTransactionAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken); // در صورت بروز خطا در زمان Commit، Rollback می‌کنیم
                throw;
            }
            finally
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction is null) return;

            try
            {
                await dbContext.Database.RollbackTransactionAsync(cancellationToken);
            }
            finally
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
        public async ValueTask DisposeAsync()
        {
            if (_currentTransaction is not null)
            {
                // اگر کسی DisposeAsync را بدون Commit یا Rollback فراخوانی کرد، باید Rollback کنیم
                await RollbackTransactionAsync();
            }

            await dbContext.DisposeAsync();
        }


    }
}
