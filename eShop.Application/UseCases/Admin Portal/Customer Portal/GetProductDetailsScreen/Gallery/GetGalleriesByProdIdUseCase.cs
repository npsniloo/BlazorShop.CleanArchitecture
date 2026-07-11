using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetGalleriesByProdIdUseCase : IGetGalleriesByProdIdUseCase
    {
        private readonly IRepository<ProductGallery, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public GetGalleriesByProdIdUseCase(IRepository<ProductGallery, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductGallery>> ExecuteAsync(int prodId)
        {
            var galleries = await repository.GetByFilterAsync(g=>g.ProductId == prodId);
            return galleries;
        }
    }
}
