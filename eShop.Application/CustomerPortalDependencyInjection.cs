using eShop.Application.UseCases.Customer_Portal;
using eShop.Application.UseCases.Customer_Portal.NewProductsScreen;
using eShop.Application.UseCases.Customer_Portal.ViewProducts;
using eShop.Application.UseCases.Customer_Portal.ViewProducts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Application
{
    public static class CustomerPortalDependencyInjection
    {
        public static IServiceCollection ConfigureCustomerServices(this IServiceCollection services)
        {
            services.AddScoped<ISearchProductUseCase, SearchProductUseCase>();
            services.AddScoped<IGetCommentsCountUseCase, GetCommentsCountUseCase>();
            services.AddScoped<IAddCommentUseCase, AddCommentUseCase>();
            services.AddScoped<IGetProductDetailsUseCase, GetProductDetailsUseCase>();
            services.AddScoped<IGetCustomerOrderByIdUseCase, GetCustomerOrderByIdUseCase>();
            services.AddScoped<IGetCustomerOrdersUseCase, GetCustomerOrdersUseCase>();
            services.AddScoped<IGetGalleriesByProdIdUseCase, GetGalleriesByProdIdUseCase>();

            services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();

            services.AddScoped<INewProductsUseCase, NewProductsUseCase>();


            services.AddScoped<IViewProductUseCase, ViewProductUseCase>();

            services.AddScoped<IAddOrderDetailUseCase, AddOrderDetailUseCase>();
            services.AddScoped<IGetCouponDiscountByCodeUseCase, GetCouponDiscountByCodeUseCase>();
            services.AddScoped<IGetShippingPriceUseCase, GetShippingPriceUseCase>();
            services.AddScoped<IReduceProductCountUseCase, ReduceProductCountUseCase>();
            services.AddScoped<ISaveOrderUseCase, SaveOrderUseCase>();


            services.AddScoped<IAddCartItemUseCase, AddCartItemUseCase>();
            services.AddScoped<IClearCartItemsUseCase, ClearCartItemsUseCase>();
            services.AddScoped<IRemoveProductFromCartUseCase, RemoveProductFromCartUseCase>();
            services.AddScoped<IGetCartItemsUseCase, GetCartItemsUseCase>();
            services.AddScoped<IGetCartItemByProductIdUseCase, GetCartItemByProductIdUseCase>();
            services.AddScoped<IUpdateCartCountUseCase, UpdateCartCountUseCase>();

            services.AddScoped<IShowFirstBannersUseCase, ShowFirstBannersUseCase>();
            services.AddScoped<IShowSecondBannersUseCase, ShowSecondBannersUseCase>();
            services.AddScoped<IShowSliderUseCase, ShowSliderUseCase>();
            services.AddScoped<IViewBestSellingProducts, ViewBestSellingProducts>();
            services.AddScoped<IViewProductsCommentsUseCase, ViewProductsCommentsUseCase>();
            services.AddScoped<IGetSettingsUseCase, GetSettingsUseCase>();




            return services;
        }
    }
}
