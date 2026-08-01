using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetGalleriesByProdIdUseCase : IGetGalleriesByProdIdUseCase
    {
        private readonly IRepository<ProductGallery, int> repository;

        public GetGalleriesByProdIdUseCase(IRepository<ProductGallery, int> repo)
        {
            this.repository = repo;
        }

        public async Task<List<ProductGallery>> ExecuteAsync(int prodId)
        {
            var galleries = await repository.GetByFilterAsync(g=>g.ProductId == prodId);
            return galleries;
        }
    }
}
