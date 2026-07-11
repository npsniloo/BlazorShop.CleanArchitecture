using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public interface IGetGalleryByIdUseCase
    {
        Task<ProductGallery?> ExecuteAsync(int id);
    }
}
