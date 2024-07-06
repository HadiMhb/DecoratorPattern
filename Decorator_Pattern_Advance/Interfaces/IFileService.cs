using Microsoft.AspNetCore.Http;

namespace Decorator_Pattern_Advance.Interfaces
{
    public interface IFileService
    {
        public bool SaveFile(IFormFile file);
        public byte[]? DownloadFile(string fileName);
    }
}
