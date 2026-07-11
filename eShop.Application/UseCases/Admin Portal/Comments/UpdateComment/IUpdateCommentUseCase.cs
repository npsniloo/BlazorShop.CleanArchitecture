
namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public interface IUpdateCommentUseCase 
    {
        public Task ExecuteAsync(UpdateCommentCommand command);
    }
}
