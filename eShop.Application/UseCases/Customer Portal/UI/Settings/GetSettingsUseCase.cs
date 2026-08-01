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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public GetSettingsUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Setting> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var settings = await unitOfWork.Settings.GetByIdAsync(1);
            if (settings == null)
                throw new Exception("settings doesnt exist");
            return settings;
        }
    }
}
