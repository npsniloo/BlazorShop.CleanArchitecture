using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class SaveOrderUseCase : ISaveOrderUseCase
    {
        private readonly IOrderRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public SaveOrderUseCase(IOrderRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(Order order)
        {
          await  repository.AddAsync(order);
          await unitOfWork.SaveChangesAsync();

        }
    }
}
