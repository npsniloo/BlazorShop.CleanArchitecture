using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Domain.Entities;

[Table("ProductGallery")]
public class ProductGallery : IEntity<int>
{
    public ProductGallery(int productId, string imageName)
    {
        Id = productId;
        ImageName = imageName;
    }
        
        [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }

    [StringLength(50)]
    public string ImageName { get; set; } = null!;

}
