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
        private readonly IDbContextFactory<OnlineShopContext> _dbFactory;
        public CommentRepository(IDbContextFactory<OnlineShopContext> dbFactory) : base(dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<int> CountByProductIdAsync(int prodId)
        {
            using var dbContext = await _dbFactory.CreateDbContextAsync();
            return await dbContext.Comments.Where(c => c.ProductId == prodId).CountAsync();
        }

      
    }
}
