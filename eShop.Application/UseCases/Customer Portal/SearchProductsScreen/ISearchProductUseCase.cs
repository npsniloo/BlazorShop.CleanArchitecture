using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public interface ISearchProductUseCase
    {
        public Task<List<Product>> Execute(int pageSize, int pageNumber, string? nameFilter);

    }
}
