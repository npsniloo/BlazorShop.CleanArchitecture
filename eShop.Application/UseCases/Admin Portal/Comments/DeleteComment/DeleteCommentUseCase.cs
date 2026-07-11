using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class DeleteCommentUseCase : IDeleteCommentUseCase
    {
        private readonly IRepository<Comment, int> repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteCommentUseCase(IRepository<Comment, int> commentRepo, IUnitOfWork unitOfWork)
        {
            this.repository = commentRepo;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(int id)
        {
            var menu = await repository.GetByIdAsync(id);
            if (menu == null)
                return;            
            repository.Remove(menu);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
