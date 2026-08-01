using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class UpdateCommentUseCase : IUpdateCommentUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UpdateCommentUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(UpdateCommentCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var comment = await unitOfWork.Comments.GetByIdAsync(command.Comment.Id);
            if (comment == null)
                return;


            comment.Email = command.Comment.Email;
            comment.CommentText = command.Comment.CommentText;
            comment.Name = command.Comment.Name;
            comment.UpdateDate = command.Comment.UpdateDate;

            await unitOfWork.SaveChangesAsync();
        }
    }
}
