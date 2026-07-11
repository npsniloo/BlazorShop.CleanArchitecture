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
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReduceProductCountUseCase(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(ReduceProductCountCommand command)
        {
            foreach (var item in command.ProductCounts)
            {
                var product = await productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new Exception("Product Not found");
                product.Qty -= item.ConsumedCount;
                               
            }
            await unitOfWork.SaveChangesAsync();
        }
    }
}
