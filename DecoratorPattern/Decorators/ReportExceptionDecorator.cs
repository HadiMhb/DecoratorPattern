using Decorator_Pattern_Basic.Services;

namespace Decorator_Pattern_Basic.Decorators
{
    public class ReportExceptionDecorator : IFileService
    {
        private readonly IFileService _fileService;
        public ReportExceptionDecorator(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<bool> SaveFileAsync(IFormFile file)
        {
            try
            {
                return await _fileService.SaveFileAsync(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex.ToString());
                return false;
            }
        }

        public byte[]? DownloadFileAsync(string fileName)
        {
            try
            {
                return _fileService.DownloadFileAsync(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
