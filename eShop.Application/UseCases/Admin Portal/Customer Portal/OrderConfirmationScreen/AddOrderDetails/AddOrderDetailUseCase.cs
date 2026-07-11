using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class AddOrderDetailUseCase : IAddOrderDetailUseCase
    {
        private readonly IRepository<OrderDetail, int> orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddOrderDetailUseCase(IRepository<OrderDetail, int> orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(List<OrderDetail> orderDetails)
        {
            foreach (var item in orderDetails)
            {
                await orderRepository.AddAsync(item);
            }
            await unitOfWork.SaveChangesAsync();
        }
    }
}
