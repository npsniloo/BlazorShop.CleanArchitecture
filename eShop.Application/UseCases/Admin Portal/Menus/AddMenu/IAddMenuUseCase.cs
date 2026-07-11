namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public interface IAddMenuUseCase
    {
        public Task ExecuteAsync(AddMenuCommand command);
    }
}
