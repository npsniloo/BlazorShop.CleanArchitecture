using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Dtos
{
    public partial class BestSellingProduct
    {
        public int ProductId { get; set; }

        public int? TotalSum { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public string? ImageName { get; set; }

        public int? Qty { get; set; }
    }
}
