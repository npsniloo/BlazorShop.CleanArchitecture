using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class GetCommentByIdUseCase : IGetCommentByIdUseCase
    {
        private readonly IRepository<Comment, int> repository;

        public GetCommentByIdUseCase(IRepository<Comment, int> commentRepo)
        {
            this.repository = commentRepo;
        }
        public async Task<Comment?> ExecuteAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
