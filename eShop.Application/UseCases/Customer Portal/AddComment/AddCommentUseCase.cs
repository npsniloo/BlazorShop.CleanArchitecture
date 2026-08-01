using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class AddCommentUseCase : IAddCommentUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AddCommentUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task ExecuteAsync(Comment comment)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            await unitOfWork.Comments.AddAsync(comment);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
