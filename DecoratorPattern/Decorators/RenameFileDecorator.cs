using Decorator_Pattern_Basic.Services;

namespace Decorator_Pattern_Basic.Decorators
{
    public class RenameFileDecorator : IFileService
    {
        private readonly IFileService _fileService;
        public RenameFileDecorator(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<bool> SaveFileAsync(IFormFile file)
        {
            var renameFile = RenameFile(file);
            return await _fileService.SaveFileAsync(renameFile);
        }

        private IFormFile RenameFile(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string prefix = "file_";
            string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
            string newFileName = prefix + timeStamp + extension;

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();

            }
            return new FormFile(new MemoryStream(fileBytes), 0, fileBytes.Length, "file", newFileName);
        }

        public byte[]? DownloadFileAsync(string fileName)
        {
            return _fileService.DownloadFileAsync(fileName);
        }
    }
}
