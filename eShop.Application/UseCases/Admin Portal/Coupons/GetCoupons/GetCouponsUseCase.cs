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
        private readonly IRepository<Coupon, int> repository;

        public GetCouponsUseCase(IRepository<Coupon, int> repo)
        {
            this.repository = repo;
        }
        public async Task<IEnumerable<Coupon>> ExecuteAsync()
        {
            return await repository.GetAsync();
        }
    }
}
