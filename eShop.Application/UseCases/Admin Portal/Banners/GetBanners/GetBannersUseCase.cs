using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class GetBannersUseCase : IGetBannersUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetBannersUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<IEnumerable<Banner>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();

            return await unitOfWork.Banners.GetAsync();
        }
    }
}
