using Microsoft.AspNetCore.Http;

namespace Decorator_Pattern_Basic.Services
{
    public interface IFileService
    {
        public Task<bool> SaveFileAsync(IFormFile file);
        public byte[]? DownloadFileAsync(string fileName);
    }
}
