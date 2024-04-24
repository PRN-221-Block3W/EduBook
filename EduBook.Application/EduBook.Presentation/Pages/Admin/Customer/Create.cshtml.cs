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
        private readonly IAccountService _accountService;
        private readonly IDepartmentService _departmentService;
        private readonly ISlotService _slotService;

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetInt32("role");
            if(role != 1)
            {
                return Redirect("/Customer/CustomerHomePage");
            } 

        ViewData["DepartmentId"] = new SelectList(_departmentService.GetList(), "DepartmentId", "Address");
        ViewData["RoleId"] = new SelectList(_slotService.GetList(), "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _accountService.Create(Account);

            return RedirectToPage("./Index");
        }
    }
}
