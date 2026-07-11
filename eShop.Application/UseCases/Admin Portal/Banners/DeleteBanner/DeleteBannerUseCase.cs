using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class DeleteBannerUseCase : IDeleteBannerUseCase
    {
        private readonly IRepository<Banner, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteBannerUseCase(IRepository<Banner, int> bannerRepository, IUnitOfWork unitOfWork)
        {
            this.repository = bannerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(int id)
        {
            var bnr = await repository.GetByIdAsync(id);
            if (bnr == null)
                return;            
            repository.Remove(bnr);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
