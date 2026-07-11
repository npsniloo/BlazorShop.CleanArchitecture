using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class UpdateCommentUseCase : IUpdateCommentUseCase
    {
        private readonly IRepository<Comment, int> repository;
        private readonly IUnitOfWork unitOfWork;
        public UpdateCommentUseCase(IRepository<Comment, int> menuRepo, IUnitOfWork unitOfWork)
        {
            this.repository = menuRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(UpdateCommentCommand command)
        {
            var comment = await repository.GetByIdAsync(command.Comment.Id);
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
