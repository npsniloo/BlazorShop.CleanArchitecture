using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ViewProductsCommentsUseCase : IViewProductsCommentsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ViewProductsCommentsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Comment>> ExecuteAsync(int productId)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var comments = (await unitOfWork.Comments.GetByFilterAsync(c => c.ProductId == productId))
                .OrderBy(c=>c.Id);
            return comments.ToList();
        }
    }
}
