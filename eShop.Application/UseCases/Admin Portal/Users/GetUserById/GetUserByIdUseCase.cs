using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetUserByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<User?> ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Users.GetByIdAsync(id);
        }
    }
}
