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
        private readonly ICommentRepository repository;

        public GetCommentsCountUseCase(ICommentRepository repo)
        {
            this.repository = repo;
        }
        public async Task<int> ExecuteAsync(int prodId)
        {
            return await repository.CountByProductIdAsync(prodId);
        }
    }
}
