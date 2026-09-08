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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetShippingPriceUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
            
        public async Task<decimal?> Execute()
        {
            var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var setting = await unitOfWork.Settings.GetByIdAsync(1);
            if (setting == null)
                throw new Exception("shipping price not found");
            return setting.Shipping;
        }
    }
}
