using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class GetBannerByIdUseCase : IGetBannerByIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetBannerByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Banner?> ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();

            return await unitOfWork.Banners.GetByIdAsync(id);
        }
    }
}
