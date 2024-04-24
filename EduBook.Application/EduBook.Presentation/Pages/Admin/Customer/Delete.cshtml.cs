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
        private readonly IAccountService _accService;

        public DeleteModel(IAccountService accService)
        {
            _accService = accService;
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

            var account = _accService.GetById((int)id);

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
            var account = _accService.GetById((int)id);

            if (account != null)
            {
                Account = account;
                _accService.Remove(Account);
            }

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
