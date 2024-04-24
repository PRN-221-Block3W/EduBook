using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Admin.Departments
{
    public class CreateModel : PageModel
    {
        private readonly EduBook.BusinessObject.EduBookContext _context;
        private readonly IAccountService _accService;

        public CreateModel(IAccountService _accService)
        {
            _context = new EduBookContext();
            this._accService = _accService;
        }

        public IActionResult OnGet()
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Departments == null || Department == null)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private IActionResult Authorized()
        {
            var id = HttpContext.Session.GetInt32("AccountId");
            if (id == null)
            {
                return RedirectToPage("/LoginPage/Login");
            }
            var role = _accService.GetById((int)id).RoleId;
            if (role != 1)
            {
                return RedirectToPage("/Customer/CustomerHomePage");
            }

            return null; // Return null if authorization succeeds
        }
    }
}
