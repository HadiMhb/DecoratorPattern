using Decorator_Pattern_Advance.Interfaces;

namespace Decorator_Pattern_Advance.Decorators
{
    public class ReportExceptionDecorator(IFileService underlying, IPolicy policy) : IFileService
    {
        public bool SaveFile(IFormFile file) => policy.Invoke(() => underlying.SaveFile(file));
        public byte[]? DownloadFile(string fileName) => policy.Invoke(() => underlying.DownloadFile(fileName));
    }
}
