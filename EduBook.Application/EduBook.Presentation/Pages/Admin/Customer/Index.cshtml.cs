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
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<Account> Account { get;set; } = default!;

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetInt32("role");
            if (role != 1)
            {
                return Redirect("/Customer/CustomerHomePage");
            }

            Account = _accountService.GetList();
            if(Account == null)
            {
                ViewData["Message"] = "The list is empty!";
            }
            return Page();
        }
    }
}
