using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class GetCommentsUseCase : IGetCommentsUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetCommentsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<IEnumerable<Comment>> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Comments.GetAsync();
        }
    }
}
