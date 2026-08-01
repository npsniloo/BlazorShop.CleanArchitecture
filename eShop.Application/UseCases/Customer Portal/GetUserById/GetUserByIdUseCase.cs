using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;


        public GetUserByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<User?> ExecuteAsync(int id)
        {
            await using var uow = await unitOfWorkFactory.CreateAsync();

            return await uow.Users.GetByIdAsync(id);
        }
    }
}
