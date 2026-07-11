using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public interface IGetCouponByIdUseCase
    {
        public Task<Coupon?> ExecuteAsync(int id);
    }
}
