using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Web.AdminPanel
{
    public class ImagesSettings
    {
        public string BannersPath { get; set; }
        public string LogoPath { get; set; }
        public string ProductsPath { get; set; }

        public string UploadBannersPath { get; set; }
        public string UploadLogoPath { get; set; }
        public string UploadProductsPath { get; set; }
        public int UploadMaxFileSize { get; set; }


    }
}
