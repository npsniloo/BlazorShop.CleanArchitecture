using eShop.Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Comments
{
    public class AddCommentCommand
    {
        public AddCommentCommand(Comment comment)
        {
            Comment = comment;
        }

        public Comment Comment { get; }
    }
}
