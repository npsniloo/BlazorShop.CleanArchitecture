using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class CouponDiscountDto
    {
        public decimal Discount { get; set; }
        public string Code { get; set; } = null!;
    }
}
