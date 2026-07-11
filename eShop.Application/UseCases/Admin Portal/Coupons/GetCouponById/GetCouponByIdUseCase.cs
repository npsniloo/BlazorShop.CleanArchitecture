using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class GetCouponByIdUseCase : IGetCouponByIdUseCase
    {
        private readonly IRepository<Coupon, int> repository;

        public GetCouponByIdUseCase(IRepository<Coupon, int> repo)
        {
            this.repository = repo;
        }
        public async Task<Coupon?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
