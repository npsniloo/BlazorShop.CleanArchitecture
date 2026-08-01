using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetShippingPriceUseCase : IGetShippingPriceUseCase
    {
        private readonly IRepository<Setting,int> repository;

        public GetShippingPriceUseCase(IRepository<Setting, int> repository)
        {
            this.repository = repository;
        }

        public async Task<decimal?> Execute()
        {
           var setting = await repository.GetByIdAsync(1);
            if (setting == null)
                throw new Exception("shipping price not found");
            return setting.Shipping;
        }
    }
}
