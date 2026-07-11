using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Products
{
    public class AddProductCommand
    {
        public AddProductCommand(Product product,IEnumerable<string> images)
        {
            Product = product;
            Images = images;
        }

        public Product Product { get; }
        public IEnumerable<string> Images { get; set; }
    }
}
