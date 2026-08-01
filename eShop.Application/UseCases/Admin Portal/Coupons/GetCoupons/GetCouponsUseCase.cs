using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public class GetCouponsUseCase : IGetCouponsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetCouponsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<IEnumerable<Coupon>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Coupons.GetAsync();
        }
    }
}
