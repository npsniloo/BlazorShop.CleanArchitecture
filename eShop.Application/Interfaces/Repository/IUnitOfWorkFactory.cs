using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Interfaces.Repository
{
    public interface  IUnitOfWorkFactory
    {
        Task<IUnitOfWork> CreateAsync(CancellationToken cancellationToken = default);
        IUnitOfWork Create(CancellationToken cancellationToken = default);
    }
}
