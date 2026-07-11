using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class GetGalleryByIdUseCase : IGetGalleryByIdUseCase
    {
        private readonly IRepository<ProductGallery, int> repository;
        public GetGalleryByIdUseCase(IRepository<ProductGallery, int> repository)
        {
            this.repository = repository;
        }
        public async Task<ProductGallery?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
