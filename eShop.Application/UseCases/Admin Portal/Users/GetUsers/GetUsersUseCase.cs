using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class GetUsersUseCase : IGetUsersUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetUsersUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<IEnumerable<User>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Users.GetAsync();
        }
    }
}
