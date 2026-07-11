using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class UpdateCouponCommand
    {
        public UpdateCouponCommand(Coupon coupon)
        {
            Coupon = coupon;
        }

        public Coupon Coupon { get; }
    }
}
