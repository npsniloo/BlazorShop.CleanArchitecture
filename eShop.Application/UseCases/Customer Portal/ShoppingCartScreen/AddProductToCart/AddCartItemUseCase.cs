using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class AddCartItemUseCase : IAddCartItemUseCase
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;


        public AddCartItemUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int productId, int userId)
        {
            await using var uow = await unitOfWorkFactory.CreateAsync();

            var product = await uow.Products.GetByIdAsync(productId);
            if (product == null || product.Qty == 0)
            {
                throw new Exception("Product not found");
            }
            var cart = (await uow.Carts.GetByFilterAsync(cart=>cart.UserId == userId && cart.ProductId == productId)).SingleOrDefault();
            if (cart != null)
                cart.Count++;
            else
            {
                cart = new Cart
                {
                    ProductId = productId,
                    UserId = userId,
                    Count = 1
                };
                await uow.Carts.AddAsync(cart);
            }
            await uow.SaveChangesAsync();

        }
    }
}
