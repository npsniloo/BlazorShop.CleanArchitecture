using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class UpdateCouponUseCase : IUpdateCouponUseCase
    {
        private readonly IRepository<Coupon, int> repository;
        private readonly IUnitOfWork unitOfWork;
        public UpdateCouponUseCase(IRepository<Coupon, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(UpdateCouponCommand command)
        {
            var coupon = await repository.GetByIdAsync(command.Coupon.Id);
            if (coupon == null)
                return;


            coupon.Code = command.Coupon.Code;
            coupon.Discount = command.Coupon.Discount;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
