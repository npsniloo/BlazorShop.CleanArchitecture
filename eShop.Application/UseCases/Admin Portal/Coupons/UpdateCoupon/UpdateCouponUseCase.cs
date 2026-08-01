using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class UpdateCouponUseCase : IUpdateCouponUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateCouponUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(UpdateCouponCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var coupon = await unitOfWork.Coupons.GetByIdAsync(command.Coupon.Id);
            if (coupon == null)
                return;


            coupon.Code = command.Coupon.Code;
            coupon.Discount = command.Coupon.Discount;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
