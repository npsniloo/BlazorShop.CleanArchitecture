using eShop.Application.Interfaces.Repository;
using eShop.Application.Interfaces.Services;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class AddCommentUseCase : IAddCommentUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AddCommentUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(AddCommentCommand command)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            await unitOfWork.Comments.AddAsync(command.Comment);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
