using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class AddCouponUseCase : IAddCouponUseCase
    {
        private readonly IRepository<Coupon, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public AddCouponUseCase(IRepository<Coupon, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(AddCouponCommand command)
        {
            await repository.AddAsync(command.Coupon);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
