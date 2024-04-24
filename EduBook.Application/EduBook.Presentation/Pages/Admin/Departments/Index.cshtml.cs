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
    public class IndexModel : PageModel
    {
        private readonly EduBook.BusinessObject.EduBookContext _context;
        private readonly IAccountService _accService;
        public IndexModel(IAccountService _accService)
        {
            _context = new EduBookContext();
            this._accService = _accService;
        }

        public IList<Department> Department { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            if (_context.Departments != null)
            {
                Department = _context.Departments.ToList();
            }
            return Page();
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
