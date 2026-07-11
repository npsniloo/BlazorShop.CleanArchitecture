namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public interface IAddUserUseCase
    {
        Task ExecuteAsync(AddUserCommand command);
    }
}
