

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public interface IDeleteCommentUseCase
    {
        public Task ExecuteAsync(int id);
    }
}
