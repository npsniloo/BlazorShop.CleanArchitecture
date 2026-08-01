using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class AddCouponUseCase : IAddCouponUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AddCouponUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(AddCouponCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            await unitOfWork.Coupons.AddAsync(command.Coupon);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
