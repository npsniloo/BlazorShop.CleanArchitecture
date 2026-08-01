using eShop.Application.Dtos;
using eShop.Application.Interfaces.Repository;

namespace eShop.Application.UseCases.Customer_Portal
{
    public class ViewBestSellingProducts : IViewBestSellingProducts
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ViewBestSellingProducts(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<BestSellingProduct>> ExecuteAsync(int count)
        {
            await using var unitOfWork = await _unitOfWorkFactory.CreateAsync();
            var products = await unitOfWork.Products.GetBestSellingProductsAsync(count);
            return products;

        }
    }
}
