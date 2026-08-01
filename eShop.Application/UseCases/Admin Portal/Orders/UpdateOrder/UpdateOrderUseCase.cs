using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class UpdateOrderUseCase : IUpdateOrderUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateOrderUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(UpdateOrderCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var order = await unitOfWork.Orders.GetByIdAsync(command.Order.Id);
            if (order == null)
                return;


            order.Address = command.Order.Address;
            order.City = command.Order.City;
            order.Shipping = command.Order.Shipping;
            order.Comment = command.Order.Comment;
            order.SubTotal = command.Order.SubTotal;
            order.City = command.Order.City;
            order.CompanyName = command.Order.CompanyName;
            order.Country = command.Order.Country;
            order.CouponCode = command.Order.CouponCode;
            order.CouponDiscount = command.Order.CouponDiscount;
            order.Email = command.Order.Email;
            order.FirstName = command.Order.FirstName;
            order.LastName = command.Order.LastName;
            order.TransactionStatus = command.Order.TransactionStatus;

            await unitOfWork.SaveChangesAsync();
        }
    }
}
