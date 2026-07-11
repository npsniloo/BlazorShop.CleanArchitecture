using eShop.Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class UpdateMenuCommand
    {
        public UpdateMenuCommand(Menu menu)
        {
            Menu = menu;
        }

        public Menu Menu { get; }
    }
}
