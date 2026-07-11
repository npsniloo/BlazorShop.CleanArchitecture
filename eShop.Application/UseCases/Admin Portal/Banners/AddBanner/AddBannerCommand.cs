using eShop.Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Banners
{
    public class AddBannerCommand
    {
        public AddBannerCommand(Banner banner)
        {
            Banner = banner;
        }

        public Banner Banner { get; }
    }
}
