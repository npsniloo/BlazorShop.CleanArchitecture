using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class GetCommentByIdUseCase : IGetCommentByIdUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetCommentByIdUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Comment?> ExecuteAsync(int id)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Comments.GetByIdAsync(id);
        }
    }
}
