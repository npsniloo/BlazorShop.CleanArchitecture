

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public interface IAddCouponUseCase
    {
        public Task ExecuteAsync(AddCouponCommand command);
    }
}
