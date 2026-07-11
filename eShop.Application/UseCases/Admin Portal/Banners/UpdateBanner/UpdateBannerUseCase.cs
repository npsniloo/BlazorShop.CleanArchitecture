using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class UpdateBannerUseCase : IUpdateBannerUseCase
    {
        private readonly IRepository<Banner, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateBannerUseCase(IRepository<Banner, int> bannerRepository, IUnitOfWork unitOfWork)
        {
            this.repository = bannerRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(UpdateBannerCommand command)
        {
            var bnr = await repository.GetByIdAsync(command.Banner.Id);
            if (bnr == null)
                return;
            

            bnr.Title = command.Banner.Title;
            bnr.Link = command.Banner.Link;
            bnr.Priority = command.Banner.Priority;
            bnr.Position = command.Banner.Position;
            bnr.Title = command.Banner.Title;
            bnr.SubTitle = command.Banner.SubTitle;
            bnr.Position = command.Banner.Position;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
