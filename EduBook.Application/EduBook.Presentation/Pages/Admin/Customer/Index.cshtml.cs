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
        private readonly IAccountService _accService;

        public IndexModel(IAccountService accService)
        {
            _accService = accService;
        }

        public IList<Account> Account { get;set; } = default!;

        public IActionResult OnGet()
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            var role = HttpContext.Session.GetInt32("role");
            if (role != 1)
            {
                return Redirect("/Customer/CustomerHomePage");
            }

            Account = _accService.GetList();
            if(Account == null)
            {
                ViewData["Message"] = "The list is empty!";
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
