using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Orders
{
    public class UpdateOrderUseCase : IUpdateOrderUseCase
    {
        private readonly IRepository<Order, int> repository;
        private readonly IUnitOfWork unitOfWork;
        public UpdateOrderUseCase(IRepository<Order, int> repo, IUnitOfWork unitOfWork)
        {
            this.repository = repo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(UpdateOrderCommand command)
        {
            var order = await repository.GetByIdAsync(command.Order.Id);
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
