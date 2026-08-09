using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class UpdateBannerUseCase : IUpdateBannerUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateBannerUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task ExecuteAsync(UpdateBannerCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var bnr = await unitOfWork.Banners.GetByIdAsync(command.Banner.Id);
            if (bnr == null)
                return;

            bnr.ImageName = command.Banner.ImageName;
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
