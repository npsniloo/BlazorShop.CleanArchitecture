using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetGalleriesByProdIdUseCase : IGetGalleriesByProdIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetGalleriesByProdIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<ProductGallery>> ExecuteAsync(int prodId)
        {
            var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var galleries = await unitOfWork.ProductGalleries.GetByFilterAsync(g => g.ProductId == prodId);
            return galleries;
        }
    }
}
