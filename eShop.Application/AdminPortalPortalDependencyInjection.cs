using eShop.Application.UseCases.Admin_Portal.Banners;
using eShop.Application.UseCases.Admin_Portal.Comments;
using eShop.Application.UseCases.Admin_Portal.Coupons;
using eShop.Application.UseCases.Admin_Portal.Menus;
using eShop.Application.UseCases.Admin_Portal.Orders;
using eShop.Application.UseCases.Admin_Portal.Products;
using eShop.Application.UseCases.Admin_Portal.Settings;
using eShop.Application.UseCases.Admin_Portal.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application
{
    public static class AdminPortalPortalDependencyInjection
    {
        public static IServiceCollection ConfigureAdminServices(this IServiceCollection services)
        {
            services.AddScoped<IGetBannerByIdUseCase, GetBannerByIdUseCase>();
            services.AddScoped<IGetBannersUseCase, GetBannersUseCase>();
            services.AddScoped<IAddBannerUseCase, AddBannerUseCase>();
            services.AddScoped<IUpdateBannerUseCase, UpdateBannerUseCase>();
            services.AddScoped<IDeleteBannerUseCase, DeleteBannerUseCase>();

            services.AddScoped<IGetCommentByIdUseCase, GetCommentByIdUseCase>();
            services.AddScoped<IGetCommentsUseCase, GetCommentsUseCase>();
            services.AddScoped<IAddCommentUseCase, AddCommentUseCase>();
            services.AddScoped<IUpdateCommentUseCase, UpdateCommentUseCase>();
            services.AddScoped<IDeleteCommentUseCase, DeleteCommentUseCase>();

            services.AddScoped<IGetMenusUseCase, GetMenusUseCase>();
            services.AddScoped<IGetMenuByIdUseCase, GetMenuByIdUseCase>();
            services.AddScoped<IAddMenuUseCase, AddMenuUseCase>();
            services.AddScoped<IUpdateMenuUseCase, UpdateMenuUseCase>();
            services.AddScoped<IDeleteMenuUseCase, DeleteMenuUseCase>();

            services.AddScoped<IGetCouponByIdUseCase, GetCouponByIdUseCase>();
            services.AddScoped<IGetCouponsUseCase, GetCouponsUseCase>();
            services.AddScoped<IAddCouponUseCase, AddCouponUseCase>();
            services.AddScoped<IUpdateCouponUseCase, UpdateCouponUseCase>();
            services.AddScoped<IDeleteCouponUseCase, DeleteCouponUseCase>();

            services.AddScoped<IGetOrderByIdUseCase, GetOrderByIdUseCase>();
            services.AddScoped<IGetOrdersUseCase, GetOrdersUseCase>();
            services.AddScoped<IGetOrderDetailsUseCase, GetOrderDetailsUseCase>();
            services.AddScoped<IAddOrderUseCase, AddOrderUseCase>();
            services.AddScoped<IUpdateOrderUseCase, UpdateOrderUseCase>();
            services.AddScoped<IDeleteOrderUseCase, DeleteOrderUseCase>();

            services.AddScoped<IAddProductUseCase, AddProductUseCase>();
            services.AddScoped<IDeleteGalleryUseCase, DeleteGalleryUseCase>();
            services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddScoped<IGetGalleriesByProdIdUseCase, GetGalleriesByProdIdUseCase>();
            services.AddScoped<IGetGalleryByIdUseCase, GetGalleryByIdUseCase>();
            services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddScoped<IGetProductsUseCase, GetProductsUseCase>();
            services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();

            services.AddScoped<IGetMainSettingUseCase, GetMainSettingUseCase>();
            services.AddScoped<IAddSettingsUseCase, AddSettingsUseCase>();
            services.AddScoped<IUpdateSettingsUseCase, UpdateSettingsUseCase>();




            services.AddScoped<IAddUserUseCase, AddUserUseCase>();
            services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
            services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
            services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();

            return services;
        }
    }
}
