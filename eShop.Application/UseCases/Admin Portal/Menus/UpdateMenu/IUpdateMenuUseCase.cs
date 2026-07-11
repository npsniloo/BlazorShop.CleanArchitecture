
namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public interface IUpdateMenuUseCase 
    {
        public Task ExecuteAsync(UpdateMenuCommand command);
    }
}
