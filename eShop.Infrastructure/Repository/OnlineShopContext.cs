
using eShop.Domain.Entities;
using eShop.Infrastructure.Repository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Repository
{
    public partial class OnlineShopContext : DbContext
    {
        public OnlineShopContext()
        {
        }

        public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banners { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Coupon> Coupons { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductGallery> ProductGalleries { get; set; }

        public virtual DbSet<Setting> Settings { get; set; }

        public virtual DbSet<User> Users { get; set; }


       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductGalleryConfiguration());
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}