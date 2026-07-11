using eShop.Application.Interfaces.Services;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace eShop.Infrastructure.FileServices
{
    public class FileHelperService : IFileHelperService
    {
        

        public string GetUniqueFileName(IBrowserFile file)
        {
            return Guid.NewGuid().ToString() + Path.GetExtension(file.Name);
        }
        public async Task UploadImageAsync(Stream stream,string destination, string fileName)
        {
            Directory.CreateDirectory(destination);
            var filePath = Path.Combine(destination, fileName);
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await stream.CopyToAsync(fileStream);

        }
        public void DeleteImage(string filePath,string fileName)
        {
            filePath = Path.Combine(filePath, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }


    }
}
