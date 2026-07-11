using Microsoft.AspNetCore.Components.Forms;

namespace eShop.Application.Interfaces.Services
{
    public interface IFileHelperService
    {
         string GetUniqueFileName(IBrowserFile file);
         Task UploadImageAsync(Stream stream,string destination, string uniqueName);
         void DeleteImage(string filePath, string fileName);

    }
}
