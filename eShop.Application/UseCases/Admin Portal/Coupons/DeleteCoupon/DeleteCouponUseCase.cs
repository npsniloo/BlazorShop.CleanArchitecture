using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class DeleteCouponUseCase : IDeleteCouponUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DeleteCouponUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var coupon = await unitOfWork.Coupons.GetByIdAsync(id);
            if (coupon == null)
                return;
            unitOfWork.Coupons.Remove(coupon);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
