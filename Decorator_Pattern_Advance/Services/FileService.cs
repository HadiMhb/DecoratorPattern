using Decorator_Pattern_Advance.Interfaces;

namespace Services
{
    public class FileService : IFileService
    {
        public byte[]? DownloadFile(string fileName)
        {
            byte[]? fileByte = default;
            return fileByte;
        }

        public bool SaveFile(IFormFile file)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", file.FileName);
            using (var sr = new FileStream(filePath, FileMode.CreateNew))
            {
                file.CopyTo(sr);
            }

            return true;
        }
    }
}
