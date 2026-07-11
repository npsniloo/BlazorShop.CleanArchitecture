using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public interface IGetMenuByIdUseCase
    {
        public Task<Menu?> ExecuteAsync(int id);
    }
}
