using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class GetGalleriesByProdIdUseCase : IGetGalleriesByProdIdUseCase
    {
        private readonly IRepository<ProductGallery, int> repository;

        public GetGalleriesByProdIdUseCase(IRepository<ProductGallery, int> repo)
        {
            this.repository = repo;
        }

        public async Task<IEnumerable<ProductGallery>> ExecuteAsync(int prodId)
        {
            var galleries = await repository.GetByFilterAsync(g=>g.ProductId == prodId);
            return galleries;
        }
    }
}
