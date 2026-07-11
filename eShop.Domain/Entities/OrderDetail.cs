using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Domain.Entities;

public  class OrderDetail : IEntity<int>
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    [StringLength(50)]
    public string ProductTitle { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }

    public int Count { get; set; }
}
