using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class OrderDto
    {
        public OrderDto(int userId, string? couponCode, decimal? couponDiscount, decimal? subTotal, decimal? total)
        {
            UserId = userId;
            CouponCode = couponCode;
            CouponDiscount = couponDiscount;
            SubTotal = subTotal;
            Total = total;
        }

        public int UserId { get;}
        public string? CouponCode { get; }
        public decimal? CouponDiscount { get; }
        public decimal? SubTotal { get;}
        public decimal? Total { get; }


    }
}
