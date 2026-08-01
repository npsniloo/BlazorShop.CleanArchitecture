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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public SaveOrderUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(Order order, List<CartItemDto> cartItems, CancellationToken cancellationToken)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();

            try
            {
                await unitOfWork.BeginTransactionAsync(cancellationToken);


                await unitOfWork.Orders.AddAsync(order);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                foreach (var item in cartItems)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        ProductPrice = item.ProductPrice.Value,
                        ProductTitle = item.ProductTitle ?? "",
                        Count = item.Count
                    };
                    await unitOfWork.OrderDetails.AddAsync(orderDetail);
                }
                await unitOfWork.SaveChangesAsync(cancellationToken);
                await unitOfWork.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // 6. Rollback در صورت بروز خطا در هر مرحله
                await unitOfWork.RollbackTransactionAsync(cancellationToken);
                // می‌توانید لاگ کنید
                throw; // خطا را به لایه بالاتر پرتاب می‌کنیم
            }

        }
    }
}
