namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public interface IUpdateUserUseCase
    {
        Task ExecuteAsync(UpdateUserCommand command);
    }
}
