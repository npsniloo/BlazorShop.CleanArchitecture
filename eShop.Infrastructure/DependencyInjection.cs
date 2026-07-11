using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Infrastructure.EmailService;
using eShop.Infrastructure.FileServices;
using eShop.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfraServices(this IServiceCollection services)
        {
            //Repository
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICartRepository,CartRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            //Common Services
            services.AddSingleton<IFileHelperService, FileHelperService>();
            services.AddScoped<IEmailService, SmtpEmailService>();

            return services;

        }
    }

}
