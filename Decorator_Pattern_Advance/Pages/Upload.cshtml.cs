using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Decorator_Pattern_Advance.Pages
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

        public bool? Success = null;

        [BindProperty]
        public IFormFile Upload { get; set; }
        public ActionResult OnPostAsync()
        {
            try
            {
                Success = _fileServicce.SaveFile(Upload);
            }
            catch (Exception)
            {
                Success = false;
            }
            return Page();
        }
    }
}
