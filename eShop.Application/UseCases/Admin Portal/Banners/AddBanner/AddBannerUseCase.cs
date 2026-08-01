using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class AddBannerUseCase : IAddBannerUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AddBannerUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(AddBannerCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            await unitOfWork.Banners.AddAsync(command.Banner);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
