using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ReduceProductCountCommand
    {
        public List<ProductCountDto> ProductCounts { get; set; } = new();
    }
    public class ProductCountDto
    {
        public int ProductId { get; set; }
        public int ConsumedCount { get; set; }
    }
}
