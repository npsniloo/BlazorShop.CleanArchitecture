using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ViewProductsCommentsUseCase : IViewProductsCommentsUseCase
    {
        private readonly ICommentRepository repository;

        public ViewProductsCommentsUseCase(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Comment>> ExecuteAsync(int productId)
        {
            var comments = (await repository.GetByFilterAsync(c => c.ProductId == productId))
                .OrderBy(c=>c.Id);
            return comments.ToList();
        }
    }
}
