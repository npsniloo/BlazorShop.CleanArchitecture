using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Interfaces.Repository
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        Task<int> CountByProductIdAsync(int prodId);
    }
}
