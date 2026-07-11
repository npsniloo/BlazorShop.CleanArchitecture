using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products  
{
    public class DeleteGalleryUseCase : IDeleteGalleryUseCase
    {
        private readonly IRepository<ProductGallery, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteGalleryUseCase(IRepository<ProductGallery, int> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(int id)
        {
            var gallery = await repository.GetByIdAsync(id);
            
            if (gallery == null)
                throw new Exception("gallery doesn't exist");

            repository.Remove(gallery);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
