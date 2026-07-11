using eShop.Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.UseCases.Admin_Portal.Menus
{
    public class AddMenuCommand
    {
        public AddMenuCommand(Menu menu)
        {
            Menu = menu;
        }

        public Menu Menu { get; }
    }
}
