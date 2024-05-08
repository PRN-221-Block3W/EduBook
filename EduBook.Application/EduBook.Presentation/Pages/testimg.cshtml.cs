using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace EduBook.Presentation.Pages
{
    public class testimgModel : PageModel
    {
        [BindProperty]
        public string ImgUrl { get; set; }

        public void OnGet(string? ImgUrlparm)
        {
            // Initialize ImgUrl with a default image URL if needed
            if (string.IsNullOrEmpty(ImgUrlparm))
            {
                ImgUrl = "/img/test.png";
            }
            else
            {
                ImgUrl = ImgUrlparm;
            }
        }

        public IActionResult OnPost(IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine("wwwroot", "img", "room");
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), uploadsFolder, fileName);

                // Ensure the target directory exists
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), uploadsFolder));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                // Set ImgUrl to the URL of the uploaded image
                ImgUrl = "/img/room/" + fileName;
            }

            // Redirect to the same page to refresh the content with the new image
            return RedirectToPage();
        }
    }
}
