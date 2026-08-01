using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class CartItemDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }
        public string? ProductTitle { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductImage { get; set; }
        public decimal? ProductDiscount { get; set; }
        public int Count { get; set; }
        public decimal RowSum { get; set; }
    }
}
