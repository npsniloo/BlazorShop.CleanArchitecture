using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repository
{
    public class CommentRepository : Repository<Comment, int>, ICommentRepository
    {
        private readonly OnlineShopContext dbContext;
        public CommentRepository(OnlineShopContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<int> CountByProductIdAsync(int prodId)
        {
            return await dbContext.Comments.Where(c => c.ProductId == prodId).CountAsync();
        }

      
    }
}
