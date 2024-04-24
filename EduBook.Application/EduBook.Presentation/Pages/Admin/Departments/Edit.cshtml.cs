using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Admin.Departments
{
    public class EditModel : PageModel
    {
        private readonly EduBook.BusinessObject.EduBookContext _context;
        private readonly IAccountService _accService;
        public EditModel(IAccountService _accService)
        {
            _context = new EduBookContext();
            this._accService = _accService;
        }

        [BindProperty]
        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department =  await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }
            Department = department;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(Department.DepartmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DepartmentExists(int id)
        {
          return (_context.Departments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
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
