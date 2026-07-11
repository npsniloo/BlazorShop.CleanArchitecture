using eShop.Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class UpdateBannerCommand
    {
        public UpdateBannerCommand(Banner banner)
        {
            Banner = banner;
        }

        public Banner Banner { get; }
    }
}
