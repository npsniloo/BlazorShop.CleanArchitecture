
namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public interface IUpdateCouponUseCase 
    {
        public Task ExecuteAsync(UpdateCouponCommand command);
    }
}
