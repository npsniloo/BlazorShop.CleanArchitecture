using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public interface IGetCommentsUseCase
    {
        Task<IEnumerable<Comment>> ExecuteAsync();
    }
}
