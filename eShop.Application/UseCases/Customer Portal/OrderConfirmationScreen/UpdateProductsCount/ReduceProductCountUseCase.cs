using eShop.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ReduceProductCountUseCase : IReduceProductCountUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ReduceProductCountUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(ReduceProductCountCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            foreach (var item in command.ProductCounts)
            {
                var product = await unitOfWork.Products.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new Exception("Product Not found");
                product.Qty -= item.ConsumedCount;
                               
            }
            await unitOfWork.SaveChangesAsync();
        }
    }
}
