using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class DeleteCommentUseCase : IDeleteCommentUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DeleteCommentUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var menu = await unitOfWork.Comments.GetByIdAsync(id);
            if (menu == null)
                return;
            unitOfWork.Comments.Remove(menu);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
