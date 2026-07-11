using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class UpdateCommentCommand
    {
        public UpdateCommentCommand(Comment comment)
        {
            Comment = comment;
        }

        public Comment Comment { get; }
    }
}
