using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class GetCouponByIdUseCase : IGetCouponByIdUseCase
    {

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetCouponByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<Coupon?> ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Coupons.GetByIdAsync(id);
        }
    }
}
