using eShop.Application.Interfaces.Repository;
using eShop.Domain.Entities;

namespace eShop.Application.UseCases.Admin_Portal.Settings
{
    public class GetMainSettingUseCase : IGetMainSettingUseCase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public GetMainSettingUseCase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Setting?> ExecuteAsync()
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            return (await unitOfWork.Settings.GetAsync()).FirstOrDefault();
        }
    }
}
