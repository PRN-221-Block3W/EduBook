using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Admin.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accService;
        private readonly IDepartmentService _depService;

        public DeleteModel(IAccountService _accService, IDepartmentService depService)
        {
            this._accService = _accService;
            _depService = depService;
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
            if (id == null)
            {
                return NotFound();
            }

            var department = _depService.GetById((int)id);

            if (department == null)
            {
                return NotFound();
            }
            else 
            {
                Department = department;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = _depService.GetById((int)id);

            if (department != null)
            {
                Department = department;
                _depService.Remove(Department);
            }

            return RedirectToPage("./Index");
        }
        private IActionResult Authorized()
        {
            var id = HttpContext.Session.GetInt32("AccountId");
            var role = _accService.GetById((int)id).RoleId;
            if (id == null || role != 1)
            {
                return RedirectToPage("/Error");
            }

            return null; // Return null if authorization succeeds
        }
    }
}
