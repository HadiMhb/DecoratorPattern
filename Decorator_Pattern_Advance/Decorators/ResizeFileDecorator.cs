using Decorator_Pattern_Advance.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace Decorator_Pattern_Advance.Decorators
{
    public class ResizeFileDecorator : IFileService
    {
        private readonly IFileService _fileService;
        public ResizeFileDecorator(IFileService fileService)
        {
            _fileService = fileService;
        }

        public bool SaveFile(IFormFile file)
        {
            IFormFile fileItem = file;
            if (file.Length > 1024 * 1024)
            {
                fileItem = ResizeFile(file);
            }
            return _fileService.SaveFile(fileItem);
        }

        private IFormFile ResizeFile(IFormFile file)
        {
            using (var sr = new MemoryStream())
            {
                file.CopyTo(sr);
                sr.Position = 0;

                var image = Image.Load(sr);

                image.Mutate(a => a.Resize(new ResizeOptions
                {
                    Size = new Size(1280, 700),
                    Mode = ResizeMode.Max
                }));

                var resizedStream = new MemoryStream();
                image.Save(resizedStream, new JpegEncoder());
                resizedStream.Position = 0;

                return new FormFile(resizedStream, 0, resizedStream.Length, file.Name, file.FileName);
            }
        }

        public byte[]? DownloadFile(string fileName)
        {
            return _fileService.DownloadFile(fileName);
        }
    }
}
