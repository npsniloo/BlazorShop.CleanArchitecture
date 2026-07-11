using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class AddCommentUseCase : IAddCommentUseCase
    {
        private readonly IRepository<Comment, int> repository;
        private readonly IUnitOfWork unitOfWork;
        public AddCommentUseCase(IRepository<Comment, int> commentRepo, IUnitOfWork unitOfWork)
        {
            this.repository = commentRepo;
            this.unitOfWork = unitOfWork;
        }
        public async Task ExecuteAsync(AddCommentCommand command)
        {
            await repository.AddAsync(command.Comment);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
