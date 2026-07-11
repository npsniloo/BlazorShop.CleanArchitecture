using eShop.Application.Interfaces.Repository;
using eShop.Application.UseCases.Common;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class GetSettingsUseCase : IGetSettingsUseCase
    {
        private readonly IRepository<Setting, int> repository;

        public GetSettingsUseCase(IRepository<Setting, int> repository)
        {
            this.repository = repository;
        }

        public async Task<Setting> ExecuteAsync()
        {
            var settings = await repository.GetByIdAsync(1);
            if (settings == null)
                throw new Exception("settings doesnt exist");
            return settings;
        }
    }
}
