using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Admin.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DeleteModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
      public Account Account { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            var role = HttpContext.Session.GetInt32("role");
            if (role != 1)
            {
                return Redirect("/Customer/CustomerHomePage");
            }
            if (id == null)
            {
                return NotFound();
            }

            var account = _accountService.GetById((int)id);

            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = _accountService.GetById((int)id);

            if (account != null)
            {
                Account = account;
                _accountService.Remove(Account);
            }

            return RedirectToPage("./Index");
        }
    }
}
