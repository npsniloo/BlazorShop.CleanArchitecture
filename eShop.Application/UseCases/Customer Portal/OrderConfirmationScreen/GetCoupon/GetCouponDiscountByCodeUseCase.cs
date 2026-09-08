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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;


        public GetCouponDiscountByCodeUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<CouponDiscountDto?> ExecuteAsync(string code)
        {
            var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var coupons = await unitOfWork.Coupons.GetByFilterAsync(c => c.Code == code);
            if (!coupons.Any())
                return null;
            var coupon = coupons.First();
            return new CouponDiscountDto { Code = code, Discount = coupon.Discount };
        }
    }
}
