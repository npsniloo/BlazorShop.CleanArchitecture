using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DeleteUserUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var user = await unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                return;

            unitOfWork.Users.Remove(user);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
