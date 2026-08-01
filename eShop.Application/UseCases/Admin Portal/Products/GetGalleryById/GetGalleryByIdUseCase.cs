using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class GetGalleryByIdUseCase : IGetGalleryByIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetGalleryByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<ProductGallery?> ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.ProductGalleries.GetByIdAsync(id);
        }
    }
}
