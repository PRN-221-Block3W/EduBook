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

namespace EduBook.Presentation.Pages.Accounts
{
    public class EditAccountModel : PageModel
    {
        private readonly IAccountService _accService;
        private readonly IDepartmentService _depService;

        public EditAccountModel(IAccountService accService, IDepartmentService depService)
        {
            _accService = accService;
            _depService = depService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account =  _accService.GetById((int)id);
            if (account == null)
            {
                return NotFound();
            }
            Account = account;
            ViewData["DepartmentId"] = new SelectList(_depService.GetList(), "DepartmentId", "Address");
           ViewData["RoleId"] = new SelectList(_accService.GetRoles(), "RoleId", "RoleName");
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

            try
            {
                _accService.Update(Account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.AccountId))
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

        private bool AccountExists(int id)
        {
          return _accService.GetById(id) != null;
        }
    }
}
