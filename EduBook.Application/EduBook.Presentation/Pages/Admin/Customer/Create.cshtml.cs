using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduBook.BusinessObject;
using EduBook.Service.IService;
using EduBook.Service.ClassService;

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
            var checkEmail = _accService.GetByEmail(Account.Email);
            if (checkEmail != null)
            {
                ViewData["Message"] = "Email is already to used";
                return Page();
            }

            if (Account.Dob > DateTime.Now)
            {
                ViewData["Message"] = "Dob is not bigger now";
                return Page();
            }

            _accService.Create(Account);

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
