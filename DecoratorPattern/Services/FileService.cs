
namespace Decorator_Pattern_Basic.Services
{
    public class FileService : IFileService
    {
        public byte[]? DownloadFileAsync(string fileName)
        {
            byte[]? fileByte = default;
            return fileByte;
        }

        public async Task<bool> SaveFileAsync(IFormFile file)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", file.FileName);
            using (var sr = new FileStream(filePath, FileMode.CreateNew))
            {
                await file.CopyToAsync(sr);
            }

            return true;
        }
    }
}
