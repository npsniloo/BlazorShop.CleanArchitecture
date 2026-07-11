using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Domain.Entities;

[Table("Order")]
public  class Order : IEntity<int>
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string? CompanyName { get; set; }

    [StringLength(50)]
    public string Country { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(200)]
    public string Address { get; set; } = null!;

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? Phone { get; set; }

    [StringLength(50)]
    public string? Comment { get; set; }

    [StringLength(50)]
    public string? CouponCode { get; set; }

    [Column(TypeName = "money")]
    public decimal? CouponDiscount { get; set; }

    [Column(TypeName = "money")]
    public decimal? Shipping { get; set; }

    [Column(TypeName = "money")]
    public decimal? SubTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal? Total { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [StringLength(200)]
    public string? TransactionId { get; set; }

    [StringLength(50)]
    public string? TransactionStatus { get; set; }
}
