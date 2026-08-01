using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateUserUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(UpdateUserCommand command)
        {
           await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var user = await unitOfWork.Users.GetByIdAsync(command.User.Id);
            if (user == null)
                return;

            // TODO: map User-specific fields here
            await unitOfWork.SaveChangesAsync();
        }
    }
}
