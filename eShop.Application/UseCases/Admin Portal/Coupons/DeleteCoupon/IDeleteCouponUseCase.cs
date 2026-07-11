using eShop.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Coupons
{
    public interface IDeleteCouponUseCase
    {
        public Task ExecuteAsync(int id);
    }
}
