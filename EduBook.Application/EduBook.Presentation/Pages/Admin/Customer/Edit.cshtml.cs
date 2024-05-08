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

namespace EduBook.Presentation.Pages.Admin.Customer
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accService;
        private readonly ISlotService _slotService;
        private readonly IDepartmentService _departmentService;

        public EditModel(IAccountService accService, 
                        ISlotService slotService, 
                        IDepartmentService departmentService)
        {
            _accService = accService;
            _slotService = slotService;
            _departmentService = departmentService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }

            var account =  _accService.GetById((int)id);
            if (account == null)
            {
                return NotFound();
            }
            Account = account;
           ViewData["DepartmentId"] = new SelectList(_departmentService.GetList(), "DepartmentId", "Address");
           ViewData["RoleId"] = new SelectList(_departmentService.GetList(), "RoleId", "RoleName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
            _accService.Update(Account);

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
