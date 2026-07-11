using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class AddBannerUseCase : IAddBannerUseCase
    {
     
        private readonly IRepository<Banner, int> repository; 
        private readonly IUnitOfWork unitOfWork;
        public AddBannerUseCase(IRepository<Banner, int> bannerRepository, IUnitOfWork unitOfWork)
        {
            this.repository = bannerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(AddBannerCommand command)
        {
            await repository.AddAsync(command.Banner);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
