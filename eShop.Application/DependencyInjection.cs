using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services.Shared;
using eShop.Application.Services;
using eShop.Application.UseCases.Common;
using eShop.Application.UseCases.Common.Login;
using eShop.Application.UseCases.Common.RecoveryCode;
using eShop.Application.UseCases.Common.RegisterUser;
using eShop.Application.UseCases.Common.ResetPassword;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationaServices(this IServiceCollection services)
        {

            //Common
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<ISendRecoveryCodeHandler, SendRecoveryCodeHandler>();
            services.AddScoped<IRegisterUserHandler, RegisterUserHandler>();
            services.AddScoped<IPasswordHashService, SHA256PasswordHashService>();
            services.AddScoped<IRegisterUserHandler, RegisterUserHandler>();
            services.AddScoped<IResetPasswordHandler, ResetPasswordHandler>();

            //Customer Portal
            CustomerPortalDependencyInjection.ConfigureCustomerServices(services);

            //Admin Potral
            AdminPortalPortalDependencyInjection.ConfigureAdminServices(services);

            return services;

        }
    }
}
