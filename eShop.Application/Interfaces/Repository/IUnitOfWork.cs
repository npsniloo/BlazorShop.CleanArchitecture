using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Interfaces.Repository
{
    public interface IUnitOfWork : IAsyncDisposable, IDisposable
    {
        public IProductRepository Products { get; }
        public IRepository<ProductGallery, int> ProductGalleries { get; }
        public ICartRepository Carts { get; }
        public IOrderRepository Orders { get; }
        public IRepository<OrderDetail, int> OrderDetails { get; }
        public ICommentRepository Comments { get; }
        public IUserRepository Users { get; }
        public IRepository<Banner, int> Banners { get; }
        public IRepository<Coupon, int> Coupons { get; }
        public IRepository<Menu, int> Menus { get; }
        public IRepository<Setting, int> Settings { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);


    }
}
