using Decorator_Pattern_Basic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Decorator_Pattern_Basic.Pages
{
    public class UploadModel : PageModel
    {
        private readonly IFileService _fileServicce;
        public UploadModel(IFileService fileService)
        {
            _fileServicce = fileService;
        }

        public void OnGet()
        {

        }

        public bool Success = false;
        public bool IsPosted = false;

        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task<ActionResult> OnPostAsync()
        {
            Success = await _fileServicce.SaveFileAsync(Upload);
            IsPosted = true;
            return Page();
        }
    }
}
