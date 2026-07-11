namespace eShop.Application.UseCases.Admin_Portal.Users
{
    public interface IDeleteUserUseCase
    {
        Task ExecuteAsync(int id);
    }
}
