using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products  
{
    public class DeleteGalleryUseCase : IDeleteGalleryUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DeleteGalleryUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int id)
        {
           await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var gallery = await unitOfWork.ProductGalleries.GetByIdAsync(id);
            
            if (gallery == null)
                throw new Exception("gallery doesn't exist");

            unitOfWork.ProductGalleries.Remove(gallery);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
