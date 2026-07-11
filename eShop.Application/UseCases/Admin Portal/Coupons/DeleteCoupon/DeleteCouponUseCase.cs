using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class DeleteCouponUseCase : IDeleteCouponUseCase
    {
        private readonly IRepository<Coupon, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteCouponUseCase(IRepository<Coupon, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(int id)
        {
            var coupon = await repository.GetByIdAsync(id);
            if (coupon == null)
                return;            
            repository.Remove(coupon);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
