using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class DeleteBannerUseCase : IDeleteBannerUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DeleteBannerUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
           
            var bnr = await unitOfWork.Banners.GetByIdAsync(id);
            if (bnr == null)
                return;            
            unitOfWork.Banners.Remove(bnr);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
