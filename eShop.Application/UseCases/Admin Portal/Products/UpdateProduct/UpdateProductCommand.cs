using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class UpdateProductCommand
    {
        public UpdateProductCommand(Product product, IEnumerable<string> newImages)
        {
            Product = product;
            NewImages = newImages;
        }

        public Product Product { get; }
        public IEnumerable<string> NewImages { get; set; }
    }
}
