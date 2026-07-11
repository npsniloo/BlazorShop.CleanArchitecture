using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class GetCommentsUseCase : IGetCommentsUseCase
    {
        private readonly IRepository<Comment, int> repository;

        public GetCommentsUseCase(IRepository<Comment, int> repo)
        {
            this.repository = repo;
        }
        public async Task<IEnumerable<Comment>> ExecuteAsync()
        {
            return await repository.GetAsync();
        }
    }
}
