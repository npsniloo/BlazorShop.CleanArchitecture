using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetCouponDiscountByCodeUseCase : IGetCouponDiscountByCodeUseCase
    {
        private readonly IRepository<Coupon, int> repository;

        public GetCouponDiscountByCodeUseCase(IRepository<Coupon, int> repository)
        {
            this.repository = repository;
        }

        public async Task<CouponDiscountDto?> ExecuteAsync(string code)
        {
            var coupons = await repository.GetByFilterAsync(c => c.Code == code);
            if (!coupons.Any())
                return null;
            var coupon = coupons.First();
            return new CouponDiscountDto { Code = code, Discount = coupon.Discount };
        }
    }
}
