using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetCommentsCountUseCase : IGetCommentsCountUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetCommentsCountUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<int> ExecuteAsync(int prodId)
        {
            var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return await unitOfWork.Comments.CountByProductIdAsync(prodId);
        }
    }
}
