using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public interface IGetCouponsUseCase
    {
        Task<IEnumerable<Coupon>> ExecuteAsync();
    }
}
