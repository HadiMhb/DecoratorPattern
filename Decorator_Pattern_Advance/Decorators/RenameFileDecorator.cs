using Decorator_Pattern_Advance.Interfaces;

namespace Decorator_Pattern_Advance.Decorators
{
    public class RenameFileDecorator : IFileService
    {
        private readonly IFileService _fileService;
        public RenameFileDecorator(IFileService fileService)
        {
            _fileService = fileService;
        }

        public bool SaveFile(IFormFile file)
        {
            var renameFile = RenameFile(file);
            return _fileService.SaveFile(renameFile);
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

        public byte[]? DownloadFile(string fileName)
        {
            return _fileService.DownloadFile(fileName);
        }
    }
}
