using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Domain.Entities;

public  class Menu : IEntity<int>
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Title { get; set; }

    [StringLength(300)]
    public string? Link { get; set; }

    [StringLength(20)]
    public string? Type { get; set; }
}
