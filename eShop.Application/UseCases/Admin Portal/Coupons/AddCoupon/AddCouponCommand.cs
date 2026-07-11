using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class AddCouponCommand
    {
        public AddCouponCommand(Coupon coupon)
        {
            Coupon = coupon;
        }

        public Coupon Coupon { get; }
    }
}
