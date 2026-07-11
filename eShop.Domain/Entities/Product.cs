using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Domain.Entities;

public class Product : IEntity<int>
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string? Title { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [StringLength(4000)]
    public string? FullDesc { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [Column(TypeName = "money")]
    public decimal? Discount { get; set; }

    [StringLength(50)]
    public string? ImageName { get; set; }

    public int? Qty { get; set; }

    [StringLength(1000)]
    public string? Tags { get; set; }

    [StringLength(300)]
    public string? VideoUrl { get; set; }

    public virtual IReadOnlyCollection<ProductGallery> Galleries => _galleries.AsReadOnly();

    private readonly List<ProductGallery> _galleries = new();

    public void AddGalleries(IEnumerable<string> newImageUrls)
    {
        if (newImageUrls == null || !newImageUrls.Any()) return;


        foreach (var name in newImageUrls)
        {
            // جلوگیری از افزودن عکس تکراری (در صورت نیاز)
            if (!_galleries.Any(g => g.ImageName == name))
            {
                _galleries.Add(new ProductGallery(this.Id, name));
            }
        }
    }

}
