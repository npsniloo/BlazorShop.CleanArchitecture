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
        private readonly ICommentRepository commentRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddCommentUseCase(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            this.commentRepository = commentRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(Comment comment)
        {
            await commentRepository.AddAsync(comment);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
