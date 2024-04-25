using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Admin.Customer
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accService;
        private readonly IDepartmentService _departmentService;
        private readonly ISlotService _slotService;

        public CreateModel(IAccountService accService, IDepartmentService departmentService, ISlotService slotService)
        {
            _accService = accService;
            _departmentService = departmentService;
            _slotService = slotService;
        }

        public IActionResult OnGet()
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }

            ViewData["DepartmentId"] = new SelectList(_departmentService.GetList(), "DepartmentId", "Address");
        ViewData["RoleId"] = new SelectList(_slotService.GetList(), "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _accService.Create(Account);

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
